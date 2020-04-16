using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Competitions.Clients;
using Competitions.Entities;

namespace Competitions.UI
{
    public partial class MainForm : Form
    {
        public static readonly Session Session = new Session(Properties.Settings.Default.SqlConnection);
        private EditClient<CompetitionResult> _competitionsResultsControl;

        public MainForm()
        {
            InitializeComponent();

            _competitionsResultsControl = new EditClient<CompetitionResult>(Session.CompetitionsResults) { Dock = DockStyle.Fill };

            UpdateEmployees();
        }

        private void UpdateEmployees()
        {
            comboBox_Employees.Items.Clear();
            comboBox_Employees.Items.AddRange(Session.Employees.GetAll(true).ToArray());

            string currentFullName = Session.CurrentEmployee?.FullName;
            label_CurrentUser.Text = string.IsNullOrEmpty(currentFullName) ? "не выбран" : currentFullName;

            CheckAndUpdateEmployeeButtons();

            panel_CompetitionsResults.Controls.Add(_competitionsResultsControl);
        }
        private void CheckAndUpdateEmployeeButtons()
        {
            var selectedEmployee = comboBox_Employees.SelectedItem as Employee;
            button_ChangeUser.Enabled = selectedEmployee != null && !selectedEmployee.Equals(Session.CurrentEmployee);

            button_EmployeeAdd.Enabled = Session.Employees.CheckAccess(AccessMethodNames.Add);
            button_EmployeeEdit.Enabled = selectedEmployee != null && !selectedEmployee.Equals(Session.CurrentEmployee) && Session.Employees.CheckAccess(AccessMethodNames.Add) &&
                                          Session.Employees.CheckAccess(AccessMethodNames.Delete);
            button_EmployeeDelete.Enabled = selectedEmployee != null && !selectedEmployee.Equals(Session.CurrentEmployee) && Session.Employees.CheckAccess(AccessMethodNames.Delete);

            _competitionsResultsControl.Button_Add.Enabled =
                Session.CompetitionsResults.CheckAccess(AccessMethodNames.Add);

            membersToolStripMenuItem.Enabled = Session.Members.CheckAccess(AccessMethodNames.Get);
            conductsCompetitionsToolStripMenuItem.Enabled = Session.ConductsCompetitions.CheckAccess(AccessMethodNames.Get);
            sportTypesCompetitionsToolStripMenuItem.Enabled = Session.SportTypesCompetitions.CheckAccess(AccessMethodNames.Get);
            competitionsClientToolStripMenuItem.Enabled = Session.Competitions.CheckAccess(AccessMethodNames.Get);
            sportTypesDisciplinesToolStripMenuItem.Enabled = Session.SportTypesDisciplines.CheckAccess(AccessMethodNames.Get);
            sportTypesToolStripMenuItem.Enabled = Session.SportTypes.CheckAccess(AccessMethodNames.Get);
            disciplinesToolStripMenuItem.Enabled = Session.Disciplines.CheckAccess(AccessMethodNames.Get);
            unitTypesToolStripMenuItem.Enabled = Session.UnitTypes.CheckAccess(AccessMethodNames.Get);
            accessRightsToolStripMenuItem.Enabled = Session.AccessRights.CheckAccess(AccessMethodNames.Get);
            rolesToolStripMenuItem.Enabled = Session.Roles.CheckAccess(AccessMethodNames.Get);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.Dispose();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            var entity = new Employee();
            var entityEditForm = new EditForm("Добавление сотрудника", entity, Session);
            if (entityEditForm.ShowDialog() == DialogResult.OK)
            {
                var addedEmployee = entityEditForm.Entity as Employee;
                try
                {
                    Session.Employees.Add(addedEmployee);
                }
                catch (SQLiteException exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка добавления сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    UpdateEmployees();
                    comboBox_Employees.SelectedItem = addedEmployee;
                }
            }
        }

        private void button_EmployeeEdit_Click(object sender, EventArgs e)
        {
            var entity = comboBox_Employees.SelectedItem as Employee;
            var entityEditForm = new EditForm("Редактирование сотрудника", entity, Session);
            if (entityEditForm.ShowDialog() == DialogResult.OK)
            {
                var editedEmployee = entityEditForm.Entity as Employee;
                try
                {
                    Session.Employees.Edit(editedEmployee);
                }
                catch (SQLiteException exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка редактирования сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    UpdateEmployees();
                    comboBox_Employees.SelectedItem = editedEmployee;
                }
            }
        }

        private void button_EmployeeDelete_Click(object sender, EventArgs e)
        {
            var entity = comboBox_Employees.SelectedItem as Employee;
            if (entity != null &&
                entity.ID.HasValue &&
                MessageBox.Show($"Вы уверены, что ходите удалить сотрудника '{entity.Login}'?",
                    "Подтвердите удаление сотрудника",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Session.Employees.Delete(entity.ID.Value);
                }
                catch (SQLiteException exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка редактирования сотрудника", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                if (entity.Equals(Session.CurrentEmployee))
                {
                    Session.DeAuthorize();
                }
                UpdateEmployees();
            }
        }

        private void comboBox_Employees_SelectedValueChanged(object sender, EventArgs e) => CheckAndUpdateEmployeeButtons();

        private void button1_Click(object sender, EventArgs e)
        {
            var competitions = Session.Competitions.GetAll();
            var competitionsResults = Session.CompetitionsResults.GetAll();
            var conductsCompetitions = Session.ConductsCompetitions.GetAll();
            var disciplines = Session.Disciplines.GetAll();
            var employees = Session.Employees.GetAll();
            var members = Session.Members.GetAll();
            var roles = Session.Roles.GetAll();
            var sportTypes = Session.SportTypes.GetAll();
            var sportTypesCompetitions = Session.SportTypesCompetitions.GetAll();
            var sportTypesDisciplines = Session.SportTypesDisciplines.GetAll();
            var unitTypes = Session.UnitTypes.GetAll();
            var accessRights = Session.AccessRights.GetAll();
        }

        private void button_ChangeUser_Click(object sender, EventArgs e)
        {
            if (comboBox_Employees.SelectedItem is Employee currentEmployee)
            {
                //new password
                string password = null;
                if (string.IsNullOrEmpty(currentEmployee.CryptedPassword))
                {
                    MessageBox.Show("Создайте пароль для нового пользователя", "Создание пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var newPasswordForm = new InputForm("Введите новый пароль");
                    if (newPasswordForm.ShowDialog() == DialogResult.OK)
                    {
                        password = newPasswordForm.TextBox.Text;
                    }
                }

                //auth
                var passwordForm = new InputForm("Введите пароль");
                if (!string.IsNullOrEmpty(password) || passwordForm.ShowDialog() == DialogResult.OK)
                {
                    password = string.IsNullOrEmpty(passwordForm.TextBox.Text) ? password : passwordForm.TextBox.Text;
                    if (!Session.Authorize(currentEmployee.Login, password))
                    {
                        MessageBox.Show($"Ошибка авторизации пользователя '{currentEmployee.Login}'", "Ошибка входа",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        UpdateEmployees();
                    }
                }
            }
        }

        private void membersToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<Member>(Session.Members, "Редактирование участников").ShowDialog();

        private void conductsCompetitionsToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<ConductCompetition>(Session.ConductsCompetitions, "Редактирование проведений соревнований").ShowDialog();

        private void sportTypesCompetitionsToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<SportTypeCompetition>(Session.SportTypesCompetitions, "Редактирование спортивных направений в соревнованиях").ShowDialog();

        private void competitionsClientToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<Competition>(Session.Competitions, "Редактирование типов соревнований").ShowDialog();

        private void sportTypesDisciplinesToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<SportTypeDiscipline>(Session.SportTypesDisciplines, "Редактирование дисциплин спортивных направлений").ShowDialog();

        private void sportTypesToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<SportType>(Session.SportTypes, "Редактирование спортивных направлений").ShowDialog();

        private void disciplinesToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<Discipline>(Session.Disciplines, "Редактирование дисциплин").ShowDialog();

        private void unitTypesToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<UnitType>(Session.UnitTypes, "Редактирование единиц оценивания").ShowDialog();

        private void accessRightsToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<AccessRight>(Session.AccessRights, "Редактирование прав доступа").ShowDialog();

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e) =>
            new EditClientForm<Role>(Session.Roles, "Редактирование должностей").ShowDialog();
    }
}
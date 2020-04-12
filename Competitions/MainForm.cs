using System;
using System.Windows.Forms;

namespace Competitions
{
    public partial class MainForm : Form
    {
        public static readonly Session Session = new Session(Properties.Settings.Default.SqlConnection);
        public MainForm()
        {
            InitializeComponent();

            comboBox_Employees.Items.AddRange(Session.Employees.GetAll());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.Dispose();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var competitions = Session.Competitions.GetAll();
            var competitionsResults = Session.CompetitionsResults.GetAll();
            var conductsCompetitions = Session.ConductsCompetitions.GetAll();
            var disciplines = Session.Disciplines.GetAll();
            var xs = Session.Employees.GetAll();
            var members = Session.Members.GetAll();
            var roles = Session.Roles.GetAll();
            var sportTypes = Session.SportTypes.GetAll();
            var sportTypesCompetitions = Session.SportTypesCompetitions.GetAll();
            var sportTypesDisciplines = Session.SportTypesDisciplines.GetAll();
            var unitTypes = Session.UnitTypes.GetAll();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            object entity = comboBox_Employees.SelectedItem;
            var entityEditForm = new EditForm("Редактирование сотрудника", entity, Session);
            entityEditForm.ShowDialog();
        }
    }
}

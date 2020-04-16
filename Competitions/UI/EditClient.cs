using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Competitions.Clients;
using Competitions.Entities;

namespace Competitions.UI
{
    public partial class EditClient<T> : UserControl where T: EntityBase, new()
    {
        private readonly ClientBase<T> _client;
        public EditClient(ClientBase<T> client)
        {
            _client = client;
            InitializeComponent();

            groupBox_ClientDisplayName.Text = _client.DisplayName;

            LoadDataGrid();
            CheckAndUpdateContextButtons();
        }

        private void LoadDataGrid()
        {
            try
            {
                DataGridView_Client.DataSource = _client.GetAll(false);
            }
            catch { } //не выводить таблицу, вывод ошибок не требуется
            /*catch (Exception exception)
            {
                MessageBox.Show($"Ошибка при загрузке '{_client.DisplayName}': {exception.Message}", "Ошибка загрузки таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }*/
        }

        private void DataGridView_Client_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }

            DataGridView dataGridView = (DataGridView)sender;

            int rowIndex = dataGridView.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) { return; }

            dataGridView.ClearSelection();

            dataGridView.Rows[rowIndex].Selected = true;

            CheckAndUpdateContextButtons();

            contextMenuStrip_Entity.Show(dataGridView, e.X, e.Y);
        }

        private void CheckAndUpdateContextButtons()
        {
            Button_Add.Enabled = _client.CheckAccess(AccessMethodNames.Add);

            editToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;

            if (DataGridView_Client.SelectedRows.Count > 0)
            {
                editToolStripMenuItem.Enabled = _client.CheckAccess(AccessMethodNames.Add) && _client.CheckAccess(AccessMethodNames.Delete);
                deleteToolStripMenuItem.Enabled = _client.CheckAccess(AccessMethodNames.Delete);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var entity = new T();
            var entityEditForm = new EditForm($"Добавление '{_client.DisplayName}'", entity, _client.Session);
            if (entityEditForm.ShowDialog() == DialogResult.OK)
            {
                var addedEntity = entityEditForm.Entity as T;
                try
                {
                    _client.Add(addedEntity);
                }
                catch (SQLiteException exception)
                {
                    MessageBox.Show(exception.Message, $"Ошибка добавления '{_client.DisplayName}'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    LoadDataGrid();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGridView_Client.SelectedRows.Count > 0)
            {
                var selectedRow = DataGridView_Client.SelectedRows[0];
                if (selectedRow.DataBoundItem is EntityBase entity)
                {
                    var entityEditForm =
                        new EditForm($"Редактирование '{_client.DisplayName}'", entity, _client.Session);
                    if (entityEditForm.ShowDialog() == DialogResult.OK)
                    {
                        var addedEntity = entityEditForm.Entity as T;
                        try
                        {
                            _client.Edit(addedEntity);
                        }
                        catch (SQLiteException exception)
                        {
                            MessageBox.Show(exception.Message, $"Ошибка редактирования '{_client.DisplayName}'",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LoadDataGrid();
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGridView_Client.SelectedRows.Count > 0)
            {
                var selectedRow = DataGridView_Client.SelectedRows[0];
                if (selectedRow.DataBoundItem is EntityBase entity && MessageBox.Show($"Вы уверены, что ходите удалить '{entity}'?",
                        "Подтвердите удаление",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _client.Delete(entity.ID.Value);
                    }
                    catch (SQLiteException exception)
                    {
                        MessageBox.Show(exception.Message, "Ошибка редактирования", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    LoadDataGrid();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var entity = new T();
            var entityEditForm = new EditForm($"Добавление '{_client.DisplayName}'", entity, _client.Session);
            if (entityEditForm.ShowDialog() == DialogResult.OK)
            {
                var addedEntity = entityEditForm.Entity as T;
                try
                {
                    _client.Add(addedEntity);
                }
                catch (SQLiteException exception)
                {
                    MessageBox.Show(exception.Message, $"Ошибка добавления '{_client.DisplayName}'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    LoadDataGrid();
                }
            }
        }
    }
}
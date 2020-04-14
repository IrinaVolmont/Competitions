using System;
using System.Windows.Forms;
using Competitions.Clients;
using Competitions.Entities;

namespace Competitions.UI
{
    public partial class EditClient : UserControl
    {
        private readonly ClientBase<EntityBase> _client;
        public EditClient(ClientBase<EntityBase> client)
        {
            _client = client;
            InitializeComponent();

            groupBox_ClientDisplayName.Text = client.DisplayName;

            try
            {
                DataGridView_Client.DataSource = _client.GetAll(false);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка при загрузке '{_client.DisplayName}': {exception.Message}", "Ошибка загрузки таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }
    }
}

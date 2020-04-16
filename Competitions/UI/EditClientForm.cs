using System.Windows.Forms;
using Competitions.Clients;
using Competitions.Entities;

namespace Competitions.UI
{
    public partial class EditClientForm<T> : Form where T : EntityBase, new()
    {
        public EditClientForm(ClientBase<T> client, string title)
        {
            InitializeComponent();

            panel_Main.Controls.Add(new EditClient<T>(client) { Dock = DockStyle.Fill });

            this.Text = title;
        }

        private void EditClientForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}

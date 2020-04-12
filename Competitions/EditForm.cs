using System.Windows.Forms;

namespace Competitions
{
    public partial class EditForm : Form
    {
        private readonly Session _session;
        public EditForm(string title, object entity, Session session)
        {
            InitializeComponent();
            this.Text = title;
            _session = session;

            propertyGrid_Entity.SelectedObject = entity;
        }

        private void button_Save_Click(object sender, System.EventArgs e) => this.DialogResult = DialogResult.OK;
    }
}

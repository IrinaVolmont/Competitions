using System;
using System.Windows.Forms;

namespace Competitions.UI
{
    public partial class InputForm : Form
    {
        public InputForm(string title, string defaultText = "")
        {
            InitializeComponent();

            this.Text = title;
            TextBox.Text = defaultText;
        }

        private void button_Ok_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;
    }
}

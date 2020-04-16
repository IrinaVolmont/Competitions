using System;
using System.ComponentModel;
using System.Windows.Forms;
using Competitions.Entities;

namespace Competitions.UI
{
    public partial class EditForm : Form
    {
        private readonly Session _session;
        public EntityBase Entity;

        public EditForm(string title, EntityBase entity, Session session)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            InitializeComponent();
            this.Text = title;
            _session = session;

            Entity = entity;
            propertyGrid_Entity.SelectedObject = Entity;
        }

        private void button_Save_Click(object sender, System.EventArgs e)
        {
            if (!IsPropertiesCorrect)
            {
                MessageBox.Show("Заполните обязательные поля", "Ошибка корректности ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Entity = propertyGrid_Entity.SelectedObject as EntityBase;
        }

        private bool IsPropertiesCorrect
        {
            get
            {
                foreach (var propertyInfo in Entity.GetType().GetProperties())
                {
                    var browsableAttribute =  (BrowsableAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(BrowsableAttribute));
                    if (browsableAttribute != null && !browsableAttribute.Browsable)
                    {
                        continue;
                    }

                    object value = propertyInfo.GetValue(Entity);
                    Type type = propertyInfo.PropertyType;
                    bool nullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

                    if (!nullable && value == null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private void EditForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
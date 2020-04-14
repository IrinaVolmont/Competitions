namespace Competitions.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_Employees = new System.Windows.Forms.ComboBox();
            this.button_EmployeeAdd = new System.Windows.Forms.Button();
            this.button_EmployeeEdit = new System.Windows.Forms.Button();
            this.button_EmployeeDelete = new System.Windows.Forms.Button();
            this.groupBox_Employees = new System.Windows.Forms.GroupBox();
            this.button_ChangeUser = new System.Windows.Forms.Button();
            this.label_CurrentUser = new System.Windows.Forms.Label();
            this.label_CurrentUserInfo = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.участникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администрированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_CompetitionsResults = new System.Windows.Forms.Panel();
            this.groupBox_Employees.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Employees
            // 
            this.comboBox_Employees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Employees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Employees.FormattingEnabled = true;
            this.comboBox_Employees.Location = new System.Drawing.Point(9, 32);
            this.comboBox_Employees.Name = "comboBox_Employees";
            this.comboBox_Employees.Size = new System.Drawing.Size(337, 21);
            this.comboBox_Employees.TabIndex = 0;
            this.comboBox_Employees.SelectedValueChanged += new System.EventHandler(this.comboBox_Employees_SelectedValueChanged);
            // 
            // button_EmployeeAdd
            // 
            this.button_EmployeeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_EmployeeAdd.Enabled = false;
            this.button_EmployeeAdd.Location = new System.Drawing.Point(458, 32);
            this.button_EmployeeAdd.Name = "button_EmployeeAdd";
            this.button_EmployeeAdd.Size = new System.Drawing.Size(100, 23);
            this.button_EmployeeAdd.TabIndex = 1;
            this.button_EmployeeAdd.Text = "Добавить";
            this.button_EmployeeAdd.UseVisualStyleBackColor = true;
            this.button_EmployeeAdd.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_EmployeeEdit
            // 
            this.button_EmployeeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_EmployeeEdit.Enabled = false;
            this.button_EmployeeEdit.Location = new System.Drawing.Point(564, 32);
            this.button_EmployeeEdit.Name = "button_EmployeeEdit";
            this.button_EmployeeEdit.Size = new System.Drawing.Size(100, 23);
            this.button_EmployeeEdit.TabIndex = 2;
            this.button_EmployeeEdit.Text = "Редактировать";
            this.button_EmployeeEdit.UseVisualStyleBackColor = true;
            this.button_EmployeeEdit.Click += new System.EventHandler(this.button_EmployeeEdit_Click);
            // 
            // button_EmployeeDelete
            // 
            this.button_EmployeeDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_EmployeeDelete.Enabled = false;
            this.button_EmployeeDelete.Location = new System.Drawing.Point(670, 32);
            this.button_EmployeeDelete.Name = "button_EmployeeDelete";
            this.button_EmployeeDelete.Size = new System.Drawing.Size(100, 23);
            this.button_EmployeeDelete.TabIndex = 3;
            this.button_EmployeeDelete.Text = "Удалить";
            this.button_EmployeeDelete.UseVisualStyleBackColor = true;
            this.button_EmployeeDelete.Click += new System.EventHandler(this.button_EmployeeDelete_Click);
            // 
            // groupBox_Employees
            // 
            this.groupBox_Employees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Employees.Controls.Add(this.button_ChangeUser);
            this.groupBox_Employees.Controls.Add(this.label_CurrentUser);
            this.groupBox_Employees.Controls.Add(this.label_CurrentUserInfo);
            this.groupBox_Employees.Controls.Add(this.comboBox_Employees);
            this.groupBox_Employees.Controls.Add(this.button_EmployeeDelete);
            this.groupBox_Employees.Controls.Add(this.button_EmployeeAdd);
            this.groupBox_Employees.Controls.Add(this.button_EmployeeEdit);
            this.groupBox_Employees.Location = new System.Drawing.Point(12, 27);
            this.groupBox_Employees.Name = "groupBox_Employees";
            this.groupBox_Employees.Size = new System.Drawing.Size(776, 68);
            this.groupBox_Employees.TabIndex = 4;
            this.groupBox_Employees.TabStop = false;
            this.groupBox_Employees.Text = "Сотрудники";
            // 
            // button_ChangeUser
            // 
            this.button_ChangeUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ChangeUser.Location = new System.Drawing.Point(352, 32);
            this.button_ChangeUser.Name = "button_ChangeUser";
            this.button_ChangeUser.Size = new System.Drawing.Size(100, 23);
            this.button_ChangeUser.TabIndex = 6;
            this.button_ChangeUser.Text = "Сменить";
            this.button_ChangeUser.UseVisualStyleBackColor = true;
            this.button_ChangeUser.Click += new System.EventHandler(this.button_ChangeUser_Click);
            // 
            // label_CurrentUser
            // 
            this.label_CurrentUser.AutoSize = true;
            this.label_CurrentUser.Location = new System.Drawing.Point(122, 16);
            this.label_CurrentUser.Name = "label_CurrentUser";
            this.label_CurrentUser.Size = new System.Drawing.Size(60, 13);
            this.label_CurrentUser.TabIndex = 5;
            this.label_CurrentUser.Text = "не выбран";
            // 
            // label_CurrentUserInfo
            // 
            this.label_CurrentUserInfo.AutoSize = true;
            this.label_CurrentUserInfo.Location = new System.Drawing.Point(6, 16);
            this.label_CurrentUserInfo.Name = "label_CurrentUserInfo";
            this.label_CurrentUserInfo.Size = new System.Drawing.Size(110, 13);
            this.label_CurrentUserInfo.TabIndex = 4;
            this.label_CurrentUserInfo.Text = "Текущий сотрудник:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.участникиToolStripMenuItem,
            this.администрированиеToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // участникиToolStripMenuItem
            // 
            this.участникиToolStripMenuItem.Name = "участникиToolStripMenuItem";
            this.участникиToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.участникиToolStripMenuItem.Text = "Участники";
            // 
            // администрированиеToolStripMenuItem
            // 
            this.администрированиеToolStripMenuItem.Name = "администрированиеToolStripMenuItem";
            this.администрированиеToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.администрированиеToolStripMenuItem.Text = "Администрирование";
            // 
            // panel_CompetitionsResults
            // 
            this.panel_CompetitionsResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_CompetitionsResults.Location = new System.Drawing.Point(12, 101);
            this.panel_CompetitionsResults.Name = "panel_CompetitionsResults";
            this.panel_CompetitionsResults.Size = new System.Drawing.Size(776, 337);
            this.panel_CompetitionsResults.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_CompetitionsResults);
            this.Controls.Add(this.groupBox_Employees);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проведение соревнований";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox_Employees.ResumeLayout(false);
            this.groupBox_Employees.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Employees;
        private System.Windows.Forms.Button button_EmployeeAdd;
        private System.Windows.Forms.Button button_EmployeeEdit;
        private System.Windows.Forms.Button button_EmployeeDelete;
        private System.Windows.Forms.GroupBox groupBox_Employees;
        private System.Windows.Forms.Button button_ChangeUser;
        private System.Windows.Forms.Label label_CurrentUser;
        private System.Windows.Forms.Label label_CurrentUserInfo;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem участникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem администрированиеToolStripMenuItem;
        private System.Windows.Forms.Panel panel_CompetitionsResults;
    }
}


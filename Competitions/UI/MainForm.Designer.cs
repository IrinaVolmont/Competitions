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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBox_Employees = new System.Windows.Forms.ComboBox();
            this.button_EmployeeAdd = new System.Windows.Forms.Button();
            this.button_EmployeeEdit = new System.Windows.Forms.Button();
            this.button_EmployeeDelete = new System.Windows.Forms.Button();
            this.groupBox_Employees = new System.Windows.Forms.GroupBox();
            this.button_ChangeUser = new System.Windows.Forms.Button();
            this.label_CurrentUser = new System.Windows.Forms.Label();
            this.label_CurrentUserInfo = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.membersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_CompetitionsResults = new System.Windows.Forms.Panel();
            this.conductsCompetitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sportTypesCompetitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.competitionsClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sportTypesDisciplinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sportTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accessRightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.comboBox_Employees.Size = new System.Drawing.Size(1021, 21);
            this.comboBox_Employees.TabIndex = 0;
            this.comboBox_Employees.SelectedValueChanged += new System.EventHandler(this.comboBox_Employees_SelectedValueChanged);
            // 
            // button_EmployeeAdd
            // 
            this.button_EmployeeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_EmployeeAdd.Enabled = false;
            this.button_EmployeeAdd.Location = new System.Drawing.Point(1142, 32);
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
            this.button_EmployeeEdit.Location = new System.Drawing.Point(1248, 32);
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
            this.button_EmployeeDelete.Location = new System.Drawing.Point(1354, 32);
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
            this.groupBox_Employees.Size = new System.Drawing.Size(1460, 68);
            this.groupBox_Employees.TabIndex = 4;
            this.groupBox_Employees.TabStop = false;
            this.groupBox_Employees.Text = "Сотрудники";
            // 
            // button_ChangeUser
            // 
            this.button_ChangeUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ChangeUser.Location = new System.Drawing.Point(1036, 32);
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
            this.membersToolStripMenuItem,
            this.conductsCompetitionsToolStripMenuItem,
            this.sportTypesCompetitionsToolStripMenuItem,
            this.competitionsClientToolStripMenuItem,
            this.sportTypesDisciplinesToolStripMenuItem,
            this.sportTypesToolStripMenuItem,
            this.disciplinesToolStripMenuItem,
            this.unitTypesToolStripMenuItem,
            this.accessRightsToolStripMenuItem,
            this.rolesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1484, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // membersToolStripMenuItem
            // 
            this.membersToolStripMenuItem.Name = "membersToolStripMenuItem";
            this.membersToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.membersToolStripMenuItem.Text = "Участники";
            this.membersToolStripMenuItem.Click += new System.EventHandler(this.membersToolStripMenuItem_Click);
            // 
            // panel_CompetitionsResults
            // 
            this.panel_CompetitionsResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_CompetitionsResults.Location = new System.Drawing.Point(12, 101);
            this.panel_CompetitionsResults.Name = "panel_CompetitionsResults";
            this.panel_CompetitionsResults.Size = new System.Drawing.Size(1460, 648);
            this.panel_CompetitionsResults.TabIndex = 6;
            // 
            // conductsCompetitionsToolStripMenuItem
            // 
            this.conductsCompetitionsToolStripMenuItem.Name = "conductsCompetitionsToolStripMenuItem";
            this.conductsCompetitionsToolStripMenuItem.Size = new System.Drawing.Size(168, 20);
            this.conductsCompetitionsToolStripMenuItem.Text = "Проведение соревнований";
            this.conductsCompetitionsToolStripMenuItem.Click += new System.EventHandler(this.conductsCompetitionsToolStripMenuItem_Click);
            // 
            // sportTypesCompetitionsToolStripMenuItem
            // 
            this.sportTypesCompetitionsToolStripMenuItem.Name = "sportTypesCompetitionsToolStripMenuItem";
            this.sportTypesCompetitionsToolStripMenuItem.Size = new System.Drawing.Size(252, 20);
            this.sportTypesCompetitionsToolStripMenuItem.Text = "Спортивные направения в соревнованиях";
            this.sportTypesCompetitionsToolStripMenuItem.Click += new System.EventHandler(this.sportTypesCompetitionsToolStripMenuItem_Click);
            // 
            // competitionsClientToolStripMenuItem
            // 
            this.competitionsClientToolStripMenuItem.Name = "competitionsClientToolStripMenuItem";
            this.competitionsClientToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.competitionsClientToolStripMenuItem.Text = "Типы соревнований";
            this.competitionsClientToolStripMenuItem.Click += new System.EventHandler(this.competitionsClientToolStripMenuItem_Click);
            // 
            // sportTypesDisciplinesToolStripMenuItem
            // 
            this.sportTypesDisciplinesToolStripMenuItem.Name = "sportTypesDisciplinesToolStripMenuItem";
            this.sportTypesDisciplinesToolStripMenuItem.Size = new System.Drawing.Size(237, 20);
            this.sportTypesDisciplinesToolStripMenuItem.Text = "Дисциплины спортивных направлений";
            this.sportTypesDisciplinesToolStripMenuItem.Click += new System.EventHandler(this.sportTypesDisciplinesToolStripMenuItem_Click);
            // 
            // sportTypesToolStripMenuItem
            // 
            this.sportTypesToolStripMenuItem.Name = "sportTypesToolStripMenuItem";
            this.sportTypesToolStripMenuItem.Size = new System.Drawing.Size(163, 20);
            this.sportTypesToolStripMenuItem.Text = "Спортивные направления";
            this.sportTypesToolStripMenuItem.Click += new System.EventHandler(this.sportTypesToolStripMenuItem_Click);
            // 
            // disciplinesToolStripMenuItem
            // 
            this.disciplinesToolStripMenuItem.Name = "disciplinesToolStripMenuItem";
            this.disciplinesToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.disciplinesToolStripMenuItem.Text = "Дисциплины";
            this.disciplinesToolStripMenuItem.Click += new System.EventHandler(this.disciplinesToolStripMenuItem_Click);
            // 
            // unitTypesToolStripMenuItem
            // 
            this.unitTypesToolStripMenuItem.Name = "unitTypesToolStripMenuItem";
            this.unitTypesToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.unitTypesToolStripMenuItem.Text = "Единицы оценивания";
            this.unitTypesToolStripMenuItem.Click += new System.EventHandler(this.unitTypesToolStripMenuItem_Click);
            // 
            // accessRightsToolStripMenuItem
            // 
            this.accessRightsToolStripMenuItem.Name = "accessRightsToolStripMenuItem";
            this.accessRightsToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.accessRightsToolStripMenuItem.Text = "Права доступа";
            this.accessRightsToolStripMenuItem.Click += new System.EventHandler(this.accessRightsToolStripMenuItem_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.rolesToolStripMenuItem.Text = "Должности";
            this.rolesToolStripMenuItem.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 761);
            this.Controls.Add(this.panel_CompetitionsResults);
            this.Controls.Add(this.groupBox_Employees);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1500, 800);
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
        private System.Windows.Forms.ToolStripMenuItem membersToolStripMenuItem;
        private System.Windows.Forms.Panel panel_CompetitionsResults;
        private System.Windows.Forms.ToolStripMenuItem conductsCompetitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sportTypesCompetitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem competitionsClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sportTypesDisciplinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sportTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accessRightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
    }
}


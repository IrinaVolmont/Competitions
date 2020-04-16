namespace Competitions.UI
{
    partial class EditClient<T>
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DataGridView_Client = new System.Windows.Forms.DataGridView();
            this.groupBox_ClientDisplayName = new System.Windows.Forms.GroupBox();
            this.Button_Add = new System.Windows.Forms.Button();
            this.contextMenuStrip_Entity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Client)).BeginInit();
            this.groupBox_ClientDisplayName.SuspendLayout();
            this.contextMenuStrip_Entity.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView_Client
            // 
            this.DataGridView_Client.AllowUserToAddRows = false;
            this.DataGridView_Client.AllowUserToDeleteRows = false;
            this.DataGridView_Client.AllowUserToResizeRows = false;
            this.DataGridView_Client.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Client.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_Client.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView_Client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Client.Location = new System.Drawing.Point(6, 19);
            this.DataGridView_Client.MultiSelect = false;
            this.DataGridView_Client.Name = "DataGridView_Client";
            this.DataGridView_Client.ReadOnly = true;
            this.DataGridView_Client.RowHeadersVisible = false;
            this.DataGridView_Client.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Client.Size = new System.Drawing.Size(610, 266);
            this.DataGridView_Client.TabIndex = 0;
            this.DataGridView_Client.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView_Client_MouseClick);
            // 
            // groupBox_ClientDisplayName
            // 
            this.groupBox_ClientDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_ClientDisplayName.Controls.Add(this.Button_Add);
            this.groupBox_ClientDisplayName.Controls.Add(this.DataGridView_Client);
            this.groupBox_ClientDisplayName.Location = new System.Drawing.Point(3, 3);
            this.groupBox_ClientDisplayName.Name = "groupBox_ClientDisplayName";
            this.groupBox_ClientDisplayName.Size = new System.Drawing.Size(622, 327);
            this.groupBox_ClientDisplayName.TabIndex = 1;
            this.groupBox_ClientDisplayName.TabStop = false;
            this.groupBox_ClientDisplayName.Text = "CLIENT_DISPLAY_NAME";
            // 
            // Button_Add
            // 
            this.Button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Add.Location = new System.Drawing.Point(6, 291);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(610, 30);
            this.Button_Add.TabIndex = 1;
            this.Button_Add.Text = "Добавить";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip_Entity
            // 
            this.contextMenuStrip_Entity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip_Entity.Name = "contextMenuStrip_Entity";
            this.contextMenuStrip_Entity.Size = new System.Drawing.Size(155, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editToolStripMenuItem.Text = "Редактировать";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // EditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_ClientDisplayName);
            this.Name = "EditClient";
            this.Size = new System.Drawing.Size(628, 333);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Client)).EndInit();
            this.groupBox_ClientDisplayName.ResumeLayout(false);
            this.contextMenuStrip_Entity.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DataGridView_Client;
        private System.Windows.Forms.GroupBox groupBox_ClientDisplayName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Entity;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        public System.Windows.Forms.Button Button_Add;
    }
}

namespace Competitions.UI
{
    partial class EditClient
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
            this.DataGridView_Client = new System.Windows.Forms.DataGridView();
            this.groupBox_ClientDisplayName = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Client)).BeginInit();
            this.groupBox_ClientDisplayName.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView_Client
            // 
            this.DataGridView_Client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Client.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_Client.Location = new System.Drawing.Point(3, 16);
            this.DataGridView_Client.Name = "DataGridView_Client";
            this.DataGridView_Client.Size = new System.Drawing.Size(616, 259);
            this.DataGridView_Client.TabIndex = 0;
            // 
            // groupBox_ClientDisplayName
            // 
            this.groupBox_ClientDisplayName.Controls.Add(this.DataGridView_Client);
            this.groupBox_ClientDisplayName.Location = new System.Drawing.Point(3, 3);
            this.groupBox_ClientDisplayName.Name = "groupBox_ClientDisplayName";
            this.groupBox_ClientDisplayName.Size = new System.Drawing.Size(622, 278);
            this.groupBox_ClientDisplayName.TabIndex = 1;
            this.groupBox_ClientDisplayName.TabStop = false;
            this.groupBox_ClientDisplayName.Text = "CLIENT_DISPLAY_NAME";
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
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DataGridView_Client;
        private System.Windows.Forms.GroupBox groupBox_ClientDisplayName;
    }
}

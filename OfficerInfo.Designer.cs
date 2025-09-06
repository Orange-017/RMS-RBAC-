namespace RECOMANAGESYS
{
    partial class OfficerInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.officerPanel = new System.Windows.Forms.Panel();
            this.Editbtn = new System.Windows.Forms.Button();
            this.registerbtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.Refreshbtn = new System.Windows.Forms.Button();
            this.DGVOfficers = new System.Windows.Forms.DataGridView();
            this.searchbtn = new FontAwesome.Sharp.IconButton();
            this.officerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOfficers)).BeginInit();
            this.SuspendLayout();
            // 
            // officerPanel
            // 
            this.officerPanel.BackColor = System.Drawing.Color.White;
            this.officerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.officerPanel.Controls.Add(this.Editbtn);
            this.officerPanel.Controls.Add(this.registerbtn);
            this.officerPanel.Controls.Add(this.searchbtn);
            this.officerPanel.Controls.Add(this.textBox1);
            this.officerPanel.Controls.Add(this.Deletebtn);
            this.officerPanel.Controls.Add(this.Refreshbtn);
            this.officerPanel.Controls.Add(this.DGVOfficers);
            this.officerPanel.Location = new System.Drawing.Point(31, 40);
            this.officerPanel.Name = "officerPanel";
            this.officerPanel.Size = new System.Drawing.Size(1060, 601);
            this.officerPanel.TabIndex = 4;
            this.officerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.officerPanel_Paint);
            // 
            // Editbtn
            // 
            this.Editbtn.Location = new System.Drawing.Point(169, 65);
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.Size = new System.Drawing.Size(96, 29);
            this.Editbtn.TabIndex = 13;
            this.Editbtn.Text = "Edit";
            this.Editbtn.UseVisualStyleBackColor = true;
            // 
            // registerbtn
            // 
            this.registerbtn.Location = new System.Drawing.Point(749, 81);
            this.registerbtn.Name = "registerbtn";
            this.registerbtn.Size = new System.Drawing.Size(290, 37);
            this.registerbtn.TabIndex = 12;
            this.registerbtn.Text = "Register Officer Account";
            this.registerbtn.UseVisualStyleBackColor = true;
            this.registerbtn.Click += new System.EventHandler(this.registerbtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(686, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 38);
            this.textBox1.TabIndex = 10;
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(295, 65);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(111, 35);
            this.Deletebtn.TabIndex = 1;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // Refreshbtn
            // 
            this.Refreshbtn.Location = new System.Drawing.Point(43, 65);
            this.Refreshbtn.Name = "Refreshbtn";
            this.Refreshbtn.Size = new System.Drawing.Size(98, 35);
            this.Refreshbtn.TabIndex = 0;
            this.Refreshbtn.Text = "Refresh";
            this.Refreshbtn.UseVisualStyleBackColor = true;
            this.Refreshbtn.Click += new System.EventHandler(this.Refreshbtn_Click);
            // 
            // DGVOfficers
            // 
            this.DGVOfficers.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGVOfficers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOfficers.Location = new System.Drawing.Point(18, 135);
            this.DGVOfficers.Name = "DGVOfficers";
            this.DGVOfficers.RowHeadersWidth = 51;
            this.DGVOfficers.RowTemplate.Height = 24;
            this.DGVOfficers.Size = new System.Drawing.Size(1021, 447);
            this.DGVOfficers.TabIndex = 8;
            // 
            // searchbtn
            // 
            this.searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchbtn.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.searchbtn.IconColor = System.Drawing.Color.Black;
            this.searchbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.searchbtn.IconSize = 28;
            this.searchbtn.Location = new System.Drawing.Point(989, 25);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(50, 38);
            this.searchbtn.TabIndex = 11;
            this.searchbtn.UseVisualStyleBackColor = true;
            // 
            // OfficerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 673);
            this.Controls.Add(this.officerPanel);
            this.Name = "OfficerInfo";
            this.Text = "OfficerInfo";
            this.Load += new System.EventHandler(this.OfficerInfo_Load);
            this.officerPanel.ResumeLayout(false);
            this.officerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOfficers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel officerPanel;
        private System.Windows.Forms.Button Editbtn;
        private System.Windows.Forms.Button registerbtn;
        private FontAwesome.Sharp.IconButton searchbtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button Refreshbtn;
        private System.Windows.Forms.DataGridView DGVOfficers;
    }
}
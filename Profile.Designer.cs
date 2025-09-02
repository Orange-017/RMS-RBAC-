namespace RECOMANAGESYS
{
    partial class Profilefrm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddAccountbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddProfiles = new System.Windows.Forms.Button();
            this.EditProfilebtn = new System.Windows.Forms.Button();
            this.searchbtn = new FontAwesome.Sharp.IconButton();
            this.Searchtxt = new System.Windows.Forms.TextBox();
            this.Refreshbtn = new System.Windows.Forms.Button();
            this.DGVProfile = new System.Windows.Forms.DataGridView();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.AddAccountbtn);
            this.panel1.Location = new System.Drawing.Point(57, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 51);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // AddAccountbtn
            // 
            this.AddAccountbtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.AddAccountbtn.FlatAppearance.BorderSize = 0;
            this.AddAccountbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAccountbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAccountbtn.ForeColor = System.Drawing.Color.White;
            this.AddAccountbtn.Location = new System.Drawing.Point(901, 5);
            this.AddAccountbtn.Name = "AddAccountbtn";
            this.AddAccountbtn.Size = new System.Drawing.Size(154, 41);
            this.AddAccountbtn.TabIndex = 5;
            this.AddAccountbtn.Text = "Register Account";
            this.AddAccountbtn.UseVisualStyleBackColor = false;
            this.AddAccountbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Deletebtn);
            this.panel2.Controls.Add(this.AddProfiles);
            this.panel2.Controls.Add(this.EditProfilebtn);
            this.panel2.Controls.Add(this.searchbtn);
            this.panel2.Controls.Add(this.Searchtxt);
            this.panel2.Controls.Add(this.Refreshbtn);
            this.panel2.Controls.Add(this.DGVProfile);
            this.panel2.Location = new System.Drawing.Point(57, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1060, 612);
            this.panel2.TabIndex = 1;
            // 
            // AddProfiles
            // 
            this.AddProfiles.BackColor = System.Drawing.SystemColors.HotTrack;
            this.AddProfiles.FlatAppearance.BorderSize = 0;
            this.AddProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProfiles.ForeColor = System.Drawing.Color.White;
            this.AddProfiles.Location = new System.Drawing.Point(185, 21);
            this.AddProfiles.Name = "AddProfiles";
            this.AddProfiles.Size = new System.Drawing.Size(154, 41);
            this.AddProfiles.TabIndex = 8;
            this.AddProfiles.Text = "Add Profile";
            this.AddProfiles.UseVisualStyleBackColor = false;
            this.AddProfiles.Click += new System.EventHandler(this.AddProfiles_Click);
            // 
            // EditProfilebtn
            // 
            this.EditProfilebtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.EditProfilebtn.FlatAppearance.BorderSize = 0;
            this.EditProfilebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditProfilebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditProfilebtn.ForeColor = System.Drawing.Color.White;
            this.EditProfilebtn.Location = new System.Drawing.Point(345, 21);
            this.EditProfilebtn.Name = "EditProfilebtn";
            this.EditProfilebtn.Size = new System.Drawing.Size(154, 41);
            this.EditProfilebtn.TabIndex = 7;
            this.EditProfilebtn.Text = "Edit Profile";
            this.EditProfilebtn.UseVisualStyleBackColor = false;
            this.EditProfilebtn.Click += new System.EventHandler(this.EditProfilebtn_Click);
            // 
            // searchbtn
            // 
            this.searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchbtn.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.searchbtn.IconColor = System.Drawing.Color.Black;
            this.searchbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.searchbtn.IconSize = 28;
            this.searchbtn.Location = new System.Drawing.Point(988, 21);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(50, 38);
            this.searchbtn.TabIndex = 3;
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // Searchtxt
            // 
            this.Searchtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Searchtxt.Location = new System.Drawing.Point(685, 21);
            this.Searchtxt.Multiline = true;
            this.Searchtxt.Name = "Searchtxt";
            this.Searchtxt.Size = new System.Drawing.Size(353, 38);
            this.Searchtxt.TabIndex = 6;
            this.Searchtxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Refreshbtn
            // 
            this.Refreshbtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Refreshbtn.FlatAppearance.BorderSize = 0;
            this.Refreshbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refreshbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refreshbtn.ForeColor = System.Drawing.Color.White;
            this.Refreshbtn.Location = new System.Drawing.Point(25, 21);
            this.Refreshbtn.Name = "Refreshbtn";
            this.Refreshbtn.Size = new System.Drawing.Size(154, 41);
            this.Refreshbtn.TabIndex = 4;
            this.Refreshbtn.Text = "Refresh";
            this.Refreshbtn.UseVisualStyleBackColor = false;
            this.Refreshbtn.Click += new System.EventHandler(this.viewProfilebtn_Click);
            // 
            // DGVProfile
            // 
            this.DGVProfile.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGVProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProfile.Location = new System.Drawing.Point(25, 90);
            this.DGVProfile.Name = "DGVProfile";
            this.DGVProfile.RowHeadersWidth = 51;
            this.DGVProfile.RowTemplate.Height = 24;
            this.DGVProfile.Size = new System.Drawing.Size(1013, 499);
            this.DGVProfile.TabIndex = 0;
            this.DGVProfile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProfile_CellContentClick);
            // 
            // Deletebtn
            // 
            this.Deletebtn.BackColor = System.Drawing.Color.Red;
            this.Deletebtn.Location = new System.Drawing.Point(551, 39);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(108, 23);
            this.Deletebtn.TabIndex = 9;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.UseVisualStyleBackColor = false;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // Profilefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Profilefrm";
            this.Size = new System.Drawing.Size(1164, 737);
            this.Load += new System.EventHandler(this.Profile_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DGVProfile;
        private System.Windows.Forms.Button Refreshbtn;
        private System.Windows.Forms.Button AddAccountbtn;
        private System.Windows.Forms.TextBox Searchtxt;
        private System.Windows.Forms.Button EditProfilebtn;
        private FontAwesome.Sharp.IconButton searchbtn;
        private System.Windows.Forms.Button AddProfiles;
        private System.Windows.Forms.Button Deletebtn;
    }
}

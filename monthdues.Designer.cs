namespace RECOMANAGESYS
{
    partial class monthdues
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
            this.HomeOwnersShow = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateHomeOwners = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.searchbtn = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addHomeowners = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.HomeOwnersShow)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // HomeOwnersShow
            // 
            this.HomeOwnersShow.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.HomeOwnersShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HomeOwnersShow.Location = new System.Drawing.Point(16, 57);
            this.HomeOwnersShow.Margin = new System.Windows.Forms.Padding(2);
            this.HomeOwnersShow.Name = "HomeOwnersShow";
            this.HomeOwnersShow.RowHeadersWidth = 51;
            this.HomeOwnersShow.RowTemplate.Height = 24;
            this.HomeOwnersShow.Size = new System.Drawing.Size(760, 392);
            this.HomeOwnersShow.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.updateHomeOwners);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.searchbtn);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.HomeOwnersShow);
            this.panel1.Location = new System.Drawing.Point(38, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 468);
            this.panel1.TabIndex = 1;
            // 
            // updateHomeOwners
            // 
            this.updateHomeOwners.BackColor = System.Drawing.SystemColors.HotTrack;
            this.updateHomeOwners.FlatAppearance.BorderSize = 0;
            this.updateHomeOwners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateHomeOwners.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateHomeOwners.ForeColor = System.Drawing.Color.White;
            this.updateHomeOwners.Location = new System.Drawing.Point(16, 13);
            this.updateHomeOwners.Margin = new System.Windows.Forms.Padding(2);
            this.updateHomeOwners.Name = "updateHomeOwners";
            this.updateHomeOwners.Size = new System.Drawing.Size(116, 33);
            this.updateHomeOwners.TabIndex = 5;
            this.updateHomeOwners.Text = "Update ";
            this.updateHomeOwners.UseVisualStyleBackColor = false;
            this.updateHomeOwners.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(136, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // searchbtn
            // 
            this.searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchbtn.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.searchbtn.IconColor = System.Drawing.Color.Black;
            this.searchbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.searchbtn.IconSize = 28;
            this.searchbtn.Location = new System.Drawing.Point(739, 15);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(38, 31);
            this.searchbtn.TabIndex = 3;
            this.searchbtn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(512, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 31);
            this.textBox1.TabIndex = 2;
            // 
            // addHomeowners
            // 
            this.addHomeowners.BackColor = System.Drawing.SystemColors.HotTrack;
            this.addHomeowners.FlatAppearance.BorderSize = 0;
            this.addHomeowners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addHomeowners.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.addHomeowners.ForeColor = System.Drawing.Color.White;
            this.addHomeowners.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.addHomeowners.IconColor = System.Drawing.Color.White;
            this.addHomeowners.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addHomeowners.IconSize = 25;
            this.addHomeowners.Location = new System.Drawing.Point(622, 20);
            this.addHomeowners.Margin = new System.Windows.Forms.Padding(2);
            this.addHomeowners.Name = "addHomeowners";
            this.addHomeowners.Size = new System.Drawing.Size(155, 33);
            this.addHomeowners.TabIndex = 5;
            this.addHomeowners.Text = "Add Homeowner";
            this.addHomeowners.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addHomeowners.UseVisualStyleBackColor = false;
            this.addHomeowners.Click += new System.EventHandler(this.addvisitor_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.addHomeowners);
            this.panel2.Location = new System.Drawing.Point(38, 19);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 74);
            this.panel2.TabIndex = 2;
            // 
            // monthdues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "monthdues";
            this.Size = new System.Drawing.Size(873, 599);
            ((System.ComponentModel.ISupportInitialize)(this.HomeOwnersShow)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView HomeOwnersShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconButton searchbtn;
        private System.Windows.Forms.Button button1;
        private FontAwesome.Sharp.IconButton addHomeowners;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button updateHomeOwners;
    }
}

namespace RECOMANAGESYS
{
    partial class addhomeowner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addhomeowner));
            this.label1 = new System.Windows.Forms.Label();
            this.txtHOname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHOaddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHOcontact = new System.Windows.Forms.TextBox();
            this.saveHomeowner = new System.Windows.Forms.Button();
            this.cancelvisitor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbClassification = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(96, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Homeowner Name: ";
            // 
            // txtHOname
            // 
            this.txtHOname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHOname.Location = new System.Drawing.Point(101, 175);
            this.txtHOname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHOname.Multiline = true;
            this.txtHOname.Name = "txtHOname";
            this.txtHOname.Size = new System.Drawing.Size(321, 38);
            this.txtHOname.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(96, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address:";
            // 
            // txtHOaddress
            // 
            this.txtHOaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHOaddress.Location = new System.Drawing.Point(101, 265);
            this.txtHOaddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHOaddress.Multiline = true;
            this.txtHOaddress.Name = "txtHOaddress";
            this.txtHOaddress.Size = new System.Drawing.Size(321, 38);
            this.txtHOaddress.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(504, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 27);
            this.label6.TabIndex = 11;
            this.label6.Text = "Contact Number:";
            // 
            // txtHOcontact
            // 
            this.txtHOcontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHOcontact.Location = new System.Drawing.Point(509, 175);
            this.txtHOcontact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHOcontact.Multiline = true;
            this.txtHOcontact.Name = "txtHOcontact";
            this.txtHOcontact.Size = new System.Drawing.Size(321, 38);
            this.txtHOcontact.TabIndex = 12;
            // 
            // saveHomeowner
            // 
            this.saveHomeowner.BackColor = System.Drawing.SystemColors.HotTrack;
            this.saveHomeowner.FlatAppearance.BorderSize = 0;
            this.saveHomeowner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveHomeowner.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.saveHomeowner.ForeColor = System.Drawing.Color.White;
            this.saveHomeowner.Location = new System.Drawing.Point(507, 396);
            this.saveHomeowner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveHomeowner.Name = "saveHomeowner";
            this.saveHomeowner.Size = new System.Drawing.Size(100, 42);
            this.saveHomeowner.TabIndex = 13;
            this.saveHomeowner.Text = "Save";
            this.saveHomeowner.UseVisualStyleBackColor = false;
            this.saveHomeowner.Click += new System.EventHandler(this.savevisitor_Click);
            // 
            // cancelvisitor
            // 
            this.cancelvisitor.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.cancelvisitor.FlatAppearance.BorderSize = 0;
            this.cancelvisitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelvisitor.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelvisitor.ForeColor = System.Drawing.Color.Black;
            this.cancelvisitor.Location = new System.Drawing.Point(313, 395);
            this.cancelvisitor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelvisitor.Name = "cancelvisitor";
            this.cancelvisitor.Size = new System.Drawing.Size(100, 42);
            this.cancelvisitor.TabIndex = 14;
            this.cancelvisitor.Text = "Cancel";
            this.cancelvisitor.UseVisualStyleBackColor = true;
            this.cancelvisitor.Click += new System.EventHandler(this.cancelvisitor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(504, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 27);
            this.label2.TabIndex = 15;
            this.label2.Text = "Classification:";
            // 
            // cbClassification
            // 
            this.cbClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.cbClassification.FormattingEnabled = true;
            this.cbClassification.Location = new System.Drawing.Point(509, 274);
            this.cbClassification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbClassification.Name = "cbClassification";
            this.cbClassification.Size = new System.Drawing.Size(321, 28);
            this.cbClassification.TabIndex = 16;
            // 
            // addhomeowner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(929, 517);
            this.Controls.Add(this.cbClassification);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelvisitor);
            this.Controls.Add(this.saveHomeowner);
            this.Controls.Add(this.txtHOcontact);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHOaddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHOname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "addhomeowner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.addhomeowner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHOname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHOaddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHOcontact;
        private System.Windows.Forms.Button saveHomeowner;
        private System.Windows.Forms.Button cancelvisitor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClassification;
    }
}
﻿namespace RECOMANAGESYS
{
    partial class Announcement
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPostAnnouncement = new System.Windows.Forms.Button();
            this.PanelAnnouncement = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(53, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 63);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.PanelAnnouncement);
            this.panel2.Controls.Add(this.btnPostAnnouncement);
            this.panel2.Location = new System.Drawing.Point(53, 122);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1192, 764);
            this.panel2.TabIndex = 1;
            // 
            // btnPostAnnouncement
            // 
            this.btnPostAnnouncement.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPostAnnouncement.FlatAppearance.BorderSize = 0;
            this.btnPostAnnouncement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPostAnnouncement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostAnnouncement.ForeColor = System.Drawing.Color.White;
            this.btnPostAnnouncement.Location = new System.Drawing.Point(955, 45);
            this.btnPostAnnouncement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPostAnnouncement.Name = "btnPostAnnouncement";
            this.btnPostAnnouncement.Size = new System.Drawing.Size(213, 51);
            this.btnPostAnnouncement.TabIndex = 8;
            this.btnPostAnnouncement.Text = "Post Announcement";
            this.btnPostAnnouncement.UseVisualStyleBackColor = false;
            this.btnPostAnnouncement.Click += new System.EventHandler(this.button3_Click);
            // 
            // PanelAnnouncement
            // 
            this.PanelAnnouncement.Location = new System.Drawing.Point(56, 118);
            this.PanelAnnouncement.Name = "PanelAnnouncement";
            this.PanelAnnouncement.Size = new System.Drawing.Size(1081, 596);
            this.PanelAnnouncement.TabIndex = 9;
            this.PanelAnnouncement.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAnnouncement_Paint);
            // 
            // Announcement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Announcement";
            this.Size = new System.Drawing.Size(1310, 921);
            this.Load += new System.EventHandler(this.LoadAnnouncement);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPostAnnouncement;
        private System.Windows.Forms.FlowLayoutPanel PanelAnnouncement;
    }
}

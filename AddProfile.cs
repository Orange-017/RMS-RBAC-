using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RECOMANAGESYS
{
    public partial class AddProfile : Form
    {
        public event EventHandler ProfileAdded;


        public AddProfile()
        {
            InitializeComponent();
            DTPProfile.Value = DateTime.Now;
            cmbPosition.Items.AddRange(new string[] {
                "Homeowner", "Board Member", "Treasurer",
                "Secretary", "President", "Vice President"
            });
            cmbPosition.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void AddProfile_Load(object sender, EventArgs e)
        { }

        private void ProfilePic_Click(object sender, EventArgs e)
        {}

        private void button2_Click(object sender, EventArgs e)
        { }
        private void savevisitor_Click(object sender, EventArgs e)
        {}

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Full Name.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbPosition.SelectedItem == null)
            {
                MessageBox.Show("Please select a Position.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
      
            SaveProfile(txtName.Text, txtAddress.Text, txtContact.Text,
                      DTPProfile.Value, cmbPosition.SelectedItem.ToString());       
    }
        private void SaveProfile(string fullName, string address, string contact, DateTime memberSince, string position)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM TBL_Profiles WHERE FullName = @fullName AND ContactNumber = @contact";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@fullName", fullName.Trim());
                        checkCmd.Parameters.AddWithValue("@contact", string.IsNullOrWhiteSpace(contact) ? (object)DBNull.Value : contact.Trim());

                        int existingCount = (int)checkCmd.ExecuteScalar();
                        if (existingCount > 0)
                        {
                            MessageBox.Show("A profile with this name and contact number already exists!", "Duplicate Entry",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertQuery = @"INSERT INTO TBL_Profiles 
                                 (FullName, CompleteAddress, ContactNumber, MemberSince, PositionInHOA) 
                                 VALUES 
                                 (@fullName, @address, @contact, @memberSince, @position)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullName", fullName.Trim());
                        cmd.Parameters.AddWithValue("@address", string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address.Trim());
                        cmd.Parameters.AddWithValue("@contact", string.IsNullOrWhiteSpace(contact) ? (object)DBNull.Value : contact.Trim());
                        cmd.Parameters.AddWithValue("@memberSince", memberSince);
                        cmd.Parameters.AddWithValue("@position", position);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ProfileAdded?.Invoke(this, EventArgs.Empty);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelvisitor_Click(object sender, EventArgs e)
            {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Full Name.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbPosition.SelectedItem == null)
            {
                MessageBox.Show("Please select a Position.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveProfile(
                txtName.Text.Trim(),
                txtAddress.Text.Trim(),
                txtContact.Text.Trim(),
                DTPProfile.Value,
                cmbPosition.SelectedItem.ToString()
            );
        }
    }
    }


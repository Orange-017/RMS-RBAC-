using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RECOMANAGESYS
{
    public partial class addhomeowner : Form
    {
        public addhomeowner()
        {
            InitializeComponent();
            cbClassification.Items.Clear();
            cbClassification.Items.Add("Active");
            cbClassification.Items.Add("Inactive");
            cbClassification.SelectedIndex = 0;
        }

        private void cancelvisitor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savevisitor_Click(object sender, EventArgs e) //saveHomeowner na name neto
        {


            string fullName = txtHOname.Text.Trim();
            string address = txtHOaddress.Text.Trim();
            string contactNumber = txtHOcontact.Text.Trim();
            string status = cbClassification.SelectedItem?.ToString() ?? "Active"; // Default Active

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please enter the Full Name and Address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO Homeowners (FullName, Address, ContactNumber, Status)
                             VALUES (@FullName, @Address, @ContactNumber, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                        cmd.Parameters.AddWithValue("@Status", status);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Homeowner added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add homeowner.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {
            txtHOname.Clear();
            txtHOaddress.Clear();
            txtHOcontact.Clear();
            cbClassification.SelectedIndex = 0; // Or -1 to deselect
        }

        private void addhomeowner_Load(object sender, EventArgs e)
        {

        }
    }

}

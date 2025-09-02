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
    public partial class Profilefrm : UserControl
    {
        private string SelectedProfileId;
        private DataTable originalDataTable;
        private bool isEditMode = false;
        public Profilefrm()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadProfiles();


        }
        private void SetupDataGridView()
        {
            DGVProfile.AutoGenerateColumns = false;
            DGVProfile.AllowUserToAddRows = false;
            DGVProfile.AllowUserToDeleteRows = false;
            DGVProfile.ReadOnly = false;
            DGVProfile.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVProfile.MultiSelect = false;

            DGVProfile.Columns.Clear();
            DGVProfile.RowTemplate.Height = 35;
           
            DGVProfile.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Name",
                Name = "FullName",
                Width = 150,

                ReadOnly = false
            });
            DGVProfile.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CompleteAddress",
                HeaderText = "Complete Address",
                Name = "CompleteAddress",
                Width = 230,
                ReadOnly = false 
            });
            DGVProfile.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ContactNumber",
                HeaderText = "Contact Number",
                Name = "ContactNumber",
                Width = 120,
                ReadOnly = false 
            });
            DGVProfile.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MemberSince",
                HeaderText = "Member Since",
                Name = "MemberSince",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy" },
                ReadOnly = false 
            });
            DGVProfile.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PositionInHOA",
                HeaderText = "Position in HOA",
                Name = "PositionInHOA",
                Width = 120,
                ReadOnly = false 
            });
            
            DGVProfile.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProfileID",
                HeaderText = "ProfileID",
                Name = "ProfileID",
                Visible = false,
                ReadOnly = true 
            });
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Padding = new Padding(0, 5, 0, 5);


        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Refreshbtn.Click += viewProfilebtn_Click;
            AddProfiles.Click += AddProfiles_Click;
            EditProfilebtn.Click += EditProfilebtn_Click;
            searchbtn.TextChanged += searchbtn_TextChanged;
          
        }


        public void LoadProfiles()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                        ProfileID,
                        FullName,
                        ISNULL(CompleteAddress, 'Not Specified') AS CompleteAddress,
                        ISNULL(ContactNumber, 'Not Specified') AS ContactNumber,
                        MemberSince,
                        PositionInHOA
                    FROM TBL_Profiles 
                    ORDER BY FullName";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DGVProfile.ClearSelection(); 
                      

                        originalDataTable = dt.Copy(); 
                        DGVProfile.DataSource = dt;
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
                MessageBox.Show($"Error loading profiles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVProfile_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            registerform regform = new registerform();
            regform.Show();

        }

        private void EditProfilebtn_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
               
                EnableEditMode();
                EditProfilebtn.Text = "Save Changes";
                isEditMode = true;
                MessageBox.Show("Edit mode enabled. You can now modify the cells. Click 'Save Changes' when done.",
                    "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {         
                if (SaveChanges())
                {
                    DisableEditMode();
                    EditProfilebtn.Text = "Edit Profile";
                    isEditMode = false;
                    LoadProfiles(); 
                    MessageBox.Show("Changes saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool SaveChanges()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    foreach (DataGridViewRow row in DGVProfile.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string profileId = row.Cells["ProfileID"].Value?.ToString();
                        if (string.IsNullOrEmpty(profileId)) continue;

                        string updateQuery = @"UPDATE TBL_Profiles SET 
                            FullName = @FullName,
                            CompleteAddress = @CompleteAddress,
                            ContactNumber = @ContactNumber,
                            MemberSince = @MemberSince,
                            PositionInHOA = @PositionInHOA
                            WHERE ProfileID = @ProfileID";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProfileID", profileId);
                            cmd.Parameters.AddWithValue("@FullName", row.Cells["FullName"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@CompleteAddress",
                                row.Cells["CompleteAddress"].Value?.ToString() == "Not Specified" ?
                                DBNull.Value : row.Cells["CompleteAddress"].Value);
                            cmd.Parameters.AddWithValue("@ContactNumber",
                                row.Cells["ContactNumber"].Value?.ToString() == "Not Specified" ?
                                DBNull.Value : row.Cells["ContactNumber"].Value);
                            cmd.Parameters.AddWithValue("@MemberSince", row.Cells["MemberSince"].Value ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@PositionInHOA", row.Cells["PositionInHOA"].Value?.ToString() ?? "");

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error while saving: {sqlEx.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void DGVProfile_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!isEditMode) return;

            string columnName = DGVProfile.Columns[e.ColumnIndex].Name;
            string value = e.FormattedValue?.ToString();

       
            if ((columnName == "FullName") && string.IsNullOrWhiteSpace(value))
            {
                e.Cancel = true;
                MessageBox.Show("Name cannot be empty!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (columnName == "MemberSince" && !string.IsNullOrWhiteSpace(value))
            {
                if (!DateTime.TryParse(value, out _))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter a valid date format (MM/DD/YYYY)!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        { }
        
        private void viewProfilebtn_Click(object sender, EventArgs e)
        {
            LoadProfiles();
            MessageBox.Show("Profile list refreshed!", "Refresh",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DGVProfile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void DGVProfile_CellClick(Object sender, DataGridViewCellEventArgs e)
        {  
        }

        private void AddProfiles_Click(object sender, EventArgs e)
        {
            using (var addProfileForm = new AddProfile())
            {
                addProfileForm.ProfileAdded += (s, args) =>
                {
                    LoadProfiles();
                };

                var result = addProfileForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadProfiles();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { }
        
        private void EnableEditMode()
        {
            DGVProfile.ReadOnly = false;     
            DGVProfile.Columns["ProfileID"].ReadOnly = true;
        }
        private void DisableEditMode()
        {
            DGVProfile.ReadOnly = true;
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            FilterUsers(searchbtn.Text);
        }
        private void searchbtn_TextChanged(object sender, EventArgs e)
        {
            FilterUsers(searchbtn.Text);
        }

        private void FilterUsers(string searchText)
        {
            try
            {
                if (DGVProfile.DataSource is DataTable dt)
                {
                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        string filterExpression = $"FullName LIKE '%{searchText}%' OR " +
                                                $"PositionInHOA LIKE '%{searchText}%' OR " +
                                                $"ContactNumber LIKE '%{searchText}%' OR " +
                                                $"CompleteAddress LIKE '%{searchText}%'";
                        dt.DefaultView.RowFilter = filterExpression;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (DGVProfile.SelectedRows.Count == 0 || DGVProfile.SelectedRows[0].Index < 0)
            {
                MessageBox.Show("Please select a profile to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = DGVProfile.SelectedRows[0];
            string profileId = selectedRow.Cells["ProfileID"].Value?.ToString();

            if (string.IsNullOrEmpty(profileId))
            {
                MessageBox.Show("Could not find the profile ID. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show($"Are you sure you want to delete profile '{selectedRow.Cells["FullName"].Value}'?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM TBL_Profiles WHERE ProfileID = @ProfileID";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProfileID", profileId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);                          
                            LoadProfiles();
                        }
                        else
                        {
                            MessageBox.Show("Profile not found or already deleted.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Error deleting profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


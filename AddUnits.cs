using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RECOMANAGESYS
{
    public partial class AddUnits : Form
    {
        private static string connectionString =
            "Data Source=LAPTOP-FT905FTC\\SQLEXPRESS;Initial Catalog=RecordManagement;Integrated Security=True;";

        private int? prefilledHomeownerId;

        public AddUnits()
        {
            InitializeComponent();
            this.Text = "Add New Unit";
        }

        public AddUnits(int homeownerId)
        {
            InitializeComponent();
            this.prefilledHomeownerId = homeownerId;
            this.Text = "Add New Unit";

            if (HomeownerID != null)
            {
                HomeownerID.Text = homeownerId.ToString();
                HomeownerID.ReadOnly = true;
                LoadHomeownerInfo(homeownerId);
            }
        }

        private void AddUnits_Load(object sender, EventArgs e)
        {
            try
            {
                if (cmbUnitType != null)
                {
                    cmbUnitType.Items.Clear();
                    cmbUnitType.Items.AddRange(new string[] { "Town house", "Single Attach", "Single Detach", "Apartment" });
                    if (cmbUnitType.Items.Count > 0)
                        cmbUnitType.SelectedIndex = 0;
                }
                LoadApprovedByUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HomeownerID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (HomeownerID != null && int.TryParse(HomeownerID.Text, out int homeownerId))
                {
                    LoadHomeownerInfo(homeownerId);
                }
                else
                {
                    if (lblHomeownerInfo != null)
                    {
                        lblHomeownerInfo.Text = "Enter valid Homeowner ID";
                        lblHomeownerInfo.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                if (lblHomeownerInfo != null)
                {
                    lblHomeownerInfo.Text = "Error checking homeowner";
                    lblHomeownerInfo.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        private void DTPOwnership_ValueChanged(object sender, EventArgs e)
        {

        }
        private void LoadHomeownerInfo(int homeownerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT FirstName, LastName, 
                               (SELECT COUNT(*) FROM HomeownerUnits WHERE HomeownerID = @id) as CurrentUnits
                        FROM Residents WHERE HomeownerID = @id AND IsActive = 1";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", homeownerId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["FirstName"]?.ToString() ?? "";
                            string lastName = reader["LastName"]?.ToString() ?? "";
                            string ownerName = $"{firstName} {lastName}".Trim();
                            int currentUnits = Convert.ToInt32(reader["CurrentUnits"]);

                            if (lblHomeownerInfo != null)
                            {
                                lblHomeownerInfo.Text = $"Owner: {ownerName} | Current Units: {currentUnits}";
                                lblHomeownerInfo.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                        else
                        {
                            if (lblHomeownerInfo != null)
                            {
                                lblHomeownerInfo.Text = "Homeowner not found!";
                                lblHomeownerInfo.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (lblHomeownerInfo != null)
                {
                    lblHomeownerInfo.Text = $"Error loading homeowner info: {ex.Message}";
                    lblHomeownerInfo.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        public class ListItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ListItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }


        private void LoadApprovedByUsers()
        {
            try
            {
                if (cmbApprovedBy != null)
                {
                    cmbApprovedBy.Items.Clear();
                    cmbApprovedBy.Items.Add(new ListItem("-- Select Approver --", 0));

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = @"
                            SELECT u.UserID, u.Username, r.RoleName 
                            FROM Users u 
                            INNER JOIN TBL_Roles r ON u.RoleID = r.RoleID 
                            WHERE u.IsActive = 1 
                            ORDER BY r.RoleName, u.Username";

                        SqlCommand cmd = new SqlCommand(query, con);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["UserID"]);
                                string roleName = reader["RoleName"]?.ToString() ?? "No Role";
                                string username = reader["Username"]?.ToString() ?? "";
                                string displayText = $"{roleName}";

                                cmbApprovedBy.Items.Add(new ListItem(displayText, userId));
                            }
                        }
                    }

                    cmbApprovedBy.DisplayMember = "Text";
                    cmbApprovedBy.ValueMember = "Value";
                    cmbApprovedBy.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(HomeownerID.Text) || !int.TryParse(HomeownerID.Text, out int homeownerId))
            {
                MessageBox.Show("Please enter a valid Homeowner ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HomeownerID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(unitNumbertxt.Text))
            {
                MessageBox.Show("Please enter a unit number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                unitNumbertxt.Focus();
                return false;
            }

            if (cmbUnitType != null && cmbUnitType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a unit type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUnitType.Focus();
                return false;
            }

            return true;
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                int homeownerId = Convert.ToInt32(HomeownerID.Text);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {

                            string checkQuery = "SELECT COUNT(*) FROM Residents WHERE HomeownerID = @id AND IsActive = 1";
                            SqlCommand checkCmd = new SqlCommand(checkQuery, con, transaction);
                            checkCmd.Parameters.AddWithValue("@id", homeownerId);

                            int homeownerExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (homeownerExists == 0)
                            {
                                MessageBox.Show("Homeowner ID does not exist or is inactive!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }

                            string duplicateQuery = "SELECT COUNT(*) FROM TBL_Units WHERE UnitNumber = @unitNumber";
                            SqlCommand duplicateCmd = new SqlCommand(duplicateQuery, con, transaction);
                            duplicateCmd.Parameters.AddWithValue("@unitNumber", unitNumbertxt.Text.Trim());

                            int duplicateExists = Convert.ToInt32(duplicateCmd.ExecuteScalar());
                            if (duplicateExists > 0)
                            {
                                MessageBox.Show("This unit number already exists!", "Duplicate Unit",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                transaction.Rollback();
                                return;
                            }

                            string insertUnitQuery = @"INSERT INTO TBL_Units (UnitNumber, Block, Lot, UnitType)
                                               VALUES (@unitNumber, @block, @lot, @unitType);
                                               SELECT SCOPE_IDENTITY();";

                            SqlCommand insertUnitCmd = new SqlCommand(insertUnitQuery, con, transaction);
                            insertUnitCmd.Parameters.AddWithValue("@unitNumber", unitNumbertxt.Text.Trim());
                            insertUnitCmd.Parameters.AddWithValue("@block", blocktxt?.Text?.Trim() ?? (object)DBNull.Value);
                            insertUnitCmd.Parameters.AddWithValue("@lot", lottxt?.Text?.Trim() ?? (object)DBNull.Value);
                            insertUnitCmd.Parameters.AddWithValue("@unitType", cmbUnitType?.Text ?? (object)DBNull.Value);

                            int newUnitId = Convert.ToInt32(insertUnitCmd.ExecuteScalar());

                            object approvedByValue = DBNull.Value;
                            if (cmbApprovedBy != null && cmbApprovedBy.SelectedIndex > 0)
                            {
                                ListItem selectedItem = (ListItem)cmbApprovedBy.SelectedItem;
                                approvedByValue = selectedItem.Value;
                            }

                            string insertJunctionQuery = @"INSERT INTO HomeownerUnits (HomeownerID, UnitID, DateOfOwnership, ApprovedByUserID)
                                                     VALUES (@homeownerId, @unitId, @dateOfOwnership, @ApprovedByUserID)";
                            SqlCommand insertJunctionCmd = new SqlCommand(insertJunctionQuery, con, transaction);
                            insertJunctionCmd.Parameters.AddWithValue("@homeownerId", homeownerId);
                            insertJunctionCmd.Parameters.AddWithValue("@unitId", newUnitId);
                            insertJunctionCmd.Parameters.AddWithValue("@dateOfOwnership", DateTime.Now);
                            insertJunctionCmd.Parameters.AddWithValue("@ApprovedByUserID", approvedByValue);
                            insertJunctionCmd.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Unit added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception innerEx)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error saving unit: {innerEx.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving unit: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Approvedbytxt_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
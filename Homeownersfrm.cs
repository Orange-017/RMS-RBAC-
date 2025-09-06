using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace RECOMANAGESYS
{
    public partial class Homeowners : UserControl
    {
        private static string connectionString =
            "Data Source=LAPTOP-FT905FTC\\SQLEXPRESS;Initial Catalog=RecordManagement;Integrated Security=True;";

        public Homeowners()
        {
            InitializeComponent();
            LoadHomeowners();
        }

        private void Homeowners_Load(object sender, EventArgs e)
        {
            DGVResidents.CellDoubleClick += DGVResidents_CellDoubleClick;

            LoadHomeowners();
        }

        public void LoadHomeowners()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
            
                    string query = @"
                SELECT
                    r.HomeownerID,
                    ISNULL(r.FirstName, '') as FirstName,
                    ISNULL(r.MiddleName, '') as MiddleName,
                    ISNULL(r.LastName, '') as LastName,
                    ISNULL(r.HomeAddress, '') as HomeAddress,
                    ISNULL(r.ContactNumber, '') as ContactNumber,
                    ISNULL(r.EmailAddress, '') as EmailAddress,
                    ISNULL(r.EmergencyContactPerson, '') as EmergencyContactPerson,
                    ISNULL(r.EmergencyContactNumber, '') as EmergencyContactNumber,
                    ISNULL(r.ResidencyType, '') as ResidencyType,
                    ISNULL(hu.ApprovedByUserID, 0) as ApprovedByUserID,
                    ISNULL(COUNT(hu.UnitID), 0) as UnitsAcquired
                FROM Residents r
                LEFT JOIN HomeownerUnits hu ON r.HomeownerID = hu.HomeownerID
                WHERE r.IsActive = 1
                GROUP BY r.HomeownerID, r.FirstName, r.MiddleName, r.LastName,
                         r.HomeAddress, r.ContactNumber, r.EmailAddress,
                         r.EmergencyContactPerson, r.EmergencyContactNumber,
                         r.ResidencyType, hu.ApprovedByUserID
                ORDER BY r.HomeownerID"; 

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                   
                    DGVResidents.DataSource = dt;
                    SetupColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading homeowners: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadHomeownersSimple();
            }
        }
     
        private void LoadHomeownersSimple()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                
                    string query = @"
                        SELECT
                            HomeownerID,
                            FirstName,
                            LastName,
                            HomeAddress,
                            ContactNumber,
                            EmailAddress,
                            EmergencyContactPerson,
                            EmergencyContactNumber,
                            ResidencyType
                        FROM Residents
                        WHERE IsActive = 1
                        ORDER BY LastName, FirstName";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DGVResidents.DataSource = dt;
                    SetupBasicColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Critical error: {ex.Message}\n\nPlease check your database connection and table structure.",
                    "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
        private void SetupColumns()
        {
            try
            {
                if (DGVResidents.Columns.Count > 0)
                {
                   
                    if (DGVResidents.Columns["HomeownerID"] != null)
                    {
                        DGVResidents.Columns["HomeownerID"].HeaderText = "Homeowner ID";
                        DGVResidents.Columns["HomeownerID"].Width = 50;
                    }

                    if (DGVResidents.Columns["FirstName"] != null)
                    {
                        DGVResidents.Columns["FirstName"].HeaderText = "First Name";
                        DGVResidents.Columns["FirstName"].Width = 100;
                    }

                    if (DGVResidents.Columns["MiddleName"] != null)
                    {
                        DGVResidents.Columns["MiddleName"].HeaderText = "Middle Name";
                        DGVResidents.Columns["MiddleName"].Width = 100;
                    }

                    if (DGVResidents.Columns["LastName"] != null)
                    {
                        DGVResidents.Columns["LastName"].HeaderText = "Last Name";
                        DGVResidents.Columns["LastName"].Width = 100;
                    }

                    if (DGVResidents.Columns["HomeAddress"] != null)
                    {
                        DGVResidents.Columns["HomeAddress"].HeaderText = "Home Address";
                        DGVResidents.Columns["HomeAddress"].Width = 200;
                    }

                    if (DGVResidents.Columns["ContactNumber"] != null)
                    {
                        DGVResidents.Columns["ContactNumber"].HeaderText = "Contact Number";
                        DGVResidents.Columns["ContactNumber"].Width = 120;
                    }

                    if (DGVResidents.Columns["EmailAddress"] != null)
                    {
                        DGVResidents.Columns["EmailAddress"].HeaderText = "Email";
                        DGVResidents.Columns["EmailAddress"].Width = 150;
                    }

                    if (DGVResidents.Columns["EmergencyContactPerson"] != null)
                    {
                        DGVResidents.Columns["EmergencyContactPerson"].HeaderText = "Emergency Contact";
                        DGVResidents.Columns["EmergencyContactPerson"].Width = 150;
                        DGVResidents.Columns["EmergencyContactPerson"].Visible = true;
                    }

                    if (DGVResidents.Columns["EmergencyContactNumber"] != null)
                    {
                        DGVResidents.Columns["EmergencyContactNumber"].HeaderText = "Emergency Number";
                        DGVResidents.Columns["EmergencyContactNumber"].Width = 120;
                        DGVResidents.Columns["EmergencyContactNumber"].Visible = true;
                    }

                    if (DGVResidents.Columns["ResidencyType"] != null)
                    {
                        DGVResidents.Columns["ResidencyType"].HeaderText = "Residency Type";
                        DGVResidents.Columns["ResidencyType"].Width = 80;
                    }
            
                    if (DGVResidents.Columns["ApprovedByUserID"] != null)
                    {
                        DGVResidents.Columns["ApprovedByUserID"].HeaderText = "Approved By UserID";
                        DGVResidents.Columns["ApprovedByUserID"].Width = 120;
                        DGVResidents.Columns["ApprovedByUserID"].Visible = false;
                    }

                    if (DGVResidents.Columns["UnitsAcquired"] != null)
                    {
                        DGVResidents.Columns["UnitsAcquired"].HeaderText = "Units Owned";
                        DGVResidents.Columns["UnitsAcquired"].Width = 80;
                    }

               
                    DGVResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    DGVResidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DGVResidents.ReadOnly = true;
                    DGVResidents.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting up columns: {ex.Message}", "Column Setup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupBasicColumns()
        {
            try
            {
                if (DGVResidents.Columns.Count > 0)
                {
                    DGVResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DGVResidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    DGVResidents.ReadOnly = true;
                    DGVResidents.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting up basic columns: {ex.Message}", "Setup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      
        private void AddResidentsbtn_Click(object sender, EventArgs e)
        {
            try
            {
                ResidencyRegisterfrm registerForm = new ResidencyRegisterfrm();
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    LoadHomeowners(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening registration form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
        private void refreshbtn_Click(object sender, EventArgs e)
        {
            LoadHomeowners();
            MessageBox.Show("Data refreshed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

  
        private void Edit_Click(object sender, EventArgs e)
        {
            if (DGVResidents.SelectedRows.Count > 0)
            {
                try
                {
                    int homeownerId = Convert.ToInt32(DGVResidents.SelectedRows[0].Cells["HomeownerID"].Value);

                    ResidencyRegisterfrm editForm = new ResidencyRegisterfrm(homeownerId);          

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadHomeowners();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening edit form: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a homeowner to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (DGVResidents.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("WARNING: This will permanently delete this homeowner and all their associated units! This action cannot be undone.\n\nAre you sure you want to proceed?",
                    "CONFIRM PERMANENT DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int homeownerId = Convert.ToInt32(DGVResidents.SelectedRows[0].Cells["HomeownerID"].Value);
                        string homeownerName = $"{DGVResidents.SelectedRows[0].Cells["FirstName"].Value} {DGVResidents.SelectedRows[0].Cells["LastName"].Value}";

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();

                           
                            string checkQuery = "SELECT COUNT(*) FROM Residents WHERE HomeownerID = @id";
                            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                            checkCmd.Parameters.AddWithValue("@id", homeownerId);
                            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (exists == 0)
                            {
                                MessageBox.Show($"Homeowner ID {homeownerId} not found in database.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            using (SqlTransaction transaction = conn.BeginTransaction())
                            {
                                try
                                {
                                    int unitsDeleted = 0;
                                    int homeownerUnitsDeleted = 0;
                                    int residentDeleted = 0;

                                    
                                    List<int> unitIds = new List<int>();
                                    string getUnitsQuery = "SELECT UnitID FROM HomeownerUnits WHERE HomeownerID = @id";
                                    SqlCommand getUnitsCmd = new SqlCommand(getUnitsQuery, conn, transaction);
                                    getUnitsCmd.Parameters.AddWithValue("@id", homeownerId);

                                    using (SqlDataReader reader = getUnitsCmd.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            unitIds.Add(Convert.ToInt32(reader["UnitID"]));
                                        }
                                    }

                                    
                                    string deleteHomeownerUnitsQuery = "DELETE FROM HomeownerUnits WHERE HomeownerID = @id";
                                    SqlCommand deleteHomeownerUnitsCmd = new SqlCommand(deleteHomeownerUnitsQuery, conn, transaction);
                                    deleteHomeownerUnitsCmd.Parameters.AddWithValue("@id", homeownerId);
                                    homeownerUnitsDeleted = deleteHomeownerUnitsCmd.ExecuteNonQuery();

                                   
                                    if (unitIds.Count > 0)
                                    {
                                       
                                        string deleteUnitsQuery = "DELETE FROM TBL_Units WHERE UnitID IN ({0})";
                                        string unitIdParameters = string.Join(",", unitIds.Select((id, index) => $"@unitId{index}"));
                                        deleteUnitsQuery = string.Format(deleteUnitsQuery, unitIdParameters);

                                        SqlCommand deleteUnitsCmd = new SqlCommand(deleteUnitsQuery, conn, transaction);

                                      
                                        for (int i = 0; i < unitIds.Count; i++)
                                        {
                                            deleteUnitsCmd.Parameters.AddWithValue($"@unitId{i}", unitIds[i]);
                                        }

                                        unitsDeleted = deleteUnitsCmd.ExecuteNonQuery();
                                    }

                                
                                    string deleteResidentQuery = "DELETE FROM Residents WHERE HomeownerID = @id";
                                    SqlCommand deleteResidentCmd = new SqlCommand(deleteResidentQuery, conn, transaction);
                                    deleteResidentCmd.Parameters.AddWithValue("@id", homeownerId);
                                    residentDeleted = deleteResidentCmd.ExecuteNonQuery();

                                    if (residentDeleted > 0)
                                    {
                                        transaction.Commit();

                                        MessageBox.Show($"PERMANENTLY DELETED:\n- Homeowner: {homeownerName} (ID: {homeownerId})\n- {unitsDeleted} unit(s)\n- {homeownerUnitsDeleted} unit association(s)",
                                            "Deletion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        LoadHomeowners(); 
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("No records were deleted. The homeowner may not exist or was already deleted.", "Warning",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                catch (SqlException sqlEx)
                                {
                                    transaction.Rollback();

                                    if (sqlEx.Number == 547) 
                                    {
                                        MessageBox.Show($"Cannot delete homeowner due to foreign key constraints.\n\nThere may be other records in the database that reference this homeowner.\n\nError: {sqlEx.Message}",
                                            "Constraint Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show($"SQL Error during deletion: {sqlEx.Message}\nError Number: {sqlEx.Number}", "Database Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show($"Error during deletion: {ex.Message}", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error in delete process: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a homeowner to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
        private void AddUnitbtn_Click(object sender, EventArgs e)
        {
            try
            {
                AddUnits addUnitsForm = new AddUnits(); 

                if (addUnitsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadHomeowners(); 
                    MessageBox.Show("Unit added successfully! Grid refreshed.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening add units form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OfficerInfo officerInfo = new OfficerInfo();
            officerInfo.Show();
        }
        private void DGVResidents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                int homeownerId = Convert.ToInt32(DGVResidents.Rows[e.RowIndex].Cells["HomeownerID"].Value);
                ShowResidentUnits(homeownerId);
            }
        }
        private void ShowResidentUnits(int homeownerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            hu.DateOfOwnership,
                            tu.UnitNumber,
                            tu.Block,
                            tu.UnitType,
                            us.Username AS ApprovedBy                            
                        FROM HomeownerUnits hu
                        INNER JOIN TBL_Units tu ON hu.UnitID = tu.UnitID
                        LEFT JOIN Users us ON hu.ApprovedByUserID = us.UserID
                        WHERE hu.HomeownerID = @homeownerId
                        ORDER BY tu.UnitNumber;";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@homeownerId", homeownerId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    Form detailsForm = new Form();
                    detailsForm.Text = "Resident Units Information";
                    detailsForm.Width = 800;
                    detailsForm.Height = 400;

                    DataGridView dgv = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        DataSource = dt,
                        ReadOnly = true,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    };

                    detailsForm.Controls.Add(dgv);
                    detailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching units: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
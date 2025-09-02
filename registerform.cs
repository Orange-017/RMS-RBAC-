using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BCrypt.Net;

namespace RECOMANAGESYS
{
    public partial class registerform : Form
    {
        private const int MinimumPasswordLength = 8;
        private const int ContactNumberLength = 11;
        private byte[] profilePictureData;

        public event EventHandler RegistrationSuccess;

        public registerform()
        {
            InitializeComponent();
            InitializeNewControls();
        }

        private void InitializeNewControls()
        {     
            if (DTPProfile != null)
                DTPProfile.Value = DateTime.Now;
            
            if (pbProfilePic != null)
            {
                pbProfilePic.SizeMode = PictureBoxSizeMode.Zoom;
                pbProfilePic.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void registerform_Load(object sender, EventArgs e)
        {
            LoadRolesIntoComboBox();
        }

        private void LoadRolesIntoComboBox()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT RoleId, RoleName 
                        FROM TBL_Roles 
                        WHERE RoleName != 'President' 
                           OR NOT EXISTS (
                               SELECT 1 FROM Users U 
                               JOIN TBL_Roles R ON U.RoleId = R.RoleId 
                               WHERE R.RoleName = 'President' AND U.IsActive = 1
                           )  
                        ORDER BY RoleName";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbRole.DataSource = dt;
                        cmbRole.DisplayMember = "RoleName";
                        cmbRole.ValueMember = "RoleId";
                        cmbRole.SelectedIndex = -1; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (!ValidateRegistrationInputs())
                return;

            try
            {
                RegisterNewUser();
                MessageBox.Show("Registration successful! User has been added to the system.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                RegistrationSuccess?.Invoke(this, EventArgs.Empty);
                
                ClearForm();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateRegistrationInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmpass.Text) ||
                string.IsNullOrWhiteSpace(txtFname.Text) ||
                string.IsNullOrWhiteSpace(txtLname.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtContactnum.Text) ||
                cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields including role selection.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(txtUsername.Text.Trim(), @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username must contain only letters, numbers, and underscores.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username already exists. Please choose a different one.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPass.Text.Length < MinimumPasswordLength)
            {
                MessageBox.Show($"Password must be at least {MinimumPasswordLength} characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPass.Text != txtConfirmpass.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }         
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }     
            if (!Regex.IsMatch(txtContactnum.Text.Trim(), @"^\d{" + ContactNumberLength + "}$"))
            {
                MessageBox.Show($"Contact number must be exactly {ContactNumberLength} digits.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool UsernameExists(string username)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND (IsActive = 1 OR IsActive IS NULL)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void RegisterNewUser()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    INSERT INTO Users 
                    (Username, PasswordHash, Firstname, Lastname, MiddleName, RoleId, 
                     CompleteAddress, ContactNumber, EmailAddress, MemberSince, 
                     AdminAuthorizedID, ProfilePicture, IsActive) 
                    VALUES 
                    (@username, @password_hash, @firstName, @lastName, @middleName, 
                     @roleId, @address, @contactNumber, @email, @memberSince, 
                     @adminAuthorizedID, @profilePicture, @isActive)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password_hash", BCrypt.Net.BCrypt.HashPassword(txtPass.Text));
                    cmd.Parameters.AddWithValue("@firstName", txtFname.Text.Trim());
                    cmd.Parameters.AddWithValue("@lastName", txtLname.Text.Trim());
                    cmd.Parameters.AddWithValue("@middleName",
                        string.IsNullOrWhiteSpace(txtMname.Text) ? (object)DBNull.Value : txtMname.Text.Trim());

              
                    cmd.Parameters.AddWithValue("@roleId", cmbRole.SelectedValue);
                    cmd.Parameters.AddWithValue("@address",
                        string.IsNullOrWhiteSpace(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@contactNumber", txtContactnum.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

                
                    cmd.Parameters.AddWithValue("@memberSince", DTPProfile?.Value ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@adminAuthorizedID",
                        string.IsNullOrWhiteSpace(txtAdminID?.Text) ? (object)DBNull.Value : txtAdminID.Text.Trim());
                    cmd.Parameters.AddWithValue("@profilePicture", (object)profilePictureData ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@isActive", true);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void addpicbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select Profile Picture";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                       
                        FileInfo fileInfo = new FileInfo(ofd.FileName);
                        if (fileInfo.Length > 5 * 1024 * 1024)
                        {
                            MessageBox.Show("Image file size must be less than 5MB.", "File Too Large",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }                   
                        using (var originalImage = Image.FromFile(ofd.FileName))
                        {
                            var resized = ResizeImage(originalImage, 150, 150);

                            if (pbProfilePic != null)
                            {
                                pbProfilePic.Image?.Dispose(); 
                                pbProfilePic.Image = new Bitmap(resized); 
                            }

                            using (var ms = new MemoryStream())
                            {
                                resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                profilePictureData = ms.ToArray();
                            }

                            resized.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            var resized = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resized))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resized;
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txtConfirmpass.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtMname.Clear();
            txtEmail.Clear();
            txtContactnum.Clear();
            txtAddress.Clear();

            if (txtAdminID != null)
                txtAdminID.Clear();

            if (DTPProfile != null)
                DTPProfile.Value = DateTime.Now;

            if (pbProfilePic != null)
            {
                pbProfilePic.Image?.Dispose();
                pbProfilePic.Image = null;
            }

            profilePictureData = null;
            cmbRole.SelectedIndex = -1;

            txtUsername.Focus();
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all fields?", "Confirm Clear",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
                this.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e) { }
        private void DTPProfile_ValueChanged(object sender, EventArgs e) { }
    }
}
/*
 --CREATE TABLE TBL_Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);

-- CREATE PERMISSIONS TABLE
CREATE TABLE TBL_Permissions (
    PermissionId INT PRIMARY KEY IDENTITY(1,1),
    PermissionName NVARCHAR(100) NOT NULL UNIQUE
);

-- CREATE ROLE-PERMISSIONS JUNCTION TABLE
CREATE TABLE TBL_RolePermissions (
    RoleId INT NOT NULL FOREIGN KEY REFERENCES TBL_Roles(RoleId),
    PermissionId INT NOT NULL FOREIGN KEY REFERENCES TBL_Permissions(PermissionId),
    PRIMARY KEY (RoleId, PermissionId)
);

-- CREATE USERS TABLE 
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Firstname NVARCHAR(50) NOT NULL,
    Lastname NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50) NULL,
    RoleId INT NOT NULL FOREIGN KEY REFERENCES TBL_Roles(RoleId),
    CompleteAddress NVARCHAR(255) NULL,
    ContactNumber NVARCHAR(20) NULL,
    EmailAddress NVARCHAR(100) NULL
);

-- insert to TBL_Roles
INSERT INTO TBL_Roles (RoleName) VALUES
('President'),
('Vice President'),
('Secretary'),
('Treasurer'),
('Auditor'),
('PRO'),
('Member');

-- insert to  TBL_Permissions
INSERT INTO TBL_Permissions (PermissionName) VALUES
('CanRegisterAccount'),
('CanAccessProfiles'),
('CanAccessVisitorLog'),
('CanAccessMonthlyDues'),
('CanAccessScheduling'),
('CanAccessAnnouncements'),
('CanAccessDocuments'),
('CanEditMonthlyDues'),
('CanPostAnnouncements');



--for president
INSERT INTO TBL_RolePermissions (RoleId, PermissionId)
SELECT (SELECT RoleId FROM TBL_Roles WHERE RoleName = 'President'), PermissionId 
FROM TBL_Permissions;

-- Vice President 
INSERT INTO TBL_RolePermissions (RoleId, PermissionId)
SELECT (SELECT RoleId FROM TBL_Roles WHERE RoleName = 'Vice President'), PermissionId 
FROM TBL_Permissions;

-- Secretary 
INSERT INTO TBL_RolePermissions (RoleId, PermissionId)
SELECT (SELECT RoleId FROM TBL_Roles WHERE RoleName = 'Secretary'), PermissionId 
FROM TBL_Permissions;

-- Treasurer
INSERT INTO TBL_RolePermissions (RoleId, PermissionId)
SELECT (SELECT RoleId FROM TBL_Roles WHERE RoleName = 'Treasurer'), PermissionId 
FROM TBL_Permissions 
WHERE PermissionName IN (
    'CanAccessMonthlyDues',
    'CanEditMonthlyDues',
    'CanAccessScheduling',
    'CanAccessAnnouncements'
);




-- Auditor: 
INSERT INTO TBL_RolePermissions (RoleId, PermissionId)
SELECT (SELECT RoleId FROM TBL_Roles WHERE RoleName = 'Auditor'), PermissionId 
FROM TBL_Permissions 
WHERE PermissionName IN (
    'CanAccessMonthlyDues',
    'CanEditMonthlyDues',
    'CanAccessAnnouncements'
);

-- PRO: 
INSERT INTO TBL_RolePermissions (RoleId, PermissionId)
SELECT (SELECT RoleId FROM TBL_Roles WHERE RoleName = 'PRO'), PermissionId 
FROM TBL_Permissions 
WHERE PermissionName IN (
    'CanAccessVisitorLog',
    'CanAccessScheduling',
    'CanAccessAnnouncements',
    'CanPostAnnouncements'
);

--creating homeowners table
CREATE TABLE Homeowners (
	HomeownerId INT PRIMARY KEY IDENTITY(1,1),
	FullName NVARCHAR(100) NOT NULL,
	Address NVARCHAR(255) NOT NULL,
	ContactNumber NVARCHAR(20),
	Status NVARCHAR(20) NOT NULL DEFAULT 'Active' -- Active or Inactive
);

--monthly dues table
CREATE TABLE MonthlyDues (
	DueId INT PRIMARY KEY IDENTITY(1,1),
	HomeownerId INT FOREIGN KEY REFERENCES Homeowners(HomeownerId),
	PaymentDate DATE NOT NULL,
	AmountPaid DECIMAL(10,2) NOT NULL,
	DueRate DECIMAL(10,2) NOT NULL,
	MonthCovered VARCHAR(20) NOT NULL, -- ex: 'August 2025'
	Remarks NVARCHAR(255) NULL
);


-- for announcement storage
CREATE TABLE Announcements (
    Id INT PRIMARY KEY IDENTITY(1,1),    -- Auto-increment ID
    Title NVARCHAR(200) NOT NULL,        -- Title of announcement
    Message NVARCHAR(MAX) NOT NULL,      -- Body text
    DatePosted DATETIME DEFAULT GETDATE() -- Auto date when posted
);
*/

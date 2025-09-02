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
    public partial class monthdues : UserControl
    {
        public monthdues()
        {
            InitializeComponent();
            LoadHomeowners();
        }
        private void addvisitor_Click(object sender, EventArgs e) //addHomeowners to, old name nya addvisitor hindi na mabago dito mag-eerror
        {
            using (addhomeowner homeowner = new addhomeowner())
            {
                homeowner.ShowDialog();
            }
            LoadHomeowners(); // Reload grid after adding
        }

        private void button2_Click(object sender, EventArgs e) //updateHomeOwners na name neto
        {
            if (HomeOwnersShow.CurrentRow != null)
            {
                // Get the selected homeowner's ID from the grid
                int selectedHomeownerId = Convert.ToInt32(HomeOwnersShow.CurrentRow.Cells["HomeownerId"].Value);

                // Pass this ID to the UpdateMonthlyDues form constructor
                using (UpdateMonthlyDues updateMonthlyDues = new UpdateMonthlyDues(selectedHomeownerId))
                {
                    updateMonthlyDues.ShowDialog();
                }

                LoadHomeowners(); // Reload grid after update
            }
            else
            {
                MessageBox.Show("Please select a homeowner to update.");
            }
        }
        private void LoadHomeowners()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT HomeownerId, FullName, Address, ContactNumber, Status FROM Homeowners";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    HomeOwnersShow.DataSource = dt;
                }
            }
        }
    }
}

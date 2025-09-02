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
    public partial class UpdateMonthlyDues : Form
    {
        private int selectedHomeownerId;
        public UpdateMonthlyDues(int homeownerId)
        {
            InitializeComponent();
            selectedHomeownerId = homeownerId;
            LoadMonthlyDuesData();  // Load data based on homeownerId right away
        }
        private void cancelvisitor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadMonthlyDuesData()
        {
            string query = @"
        SELECT h.FullName, h.Address, h.Status, 
               md.PaymentDate, md.AmountPaid, md.DueRate, md.MonthCovered 
        FROM Homeowners h
        LEFT JOIN MonthlyDues md ON h.HomeownerId = md.HomeownerId
        WHERE h.HomeownerId = @homeownerId";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@homeownerId", selectedHomeownerId);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblNameHO.Text = reader["FullName"].ToString();
                        lblAddressHO.Text = reader["Address"].ToString();
                        lblClassificationHO.Text = reader["Status"].ToString();

                        if (reader["PaymentDate"] != DBNull.Value)
                            dtpPaymentDate.Value = Convert.ToDateTime(reader["PaymentDate"]);

                        txtAmountPaid.Text = reader["AmountPaid"] != DBNull.Value ? reader["AmountPaid"].ToString() : "0";
                        lblDueRate.Text = reader["DueRate"] != DBNull.Value ? reader["DueRate"].ToString() : "0";
                        // You can also show MonthCovered if needed
                    }
                }
            }
        }

        private void savevisitor_Click(object sender, EventArgs e)
        {
            string query = @"
        IF EXISTS (SELECT 1 FROM MonthlyDues WHERE HomeownerId = @homeownerId)
        BEGIN
            UPDATE MonthlyDues
            SET PaymentDate = @paymentDate,
                AmountPaid = @amountPaid,
                DueRate = @dueRate -- if you want to update this too
            WHERE HomeownerId = @homeownerId
        END
        ELSE
        BEGIN
            INSERT INTO MonthlyDues (HomeownerId, PaymentDate, AmountPaid, DueRate, MonthCovered)
            VALUES (@homeownerId, @paymentDate, @amountPaid, @dueRate, @monthCovered)
        END";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@homeownerId", selectedHomeownerId);
                cmd.Parameters.AddWithValue("@paymentDate", dtpPaymentDate.Value);
                cmd.Parameters.AddWithValue("@amountPaid", decimal.Parse(txtAmountPaid.Text));
                cmd.Parameters.AddWithValue("@dueRate", decimal.Parse(lblDueRate.Text)); // or some other source
                cmd.Parameters.AddWithValue("@monthCovered", "August 2025"); // You can make this dynamic if needed

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Monthly dues updated successfully!");
                else
                    MessageBox.Show("Update failed.");
            }
        }

        private void UpdateMonthlyDues_Load(object sender, EventArgs e)
        {

        }
    }
}
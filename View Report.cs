using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ACCIDENT_CRIME_REPORT_SYSTEM
{
    public partial class viewReport : Form
    {
        public viewReport()
        {
            InitializeComponent();
            LoadCases();
        }

        private void viewReport_Load(object sender, EventArgs e)
        {
            LoadCases();
        }

        private void LoadCases()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["CrimeReportDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string query = "SELECT case_id, date_time, location, officer_name, description FROM police_case";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                         
                        dataGridView1.Columns["case_id"].HeaderText = "Case ID";
                        dataGridView1.Columns["date_time"].HeaderText = "Date/Time";
                        dataGridView1.Columns["officer_name"].HeaderText = "Officer Name";
                        dataGridView1.Columns["location"].HeaderText = "Location";
                        dataGridView1.Columns["description"].HeaderText = "Description";
                         
                        dataGridView1.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtSelectID.Text = row.Cells["case_id"].Value.ToString();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCases();
        }

        private void BtnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadCases();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            homePage homePage = new homePage();
            homePage.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(txtSelectID.Text))
            {
                MessageBox.Show("Please select a case ID to delete");
                return;
            }
             
            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete this case?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.No)
                return;

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["CrimeReportDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string query = "DELETE FROM police_case WHERE case_id = @case_id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@case_id", txtSelectID.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Case deleted successfully");
                 
                LoadCases();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["CrimeReportDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string query = "SELECT case_id, date_time, location, officer_name, description FROM police_case WHERE case_id LIKE @search OR location LIKE @search";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

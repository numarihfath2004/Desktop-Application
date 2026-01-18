using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ACCIDENT_CRIME_REPORT_SYSTEM
{
    public partial class addReport : Form
    {
        public addReport()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            homePage homePage = new homePage();
            homePage.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["CrimeReportDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    string query = "Insert INTO police_case (case_id, date_time, location, officer_name, description)" + "VALUES (@CaseId, @DateTime, @Location, @OfficeName , @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CaseId", txtCaseID.Text);
                        cmd.Parameters.AddWithValue("@DateTime", dtpDate55.Text);
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                        cmd.Parameters.AddWithValue("@OfficeName", txtOfficer.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                        int row = cmd.ExecuteNonQuery();
                        if (row != 0)
                        {
                            MessageBox.Show("done !");
                        }
                        else
                        {
                            MessageBox.Show("no done !");


                        }


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addReport_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }


        }
    }
}

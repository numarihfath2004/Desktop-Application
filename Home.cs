using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ACCIDENT_CRIME_REPORT_SYSTEM
{
    public partial class homePage : Form
    {
        public homePage()
        {
            InitializeComponent();


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["CrimeReportDB"].ConnectionString;

                using(SqlConnection conn = new SqlConnection(cs)) { 
                    conn.Open();


                    MessageBox.Show("ok");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            addReport addReport = new addReport();
            addReport.Show();
            this.Hide();
        }

        private void btnViewreport_Click(object sender, EventArgs e)
        {
            viewReport viewReport = new viewReport();
            viewReport.Show();
            this.Hide();

        }

        private void homePage_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACCIDENT_CRIME_REPORT_SYSTEM
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        
        private void btn2_Click(object sender, EventArgs e)
        {
            string username = txt1.Text;
            string password = txt2.Text;



            if (username == "main admin" && password == "12345")
            {
                homePage home = new homePage();
                home.Show();
                this.Hide();

            }
            else if (username == "standard" && password == "67890")
            {
                homePage home = new homePage();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

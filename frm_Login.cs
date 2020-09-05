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

namespace Davison_Estate_Agency
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
            //Created a new database connection
            SqlConnection dataConnection = new SqlConnection();

            try
            {
                //Created a connection with DavidsonsEstates.mdf
                dataConnection.ConnectionString = "Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True";

                dataConnection.Open();

                // On success lblMsg will be updated to Connected
                lblMsg.Text += "Connected";
            }
            catch (SqlException e)
            {
                //If there is a problem this message will be displayed due to the 'catch'
                lblMsg.Text += "An error has occurred accessing the database " + e.Message;

            }
        }


        private void btn_login_Click(object sender, EventArgs e)
        {
            //Connection to the DavidsonsEstates.mdf 
            SqlConnection dataConnection = new SqlConnection();
            dataConnection.ConnectionString = "Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True";


            //Query to the DavidsonsEstates database for username and password
            string query = "SELECT * FROM tblEmployee WHERE email = '" + txtEmail.Text.Trim() + "'and password = '" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter SqlAd = new SqlDataAdapter(query, dataConnection);
            DataTable DataTable = new DataTable();
            SqlAd.Fill(DataTable);

            //If successful login details access is granted and taken to the MainMenu, Else you will be advised to check Email and Password
            if (DataTable.Rows.Count == 1)
            {

                frm_MainMenu MM = new frm_MainMenu();
                this.Hide();
                MM.Show();
            }
            else
            {
                MessageBox.Show("Check your Email and Password");
            }
        }


        private void btn_exit_Click(object sender, EventArgs e) 
        {
            //Close Login Box
            Close();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }
    }
}


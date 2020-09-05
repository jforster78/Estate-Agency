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

namespace Davison_Estate_Agency
{
    public partial class frm_EmployeeAccounts : Form
    {
        public frm_EmployeeAccounts()
        {
            InitializeComponent();
            //Created a new database connection
            SqlConnection dataConnection = new SqlConnection();

            try
            {
                //Created a connection with DavisonEstates.mdf
                dataConnection.ConnectionString = "Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True";

                dataConnection.Open();

                //On success lblMsg2 will be updated to Connected
                lblMsg.Text += "Connected";
            }
            catch (SqlException e)
            {
                //If there is a problem this message will be displayed due to the 'catch'
                lblMsg.Text += "An error has occurred accessing the database " + e.Message;

            }
        }

        //Used for searching the employees ID 
        private void button2_Click(object sender, EventArgs e)
        {
            string EmployeeIDInput = txtSearchID.Text;

            //Connection to the DavisonEstates.mdf 
            SqlConnection dataConnection = new SqlConnection();
            dataConnection.ConnectionString = "Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True";

            dataConnection.Open();

            SqlCommand dataCommand = new SqlCommand();
            dataCommand.Connection = dataConnection;

            //Query to database tblEmployees table for user details based on employee ID
            dataCommand.CommandText = "SELECT * FROM tblEmployee WHERE EmployeeID = '" + EmployeeIDInput + "'";
            SqlDataReader dataReader = dataCommand.ExecuteReader();
            dataReader.Read();

            {
                //Displays records found in relevent textboxes
                if (dataReader.HasRows)
                {
                    int EmployeeID = dataReader.GetInt32(0);
                    string Firstname = dataReader.GetString(1);
                    string Surname = dataReader.GetString(2);
                    string Email = dataReader.GetString(3);
                    int Password = dataReader.GetInt32(4);

                    txtDisplayEmployeeID.Text = Convert.ToString(EmployeeID);
                    txtDisplayFirstname.Text = Firstname;
                    txtDisplaySurname.Text = Surname;
                    txtDisplayEmail.Text = Email;
                    txtDisplayPassword.Text = Convert.ToString(Password);

                    //Displayed if record found
                    lblMsg.Text = "Record found";
                }
                else
                {
                    //Clears out textboxes
                    txtDisplayEmployeeID.Text = String.Empty;
                    txtDisplayFirstname.Text = String.Empty;
                    txtDisplaySurname.Text = String.Empty;
                    txtDisplayEmail.Text = String.Empty;
                    txtDisplayPassword.Text = String.Empty;

                    //Displayed if no record is found
                    lblMsg.Text = "Sorry no record found";
                }
            }
          }
         
        
        private void btn_update_Click(object sender, EventArgs e)
        {
            //Connection to database DavisonEstates.mdf
            SqlConnection dataConnection = new SqlConnection();
            dataConnection.ConnectionString = "Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True";

            dataConnection.Open();

            //Query to update User account using parameters
            SqlCommand dataCommand = new SqlCommand("UPDATE tblEmployee SET Firstname=@a2 , Surname=@a3 , Email=@a4 , Password=@a5 WHERE EmployeeID = @a1", dataConnection);
            dataCommand.Parameters.AddWithValue("a1", txtDisplayEmployeeID.Text);
            dataCommand.Parameters.AddWithValue("a2", txtDisplayFirstname.Text);
            dataCommand.Parameters.AddWithValue("a3", txtDisplaySurname.Text);
            dataCommand.Parameters.AddWithValue("a4", txtDisplayEmail.Text);
            dataCommand.Parameters.AddWithValue("a5", txtDisplayPassword.Text);
            dataCommand.ExecuteNonQuery();
            
            //Clears out all textboxes after success
            txtDisplayEmployeeID.Text = String.Empty;
            txtDisplayFirstname.Text = String.Empty;
            txtDisplaySurname.Text = String.Empty;
            txtDisplayEmail.Text = String.Empty;
            txtDisplayPassword.Text = String.Empty;

            //Message to say update successful
            lblMsg.Text = "User account successfully updated";
        }

        
        private void btn_delete_Click(object sender, EventArgs e)
        {
            //Connection to database DavisonEstates.mdf
            SqlConnection dataConnection = new SqlConnection();
            dataConnection.ConnectionString = "Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True";

            dataConnection.Open();

            //Query to delete user account using parameters
            SqlCommand dataCommand = new SqlCommand("DELETE FROM tblEmployee WHERE EmployeeID=@a1", dataConnection);
            dataCommand.Parameters.AddWithValue("a1", txtDisplayEmployeeID.Text);
            dataCommand.ExecuteNonQuery();

            //Clears out all textboxes after success
            txtDisplayEmployeeID.Text = String.Empty;
            txtDisplayFirstname.Text = String.Empty;
            txtDisplaySurname.Text = String.Empty;
            txtDisplayEmail.Text = String.Empty;
            txtDisplayPassword.Text = String.Empty;

            //Message to say successful
            lblMsg.Text = "User account successfully deleted";
        }

       
        private void btn_add_Click(object sender, EventArgs e)
        {
            //Connection to database DavisonEstates.mdf
            SqlConnection dataConnection = new SqlConnection();
            dataConnection.ConnectionString = "Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True";

            dataConnection.Open();

            //Query to insert a new user account using parameters
            SqlCommand dataCommand = new SqlCommand("INSERT INTO tblEmployee (EmployeeID , Firstname , Surname , Email , Password) VALUES (@a1 , @a2 , @a3 , @a4 , @a5)", dataConnection);
            dataCommand.Parameters.AddWithValue("a1", txtDisplayEmployeeID.Text);
            dataCommand.Parameters.AddWithValue("a2", txtDisplayFirstname.Text);
            dataCommand.Parameters.AddWithValue("a3", txtDisplaySurname.Text);
            dataCommand.Parameters.AddWithValue("a4", txtDisplayEmail.Text);
            dataCommand.Parameters.AddWithValue("a5", txtDisplayPassword.Text);
            dataCommand.ExecuteNonQuery();
            
            //Clears out all textboxes after success
            txtDisplayEmployeeID.Text = String.Empty;
            txtDisplayFirstname.Text = String.Empty;
            txtDisplaySurname.Text = String.Empty;
            txtDisplayEmail.Text = String.Empty;
            txtDisplayPassword.Text = String.Empty;

            //Message to say successful
            lblMsg.Text = "User account successfully added";

        }


        //Closes EmployeeAccounts form.
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

 
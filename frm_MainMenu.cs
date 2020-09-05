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
    public partial class frm_MainMenu : Form
    {

        //Calling the Office class
        Office ViewOffice;
        House ViewHouse;
        Flat ViewFlat;


        public frm_MainMenu()
        {
            InitializeComponent();


            //create a database connection
            SqlConnection dataConnection = new SqlConnection();

            try
            {
                //create that connection with DavisonEstates.mdf
                dataConnection.ConnectionString = "Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True";

                dataConnection.Open();

                //update the lblMsg.Text on the form with confirmation that you are connected to database
                lblMsg.Text += "Connected";
            }
            catch (SqlException e)
            {
                //If there is a problem with connection, display message thanks to the 'catch'
                lblMsg.Text += "An error has occurred accessing the database " + e.Message;
            }

            //Inactive until property selected in the dataViewGrid1
            button3.Enabled = false;

            //Inactive until an available property is selected through button3.
            txtAppoint.Enabled = false;
            button5.Enabled = false;
        }

        DataTable dt = new DataTable();
        int n;


        //Once clicked it will retrieve the all data from DavisonEstates.mdf, tblProperty for only available property and will place it in the dataGridView1.
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection dataConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True");

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblProperty", dataConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item[9].ToString();
                dataGridView1.Rows[n].Cells[10].Value = item[10].ToString();
                dataGridView1.Rows[n].Cells[11].Value = item[11].ToString();
                dataGridView1.Rows[n].Cells[12].Value = item[12].ToString();
                dataGridView1.Rows[n].Cells[13].Value = item[13].ToString();
            }
        }


        //Once clicked it will retrieve the data from DavisonEstates.mdf, tblProperty for only available property and will place it in the dataGridView1. 
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection dataConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True");

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblProperty WHERE Availability = 'To Let' OR Availability = 'For Sale'", dataConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item[9].ToString();
                dataGridView1.Rows[n].Cells[10].Value = item[10].ToString();
                dataGridView1.Rows[n].Cells[11].Value = item[11].ToString();
                dataGridView1.Rows[n].Cells[12].Value = item[12].ToString();
                dataGridView1.Rows[n].Cells[13].Value = item[13].ToString();
            }
        }


        //Search by reference number via the txtSearchRef textbox.
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection dataConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True");

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblProperty WHERE ReferenceNumber = '" + txtSearchRef.Text + "'", dataConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item[9].ToString();
                dataGridView1.Rows[n].Cells[10].Value = item[10].ToString();
                dataGridView1.Rows[n].Cells[11].Value = item[11].ToString();
                dataGridView1.Rows[n].Cells[12].Value = item[12].ToString();
                dataGridView1.Rows[n].Cells[13].Value = item[13].ToString();
            }
        }


        //On selection of a row or cell of data, the data is then sent to the appropriate textboxes.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                n = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[n];
                txtDisplayRef.Text = row.Cells[0].Value.ToString();
                txtDisplayAval.Text = row.Cells[1].Value.ToString();
                txtDisplayVal.Text = row.Cells[2].Value.ToString();
                txtDisplayLoc.Text = row.Cells[3].Value.ToString();
                txtDisplayNo.Text = row.Cells[4].Value.ToString();
                txtDisplayType.Text = row.Cells[5].Value.ToString();
                txtDisplaySqft.Text = row.Cells[6].Value.ToString();
                txtDisplayFlr.Text = row.Cells[7].Value.ToString();
                txtDisplayBeds.Text = row.Cells[8].Value.ToString();
                txtDisplayBaths.Text = row.Cells[9].Value.ToString();
                txtDisplayRecp.Text = row.Cells[10].Value.ToString();
                txtDisplayGar.Text = row.Cells[11].Value.ToString();
                txtDisplayGard.Text = row.Cells[12].Value.ToString();
                txtAppoint.Text = row.Cells[13].Value.ToString();
            }
            else
            {
                //message wil be show if you click on the dataGridView without first selecting search all property or search available property buttons
                MessageBox.Show("Please select SEARCH ALL PROPERTY or SEARCH AVAILABLE PROPERTY from the SEARCH MENU");
            }

            //Activates button3 once a selection is made in th dataGridView.
            button3.Enabled = true;
        }


        //SWITCH STATEMENT IS USED. ONCE BUTTON IS CLICKED IT WILL BUILD THE OBJECT USING THE CORRECT CLASS, ONLY ONCE THE CONDITION IS MET.
        private void button3_Click(object sender, EventArgs e)
        {
            switch(txtDisplayAval.Text + txtDisplayType.Text)
            {
                case "To Let" + "Office":
                case "For Sale" + "Office":

                    ViewOffice = new Office(Convert.ToInt32(txtDisplayRef.Text), txtDisplayLoc.Text, Convert.ToInt32(txtDisplayNo.Text), txtDisplayType.Text, Convert.ToInt32(txtDisplaySqft.Text), Convert.ToInt32(txtDisplayVal.Text), txtDisplayAval.Text);
                    MessageBox.Show("Thank you for confirming to view this commercial property:\r\n\r\n" + ViewOffice.ToString() + "\r\n\r\nPlease enter details in the Appointment Notes.");

                    txtAppoint.Enabled = true;
                    button5.Enabled = true;
                    button3.Enabled = false;
                    break;

                case "To Let" + "Terrace House":
                case "To Let" + "Semi-Detached House":
                case "To Let" + "Detached House":
                case "For Sale" + "Terrace House":
                case "For Sale" + "Semi-Detached House":
                case "For Sale" + "Detached House":

                    ViewHouse = new House(Convert.ToInt32(txtDisplayRef.Text), txtDisplayLoc.Text, Convert.ToInt32(txtDisplayNo.Text), txtDisplayType.Text, Convert.ToInt32(txtDisplaySqft.Text), Convert.ToInt32(txtDisplayVal.Text), txtDisplayAval.Text, Convert.ToInt32(txtDisplayBeds.Text), Convert.ToInt32(txtDisplayBaths.Text), Convert.ToInt32(txtDisplayRecp.Text), txtDisplayGar.Text, txtDisplayGard.Text);
                    MessageBox.Show("Thank you for confirming to view this residential property:\r\n\r\n" + ViewHouse.ToString() + "\r\n\r\nPlease enter details in the Appointment Notes.");

                    txtAppoint.Enabled = true;
                    button5.Enabled = true;
                    button3.Enabled = false;
                    break;

                case "To Let" + "Flat":
                case "For Sale" + "Flat":

                    ViewFlat = new Flat(Convert.ToInt32(txtDisplayRef.Text), txtDisplayLoc.Text, Convert.ToInt32(txtDisplayNo.Text), txtDisplayType.Text, Convert.ToInt32(txtDisplaySqft.Text), Convert.ToInt32(txtDisplayVal.Text), txtDisplayAval.Text, txtDisplayFlr.Text, Convert.ToInt32(txtDisplayBeds.Text), Convert.ToInt32(txtDisplayBaths.Text), Convert.ToInt32(txtDisplayRecp.Text), txtDisplayGar.Text, txtDisplayGard.Text);
                    MessageBox.Show("Thank you for confirming to view this residential property:\r\n\r\n" + ViewFlat.ToString() + "\r\n\r\nPlease enter details in the Appointment Notes.");

                    txtAppoint.Enabled = true;
                    button5.Enabled = true;
                    button3.Enabled = false;
                    break;

                default:
                    MessageBox.Show("Sorry! This property is not available for viewing");
                    return;
            }
        }


        //This will update the database DavisonEstates.mdf, tblProperty, Column = Appointment.
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection dataConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;" +
                    "AttachDbFilename=|DataDirectory|\\DavisonEstates.mdf;" +
                    "Integrated Security=True;Connect Timeout=30;User Instance=True");

            dataConnection.Open();

            string strUpdateAll = "UPDATE tblProperty SET Appointments = '" + txtAppoint.Text + "' WHERE ReferenceNumber = '" + txtDisplayRef.Text + "'";
            SqlCommand dataCommand = new SqlCommand(strUpdateAll, dataConnection);

            dataCommand.ExecuteNonQuery();

            dataConnection.Close();
            button2_Click(sender, e);


            //Once update is done this box and button will become inactive again.
            txtAppoint.Enabled = false;
            button5.Enabled = false;
        }


        //(Cancel) Clears the txtAppoint and deactivates the textbox and button.
        private void button6_Click(object sender, EventArgs e)
        {
            txtAppoint.Text = String.Empty;
            txtAppoint.Enabled = false;
            button5.Enabled = false;
        }


        //Opens EmployeeAccounts Form 
        private void button7_Click(object sender, EventArgs e)
        {
            frm_EmployeeAccounts EA = new frm_EmployeeAccounts();
            EA.ShowDialog();
        }
    }
}


/*
 
 Author Name : Joon An
 ID: 991448483
 Date : July 20, 2018
 
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {   
            // Required field validation. Whent they are invalid, it will stop.
            if (!this.RequiredFieldValidator1.IsValid || !this.RequiredFieldValidator2.IsValid)
                return;

            // SQL query by using dataSet (not connected to SQL Server)
            SqlConnection cnn;
            SqlDataAdapter dap;
            System.Data.DataSet ds;
            string queryString;

            string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=CarSalesDB;Integrated Security=SSPI;Persist Security Info=False";
            cnn = new SqlConnection(connectionString);
            queryString = "Select * from CUSTOMERS";

            try
            {
                cnn.Open();

                dap = new SqlDataAdapter(queryString, cnn);
                ds = new DataSet();

                // DataSet object that stores the query result.
                dap.Fill(ds, "Customer");

                string userName = this.TextBox1.Text;
                string password = this.TextBox2.Text;

                foreach (DataRow row in ds.Tables["Customer"].Rows)
                {
                    // ToLower and Trim methods to preven the case sensitive and white space issues
                    if(userName.ToLower().Trim() == row["user_name"].ToString())
                    {

                        if (password.Trim() == row["password"].ToString())
                        {
                            
                            // Session to store data from database and send to another page
                            Session["UserName"] = row["user_name"];
                            Session["Address"] = row["address"];
                            Session["PostalCode"] = row["postal_code"];
                            Session["Phone"] = row["phone"];
                            Session["Email"] = row["email"];

                            // When login is successful
                            Response.Redirect("Profile.aspx");

                        }
                        else
                        {
                            // When wrong is password only
                            this.Label1.Text = "You got a wrong password.";
                            return;

                        }

                    } else
                    {
                        // When user name is wrong
                        this.Label1.Text = "You got a wrong user name. Are you new customer?";

                    }
                
                }
            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);

            }
            finally
            {

                if (cnn.State == ConnectionState.Open)
                {

                    cnn.Close();

                }

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("Registration.aspx");

        }

        
    }
}
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
                dap.Fill(ds, "Customer");

                string userName = this.TextBox1.Text;
                string password = this.TextBox2.Text;

                foreach (DataRow row in ds.Tables["Customer"].Rows)
                {
                    if(userName == row["user_name"].ToString())
                    {

                        if (password == row["password"].ToString())
                        {
                            
                            Session["UserName"] = row["user_name"];
                            Session["Address"] = row["address"];
                            Session["PostalCode"] = row["postal_code"];
                            Session["Phone"] = row["phone"];
                            Session["Email"] = row["email"];

                            Response.Redirect("Profile.aspx");

                        }
                        else
                        {

                            this.Label1.Text = "You got a wrong password.";
                            return;

                        }

                    } else
                    {

                        this.Label1.Text = "You got a wrong customer name.";

                    }
                
                }
            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("Registration.aspx");

        }

        
    }
}
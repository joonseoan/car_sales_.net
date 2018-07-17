using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection cnn;
            SqlCommand command;

            string connetionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=CarSalesDB;Integrated Security=SSPI;Persist Security Info=False";
            
            cnn = new SqlConnection(connetionString);

            try
            {

                cnn.Open();

                command = new SqlCommand("INSERT INTO CUSTOMERS VALUES (@user_name, @address, @postal_code, @phone, @email, @email_confirm, @password)", cnn);

                // Assign book_name, author_name, publish_date to Insert query
                command.Parameters.AddWithValue("@user_name", this.TextBox1.Text);
                command.Parameters.AddWithValue("@address", this.TextBox2.Text);
                command.Parameters.AddWithValue("@postal_code", this.TextBox3.Text);
                command.Parameters.AddWithValue("@phone", this.TextBox4.Text);
                command.Parameters.AddWithValue("@email", this.TextBox5.Text);
                command.Parameters.AddWithValue("@email_confirm", this.TextBox6.Text);
                command.Parameters.AddWithValue("@password", this.TextBox7.Text);     

                command.ExecuteNonQuery();

                //Response.Write(r + "records added");
                cnn.Close();

                this.Label8.Text = "You are successfully registered on our database";
            }

            catch (SqlException ex)
            {

                Response.Write("Error in connection ! ");
                //this.Label8.Text = $"Error in SQL! {ex.Message}";

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
            Response.Redirect("Default.aspx");
        }
    }
}
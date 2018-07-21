/*
 
 Author Name : Joon An
 ID: 991448483
 Date : July 20, 2018
 
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Candadian Postal Code : It must be UPPER Letter and there must be a space
        string can_postal_code = "\\A[ABCEGHJKLMNPRSTVXY]\\d[A-Z] ?\\d[A-Z]\\d\\z";

        SqlConnection cnn;

        SqlDataAdapter dap;
        System.Data.DataSet ds;
        string queryString;

        string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=CarSalesDB;Integrated Security=SSPI;Persist Security Info=False";

        // Entire validation control
        Boolean isValidation = false;

        private void userNameValidation()
        {

            // Finding white space in user name
            foreach (char c in this.TextBox1.Text.Trim())
            {
                if (c == ' ')
                {

                    isValidation = false;
                    this.Label8.Text = "You have to remove space in your user name.";

                    return;

                }

            }


            foreach (DataRow row in ds.Tables["Customer"].Rows)
            {

                // finding a duplicated user name
                if (this.TextBox1.Text.Trim() == row["user_name"].ToString())
                {

                    isValidation = false;
                    this.Label8.Text = "The user name is overlapped with another user.";

                    return;

                }

            }

        }

        private void passwordValidation()
        {

            foreach (char c in this.TextBox7.Text.Trim())
            {
                // Finding a space
                if (c == ' ')
                {

                    isValidation = false;
                    this.Label8.Text = "You have to remove space in your password.";

                    return;

                }

            }

            if (this.TextBox7.Text.Trim().Length < 8)
            {

                // Password must be more than 8 characters
                isValidation = false;
                this.Label8.Text = "Your password must be more than 8 characters.";


            }

        }

        protected void postalCodeValidation()
        {

            if (!Regex.IsMatch(this.TextBox3.Text + this.TextBox8.Text, can_postal_code))
            {
                // finding an error about Canadian postal code implementing regex up and above 
                isValidation = false;
                this.Label8.Text = "You must input postal code in a correct format.";
 
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // defualt validation value
            isValidation = true;

            cnn = new SqlConnection(connectionString);
            queryString = "Select * from CUSTOMERS";

            try
            {

                cnn.Open();

                dap = new SqlDataAdapter(queryString, cnn);
                ds = new DataSet();
                dap.Fill(ds, "Customer");
                
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlCommand command;
            
            cnn = new SqlConnection(connectionString);

            this.Label8.Text = "";

            // Insert Customer info
            try
            {

                cnn.Open();

                command = new SqlCommand("INSERT INTO CUSTOMERS VALUES (@user_name, @address, @postal_code, @phone, @email, @email_confirm, @password)", cnn);
                
                // user_name validation : white space and overlapped user name
                userNameValidation();
                    
                // No way to validate as long as we use simle text input (Just Required Field Test)
                command.Parameters.AddWithValue("@address", this.TextBox2.Text);

                // postal code validation
                postalCodeValidation();

                // When telephone number is not recognizable
                if (!this.RegularExpressionValidator1.IsValid) return;
                command.Parameters.AddWithValue("@phone", this.TextBox4.Text.Trim());

                // When telephone email is not recognizable
                if (!this.RegularExpressionValidator2.IsValid) return;
                command.Parameters.AddWithValue("@email", this.TextBox5.Text.Trim());

                // When telephone email is not recognizable
                // When it has differetn email from the one above
                if (!this.RegularExpressionValidator3.IsValid) return;
                if (!this.CompareValidator1.IsValid) return;
                command.Parameters.AddWithValue("@email_confirm", this.TextBox6.Text.Trim());

                // passwordValidation : white space
                passwordValidation();

                // evaluated result of user name, password, and postal code
                if (isValidation)
                {

                    command.Parameters.AddWithValue("@user_name", this.TextBox1.Text.ToLower().Trim());
                    command.Parameters.AddWithValue("@password", this.TextBox7.Text.Trim());
                    command.Parameters.AddWithValue("@postal_code", this.TextBox3.Text + " " + this.TextBox8.Text);

                }
                else
                {
                    // stop work when it has invalid value
                    isValidation = true;
                    return;

                }
                 // space // number of letter     

                command.ExecuteNonQuery();

                //Response.Write(r + "records added");
                cnn.Close();

                this.Label11.Text = "You are successfully registered on our database. Please, go back to Login.";

                this.TextBox1.Text = "";
                this.TextBox2.Text = "";
                this.TextBox3.Text = "";
                this.TextBox4.Text = "";
                this.TextBox5.Text = "";
                this.TextBox6.Text = "";
                this.TextBox7.Text = "";
                
                

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
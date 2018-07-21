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

    public partial class Profile : System.Web.UI.Page
    {
        // Using connection for insert and inconnection for select query

        // SQL connection
        SqlConnection cnn;
        SqlCommand command;

        SqlDataAdapter dap;
        System.Data.DataSet ds = new DataSet();

        string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=CarSalesDB;Integrated Security=SSPI;Persist Security Info=False";

        // List Collection to add car brands that control the model in drop down list
        List<string> brand;

        private SqlDataAdapter queryOrders()
        {

            string queryString = "Select * From ORDERS";

            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();

                // dap object that stores query result from database
                dap = new SqlDataAdapter(queryString, cnn);
             
                cnn.Close();

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

            // return dap instances
            return dap;

        }

        private int id_management()
        {

            int set_id = 1;

            // get dap instance
            SqlDataAdapter dap = queryOrders();

            dap.Fill(ds, "CRM_ID");

            // ID which is a primary key will be updated automatically
            // To prevent ther users from generating issues like duplicated key value
            foreach (DataRow get_id in ds.Tables["CRM_ID"].Rows)
            {

                if (get_id["crmId"] != null)
                {
                   
                    if (set_id == Int32.Parse(get_id["crmId"].ToString()))
                    {
                        // if there is the existing value, it adds one to the value
                        set_id++;

                    }

                }
                else
                {
                        // If no data is available, the default value is 1
                        set_id = 1;

                }

            }
    
            return set_id;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Actaully this is for the dropdown list
            //   to prevent it from appending items withouth clear()
            //   from resetting itselft once we select an item 
            if (!IsPostBack)
            {
                // get session value from default page
                this.Label1.Text = (string)(Session["UserName"]);
                this.TableCell6.Text = (string)(Session["UserName"]);
                this.TableCell7.Text = (string)(Session["Address"]);
                this.TableCell8.Text = (string)(Session["PostalCode"]);
                this.TableCell9.Text = (string)(Session["Phone"]);
                this.TableCell10.Text = (string)(Session["Email"]);
                this.Label2.Text = (string)(Session["UserName"]);

                // car band
                this.DropDownList1.Items.Add("ACURA");
                this.DropDownList1.Items.Add("AUDI");
                this.DropDownList1.Items.Add("BENZ");
                this.DropDownList1.Items.Add("LEXUS");

                // models
                this.DropDownList2.Items.Add("NSX");
                this.DropDownList2.Items.Add("MSX");
                this.DropDownList2.Items.Add("RDX");
                
                // color
                this.DropDownList3.Items.Add("SILVER");
                this.DropDownList3.Items.Add("WHITE");
                this.DropDownList3.Items.Add("BLUE");
                this.DropDownList3.Items.Add("RED");
                this.DropDownList3.Items.Add("BLACK");

                // year
                this.DropDownList4.Items.Add("2011");
                this.DropDownList4.Items.Add("2012");
                this.DropDownList4.Items.Add("2013");
                this.DropDownList4.Items.Add("2014");
                this.DropDownList4.Items.Add("2015");
                this.DropDownList4.Items.Add("2016");
                this.DropDownList4.Items.Add("2017");
                this.DropDownList4.Items.Add("2018");

            }

                // invoke id_management and set up id value
                int id = id_management();
                string crm_id;

                if (id > 99)
                {

                    crm_id = id.ToString();

                }
                else if (id > 9 && id <= 99)
                {

                    crm_id = $"0{id.ToString()}";

                }
                else
                {

                    crm_id = $"00{id.ToString()}";
                }

                this.Label4.Text = crm_id;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            this.Label3.Text = "";
            this.Label6.Text = "";

            // When the required field is empty, it will stop
            if (!this.RequiredFieldValidator1.IsValid) return;

            cnn = new SqlConnection(connectionString);

            try
            {

                cnn.Open();

                command = new SqlCommand("INSERT INTO ORDERS VALUES (@crmId, @brand, @model, @year, @colour, @price, @user_name)", cnn);

                // insert order info
                command.Parameters.AddWithValue("@crmId", this.Label4.Text);
                command.Parameters.AddWithValue("@brand", this.DropDownList1.SelectedValue.ToString());
                command.Parameters.AddWithValue("@model", this.DropDownList2.SelectedValue.ToString());
                command.Parameters.AddWithValue("@year", this.DropDownList4.SelectedValue.ToString());
                command.Parameters.AddWithValue("@colour", this.DropDownList3.SelectedValue.ToString());
                command.Parameters.AddWithValue("@price", Convert.ToDouble(this.TextBox5.Text.Trim()));
                command.Parameters.AddWithValue("@user_name", this.Label2.Text);

                command.ExecuteNonQuery();

                cnn.Close();

                this.Label6.Text = "Your order is successfully registered on our database";

                this.TextBox5.Text = "";

            }

            catch (SqlException ex)
            {

                this.Label3.Text = $"Error in SQL! {ex.Message}";

            }
            catch (FormatException fe)
            {
                this.Label3.Text = "You have enter a digit number.";
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
            // back to login page
            Response.Redirect("Default.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            // get dap object again to implement the stored data
            SqlDataAdapter dap = queryOrders();

            dap.Fill(ds, "Customer_History");

            if (this.ListBox1.Items.Count > 0)
            {
                // To prevent appending
                this.ListBox1.Items.Clear();

            }

            foreach (DataRow row in ds.Tables["Customer_History"].Rows)
            {
                // List up customer's order history
                if(this.Label2.Text == row["user_name"].ToString())
                {
                    this.ListBox1.Items.Add(row["user_name"] + " - " + row["crmId"] +
                    " - " + row["brand"] + " - " + row["model"] + " - " + row["year"] +
                    " - " + row["colour"] + " - $" + row["price"]);
                }
                
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList2.Items.Clear();

            brand = new List<string>();

            foreach (ListItem each_brand in this.DropDownList1.Items)
            {
                    // by adding brands to List, we can minimize hard coding.
                    brand.Add(each_brand.ToString());

            }

            // when brand is ACURA     
            if (DropDownList1.SelectedValue.ToString() == brand[0])
            {

                // when brand is ACURA 
                DropDownList2.Items.Add("NSX");
                DropDownList2.Items.Add("MSX");
                DropDownList2.Items.Add("RDX");

            }

            // When brand is AUDI
            if (DropDownList1.SelectedValue.ToString() == brand[1])
            {

                 DropDownList2.Items.Add("A8");
                 DropDownList2.Items.Add("Q7");
                 DropDownList2.Items.Add("Q5");

            }

            // When brand is Benz
            if (DropDownList1.SelectedValue.ToString() == brand[2])
            {

                 DropDownList2.Items.Add("ML");
                 DropDownList2.Items.Add("GLE");
                 DropDownList2.Items.Add("GLC");

            }

            // When brand is LEXUS
            if (DropDownList1.SelectedValue.ToString() == brand[3])
            {

                 DropDownList2.Items.Add("RX350");
                 DropDownList2.Items.Add("RC300");
                 DropDownList2.Items.Add("NX300");

            }
  
        }

    }

}
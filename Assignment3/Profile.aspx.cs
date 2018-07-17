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
        SqlConnection cnn;
        SqlCommand command;

        SqlDataAdapter dap;
        System.Data.DataSet ds = new DataSet();

        string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=CarSalesDB;Integrated Security=SSPI;Persist Security Info=False";

        private SqlDataAdapter queryOrders()
        {

            string queryString = "Select * From ORDERS";

            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();

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

            return dap;

        }

        private int id_management()
        {

            int set_id = 1;

            SqlDataAdapter dap = queryOrders();

            dap.Fill(ds, "CRM_ID");

            foreach (DataRow get_id in ds.Tables["CRM_ID"].Rows)
            {

                if (get_id["crmId"] != null)
                {

                    if (set_id == Int32.Parse(get_id["crmId"].ToString()))
                    {

                         set_id++;

                    }

                }
                else
                {

                        set_id = 1;

                }

            }
    
            return set_id;

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            this.Label1.Text = (string)(Session["UserName"]);
            this.TableCell6.Text = (string)(Session["UserName"]);
            this.TableCell7.Text = (string)(Session["Address"]);
            this.TableCell8.Text = (string)(Session["PostalCode"]);
            this.TableCell9.Text = (string)(Session["Phone"]);
            this.TableCell10.Text = (string)(Session["Email"]);
            this.Label2.Text = (string)(Session["UserName"]);

            int id = id_management();
            string crm_id;

            if (id > 99)
            {

                crm_id = id.ToString();      

            } else if (id > 9 && id <= 99)
            {

                crm_id = $"0{id.ToString()}";

            } else
            {

                crm_id = $"00{id.ToString()}";
            }

            this.Label4.Text = crm_id; 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            cnn = new SqlConnection(connectionString);

            try
            {

                cnn.Open();

                command = new SqlCommand("INSERT INTO ORDERS VALUES (@crmId, @brand, @model, @year, @colour, @price, @user_name)", cnn);

                // Assign book_name, author_name, publish_date to Insert query
                command.Parameters.AddWithValue("@crmId", this.Label4.Text);
                command.Parameters.AddWithValue("@brand", this.TextBox1.Text);
                command.Parameters.AddWithValue("@model", this.TextBox2.Text);
                command.Parameters.AddWithValue("@year", this.TextBox3.Text);
                command.Parameters.AddWithValue("@colour", this.TextBox4.Text);
                command.Parameters.AddWithValue("@price", Convert.ToDouble(this.TextBox5.Text));
                command.Parameters.AddWithValue("@user_name", this.Label2.Text);
                
                //command.Parameters.AddWithValue("@email", this.Label2.Text);
                command.ExecuteNonQuery();

                //Response.Write(r + "records added");
                cnn.Close();

                this.Label3.Text = "You are successfully registered on our database";

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

        protected void Button3_Click(object sender, EventArgs e)
        {

            SqlDataAdapter dap = queryOrders();

            dap.Fill(ds, "Customer_History");

            if (this.ListBox1.Items.Count > 0)
            {
                this.ListBox1.Items.Clear();
            }

            foreach (DataRow row in ds.Tables["Customer_History"].Rows)
            {

                if(this.Label2.Text == row["user_name"].ToString())
                {
                    this.ListBox1.Items.Add(row["user_name"] + " - " + row["crmId"] +
                    " - " + row["brand"] + " - " + row["model"] + " - " + row["year"] +
                    " - " + row["colour"] + " - $" + row["price"]);
                }
                

            }
        }

    
    }
}
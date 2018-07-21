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
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Assignment3
{

    public class Global : System.Web.HttpApplication
    {
        
        // public object MessageBox { get; private set; }
        // Connection object
        SqlConnection cnn;
        // Command Object
        SqlCommand command;

        // setup connection string to SQL server
        string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=CarSalesDB;Integrated Security=SSPI;Persist Security Info=False";

        // setup creating CUSTOMERS table

        string createCustomerString = "CREATE TABLE dbo.CUSTOMERS " +
          "(user_name VARCHAR(50) PRIMARY KEY," +
          "address VARCHAR(50) NOT NULL," +
          "postal_code VARCHAR(7) NOT NULL," +
          "phone VARCHAR(14) NOT NULL," +
          "email VARCHAR(50) NOT NULL," +
          "email_confirm VARCHAR(50) NOT NULL," +
          "password VARCHAR(50) NOT NULL)";

        // setup creating ORDERS table
        
        string createOrdersString = "CREATE TABLE dbo.ORDERS " +
          "(crmId CHAR(3) PRIMARY KEY," +
          "brand VARCHAR(50) NOT NULL," +
          "model VARCHAR(50) NOT NULL," +
          "year CHAR(4) NOT NULL," +
          "colour VARCHAR(50) NOT NULL," +
          "price NUMERIC(10, 2) NOT NULL," +
          "user_name VARCHAR(50) NOT NULL," +
          "CONSTRAINT FK_CUSTOMERS_ORDERS FOREIGN KEY(user_name) REFERENCES CUSTOMERS(user_name))";
         
        protected void Application_Start(object sender, EventArgs e)
        {

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.4.1.min.js",
                DebugPath = "~/scripts/jquery-1.4.1.js",
                CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.min.js",
                CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.js"

            });

            // initializing con instance cotaining connectioon property
            cnn = new SqlConnection(connectionString);

            // Creating CUSTOMERS table
            try
            {
                // open connection
                cnn.Open();

                // trying to connect to the database and input creating CUSTOMERS table command
                command = new SqlCommand(createCustomerString, cnn);

                // executes creating BOOKS table command
                SqlDataReader reader_customers = command.ExecuteReader();

            }
            catch (SqlException ex)
            {
                // SQL Error Message
                Console.Write("Error in SQL! " + ex.Message);

            }
            finally
            {

                if (cnn.State == ConnectionState.Open)
                {

                    cnn.Close();

                }

            }

            // Creating REVIEWS table
            
            try
            {

                cnn.Open();

                command = new SqlCommand(createOrdersString, cnn);

                SqlDataReader reader_orders = command.ExecuteReader();

            }
            catch (SqlException ex)
            {

                Console.Write("Error in SQL! " + ex.Message);

            }
            finally
            {

                if (cnn.State == ConnectionState.Open)
                {

                    cnn.Close();

                }

            }

        }
        
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

    }

}
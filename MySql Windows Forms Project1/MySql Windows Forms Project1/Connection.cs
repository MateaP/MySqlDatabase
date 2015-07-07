using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MySql_Windows_Forms_Project1
{
    public static class Connection
    {

        /*
        * Purpose : makes a connection with MySql server
        * Input parameters : None
        * returns : MySqlDataAdapter
        * Date created : 06.07.2015
        * Date last changed : 06.07.2015
        * Author : Matea
        */
        public static string retrieveConnection()
        {
            string connInfo = String.Empty;
            
            try
            {
                connInfo = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            }
            catch(Exception ex)
            {
				throw new ArgumentException("Connection String connect was not found in app.config! Execution aborted");
            }
            check(connInfo);
            return connInfo;
        }

        public static MySqlDataAdapter Connect(string command)
        {
            MySqlDataAdapter adapter = null;
            string str = retrieveConnection();
            try
            {         
                adapter = new MySqlDataAdapter(command, str);
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Connection String connect was found in app.config but the connection can not be established! Execution aborted");
            }
            return adapter;
        }

        public static void check(String str)
        {
            RegexStringValidator r = new RegexStringValidator(@"^([^=;]+=[^=;]*)(;[^=;]+=[^=;]*)*;?$");
            RegexStringValidator r1 = new RegexStringValidator(@"\b(server|database|password|user id)\b");
            try
            {
                r.Validate(str);
                r1.Validate(str);
                MessageBox.Show("Validated");
            }
            catch (ArgumentException e)
            {
                // Validation failed.
                MessageBox.Show(String.Format("Error: {0}", e.Message.ToString()));
            }
        }
    }
}

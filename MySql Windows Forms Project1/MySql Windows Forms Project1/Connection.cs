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

        public static string retrieveConnection()
        {
            ConnectionStringSettings setting_constr = null;
            setting_constr = ConfigurationManager.ConnectionStrings["connect"];
            string con_str = String.Empty;
            try
            {
                con_str = setting_constr.ConnectionString; 
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("The specified connection string does not exist!");
                return String.Empty;
            }
            catch(MySqlException)
            {
                MessageBox.Show("Error in the specified connection in app.config!");
                return String.Empty;
            }

            return con_str;
        }

        public static MySqlDataAdapter Connect(string command)
        {
            //ConnectionStringSettings setting_constr = null;
            //setting_constr = ConfigurationManager.ConnectionStrings["connect1"];
            //string con_str = setting_constr.ConnectionString;

            string str = retrieveConnection();
            if(str != "")
                return new MySqlDataAdapter(command, str);
            return null;
            
        }
    }
}

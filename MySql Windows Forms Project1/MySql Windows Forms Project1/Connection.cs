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
		* Purpose :
		* Input parameters : None
		* returns : ....
		* Date created :
		* Date last changed :
		* Author :
		*/
        public static string retrieveConnection()
        {
            //string connInfo = new prazen connection string, veruvam moze od methodite da se najde
            try
            {
				connInfo = ConfigurationManager.ConnectionStrings["connect"].ConnectionString; 
            }
            catch(Exception ex)
            {
				throw new ArgumentExpection("Connection String connect was not found in app.config! Execution aborted");
            }
            return connInfo;
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

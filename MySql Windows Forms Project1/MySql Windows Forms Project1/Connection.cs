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
        
       

        public static MySqlDataAdapter Connect(string command)
        {
            ConnectionStringSettings setting_constr = null;
            setting_constr = ConfigurationManager.ConnectionStrings["connect"];
            string con_str = setting_constr.ConnectionString + Environment.NewLine;
            MySqlDataAdapter ad = new MySqlDataAdapter(command, con_str);
            
            return ad;
        }
    }
}

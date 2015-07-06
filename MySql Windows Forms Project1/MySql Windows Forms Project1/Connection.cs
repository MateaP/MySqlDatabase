using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySql_Windows_Forms_Project1
{
    public static class Connection
    {
        
       

        public static MySqlDataAdapter Connect(string command)
        {
            string strConn = "server=localhost;user id=root;password=0000;database=menagerie;";
            MySqlDataAdapter ad = new MySqlDataAdapter(command, strConn);
            
            return ad;
        }
    }
}

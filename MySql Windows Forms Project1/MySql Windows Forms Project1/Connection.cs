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
	//singleton object da bide, objektot koj ke vraka konekcija
    public class Connection
    {
        private static Connection instance;
        private static MySqlConnection conn;

        private Connection() { }

        /*
        * Purpose : makes a connection with MySql server
        * Preconditions : app.config must be present and connect connection string must exists
		* Postconditions : Exceptio 
		* Input parameters : None
        * returns : Connection string validated
        * Date created : 06.07.2015
        * Date last changed : 06.07.2015
        * Author (e-mail) : Matea matea@edusoft.com.mk
        */
        private static string getConnString() 
        {
            string connInfo = String.Empty;
            const string regex = @"((.*(server|user id|password|database)=[^=;]*;){4})";
             
            try
            {
                connInfo = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
				RegexStringValidator r = new RegexStringValidator(regex);
                r.Validate(connInfo);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("The connection string is not valid!");
            }
            catch(Exception ex)
            {
				throw new ArgumentException("Connection String connect was not found in app.config! Execution aborted");
            }
			
            return connInfo;
			
        }

        public static MySqlConnection provideConnection()
        {
            if (instance == null)
            {
                instance = new Connection();
                string str = getConnString();
                try
                {
                    conn = new MySqlConnection(str);
                }
                catch (Exception ex)
                {
                    throw ex;                  
                }
            }
            return conn;
        }


    }
}

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
    public static class Connection
    {

        /*
        * Purpose : makes a connection with MySql server
        * Preconditions : app.config must be present and connect connection string must exists
		* Postconditions : Exceptio 
		* Input parameters : None
        * returns : Connection string validated
        * Date created : 06.07.2015
        * Date last changed : 06.07.2015
        * Author (e-mail) : Matea
        */
        public static string getConnString() --private
        {
            string connInfo = String.Empty;
			//declarija so const constantata
            RegexStringValidator r = new RegexStringValidator(@"((.*(server|user id|password|database)=[^=;]*;){4})");

            try
            {
                connInfo = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
				//tuka treba da se stoi new
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
			finally
			{
				return connInfo;
			}
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


    }
}

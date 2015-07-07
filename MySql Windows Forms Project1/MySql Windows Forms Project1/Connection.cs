using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


namespace MySql_Windows_Forms_Project1
{
    public class Connection
    {
        private static Connection instance;
        private static IDbConnection conn;
        private static object syncRoot = new Object();

        private Connection() { }

        /*
        * Purpose : returns connestion string
        * Preconditions : app.config must be present and connect connection string must exists
		* Postconditions : Exception 
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

        /*
        * Purpose : makes a connection with MySql server
        * Preconditions : connection string must exists
		* Postconditions : Exception 
		* Input parameters : None
        * returns : IDbConnection 
        * Date created : 06.07.2015
        * Date last changed : 07.07.2015
        * Author (e-mail) : Matea matea@edusoft.com.mk
        */
        public static IDbConnection provideConnection()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    instance = new Connection();
                    string str = getConnString();
                    try
                    {
                        conn = new MySqlConnection();
                        conn.ConnectionString = str;
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return conn;
        }


    }
}

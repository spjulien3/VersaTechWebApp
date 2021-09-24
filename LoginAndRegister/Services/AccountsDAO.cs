using VersaTechWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace VersaTechWebApp.Services
{
    public class AccountsDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public bool AuthenticateUserAndPassword(Account account)
        {
            bool success = false;
            //return true if found
            string sqlStatement = "SELECT * FROM dbo.Accounts WHERE username=@username AND password=@password ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = account.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = account.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return success;
        }

        public bool IsAdmin(Account account)
        {
            if(account.Role == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
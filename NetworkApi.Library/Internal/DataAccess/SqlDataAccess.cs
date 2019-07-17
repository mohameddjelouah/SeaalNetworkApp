using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApi.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        //load data with parameters like id or something
          public List<T> LoadData<T, U>(string storedProcedure, U parametres,string connectionStringName)
          {
              string connectionString = GetConnectionString(connectionStringName);

              using (IDbConnection connection = new SqlConnection(connectionString))
              {
                  List<T> rows = connection.Query<T>(storedProcedure, parametres, commandType: CommandType.StoredProcedure).ToList();

                  return rows;
              }
          }

        public List<T> LoadData<T>(string storedProcedure, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName); 

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parametres, commandType: CommandType.StoredProcedure);
   
            }
        }




    }
}

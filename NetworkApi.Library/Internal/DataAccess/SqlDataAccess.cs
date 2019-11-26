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
















        public List<T> LoadMultiData<T,O, U>(string storedProcedure, Func<T,O,T> map, U parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
               var rows =   connection.Query<T,O,T>(storedProcedure, map ,parametres, commandType: CommandType.StoredProcedure).AsQueryable().ToList();
                
                return rows;
            }
        }


























        // save data in the data base
        public void SaveData<T>(string storedProcedure, T parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parametres, commandType: CommandType.StoredProcedure);
   
            }
        }


        public void DeleteData<T>(string storedProcedure, T parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parametres, commandType: CommandType.StoredProcedure);

            }
        }




    }
}

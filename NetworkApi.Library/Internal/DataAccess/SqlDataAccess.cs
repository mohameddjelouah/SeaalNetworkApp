using Dapper;
using Dapper.Mapper;
using NetworkApi.Library.Models;
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



        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = (await connection.QueryAsync<T>(storedProcedure, parametres, commandType: CommandType.StoredProcedure)).ToList();

                return rows;
            }
        }



        // we are tring to load the incident in one model
        public async Task<List<PostIncidentModel>>  LoadAllIncidents(string storedProcedure, object parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = (  await connection.QueryAsync<PostIncidentModel, SelectedDirectionModel, SiteModel, NatureModel, OriginModel, OperateurModel, PostIncidentModel>(storedProcedure,
                    
                    
                    (incident,direction,site,nature,origin,operateur) => { 
                                                                            incident.Direction = direction;
                                                                            incident.Site = site;
                                                                            incident.Nature = nature;
                                                                            incident.Origin = origin;
                                                                            incident.Operateur = operateur;
                                                                            return incident;
                                                                            }
                    
                    
                    
                    
                    
                    ,parametres, commandType: CommandType.StoredProcedure, splitOn: "Id")).ToList();






                
                return rows;
            }
        }









        public async Task<List<DirectionModel>> LoadDirections(string storedProcedure, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {


                //List<DirectionModel> rows = (await connection.QueryAsync<DirectionModel, SiteModel>(storedProcedure, commandType: CommandType.StoredProcedure)).Distinct().ToList();






                var DirectionDictionary = new Dictionary<int, DirectionModel>();
                List<DirectionModel> rows = (await connection.QueryAsync<DirectionModel, SiteModel, DirectionModel>(

                        storedProcedure,

                        (direction, Site) =>
                        {
                            DirectionModel DirectionEntry;

                            if (!DirectionDictionary.TryGetValue(direction.Id, out DirectionEntry))
                            {
                                DirectionEntry = direction;
                                DirectionEntry.Sites = new List<SiteModel>();
                                DirectionDictionary.Add(DirectionEntry.Id, DirectionEntry);
                            }

                            DirectionEntry.Sites.Add(Site);
                            return DirectionEntry;
                        },
                        splitOn: "Id"

                        , commandType: CommandType.StoredProcedure)).Distinct().ToList();

                return rows;
            }
        }



        // save data in the data base
        public async Task SaveData<T>(string storedProcedure, T parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
               await  connection.ExecuteAsync(storedProcedure, parametres, commandType: CommandType.StoredProcedure);
   
            }
        }


        public async Task DeleteData<T>(string storedProcedure, T parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
               await  connection.ExecuteAsync(storedProcedure, parametres, commandType: CommandType.StoredProcedure);

            }
        }




    }
}

using Dapper;
using Dapper.Mapper;
using NetworkApi.Library.Models;
using NetworkApi.Library.Models.DashboardModels;
using NetworkApi.Library.Models.InterventionModels;
using NetworkApi.Library.Models.ListDesSiteModels;
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
    internal class SqlDataAccess : IDisposable
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
                    
                    
                    
                    
                    
                    ,parametres, commandType: CommandType.StoredProcedure, splitOn: "Id")
                    ).ToList();






                
                return rows;
            }
        }




        public async Task<List<FullSiteModel>> LoadAllSites(string storedProcedure,  string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<FullSiteModel> fullSite = new List<FullSiteModel>();
                var SiteDetails = (await connection.QueryAsync<SiteDetail, SelectedDirectionModel, SiteModel, DhcpModel, SiteDetail>(storedProcedure,


                    (siteDetail, direction, site, dhcp) => {
                        siteDetail.Direction = direction;
                        siteDetail.Site = site;
                        siteDetail.Dhcp = dhcp;
                        
                        return siteDetail;
                    }
                    ,  commandType: CommandType.StoredProcedure, splitOn: "Id")
                    ).ToList();


                foreach (var item in SiteDetails)
                {
                    fullSite.Add(new FullSiteModel { Detail = item, 
                                                     SiteEquipements = await LoadAllSitesEquipement("spGetAllSiteEquipement", new { Id = item.Id }, "SeaalNetworkDB"),
                                                     SiteOperateurs = await LoadAllSitesOperateur("spGetAllSiteOrerateur", new { Id = item.Id }, "SeaalNetworkDB")
                                                    }
                    );

                }
               
                return fullSite;
            }
        }




        public async Task<List<SiteEquipementModel>> LoadAllSitesEquipement(string storedProcedure, object parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                var SiteEquipements = (await connection.QueryAsync<SiteEquipementModel, EquipementModel, SiteEquipementModel>(storedProcedure,


                    (siteEquipement, equipement) => {
                        siteEquipement.Equipement = equipement;
                        

                        return siteEquipement;
                    }
                    , parametres, commandType: CommandType.StoredProcedure, splitOn: "Id")
                    ).ToList();

                return SiteEquipements;
            }
        }

        public async Task<List<SiteOperateurModel>> LoadAllSitesOperateur(string storedProcedure, object parametres, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                var SiteOperateurs = (await connection.QueryAsync<SiteOperateurModel, OperateurModel, SiteOperateurModel>(storedProcedure,


                    (siteOperateur, operateur) => {
                        siteOperateur.Operateur = operateur;


                        return siteOperateur;
                    }
                    , parametres, commandType: CommandType.StoredProcedure, splitOn: "Id")
                    ).ToList();

                return SiteOperateurs;
            }
        }





        public async Task<List<InterventionModel>> LoadAllInterventions(string storedProcedure,  string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = (await connection.QueryAsync<InterventionModel, SelectedDirectionModel, SiteModel, IdentificationModel, EquipementModel, ActionModel, InterventionModel>(storedProcedure,

                    (intervention, direction, site, identification, equipement, action) => {
                        intervention.Direction = direction;
                        intervention.Site = site;
                        intervention.Identification = identification;
                        intervention.Equipement = equipement;
                        intervention.Action = action;
                        return intervention;
                    }

                    ,  commandType: CommandType.StoredProcedure, splitOn: "Id")).ToList();

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



        //-----------------------------------------Load Dashboard Data------------------------------------------------------\\
        public async Task<DashboardModel> LoadDashboard(string storedProcedure, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                DashboardModel dm = new DashboardModel();


                using (var rows = (await connection.QueryMultipleAsync(storedProcedure, commandType: CommandType.StoredProcedure)))
                {
                    
                       
                    dm.IncidentTotal = (await rows.ReadAsync<IncidentTotalModel>()).FirstOrDefault();
                    dm.IncidentThisYear = (await rows.ReadAsync<IncidentThisYearModel>()).FirstOrDefault();
                    dm.IncidentThisMonth = (await rows.ReadAsync<IncidentThisMonthModel>()).FirstOrDefault();
                    dm.IncidentLastYear = (await rows.ReadAsync<IncidentLastYearModel>()).FirstOrDefault();
                    dm.IncidentLastMonth = (await rows.ReadAsync<IncidentLastMonthModel>()).FirstOrDefault();   
                    dm.IncidentYesterday = (await rows.ReadAsync<int>()).FirstOrDefault();

                    //intervention goes here
                    dm.InterventionData = (await rows.ReadAsync<InterventionDataModel>()).FirstOrDefault();




                    dm.Sites = (await rows.ReadAsync<int>()).FirstOrDefault();

                    
                }
                return dm;


            }
        }

        //-------------------------------------------------------------------------------------------------------------------\\
        //-------------------------------------------------------------------------------------------------------------------\\


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


        //---------------------------------------------------------------------------------------------------------------------




        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool isClosed = false;
        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            isClosed = false;
        }


        public async Task<int> SaveDataInTransactionAndGetId<T>(string storedProcedure, T parametres)
        {
           
            return  await _connection.ExecuteScalarAsync<int>(storedProcedure, parametres, commandType: CommandType.StoredProcedure,transaction: _transaction);
           
        }

        public async Task SaveDataInTransaction<T>(string storedProcedure, T parametres)
        {

            await _connection.ExecuteAsync(storedProcedure, parametres, commandType: CommandType.StoredProcedure, transaction: _transaction);

        }

        public async Task<List<T>> LoadDataInTransaction<T, U>(string storedProcedure, U parametres)
        {
             List<T> rows = (await _connection.QueryAsync<T>(storedProcedure, parametres, commandType: CommandType.StoredProcedure,transaction:_transaction)).ToList();
             return rows;
        }




        public void CommitTransaction()
        {

            _transaction?.Commit();
            _connection?.Close();
            isClosed = true;
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
            isClosed = true;
        }

        public void Dispose()
        {
            if (!isClosed)
            {
                try
                {
                    CommitTransaction();
                }
                catch 
                {
                    
                    //log this  in the future
                   
                }
            }

            _transaction = null;
            _connection = null;
            
        }
    }
}

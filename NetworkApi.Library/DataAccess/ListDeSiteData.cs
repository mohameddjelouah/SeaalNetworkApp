using Dapper;
using Dapper.Contrib.Extensions;
using NetworkApi.Library.Internal.DataAccess;
using NetworkApi.Library.Models;
using NetworkApi.Library.Models.InterventionModels;
using NetworkApi.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace NetworkApi.Library.DataAccess
{
    public class ListDeSiteData
    {



        public async Task AddSite(StoreFullSiteModel site)
        {
            using (SqlDataAccess sql = new SqlDataAccess())
            {
                try
                {
                    sql.StartTransaction("SeaalNetworkDB");

                    int SiteId =  await sql.SaveDataInTransactionAndGetId("dbo.spInsertSiteDetail", site.siteDetail);
                    List<StoreSiteOperateurModel> operateurs = new List<StoreSiteOperateurModel>();
                    List<StoreSiteEquipementModel> equipements = new List<StoreSiteEquipementModel>();
                    
                    foreach (var equipement in site.SiteEquipements)
                    {
                        equipements.Add(new StoreSiteEquipementModel { Id = equipement.Id, SiteId = SiteId, EquipementId = equipement.EquipementId, EquipementHostname = equipement.EquipementHostname, EquipementIp = equipement.EquipementIp });
                        
                    }

                    foreach (var operateur in site.SiteOperateurs)
                    {
                        operateurs.Add(new StoreSiteOperateurModel { Id = operateur.Id, SiteId = SiteId, OperateurId = operateur.OperateurId });
                        
                    }
  
                    await sql.SaveDataInTransaction("dbo.spInsertSiteOperateurs", operateurs);
                    await sql.SaveDataInTransaction("dbo.spInsertSiteEquipements", equipements);
                    sql.CommitTransaction();
                }
                catch 
                {
                    sql.RollbackTransaction();
                    throw;
                }
            }
            
            
        }


        public async Task<List<FullSiteModel>> GetAllSites()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var fullsite = await sql.LoadAllSites("dbo.spGetAllSitesDetail", "SeaalNetworkDB");
            return fullsite;


        }









        public async Task<List<DirectionModel>> GetAllDirections()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Directions = await sql.LoadDirections("dbo.spGettAllDirections", "SeaalNetworkDB");
            return Directions;
        }

        public async Task<List<OperateurModel>> GetOperateur()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Operateur = await sql.LoadData<OperateurModel, dynamic>("dbo.spGetOperateur", new { }, "SeaalNetworkDB");
            return Operateur;
        }


        public async Task<List<EquipementModel>> GetEquipements()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Equipement = await sql.LoadData<EquipementModel, dynamic>("dbo.spGetEquipements", new { }, "SeaalNetworkDB");
            return Equipement;
        }

        public async Task<List<DhcpModel>> GetDhcp()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var Dhcp = await sql.LoadData<DhcpModel, dynamic>("dbo.spGetDhcp", new { }, "SeaalNetworkDB");
            return Dhcp;
        }
    }



   
}

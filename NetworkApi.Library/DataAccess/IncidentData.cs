using NetworkApi.Library.Internal.DataAccess;
using NetworkApi.Library.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;

namespace NetworkApi.Library.DataAccess
{
    public class IncidentData
    {
        public async Task<List<PostIncidentModel>>   GetAllIncidents(bool isCloture)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { isClotured = isCloture };
            List<IncidentModel> output = await sql.LoadData<IncidentModel, dynamic>("dbo.spGetAllIncidents", p, "SeaalNetworkDB");
            List<PostIncidentModel> listofIncidents = new List<PostIncidentModel>();
            foreach (IncidentModel item in output)
            {
                
                listofIncidents.Add(new PostIncidentModel()
                {
                    Id = item.Id,
                    IncidentDate = item.IncidentDate,
                    Direction = JsonConvert.DeserializeObject<SelectedDirectionModel>(item.Direction),
                    Site = JsonConvert.DeserializeObject<SiteModel>(item.Site),
                    Nature = JsonConvert.DeserializeObject<NatureModel>(item.Nature),
                    Origin = JsonConvert.DeserializeObject<OriginModel>(item.Origin),
                    Operateur = JsonConvert.DeserializeObject<OperateurModel>(item.Operateur),
                    isClotured = item.isClotured,
                    Solution = item.Solution,
                    ClotureDate = item.ClotureDate,
                    AddBy = item.AddBy

                });
                



            }
            
            
            

            return listofIncidents;
        }





        public async Task<List<DirectionModel>>  GetAllDirections()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var Directions = await sql.LoadData<DirectionModel, dynamic>("dbo.spGettAllDirections", new { }, "SeaalNetworkDB");

            foreach (var item in Directions)
            {
                var directionID = new { directionID = item.Id };
                var Sites = await sql.LoadData<SiteModel, dynamic>("dbo.spGetSitesByDirectionId", directionID, "SeaalNetworkDB");
                item.Sites = Sites;
            }

            return Directions;
        }



      

        public async Task<List<NatureModel>>  GetNature()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var Nature =await sql.LoadData<NatureModel, dynamic>("dbo.spGetNature", new { }, "SeaalNetworkDB");

           

            return Nature;
        }

        public async Task<List<OriginModel>>  GetOrigin()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var Origin = await sql.LoadData<OriginModel, dynamic>("dbo.spGetOrigin", new { }, "SeaalNetworkDB");



            return Origin;
        }

        public async Task<List<OperateurModel>>  GetOperateur()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var Operateur = await sql.LoadData<OperateurModel, dynamic>("dbo.spGetOperateur", new { }, "SeaalNetworkDB");



            return Operateur;
        }



        public async Task<PostIncidentModel>  GetIncidentById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            var item = (await  sql.LoadData<IncidentModel,dynamic>("dbo.spGetIncidentById", p, "SeaalNetworkDB")).FirstOrDefault();

            PostIncidentModel incident = new PostIncidentModel() 
           
                {

                    Id = item.Id,
                    IncidentDate = item.IncidentDate,
                    Direction = JsonConvert.DeserializeObject<SelectedDirectionModel>(item.Direction),
                    Site = JsonConvert.DeserializeObject<SiteModel>(item.Site),
                    Nature = JsonConvert.DeserializeObject<NatureModel>(item.Nature),
                    Origin = JsonConvert.DeserializeObject<OriginModel>(item.Origin),
                    Operateur = JsonConvert.DeserializeObject<OperateurModel>(item.Operateur),
                    isClotured = item.isClotured,
                    Solution = item.Solution,
                    ClotureDate = item.ClotureDate,
                    AddBy = item.AddBy

                };

            return incident;
        }

        //add incident to the database

        public async Task AddIncident(PostIncidentModel incident)
        {

            IncidentModel inci = new IncidentModel()
            {
                IncidentDate = incident.IncidentDate,
                Direction = JsonConvert.SerializeObject(incident.Direction),
                Site = JsonConvert.SerializeObject(incident.Site),
                Nature = JsonConvert.SerializeObject(incident.Nature),
                Origin = JsonConvert.SerializeObject(incident.Origin),
                Operateur = JsonConvert.SerializeObject(incident.Operateur),
                isClotured = incident.isClotured,
                Solution = incident.Solution,
                ClotureDate = incident.ClotureDate,
                AddBy = incident.AddBy,
            };
            //add the incident to the database
            SqlDataAccess sql = new SqlDataAccess();
            await sql.SaveData("dbo.spInsertIncident", inci, "SeaalNetworkDB");
        }

        public async Task DeleteIncident(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            await sql.DeleteData("dbo.spDeleteIncident", p, "SeaalNetworkDB");
        }


        public async Task EditIncident(PostIncidentModel incident)
        {
            SqlDataAccess sql = new SqlDataAccess();

            IncidentModel inci = new IncidentModel()
            {
                Id = incident.Id,
                IncidentDate = incident.IncidentDate,
                Direction = JsonConvert.SerializeObject(incident.Direction),
                Site = JsonConvert.SerializeObject(incident.Site),
                Nature = JsonConvert.SerializeObject(incident.Nature),
                Origin = JsonConvert.SerializeObject(incident.Origin),
                Operateur = JsonConvert.SerializeObject(incident.Operateur),
                isClotured = incident.isClotured,
                Solution = incident.Solution,
                ClotureDate = incident.ClotureDate,
                AddBy = incident.AddBy,
            };

            
            await sql.SaveData("dbo.spEditIncident", inci, "SeaalNetworkDB");

        }

       
    }
}

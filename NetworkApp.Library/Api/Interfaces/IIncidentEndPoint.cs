using System.Collections.Generic;
using System.Threading.Tasks;
using NetworkApp.Library.Models;

namespace NetworkApp.Library.Api.Interfaces
{
    public interface IIncidentEndPoint
    {
        Task<List<IncidentModel>> GetAllIncident();

        Task<IncidentModel> GetIncident(int id);


        Task AddIncident(IncidentModel incident);

        Task EditIncident(IncidentModel incident);

        Task DeleteIncident(int id);
    }
}
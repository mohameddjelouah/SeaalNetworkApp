using System.Collections.Generic;
using System.Threading.Tasks;
using NetworkApp.Library.Models;

namespace NetworkApp.Library.Api.Interfaces
{
    public interface IIncidentEndPoint
    {
        Task<List<IncidentModel>> GetAllIncident(bool isCloture);

        Task<IncidentModel> GetIncident(int id);


        Task AddIncident(StoreIncidentModel incident);

        Task EditIncident(StoreIncidentModel incident);

        Task DeleteIncident(int id);
    }
}
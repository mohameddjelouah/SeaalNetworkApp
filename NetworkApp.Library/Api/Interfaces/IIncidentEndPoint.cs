using System.Collections.Generic;
using System.Threading.Tasks;
using NetworkApp.Library.Models;

namespace NetworkApp.Library.Api.Interfaces
{
    public interface IIncidentEndPoint
    {
        Task<List<UIIncidentModel>> GetAllIncident();

        Task<UIIncidentModel> GetIncident(int id);


        Task AddIncident(UIIncidentModel incident);

        Task DeleteIncident(int id);
    }
}
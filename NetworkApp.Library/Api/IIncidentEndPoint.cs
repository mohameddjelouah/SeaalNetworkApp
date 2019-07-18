using System.Collections.Generic;
using System.Threading.Tasks;
using NetworkApp.Library.Models;

namespace NetworkApp.Library.Api
{
    public interface IIncidentEndPoint
    {
        Task<List<UIIncidentModel>> GetAllIncident();
        Task<UIIncidentModel> GetIncident(int id);
    }
}
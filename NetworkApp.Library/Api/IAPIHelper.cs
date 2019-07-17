using NetworkApp.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api
{
    public interface IAPIHelper
    {
        

        Task<string> authe(int id);
        Task<UIIncidentModel> GetIncident(int id);
    }
}
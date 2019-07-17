using System.Net.Http;
using System.Threading.Tasks;

namespace NetworkApp.helpers
{
    public interface IAPIHelper
    {
        

        Task<string> authe(int id);
    }
}
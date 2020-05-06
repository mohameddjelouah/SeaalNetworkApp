using NetworkApp.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api.Interfaces
{
    public interface IInterventionEndPoint
    {
        Task<List<InterventionModel>> GetAllIntervention();
        Task AddIntervention(StoreInterventionModel intervention);
    }
}

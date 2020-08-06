using NetworkApp.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api.Interfaces
{
    public interface ISiteEndPoint
    {

        Task<List<FullSiteModel>> GetAllSites();
        Task AddSite(StoreFullSiteModel site);
        Task DeleteSite(int id);
        Task EditSite(StoreFullSiteModel intervention);
    }
}

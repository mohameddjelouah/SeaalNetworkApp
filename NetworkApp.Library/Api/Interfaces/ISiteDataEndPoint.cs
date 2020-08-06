using NetworkApp.Library.Models.ListDesSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api.Interfaces
{
    public interface ISiteDataEndPoint
    {
        Task<AddSiteDataModel> GetSiteData();
    }
}

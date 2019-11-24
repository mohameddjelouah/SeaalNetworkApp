using NetworkApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.Library.Api.Interfaces
{
    public interface IIncidentDataEndPoint
    {
        Task<List<DirectionModel>> GetDirections();
    }
}

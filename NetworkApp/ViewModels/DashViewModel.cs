using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;

namespace NetworkApp.ViewModels
{
    public class DashViewModel : Screen
    {
        
        private IDashboardEndPoint _dashboardEndPoint;

        public DashViewModel(IDashboardEndPoint dashboardEndPoint)
        {
            _dashboardEndPoint = dashboardEndPoint;


            


        }



        public async void test()
        {
            DashboardModel dash = await _dashboardEndPoint.GetDashboard();
        }


        



        



    }
}

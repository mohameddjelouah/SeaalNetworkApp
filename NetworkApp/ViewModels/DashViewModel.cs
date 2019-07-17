using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NetworkApp.helpers;

namespace NetworkApp.ViewModels
{
    public class DashViewModel : Screen
    {
        private string _auth;
        private IAPIHelper _apiHelper;

        public DashViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public string Auth
        {
            get { return _auth; }
            set { _auth = value; NotifyOfPropertyChange(() => Auth); }
        }

        private string _user;


        public string User
        {
            get { return _user; }
            set { _user = value; NotifyOfPropertyChange(() => User); }
        }



        public async Task  getinfo()
        {
            //User = WindowsIdentity.GetCurrent().IsAuthenticated.ToString();
            User = await _apiHelper.authe(1);
        }



    }
}

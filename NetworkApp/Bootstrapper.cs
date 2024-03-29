﻿using Caliburn.Micro;
using NetworkApp.Library.Api;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkApp
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            _container.Instance(_container)
                .PerRequest<IIncidentEndPoint,IncidentEndPoint>()
                .PerRequest<IIncidentDataEndPoint, IncidentDataEndPoint>()
                .PerRequest<IDashboardEndPoint,DashboardEndPoint>()
                .PerRequest<IInterventionDataEndPoint,InterventionDataEndPoint>()
                .PerRequest<IInterventionEndPoint, InterventionEndPoint>()
                .PerRequest<ISiteDataEndPoint,SiteDataEndPoint>()
                .PerRequest<ISiteEndPoint,SiteEndPoint>();
            
            

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAPIHelper, APIHelper>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(ViewModelType => _container.RegisterPerRequest(ViewModelType, ViewModelType.ToString(), ViewModelType));
            
                
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}

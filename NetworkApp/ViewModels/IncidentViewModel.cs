using Caliburn.Micro;
using NetworkApp.EventModels;
using NetworkApp.Helper;
using NetworkApp.Library.Api;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using NetworkApp.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.Win32;

namespace NetworkApp.ViewModels
{
    public class IncidentViewModel : Screen
    {

        public List<IncidentModel> listofincidents { get; set; }

        private IncidentModel _SelectedIncident;

        public IncidentModel SelectedIncident
        {
            get { return _SelectedIncident; }
            set {
                _SelectedIncident = value;

                NotifyOfPropertyChange(() => SelectedIncident);
                NotifyOfPropertyChange(() => CanDelete);
                NotifyOfPropertyChange(() => CanEdit);
            }
        }


        private bool _load = false;

        public bool Load
        {
            get { return _load; }
            set
            {
                _load = value;
                NotifyOfPropertyChange(() => Load);

            }
        }

        private bool _transition = false;

        public bool Transition
        {
            get { return _transition; }
            set
            {
                _transition = value;
                NotifyOfPropertyChange(() => Transition);

            }
        }

       


        private bool _prog = true;

        public bool Prog
        {
            get { return _prog; }
            set
            {
                _prog = value;
                NotifyOfPropertyChange(() => Prog);

            }
        }
        

        private BindableCollection<IncidentModel> _dataincident = new BindableCollection<IncidentModel>();

        public BindableCollection<IncidentModel> dataincident 
        {
            get { return _dataincident; }
            set {
                _dataincident = value;
                NotifyOfPropertyChange(() => dataincident);
                
            
            }
        }

        IWindowManager _window;

        private IIncidentEndPoint _incidentEndPoint;
        private IEventAggregator _events;
        public IncidentViewModel(IIncidentEndPoint incidentEndPoint, IWindowManager window, IEventAggregator events)
        {
            _incidentEndPoint = incidentEndPoint;
            _window = window;
            _events = events;


        }

        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);

            await LoadIncidents();
            NotifyOfPropertyChange(() => CanExport);
            Prog = false;
            Load = true;

        }


        private async Task  LoadIncidents ()
        {
            
            listofincidents = (await _incidentEndPoint.GetAllIncident());
            dataincident =new BindableCollection<IncidentModel>(listofincidents);
            
            
        }

        private string _search;
        public string search
        {
            get { return _search; }
            set
            {
                _search = value.ToLower();
                
                var list = listofincidents.Where(x =>
                                                    x.IncidentDate.ToString().Contains(_search) ||
                                                    x.Direction.Direction.ToLower().Contains(_search) || 
                                                    x.AddBy.ToLower().Contains(_search) || 
                                                    x.Site.Site.ToLower().Contains(_search) ||
                                                    x.Nature.Nature.ToLower().Contains(_search) ||
                                                    x.Origin.Origin.ToLower().Contains(_search) ||
                                                   (x.Operateur !=null && x.Operateur.Operateur.ToLower().Contains(_search)) ||
                                                    x.Solution.ToLower().Contains(_search) ||
                                                    x.ClotureDate.ToString().ToLower().Contains(_search) 
                                                ).ToList();
               
              
                dataincident = new BindableCollection<IncidentModel>(list);
                NotifyOfPropertyChange(() => CanExport);
            }
        }

        public async Task Delete()
        {
            //delete incident
            var Delete = IoC.Get<DeleteIncidentViewModel>();
            Transition = true;
            var result = _window.ShowDialog(Delete, null, null);
            Transition = false;
            if (result.HasValue && result.Value)
            {
                await _incidentEndPoint.DeleteIncident(SelectedIncident.Id);
                listofincidents.Remove(SelectedIncident);
                dataincident.Remove(SelectedIncident);
            }
            NotifyOfPropertyChange(() => CanExport);
        }

        
        
        public void Edit()
        {
            var Edit = IoC.Get<EditIncidentViewModel>();
            Edit.Incident = SelectedIncident;
            Transition = true;
            var result = _window.ShowDialog(Edit, null, null);
            Transition = false;
            if (Edit.isEdit)
            {

                Replace.ReplaceItem(listofincidents, SelectedIncident, Edit.Incident);
                dataincident = new BindableCollection<IncidentModel>(listofincidents);

            }

        }
        public bool CanEdit
        {
            get
            {

                bool output = false;

                if (SelectedIncident != null)
                {
                    output = true;
                }
                return output;


            }

        }
        public bool CanDelete
        {
            get
            {

                bool output = false;

                if (SelectedIncident != null)
                {
                    output = true;
                }
                return output;


            }

        }

        public bool CanExport
        {
            get
            {

                bool output = false;

                if (dataincident.Count != 0)
                {
                    output = true;
                }
                return output;


            }

        }
        public void Export()
        {


            var workbook = new XLWorkbook();
            workbook.AddWorksheet("Incidents");
            var ws = workbook.Worksheet("Incidents");
            
            ws.ColumnWidth = 30;

            var solutionrange = ws.Range("D3:H3");

            ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Style.Alignment.WrapText = true;
            //ws.SetShowRowColHeaders();
            //ws.ShowRowColHeaders = true;
            
            int row = 1;
            foreach (var c in dataincident)
            {
                ws.Range($"G{row}:H{row}").Merge();
                //Escribrie en Excel en cada celda
                ws.Cell(row, "A").SetValue<string>(Convert.ToString(c.IncidentDate.Value.ToString("dd/MM/yyyy")));
                ws.Cell("B" + row.ToString()).Value = c.Direction.Direction;
                ws.Cell("C" + row.ToString()).Value = c.Site.Site;
                ws.Cell("D" + row.ToString()).Value = c.Nature.Nature;
                ws.Cell("E" + row.ToString()).Value = c.Origin.Origin;
                ws.Cell("F" + row.ToString()).Value = c.Operateur?.Operateur;
                ws.Cell("G" + row.ToString()).Value = c.Solution;
                ws.Cell(row, "I").SetValue<string>(Convert.ToString(c.ClotureDate.Value.ToString("dd/MM/yyyy")));
                ws.Cell("J" + row.ToString()).Value = c.AddBy;
                row++;

            }

             

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files|*.xlsx",
                Title = "Export Fichier Excel"
            };

            saveFileDialog.ShowDialog();

            if (!String.IsNullOrWhiteSpace(saveFileDialog.FileName))
                workbook.SaveAs(saveFileDialog.FileName);
           

            
        }

      


        public void AddIncident()
        {
            _events.PublishOnUIThread(new AddIncidentEvent());
        }










    }
    }


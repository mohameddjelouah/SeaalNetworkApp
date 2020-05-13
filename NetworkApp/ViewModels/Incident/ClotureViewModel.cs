using Caliburn.Micro;
using NetworkApp.EventModels;
using NetworkApp.Helper;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.Win32;

namespace NetworkApp.ViewModels
{
    public class ClotureViewModel : Screen
    {

        public List<IncidentModel> listofincidents { get; set; }

        private IncidentModel _SelectedIncident;

        public IncidentModel SelectedIncident
        {
            get { return _SelectedIncident; }
            set
            {
                _SelectedIncident = value;

                NotifyOfPropertyChange(() => SelectedIncident);
                NotifyOfPropertyChange(() => CanDelete);
                NotifyOfPropertyChange(() => CanEdit);
                NotifyOfPropertyChange(() => CanCloture);
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

        private bool _dataBaseError = false;

        public bool DataBaseError
        {
            get { return _dataBaseError; }
            set
            {
                _dataBaseError = value;
                NotifyOfPropertyChange(() => DataBaseError);

            }
        }

        private BindableCollection<IncidentModel> _dataincident = new BindableCollection<IncidentModel>();

        public BindableCollection<IncidentModel> dataincident
        {
            get { return _dataincident; }
            set
            {
                _dataincident = value;
                NotifyOfPropertyChange(() => dataincident);


            }
        }

        private IWindowManager _window;
        private IIncidentEndPoint _incidentEndPoint;
        private IEventAggregator _events;

        public ClotureViewModel(IIncidentEndPoint incidentEndPoint, IWindowManager window, IEventAggregator events)
        {
            _incidentEndPoint = incidentEndPoint;
            _window = window;
            _events = events;
        }

        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);
            
          

        retry1: try
            {
                await LoadIncidents();
                NotifyOfPropertyChange(() => CanExport);
                Prog = false;
                Load = true;
            }
            catch (Exception e)
            {
                Prog = false;
                // show a dialog with retry buton or exit the application


                //for example :
                var Error = IoC.Get<NetworkErrorViewModel>();
                Transition = true;
                var result = _window.ShowDialog(Error, null, null);
                Transition = false;
                if (result.HasValue && result.Value)
                {
                    Prog = true;
                    goto retry1;

                }
                else
                {

                    DataBaseError = true;
                    // here i have to make a panel for error connextion when i exit application
                }


            }


        }


        private async Task LoadIncidents()
        {

            listofincidents = (await _incidentEndPoint.GetAllIncident(false));
            dataincident = new BindableCollection<IncidentModel>(listofincidents);


        }

        private string _search;
        public string search
        {
            get { return _search; }
            set
            {
                _search = value.ToLower();

                var list = listofincidents.Where(x =>
                                                    x.IncidentDate.Value.ToString("d/MMMM/yyyy;dd/MMMM/yyyy;d/MM/yyyy;dd/MM/yyyy;;d/M/yyyy;dd/M/yyyy").Contains(_search) ||         
                                                    x.Direction.Direction.ToLower().Contains(_search) ||
                                                    x.AddBy.ToLower().Contains(_search) ||
                                                    x.Site.Site.ToLower().Contains(_search) ||
                                                    x.Nature.Nature.ToLower().Contains(_search) ||
                                                    x.Origin.Origin.ToLower().Contains(_search) ||
                                                   (x.Operateur != null && x.Operateur.Operateur.ToLower().Contains(_search))    
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
                try
                {
                    await _incidentEndPoint.DeleteIncident(SelectedIncident.Id);
                    var secces = IoC.Get<SeccesDialogViewModel>();
                    Transition = true;
                    _window.ShowDialog(secces, null, null);
                    Transition = false;

                    listofincidents.Remove(SelectedIncident);
                    dataincident.Remove(SelectedIncident);
                    NotifyOfPropertyChange(() => CanExport);
                }
                catch (Exception)
                {

                    var faild = IoC.Get<FaildDialogViewModel>();
                    Transition = true;
                    _window.ShowDialog(faild, null, null);
                    Transition = false;
                }
                
            }
            
        }



        public void Edit()
        {
            var Edit = IoC.Get<EditClotureViewModel>();
            
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

        public bool CanCloture
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

            ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Style.Alignment.WrapText = true;
            ws.Style.Font.FontSize = 13;

            ws.Range("A1:G1").Style.Font.SetBold().Font.FontSize = 15;


            //*****************************************************************************************************
            //*****************************************************************************************************
            
            //Escribrie en Excel en cada celda

            ws.Cell(1, "A").SetValue<string>("Date Incident");
            ws.Cell(1, "B").SetValue<string>("Direction");
            ws.Cell(1, "C").SetValue<string>("Site");
            ws.Cell(1, "D").SetValue<string>("Nature");
            ws.Cell(1, "E").SetValue<string>("Origin");
            ws.Cell(1, "F").SetValue<string>("Operateur");
            ws.Cell(1, "G").SetValue<string>("Ajouter Par");

            //*****************************************************************************************************
            //*****************************************************************************************************

            int row = 2;
            foreach (var c in dataincident)
            {
                
                
                ws.Cell(row, "A").SetValue<string>(Convert.ToString(c.IncidentDate.Value.ToString("dd/MM/yyyy")));
                ws.Cell(row, "B").SetValue<string>(c.Direction.Direction);
                ws.Cell(row, "C").SetValue<string>(c.Site.Site);
                ws.Cell(row, "D").SetValue<string>(c.Nature.Nature);
                ws.Cell(row, "E").SetValue<string>(c.Origin.Origin);
                ws.Cell(row, "F").SetValue<string>(c.Operateur?.Operateur);
                ws.Cell(row, "G").SetValue<string>(c.AddBy);



               
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


        public void Cloture()
        {
            var Cloture = IoC.Get<IncidentClotureViewModel>();

            Cloture.Incident = SelectedIncident;
            Transition = true;
            var result = _window.ShowDialog(Cloture, null, null);
            Transition = false;
            if (Cloture.isCloture)
            {

                
                listofincidents.Remove(SelectedIncident);
                dataincident.Remove(SelectedIncident);
                NotifyOfPropertyChange(() => CanExport);

            }
        }

        public void AddIncident()
        {
            _events.PublishOnUIThread(new AddIncidentEvent());
        }
    }
}

using Caliburn.Micro;
using ClosedXML.Excel;
using Microsoft.Win32;
using NetworkApp.EventModels;
using NetworkApp.Helper;
using NetworkApp.Library.Api.Interfaces;
using NetworkApp.Library.Models.InterventionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp.ViewModels
{
    public class InterventionViewModel : Screen
    {



        public List<InterventionModel> listofintervention { get; set; }

        private InterventionModel _SelectedIntervention;

        public InterventionModel SelectedIntervention
        {
            get { return _SelectedIntervention; }
            set
            {
                _SelectedIntervention = value;

                NotifyOfPropertyChange(() => SelectedIntervention);
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


        private BindableCollection<InterventionModel> _dataintervention = new BindableCollection<InterventionModel>();

        public BindableCollection<InterventionModel> dataintervention
        {
            get { return _dataintervention; }
            set
            {
                _dataintervention = value;
                NotifyOfPropertyChange(() => dataintervention);


            }
        }





        private IInterventionEndPoint _interventionEndPoint;
        private IWindowManager _window;
        private IEventAggregator _events;
        public InterventionViewModel(IInterventionEndPoint interventionEndPoint, IWindowManager window, IEventAggregator events)
        {
            _interventionEndPoint = interventionEndPoint;
            _window = window;
            _events = events;
        }


        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);

        retry1: try
            {
                await LoadIntervention();
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

        private async Task LoadIntervention()
        {

            listofintervention = (await _interventionEndPoint.GetAllIntervention());
            dataintervention = new BindableCollection<InterventionModel>(listofintervention);


        }



        private string _search;
        public string search
        {
            get { return _search; }
            set
            {
                _search = value.ToLower();

                var list = listofintervention.Where(x =>
                                                    x.InterventionDate.Value.ToString("d/MMMM/yyyy;dd/MMMM/yyyy;d/MM/yyyy;dd/MM/yyyy;;d/M/yyyy;dd/M/yyyy").Contains(_search) ||
                                                    x.Direction.Direction.ToLower().Contains(_search) ||  
                                                    x.Site.Site.ToLower().Contains(_search) ||
                                                    x.Identification.Identification.ToLower().Contains(_search) ||
                                                    x.Equipement.Equipement.ToLower().Contains(_search) ||
                                                    x.Action.Action.ToLower().Contains(_search) ||                       
                                                    x.Rapport.ToLower().Contains(_search)   ||
                                                    x.AddBy.ToLower().Contains(_search) 
                                                ).ToList();


                dataintervention = new BindableCollection<InterventionModel>(list);
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
                    await _interventionEndPoint.DeleteIntervention(SelectedIntervention.Id);

                    var secces = IoC.Get<SeccesDialogViewModel>();
                    Transition = true;
                    _window.ShowDialog(secces, null, null);
                    Transition = false;

                    listofintervention.Remove(SelectedIntervention);
                    dataintervention.Remove(SelectedIntervention);
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
            var Edit = IoC.Get<EditInterventionViewModel>();
            Edit.Intervention = SelectedIntervention;
            Transition = true;
            var result = _window.ShowDialog(Edit, null, null);
            Transition = false;
            if (Edit.isEdit)
            {

                Replace.ReplaceItem(listofintervention, SelectedIntervention, Edit.Intervention);
                dataintervention = new BindableCollection<InterventionModel>(listofintervention);

            }

        }







        public bool CanEdit
        {
            get
            {

                bool output = false;

                if (SelectedIntervention != null)
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

                if (SelectedIntervention != null)
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

                if (dataintervention.Count != 0)
                {
                    output = true;
                }
                return output;


            }

        }




        public void Export()
        {


            var workbook = new XLWorkbook();
            workbook.AddWorksheet("Interventions");
            var ws = workbook.Worksheet("Interventions");

            ws.ColumnWidth = 30;

            var solutionrange = ws.Range("D3:H3");

            ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Style.Alignment.WrapText = true;
            ws.Style.Font.FontSize = 13;

            ws.Range("A1:J1").Style.Font.SetBold().Font.FontSize = 15;


            //*****************************************************************************************************
            //*****************************************************************************************************
            ws.Range("G1:H1").Merge();
            //Escribrie en Excel en cada celda

            ws.Cell(1, "A").SetValue<string>("Date Intervention");
            ws.Cell(1, "B").SetValue<string>("Direction");
            ws.Cell(1, "C").SetValue<string>("Site");
            ws.Cell(1, "D").SetValue<string>("Identification");
            ws.Cell(1, "E").SetValue<string>("Equipement");
            ws.Cell(1, "F").SetValue<string>("Action");
            ws.Cell(1, "G").SetValue<string>("Rapport");
            ws.Cell(1, "I").SetValue<string>("Ajouter Par");

            //*****************************************************************************************************
            //*****************************************************************************************************

            int row = 2;
            foreach (var c in dataintervention)
            {
                ws.Range($"G{row}:H{row}").Merge();
                ws.Cell(row, "A").SetValue<string>(Convert.ToString(c.InterventionDate.Value.ToString("dd/MM/yyyy")));
                ws.Cell(row, "B").SetValue<string>(c.Direction.Direction);
                ws.Cell(row, "C").SetValue<string>(c.Site.Site);
                ws.Cell(row, "D").SetValue<string>(c.Identification.Identification);
                ws.Cell(row, "E").SetValue<string>(c.Equipement.Equipement);
                ws.Cell(row, "F").SetValue<string>(c.Action.Action);
                ws.Cell(row, "G").SetValue<string>(c.Rapport);
                ws.Cell(row, "I").SetValue<string>(c.AddBy);

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

        public void AddIntervention()
        {
            _events.PublishOnUIThread(new AddInterventionEvent());
        }


    }
}

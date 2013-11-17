
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Wpf_Morbius.ServicePatient;
using Wpf_Morbius.Services;
using Observation = Wpf_Morbius.ServiceObservation.Observation;

namespace Wpf_Morbius.ViewModel
{
    class AddObservationViewModel : BaseViewModel
    {
        private PatientObsViewModel _patientObsViewModel;

        private int _patientId;
        private Observation _observation;
        private List<string> _selectedPaths;
        private IOService _ioService;
        private bool _closeSignal;

        // Messages
        private string _error;

        public string Comment
        {
            get { return _observation.Comment; }
            set
            {
                if (_observation.Comment != value)
                {
                    _observation.Comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }

        public string Prescription
        {
            get { return (_observation != null && _observation.Prescription != null) ? String.Join("\r\n", _observation.Prescription) : null; }
            set
            {
                _observation.Prescription = value.Split('\n').Select(p => p.TrimEnd('\r')).Where(p => !p.Equals("")).ToArray();
                OnPropertyChanged("Prescription");
            }
        }

        public string SelectedPathsText
        {
            get { return (_selectedPaths != null) ? String.Join(", ", _selectedPaths.Select(Path.GetFileName)) : null; }
        }

        public int Weight
        {
            get { return _observation.Weight; }
            set
            {
                if (_observation.Weight != value)
                {
                    _observation.Weight = value;
                    OnPropertyChanged("Weight");
                }
            }
        }

        public int BloodPressure
        {
            get { return _observation.BloodPressure; }
            set
            {
                if (_observation.BloodPressure != value)
                {
                    _observation.BloodPressure = value;
                    OnPropertyChanged("BloodPressure");
                }
            }
        }

        /// <summary>
        /// erreur lors de l'ajout d'une observation
        /// </summary>
        public string Error
        {
            get { return _error; }
            set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged("Error");
                }
            }
        }

        /// <summary>
        /// indique si on doit fermer la fenêtre ou non
        /// </summary>
        public bool CloseSignal
        {
            get { return _closeSignal; }
            set
            {
                if (_closeSignal != value)
                {
                    _closeSignal = value;
                    OnPropertyChanged("CloseSignal");
                }
            }
        }

        /// <summary>
        /// commande pour ajouter une observation au patient
        /// </summary>
        public ICommand AddObservationCommand { get; set; }

        /// <summary>
        /// commande pour ouvrir un fichier
        /// </summary>
        public ICommand OpenCommand { get; set; }

        public AddObservationViewModel(PatientObsViewModel viewModel, int patientId)
        {
            _patientObsViewModel = viewModel;
            _patientId = patientId;
            _observation = new Observation();
            _ioService = new IOService();
            _selectedPaths = new List<string>();

            Error = "";

            // Commands
            AddObservationCommand = new RelayCommand(param => AddObservation(), param => true);
            OpenCommand = new RelayCommand(param => OpenFileDialog(), param => true);
        }

        public void AddObservation()
        {
            try
            {
                Error = "";

                // We check that all fields are filled
                CheckFields();

                if (_selectedPaths.Count > 0)
                    _observation.Pictures = _ioService.OpenFiles(_selectedPaths);

                _observation.Date = DateTime.Now;

                _patientObsViewModel.AddObservation(_observation);

                // We close the window
                CloseSignal = true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private void CheckFields()
        {
            // Comment
            if (String.IsNullOrEmpty(Comment))
            {
                throw new Exception("Vous n'avez pas entré de commentaire !");
            }

            // Prescription
            if (String.IsNullOrEmpty(Prescription))
            {
                throw new Exception("Vous n'avez pas entré de prescription !");
            }

            // Photos
            if (_selectedPaths.Count == 0)
            {
                // Photo obligatoire ?
                throw new Exception("Vous n'avez pas sélectionné de photo !");
            }

            // Weight
            if (Weight == 0)
            {
                throw new Exception("Vous n'avez pas entré de poids !");
            }

            // Blood pressure
            if (BloodPressure == 0)
            {
                throw new Exception("Vous n'avez pas entré de pression !");
            }
        }

        private void ResetFields()
        {
            _selectedPaths.Clear();

            Weight = 0;
            BloodPressure = 0;
            Comment = null;
            Prescription = null;

            _observation = new Observation();
        }

        private void OpenFileDialog()
        {
            List<string> savedSelectedPath = _selectedPaths;
            string defaultPath = @"C:\";

            if (_selectedPaths.Count > 0)
                defaultPath = _selectedPaths.Last();

            _selectedPaths = _ioService.OpenMultipleFileDialog(defaultPath) ?? savedSelectedPath;

            OnPropertyChanged("SelectedPathsText");
        }
    }
}
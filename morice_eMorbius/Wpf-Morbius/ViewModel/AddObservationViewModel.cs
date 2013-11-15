
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
        private int _patientId;
        private Observation _observation;
        private List<string> _selectedPaths;
        private IOService _ioService;
        private bool _closeSignal;

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
            get { return (_selectedPaths != null) ? String.Join("\r\n", _selectedPaths.Select(Path.GetFileName)) : null; }
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

        public AddObservationViewModel(int patientId)
        {
            _patientId = patientId;
            _observation = new Observation();
            _ioService = new IOService();
            _selectedPaths = new List<string>();

            // Commands
            AddObservationCommand = new RelayCommand(param => AddObservation(), param => true);
            OpenCommand = new RelayCommand(param => OpenFileDialog(), param => true);
        }

        public void AddObservation()
        {
            try
            {
                CheckFields();

                _observation.Pictures = _ioService.OpenFiles(_selectedPaths);

                var soc = new ServiceObservation.ServiceObservationClient();
                soc.AddObservation(_patientId, _observation);

                ResetFields();
                
                // We close the window
                CloseSignal = true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void CheckFields()
        {
            // Comment
            if (Comment == null || Comment.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de commentaire !");
            }

            // Prescription
            if (Prescription == null || Prescription.Equals(""))
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
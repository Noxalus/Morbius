using System;
using System.Windows.Input;
using Wpf_Morbius.ServicePatient;

namespace Wpf_Morbius.ViewModel
{
    class AddPatientViewModel : BaseViewModel
    {
        private Patient _patient;

        /// <summary>
        /// command pour ajouter un patient
        /// </summary>
        public ICommand AddPatientCommand { get; set; }

        #region Accessors
        public string Name
        {
            get { return _patient.Name; }
            set
            {
                if (_patient.Name != value)
                {
                    _patient.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Firstname
        {
            get { return _patient.Firstname; }
            set
            {
                if (_patient.Firstname != value)
                {
                    _patient.Firstname = value;
                    OnPropertyChanged("Firstname");
                }
            }
        }

        public DateTime Birthday
        {
            get { return _patient.Birthday; }
            set
            {
                if (_patient.Birthday != value)
                {
                    _patient.Birthday = value;
                    OnPropertyChanged("Birthday");
                }
            }
        }
        #endregion

        public AddPatientViewModel()
        {
            _patient = new Patient {Birthday = DateTime.Now };

            // Commandes
            AddPatientCommand = new RelayCommand(param => CreatePatient(), param => true);
        }

        /// <summary>
        /// action permettant de créer un patient
        /// </summary>
        private void CreatePatient()
        {
            try
            {
                var spc = new ServicePatient.ServicePatientClient();

                spc.AddPatient(_patient);

                // Refresh patient list
                (App.ViewModels["PatientList"] as PatientListViewModel).RefreshPatientList();

                // Go to patient list
            }
            catch (Exception)
            {
                
                throw;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Windows.Input;
using Wpf_Morbius.ServicePatient;
using Wpf_Morbius.Tools;

namespace Wpf_Morbius.ViewModel
{
    class AddPatientViewModel : BaseViewModel
    {
        private Patient _patient;

        // Messages
        private string _error;
        private string _success;

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

        /// <summary>
        /// erreur lors de l'ajout d'un patient
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
        /// message de réussite lors de création d'un patient
        /// </summary>
        public string Success
        {
            get { return _success; }
            set
            {
                if (_success != value)
                {
                    _success = value;
                    OnPropertyChanged("Success");
                }
            }
        }
        #endregion

        public AddPatientViewModel()
        {
            Error = "";
            Success = "";

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
                Error = "";
                Success = "";

                // We check that all fields are filled
                CheckFields();

                // Check that patient didn't already exist
                foreach(var patient in (App.ViewModels["PatientList"] as PatientListViewModel).PatientList)
                {
                    if (patient.Firstname.Equals(_patient.Firstname) &&
                        patient.Name.Equals(_patient.Name) &&
                        patient.Birthday.Equals(_patient.Birthday))
                    {
                        throw new Exception("Ce patient existe déjà !");
                    }
                }

                var spc = new ServicePatient.ServicePatientClient();

                spc.AddPatient(_patient);

                Success = "Le patient \"" + StringHelper.FullName(_patient.Firstname, _patient.Name) + "\" a été bien été ajouté !";

                // Reset fields
                ResetFields();

                // Refresh patient list
                (App.ViewModels["PatientList"] as PatientListViewModel).RefreshPatientList();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private void CheckFields()
        {
            // Name
            if (Name == null || Name.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de nom !");
            }

            // Firstname
            if (Firstname == null || Firstname.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de prénom !");
            }

            // Birthday
            if (Birthday == null || Birthday.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de date de naissance !");
            }
        }

        private void ResetFields()
        {
            Firstname = null;
            Name = null;
            Birthday = DateTime.Now;

            _patient = new Patient { Birthday = DateTime.Now };
        }

    }
}

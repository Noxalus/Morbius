using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Wpf_Morbius.ServicePatient;

namespace Wpf_Morbius.ViewModel
{
    class PatientObsViewModel : BaseViewModel
    {
        private List<Observation> _observations;

        public ServiceUser.User CurrentUser
        {
            get { return LoginViewModel.GetUser(); }
        }

        public ICommand AddCommand { get; set; }

        public List<Observation> Observations
        {
            get { return _observations; }
            set
            {
                if (_observations != value)
                {
                    _observations = value;
                    OnPropertyChanged("Observations");
                }
            }
        }

        public PatientObsViewModel()
        {
            Observations = PatientViewModel.Patient.Observations.OrderByDescending(o => o.Date).ToList();

            // Commandes
            AddCommand = new RelayCommand(param => OpenAddObservationWindow(), param => true);
        }

        /// <summary>
        /// action permettant d'ouvrir la pop-up
        /// </summary>
        private void OpenAddObservationWindow()
        {
            var window = new View.PatientObsAdd();
            var vm = new AddObservationViewModel(this, PatientViewModel.Patient.Id);
            window.DataContext = vm;
            window.Show();
        }

        public void AddObservation(ServiceObservation.Observation observation)
        {
            var patient = PatientViewModel.Patient;

            var soc = new ServiceObservation.ServiceObservationClient();
            if (soc.AddObservation(patient.Id, observation))
            {
                PatientViewModel.UpdatePatient(patient.Id);

                if (PatientViewModel.Patient.Observations != null)
                {
                    Observations = PatientViewModel.Patient.Observations.OrderByDescending(o => o.Date).ToList();
                }
            }
            else
            {
                throw new Exception("L'observation n'a pas été ajoutée !");
            }
        }
    }
}


using System;
using System.Linq;
using System.Windows.Input;
using Wpf_Morbius.ServicePatient;

namespace Wpf_Morbius.ViewModel
{
    class PatientDetailsViewModel : BaseViewModel
    {
        /// <summary>
        /// command pour supprimer un patient
        /// </summary>
        public ICommand DeletePatientCommand { get; set; }

        public string LastObservation
        {
            get
            {
                if (PatientViewModel.Patient.Observations != null && 
                    PatientViewModel.Patient.Observations.Any())
                    return PatientViewModel.Patient.Observations.Last().Comment;

                return null;
            }
        }

        public PatientDetailsViewModel()
        {
            // Commandes
            DeletePatientCommand = new RelayCommand(param => DeletePatient(), param => true);
        }

        /// <summary>
        /// action permettant de supprimer un patient
        /// </summary>
        private void DeletePatient()
        {
            try
            {
                var spc = new ServicePatient.ServicePatientClient();

                spc.DeletePatient(PatientViewModel.Patient.Id);

                // Go to patient list
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
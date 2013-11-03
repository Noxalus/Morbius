
using System;
using System.Linq;
using Wpf_Morbius.ServicePatient;

namespace Wpf_Morbius.ViewModel
{
    class PatientDetailsViewModel : BaseViewModel
    {
        public string LastObservation
        {
            get
            {
                return (PatientViewModel.Patient.Observations.Any())  ? PatientViewModel.Patient.Observations[0].Comment : null;
            }
        }

        public PatientDetailsViewModel()
        {
        }
    }
}
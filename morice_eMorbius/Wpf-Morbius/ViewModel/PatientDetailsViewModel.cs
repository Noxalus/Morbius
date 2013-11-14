
using System;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Wpf_Morbius.ServicePatient;

namespace Wpf_Morbius.ViewModel
{
    class PatientDetailsViewModel : BaseViewModel
    {
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
            
        }
    }
}
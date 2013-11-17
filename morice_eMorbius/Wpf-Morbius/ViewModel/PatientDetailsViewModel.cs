
using System.Linq;

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
                {
                    return PatientViewModel.Patient.Observations.OrderByDescending(o => o.Date).Last().Comment;
                }

                return null;
            }
        }

        public PatientDetailsViewModel()
        {
            
        }
    }
}
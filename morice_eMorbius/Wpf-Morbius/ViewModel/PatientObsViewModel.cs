using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Morbius.ViewModel
{
    class PatientObsViewModel : BaseViewModel
    {
        private ServicePatient.Observation[] _obs;

        public ServicePatient.Observation[] Obs
        {
            get { return _obs; }
            set { _obs = value; }
        }

        public PatientObsViewModel()
        {
            _obs = PatientViewModel.Patient.Observations;
        }
    }
}

using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Morbius.ViewModel
{
    class PatientListViewModel : BaseViewModel
    {
        ServicePatient.Patient[] _patientList;
        private LinkCollection items = new LinkCollection();

        public LinkCollection Items
        {
            get { return this.items; }
            set
            {
                if (this.items != value)
                {
                    this.items = value;
                }
            }
        }

        /// <summary>
        /// liste des patients
        /// </summary>
        public ServicePatient.Patient[] PatientList
        {
            get { return _patientList; }
            set
            {
                if (_patientList != value)
                {
                    _patientList = value;
                    OnPropertyChanged("PatientList");
                }
            }
        }

        public PatientListViewModel()
        {
            var spc = new ServicePatient.ServicePatientClient();
            _patientList = spc.GetListPatient();

            foreach (ServicePatient.Patient p in _patientList)
            {
                this.items.Add(new Link
                {
                    DisplayName = p.Name,
                    Source = new Uri("patient/" + p.Id, UriKind.Relative),
                });
            }
        }
    }
}

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
        private LinkCollection _items = new LinkCollection();

        public LinkCollection Items
        {
            get { return this._items; }
            set
            {
                if (this._items != value)
                {
                    this._items = value;
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
            RefreshPatientList();
        }

        public void RefreshPatientList()
        {
            try
            {
                var spc = new ServicePatient.ServicePatientClient();
                _patientList = spc.GetListPatient();

                this._items.Clear();
                foreach (ServicePatient.Patient p in _patientList)
                {
                    this._items.Add(new Link
                    {
                        DisplayName = p.Name,
                        Source = new Uri("Patient/" + p.Id, UriKind.Relative),
                    });
                }
            }
            catch (Exception)
            {
            }
            
        }
    }
}


using System;
using Wpf_Morbius.Tools;

namespace Wpf_Morbius.ViewModel
{
    class PatientViewModel : BaseViewModel
    {
        public static ServicePatient.Patient Patient;
        private readonly string _basicInformation;

        public int Id
        {
            get { return Patient.Id; }
        }

        public string BasicInformation
        {
            get { return _basicInformation; }
        }

        public PatientViewModel(int id)
        {
            try
            {
                var spc = new ServicePatient.ServicePatientClient();
                Patient = spc.GetPatient(id);

                _basicInformation = StringHelper.FullName(Patient.Firstname, Patient.Name) + " - " + 
                    String.Format("{0:dd/MM/yyyy}", Patient.Birthday);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
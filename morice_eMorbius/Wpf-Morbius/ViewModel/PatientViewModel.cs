
using System;

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

                _basicInformation = UppercaseFirst(Patient.Firstname) + " " + Patient.Name.ToUpper() + " - " + String.Format("{0:dd/MM/yyyy}", Patient.Birthday);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
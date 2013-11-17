
using System;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Wpf_Morbius.Tools;

namespace Wpf_Morbius.ViewModel
{
    class PatientViewModel : BaseViewModel
    {
        private Storyboard _sb;
        public static ServicePatient.Patient Patient;
        private static string _basicInformation;

        /// <summary>
        /// command pour supprimer un patient
        /// </summary>
        public ICommand DeletePatientCommand { get; set; }

        public ServiceUser.User CurrentUser
        {
            get { return LoginViewModel.GetUser(); }
        }

        public Storyboard Sb
        {
            get { return _sb; }
            set { _sb = value; }
        }

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
            UpdatePatient(id);

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

                Sb.Begin();

                // Refresh patient list
                (App.ViewModels["PatientList"] as PatientListViewModel).RefreshPatientList();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdatePatient(int id)
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
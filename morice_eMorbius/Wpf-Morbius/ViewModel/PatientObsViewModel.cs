using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_Morbius.ViewModel
{
    class PatientObsViewModel : BaseViewModel
    {
        private ServicePatient.Observation[] _obs;
        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public ServicePatient.Observation[] Obs
        {
            get { return _obs; }
            set { _obs = value; }
        }

        public PatientObsViewModel()
        {
            _obs = PatientViewModel.Patient.Observations;

            // Commandes
            _addCommand = new RelayCommand(param => addObs(), param => true);
        }

        /// <summary>
        /// action permettant d'ouvrir la pop-up
        /// </summary>
        private void addObs()
        {
            var window = new View.PatientObsAdd();
            //var vm = new PatientObsAddViewModel();
            //window.DataContext = vm;
            window.Show();      
        }


    }
}

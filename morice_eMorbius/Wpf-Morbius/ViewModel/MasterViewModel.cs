using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Morbius.ViewModel
{
    class MasterViewModel : BaseViewModel
    {
        /// <summary>
        /// login de la personne
        /// </summary>
        public string Login
        {
            get { return LoginViewModel.GetUser().Login; }
            set
            {
                OnPropertyChanged("Login");
            }
        }

        public MasterViewModel()
        {
        }
    }
}

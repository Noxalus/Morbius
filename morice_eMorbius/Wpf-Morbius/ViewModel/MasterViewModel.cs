using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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
        }

        public MasterViewModel()
        {
        }
    }
}

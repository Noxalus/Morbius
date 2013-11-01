using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace Wpf_Morbius.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commandes
        public ICommand LoginCommand { get; set; }
        #endregion

        /// <summary>
        /// constructeur
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(param => Login(), param => true);
        }

        /// <summary>
        /// réponse à la commande login
        /// </summary>
        private void Login()
        {
        }
    }
}

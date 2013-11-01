using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_Morbius.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commandes
        public ICommand _loginCommand { get; set; }
        private string _login;
        private bool _canLogIn = true;
        private bool _closeSignal;
        private ServiceUser.User _user;
        #endregion

        #region getter / setter
        /// <summary>
        /// login de la personne
        /// </summary>
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged("Login");
                }

            }
        }

        /// <summary>
        /// flag permettant de désactiver la connexion
        /// </summary>
        /// 
        public bool CanLogIn
        {
            get { return _canLogIn; }
            set { _canLogIn = value; }
        }

        /// <summary>
        /// command pour s'authentifier
        /// </summary>
        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            set { _loginCommand = value; }
        }

        /// <summary>
        /// indique si on doit fermer la fenêtre ou non
        /// </summary>
        public bool CloseSignal
        {
            get { return _closeSignal; }
            set
            {
                if (_closeSignal != value)
                {
                    _closeSignal = value;
                    OnPropertyChanged("CloseSignal");
                }
            }
        }
        #endregion

        /// <summary>
        /// constructeur
        /// </summary>
        public LoginViewModel()
        {
            base.DisplayName = "Page de login";

            _login = "";
            _user = new ServiceUser.User();
            _loginCommand = new RelayCommand(param => LoginAccess(((PasswordBox)param).Password), param => CanLogIn);
        }

        /// <summary>
        /// action permettant de s'authentifier
        /// </summary>
        private void LoginAccess(string password)
        {
            ServiceUser.ServiceUserClient suc = new ServiceUser.ServiceUserClient();

            if (suc.Connect(_login, password))
            {
                _user = suc.GetUser(_login);

                View.MasterView window = new View.MasterView();
                ViewModel.MasterViewModel vm = new MasterViewModel();
                window.DataContext = vm;
                window.Show();
                CloseSignal = true;
            }
            else
            {

            }
        }
    }
}

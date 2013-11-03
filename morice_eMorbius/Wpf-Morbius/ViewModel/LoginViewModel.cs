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
        private string _login;
        private string _error;
        private bool _canLogIn = true;
        private bool _closeSignal;
        private static ServiceUser.User _user = new ServiceUser.User();

        // Commandes
        public ICommand _loginCommand { get; set; }

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
        /// erreur lors de connection
        /// </summary>
        public string Error
        {
            get { return _error; }
            set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged("Error");
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

        public static ServiceUser.User GetUser()
        {
            return _user;
        }

        #endregion

        /// <summary>
        /// constructeur
        /// </summary>
        public LoginViewModel()
        {
            base.DisplayName = "Page de login";

            _error = "";
            _login = "";

            // Commandes
            _loginCommand = new RelayCommand(param => LoginAccess(((PasswordBox)param).Password), param => CanLogIn);
        }

        /// <summary>
        /// action permettant de s'authentifier
        /// </summary>
        private void LoginAccess(string password)
        {
            try
            {
                Error = "";
                if (_login != "" && password != "")
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
                        Error = "Erreur d'authentification, vérifiez que vous avez bien entré les bons identifiants.";
                    }
                }
                else
                {
                    Error = "Vous devez entrer un login et un mot de passe pour vous connecter.";
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
    }
}


using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Wpf_Morbius.Tools;

namespace Wpf_Morbius.ViewModel
{
    class UserViewModel : BaseViewModel
    {
        private readonly ServiceUser.User _user;
        private readonly string _fullname;
        private string _error;
        private Storyboard _sb;

        public Storyboard Sb
        {
            get { return _sb; }
            set { _sb = value;}
        }

        /// <summary>
        /// command pour ajouter un utilisateur
        /// </summary>
        public ICommand DeleteUserCommand { get; set; }

        #region Accessors

        /// <summary>
        /// login de la personne
        /// </summary>
        public string Login
        {
            get { return _user.Login; }
        }

        /// <summary>
        /// rôle de la personne
        /// </summary>
        public string Role
        {
            get { return _user.Role; }
        }

        /// <summary>
        /// Image de la personne
        /// </summary>
        public byte[] Picture
        {
            get { return _user.Picture; }
        }

        /// <summary>
        /// Statut de connexion de la personne
        /// </summary>
        public bool Connected
        {
            get { return _user.Connected; }
        }

        /// <summary>
        /// nom complet de la personne
        /// </summary>
        public string Fullname
        {
            get { return _fullname; }
        }

        /// <summary>
        /// l'erreur qui s'est produite lors d'une opération
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

        #endregion

        public UserViewModel(string login)
        {
            try
            {
                var suc = new ServiceUser.ServiceUserClient();

                _user = suc.GetUser(login);
                _fullname = StringHelper.UppercaseFirst(_user.Firstname) + " " + _user.Name.ToUpper();

                // Commandes
                DeleteUserCommand = new RelayCommand(param => DeleteUser(), param => true);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        /// <summary>
        /// action permettant de supprimer un utilisateur
        /// </summary>
        private void DeleteUser()
        {
            try
            {
                if (_user.Login != LoginViewModel.GetUser().Login)
                {
                    var suc = new ServiceUser.ServiceUserClient();

                    suc.DeleteUser(_user.Login);

                    Sb.Begin();

                    // Refresh user list
                    (App.ViewModels["UserList"] as UserListViewModel).RefreshUserList();

                    // Go to user list
                }
                else
                {
                    Error = "Vous ne pouvez pas supprimer votre propre compte !";
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
    }
}

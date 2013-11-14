using System;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf_Morbius.ServiceUser;

namespace Wpf_Morbius.ViewModel
{
    class AddUserViewModel : BaseViewModel
    {
        private User _user;

        /// <summary>
        /// command pour ajouter un utilisateur
        /// </summary>
        public ICommand AddUserCommand { get; set; }

        #region Accessors
        public string Login
        {
            get { return _user.Login; }
            set
            {
                if (_user.Login != value)
                {
                    _user.Login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                if (_user.Name != value)
                {
                    _user.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Firstname
        {
            get { return _user.Firstname; }
            set
            {
                if (_user.Firstname != value)
                {
                    _user.Firstname = value;
                    OnPropertyChanged("Firstname");
                }
            }
        }

        public string Role
        {
            get { return _user.Role; }
            set
            {
                if (_user.Role != value)
                {
                    _user.Role = value;
                    OnPropertyChanged("Role");
                }
            }
        }

        public byte[] Picture
        {
            get { return _user.Picture; }
            set
            {
                if (_user.Picture != value)
                {
                    _user.Picture = value;
                    OnPropertyChanged("Picture");
                }
            }
        }
        #endregion

        public AddUserViewModel()
        {
            _user = new User();

            // Commandes
            AddUserCommand = new RelayCommand(param => CreateUser(((PasswordBox)param).Password), param => true);
        }

        /// <summary>
        /// action permettant de créer un utilisateur
        /// </summary>
        private void CreateUser(string password)
        {
            try
            {
                var suc = new ServiceUser.ServiceUserClient();

                _user.Pwd = password;
                suc.AddUser(_user);

                // Refresh user list
                (App.ViewModels["UserList"] as UserListViewModel).RefreshUserList();

                // Go to user list

            }
            catch (Exception)
            {
                
                throw;
            }
        }


    }
}

using System;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf_Morbius.Services;
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

        /// <summary>
        /// command pour ouvrir un fichier
        /// </summary>
        public ICommand OpenCommand { get; set; }

        private IOService _ioService;

        private string _selectedPath;
        public string SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath = value; OnPropertyChanged("SelectedPath"); }
        }


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

            _ioService = new IOService();
            OpenCommand = new RelayCommand(param => OpenFileDialog(), param => true);

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
                // Read selected file
                _user.Picture = _ioService.OpenFile(_selectedPath);

                suc.AddUser(_user);

                // Reset fields
                ResetFields();

                // Refresh user list
                (App.ViewModels["UserList"] as UserListViewModel).RefreshUserList();

                // Go to user list

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ResetFields()
        {
            SelectedPath = "";

            Login = null;
            Firstname = null;
            Name = null;
            Picture = null;
            Role = null;

            _user = new User();
        }

        private void OpenFileDialog()
        {
            SelectedPath = _ioService.OpenFileDialog(@"c:\");
            if (SelectedPath == null)
            {
                SelectedPath = string.Empty;
            }
        }
    }
}

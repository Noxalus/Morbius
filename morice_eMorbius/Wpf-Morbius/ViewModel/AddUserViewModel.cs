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

        // Messages
        private string _error;
        private string _success;

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

        /// <summary>
        /// erreur lors de l'ajout d'un utilisateur
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
        /// message de réussite lors de création d'un utilisateur
        /// </summary>
        public string Success
        {
            get { return _success; }
            set
            {
                if (_success != value)
                {
                    _success = value;
                    OnPropertyChanged("Success");
                }
            }
        }
        
        
        #endregion

        public AddUserViewModel()
        {
            Error = "";
            Success = "";

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
                Error = "";
                Success = "";

                // We check that all fields are filled
                CheckFields(password);

                // Check that patient didn't already exist
                foreach (var user in (App.ViewModels["UserList"] as UserListViewModel).UserList)
                {
                    if (user.Login.Equals(_user.Login))
                    {
                        throw new Exception("Cet utilisateur existe déjà !");
                    }
                }

                var suc = new ServiceUser.ServiceUserClient();

                // Read selected file
                _user.Picture = _ioService.OpenFile(_selectedPath);

                _user.Pwd = password;

                suc.AddUser(_user);

                // Go to user list
                Success = "L'utilisateur \"" + _user.Login + "\" a bien été ajouté !"; 

                // Reset fields
                ResetFields();

                // Refresh user list
                (App.ViewModels["UserList"] as UserListViewModel).RefreshUserList();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private void CheckFields(string password)
        {
            // Name
            if (Name == null || Name.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de nom !");
            }

            // Firstname
            if (Firstname == null || Firstname.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de prénom !");
            }

            // Login
            if (Login == null || Login.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de login !");
            }

            // Password
            if (password == null || password.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de mot de passe !");
            }

            // Role
            if (Role == null || Role.Equals(""))
            {
                throw new Exception("Vous n'avez pas entré de rôle !");
            }

            // Photo
            if (_selectedPath == null || _selectedPath.Equals(""))
            {
                // Photo obligatoire ?
                throw new Exception("Vous n'avez pas sélectionné de photo !");
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
            string savedSelectedPath = SelectedPath;
            string defaultPath = @"C:\";
            
            if (!(SelectedPath == null || SelectedPath.Equals("")))
                defaultPath = SelectedPath;

            SelectedPath = _ioService.OpenFileDialog(defaultPath);
            
            if (SelectedPath == null || SelectedPath.Equals(""))
            {
                SelectedPath = savedSelectedPath;
            }
        }
    }
}

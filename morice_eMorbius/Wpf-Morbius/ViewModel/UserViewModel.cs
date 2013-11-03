
using System;

namespace Wpf_Morbius.ViewModel
{
    class UserViewModel : BaseViewModel
    {
        private readonly ServiceUser.User _user;
        private string _fullname;

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

        public UserViewModel(string login)
        {
            try
            {
                var suc = new ServiceUser.ServiceUserClient();

                _user = suc.GetUser(login);
                _fullname = UppercaseFirst(_user.Firstname) + " " + _user.Name.ToUpper();
            }
            catch (Exception)
            {

                throw;
            }
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}

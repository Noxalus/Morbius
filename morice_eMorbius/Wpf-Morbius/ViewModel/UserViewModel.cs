
namespace Wpf_Morbius.ViewModel
{
    class UserViewModel : BaseViewModel
    {
        private ServiceUser.User _user;

        /// <summary>
        /// login de la personne
        /// </summary>
        public string Login
        {
            get { return _user.Login; }
        }

        public UserViewModel(string login)
        {
            var suc = new ServiceUser.ServiceUserClient();

            _user = suc.GetUser(login);
        }
    }
}

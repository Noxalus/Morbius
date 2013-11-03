using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Morbius.ViewModel
{
    class UserListViewModel : BaseViewModel
    {
        ServiceUser.User[] _users;
        private LinkCollection items = new LinkCollection();

        public LinkCollection Items
        {
            get { return this.items; }
            set
            {
                if (this.items != value)
                {
                    this.items = value;
                }
            }
        }

        public UserListViewModel()
        {
            var suc = new ServiceUser.ServiceUserClient();
            _users = suc.GetListUser();

            foreach (ServiceUser.User u in _users)
            {
                this.items.Add(new Link
                {
                    DisplayName = u.Login,
                    Source = new Uri("User/" + u.Login, UriKind.Relative),
                });
            }
        }
    }
}

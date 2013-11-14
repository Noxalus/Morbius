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
        private LinkCollection _items = new LinkCollection();

        public LinkCollection Items
        {
            get { return this._items; }
            set
            {
                if (this._items != value)
                {
                    this._items = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        public ServiceUser.User[] UserList
        {
            get { return _users; }
        }

        public UserListViewModel()
        {
            RefreshUserList();
        }

        public void RefreshUserList()
        {
            var suc = new ServiceUser.ServiceUserClient();
            _users = suc.GetListUser();

            this._items.Clear();
            foreach (ServiceUser.User u in _users)
            {
                this._items.Add(new Link
                {
                    DisplayName = u.Login,
                    Source = new Uri("User/" + u.Login, UriKind.Relative),
                });
            }

        }
    }
}

using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Wpf_Morbius.ViewModel
{
    class MasterViewModel : BaseViewModel
    {
        private LinkGroupCollection _menu;

        public LinkGroupCollection Menu
        {
            get { return _menu; }
        }


        /// <summary>
        /// login de la personne
        /// </summary>
        public string Login
        {
            get { return LoginViewModel.GetUser().Login; }
        }

        public MasterViewModel()
        {
            _menu = new LinkGroupCollection();
            String roleUser = LoginViewModel.GetUser().Role;
            LinkGroup groupPatient = new LinkGroup();
            LinkGroup groupUser = new LinkGroup();

            groupPatient.DisplayName = "Patients";
            groupUser.DisplayName = "Utilisateurs";

            groupPatient.Links.Add(new Link
            {
                DisplayName = "Consulter",
                Source = new Uri("/View/Pages/PatientList.xaml", UriKind.Relative),
            });
            groupUser.Links.Add(new Link
            {
                DisplayName = "Consulter",
                Source = new Uri("/View/Pages/UserList.xaml", UriKind.Relative),
            });

            if (!roleUser.Equals("Infirmier") && !roleUser.Equals("Infirmière"))
            {
                groupPatient.Links.Add(new Link
                {
                    DisplayName = "Ajouter",
                    Source = new Uri("/View/Pages/PatientAdd.xaml", UriKind.Relative),
                });
                groupUser.Links.Add(new Link
                {
                    DisplayName = "Ajouter",
                    Source = new Uri("/View/Pages/UserAdd.xaml", UriKind.Relative),
                });
            }

            _menu.Add(groupPatient);
            _menu.Add(groupUser);


        }
    }
}

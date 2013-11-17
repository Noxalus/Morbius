using System.Collections.Generic;
using System.Windows;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dictionary<string, BaseViewModel> ViewModels = new Dictionary<string, BaseViewModel>();

        /// <summary>
        /// permet de lancer la 1er fenêtre
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginWindow = new View.LoginView();

            ViewModels.Add("Login", new ViewModel.LoginViewModel());
            ViewModels.Add("UserList", new ViewModel.UserListViewModel());
            ViewModels.Add("PatientList", new ViewModel.PatientListViewModel());
            ViewModels.Add("PatientDetails", new ViewModel.PatientDetailsViewModel());

            loginWindow.DataContext = ViewModels["Login"];
            loginWindow.Show();
        }
    }
}

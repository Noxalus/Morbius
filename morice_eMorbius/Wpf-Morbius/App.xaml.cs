using System.Windows;

namespace Wpf_Morbius
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// permet de lancer la 1er fenêtre
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new View.LoginView();
            var vm = new ViewModel.LoginViewModel();
            window.DataContext = vm;

            window.Show();
        }
    }
}

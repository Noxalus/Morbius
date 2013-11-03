using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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

            //View.LoginView window = new View.LoginView();
            //ViewModel.LoginViewModel vm = new ViewModel.LoginViewModel();
            //window.DataContext = vm;

            View.MasterView window = new View.MasterView();

            window.Show();
        }
    }
}

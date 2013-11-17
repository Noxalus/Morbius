using System;
using System.Windows.Controls;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour PatientObs.xaml
    /// </summary>
    public partial class PatientObs : UserControl
    {
        public PatientObs()
        {
            InitializeComponent();
            DataContext = new PatientObsViewModel();
        }
    }
}

using System;
using System.Windows.Controls;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour patient.xaml
    /// </summary>
    public partial class Patient : UserControl
    {
        public Patient(string id)
        {
            InitializeComponent();

            DataContext = new PatientViewModel( Convert.ToInt32(id));
        }
    }
}

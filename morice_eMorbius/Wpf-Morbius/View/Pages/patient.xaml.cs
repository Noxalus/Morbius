using System;
using System.Windows.Controls;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour patient.xaml
    /// </summary>
    public partial class patient : UserControl
    {
        public patient(string id)
        {
            InitializeComponent();

            DataContext = new PatientViewModel( Convert.ToInt32(id));
        }
    }
}

using System.Windows.Controls;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour patient_add.xaml
    /// </summary>
    public partial class PatientAdd : Page
    {
        public PatientAdd()
        {
            InitializeComponent();

            DataContext = new AddPatientViewModel();
        }
    }
}

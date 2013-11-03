using System.Windows.Controls;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour patient_list.xaml
    /// </summary>
    public partial class PatientList : Page
    {
        public PatientList()
        {
            InitializeComponent();

            DataContext = new PatientListViewModel();
        }
    }
}

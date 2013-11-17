using System.Windows.Controls;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour user_details.xaml
    /// </summary>
    public partial class PatientDetails : UserControl
    {

        public PatientDetails()
        {
            InitializeComponent();

            DataContext = App.ViewModels["PatientDetails"];
        }
    }
}

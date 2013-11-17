using System.Windows.Controls;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour PatientTemp.xaml
    /// </summary>
    public partial class PatientLive : UserControl
    {
        public PatientLive()
        {
            InitializeComponent();

            DataContext = new PatientLiveViewModel();
        }
    }
}

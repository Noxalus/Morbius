using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
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

            PatientViewModel vm = new PatientViewModel(Convert.ToInt32(id));
            vm.Sb = this.FindResource("deletionStoryboard") as Storyboard;
            DataContext = vm;
        }
    }
}

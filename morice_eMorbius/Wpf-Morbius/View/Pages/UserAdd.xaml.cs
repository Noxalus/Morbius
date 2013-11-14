using System.Windows.Controls;
using Wpf_Morbius.Services;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour user_add.xaml
    /// </summary>
    public partial class UserAdd : Page
    {
        public UserAdd()
        {
            InitializeComponent();

            DataContext = new AddUserViewModel();
        }
    }
}

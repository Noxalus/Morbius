using System.Windows.Controls;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour user_add.xaml
    /// </summary>
    public partial class user_add : Page
    {
        public user_add()
        {
            InitializeComponent();

            DataContext = new AddUserViewModel();
        }
    }
}

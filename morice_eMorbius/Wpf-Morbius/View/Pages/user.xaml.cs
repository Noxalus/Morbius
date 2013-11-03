using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_Morbius.ViewModel;

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour user.xaml
    /// </summary>
    public partial class user : UserControl
    {
        public user(String login)
        {
            InitializeComponent();

            DataContext = new UserViewModel(login);
        }
    }
}

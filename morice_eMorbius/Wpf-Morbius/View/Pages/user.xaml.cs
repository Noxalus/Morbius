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

namespace Wpf_Morbius.View.Pages
{
    /// <summary>
    /// Logique d'interaction pour user.xaml
    /// </summary>
    public partial class user : UserControl
    {
        private String _login;

        public String Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public user(String login)
        {
            InitializeComponent();
            InitializeComponent();
            content.DataContext = this;
            _login = login;
        }
    }
}

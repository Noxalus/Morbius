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
    /// Logique d'interaction pour user_details.xaml
    /// </summary>
    public partial class user_details : UserControl
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public user_details()
        {
            InitializeComponent();
            _id = patient.current;
        }
    }
}

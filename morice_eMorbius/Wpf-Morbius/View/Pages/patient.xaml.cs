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
    /// Logique d'interaction pour patient.xaml
    /// </summary>
    public partial class patient : UserControl
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public patient(string id)
        {
            InitializeComponent();
            content.DataContext = this;
            _id = Convert.ToInt32(id);
            
        }


    }
}

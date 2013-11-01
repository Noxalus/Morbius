using FirstFloor.ModernUI.Presentation;
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
    /// Logique d'interaction pour patient_list.xaml
    /// </summary>
    public partial class patient_list : Page
    {
        private LinkCollection items = new LinkCollection();
        public LinkCollection Items
        {
            get { return this.items; }
            set
            {
                if (this.items != value)
                {
                    this.items = value;
                }
            }
        }

        public patient_list()
        {
            InitializeComponent();


            this.items.Add(new Link {
              DisplayName = "Patient 1", 
              Source = new Uri("patient/1", UriKind.Relative),
            });
            this.items.Add(new Link
            {
                DisplayName = "Patient 2",
                Source = new Uri("patient/2", UriKind.Relative),
            });
            listBox.DataContext = this;
        }
    }
}

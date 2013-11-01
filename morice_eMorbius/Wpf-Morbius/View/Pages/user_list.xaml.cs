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
    /// Logique d'interaction pour user_list.xaml
    /// </summary>
    public partial class user_list : Page
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

        public user_list()
        {
            InitializeComponent();

            this.items.Add(new Link
            {
                DisplayName = "Utilisateur 1",
                Source = new Uri("user/login1", UriKind.Relative),
            });
            this.items.Add(new Link
            {
                DisplayName = "Utilisateur 2",
                Source = new Uri("user/login2", UriKind.Relative),
            });
            listBox.DataContext = this;
        }
    }
}

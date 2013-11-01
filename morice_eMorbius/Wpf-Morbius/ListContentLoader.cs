using FirstFloor.ModernUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Morbius.View.Pages;

namespace Wpf_Morbius
{
    public class ListContentLoader : DefaultContentLoader
    {
        protected override object LoadContent(Uri uri)
        {
            String[] elt = uri.ToString().Split('/');

            if (elt[0].Equals("patient"))
                return new patient(elt[1]);
            if (elt[0].Equals("user"))
                return new user(elt[1]);
            return base.LoadContent(uri);
        }
    }
}

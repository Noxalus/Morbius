using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Morbius.Services
{
    public class IOService
    {
        public string OpenFileDialog(string defaultPath)
        {
            var dialog = new OpenFileDialog { InitialDirectory = defaultPath };
            dialog.ShowDialog();

            return dialog.FileName;
        }

        public byte[] OpenFile(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}

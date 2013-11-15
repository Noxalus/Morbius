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
            // Set the file dialog to filter for graphics files.

            var dialog = new OpenFileDialog { InitialDirectory = defaultPath };
            dialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            dialog.Title = "\\o/ Mon superbe selecteur d'image ! \\o/";

            var result = dialog.ShowDialog();

            return dialog.FileName;
        }

        public List<string> OpenMultipleFileDialog(string defaultPath)
        {
            // Set the file dialog to filter for graphics files.

            var dialog = new OpenFileDialog { InitialDirectory = defaultPath };
            dialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            dialog.Multiselect = true;
            dialog.Title = "\\o/ Mon superbe selecteur d'image multiple ! \\o/";

            dialog.ShowDialog();

            return dialog.FileNames.ToList();
        }

        public byte[] OpenFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        public byte[][] OpenFiles(List<string> paths)
        {
            return paths.Select(File.ReadAllBytes).ToArray();
        }
    }
}

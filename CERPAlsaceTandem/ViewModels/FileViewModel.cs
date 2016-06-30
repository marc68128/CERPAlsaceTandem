using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CERPAlsaceTandem.ViewModels
{
    public class FileViewModel : BaseViewModel
    {
        public FileViewModel(string path)
        {
            Path = path;
            Date = File.GetCreationTime(path);
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date { get; set; }
    }
}

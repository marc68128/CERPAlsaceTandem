using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Models
{
    public class PhotoCollection : FileCollection<PhotoFileViewModel>
    {
        public PhotoCollection(List<PhotoFileViewModel> list) : base(list)
        {       
        }
    }
}

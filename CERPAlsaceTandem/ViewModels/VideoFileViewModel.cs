using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell32;


namespace CERPAlsaceTandem.ViewModels
{
    public class VideoFileViewModel : FileViewModel
    {
        public VideoFileViewModel(string path) : base(path)
        {
            var shl = new Shell();
            var fldr = shl.NameSpace(System.IO.Path.GetDirectoryName(path));
            var itm = fldr.ParseName(System.IO.Path.GetFileName(path));
            
            var propValue = fldr.GetDetailsOf(itm, 27);
            TimeSpan duration;
            if (TimeSpan.TryParse(propValue, out duration))
                Duration = duration;
        }

        public TimeSpan Duration { get; set; }
    }
}

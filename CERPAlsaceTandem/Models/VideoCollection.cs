using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Models
{
    public class VideoCollection : FileCollection<VideoFileViewModel>
    {
        public VideoCollection(List<VideoFileViewModel> list) : base(list)
        {
        }
    }
}

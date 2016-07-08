using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Models
{
    public class VideoCollection : FileCollection
    {
        public VideoCollection(IEnumerable<VideoFileViewModel> list) : base(list)
        {
            FileType = FileType.Video;

            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();

            var firstPath = Path.Combine(Path.GetTempPath(), "first.jpg");
            ffMpeg.GetVideoThumbnail(list.FirstOrDefault()?.Path, firstPath);

            var lastPath = Path.Combine(Path.GetTempPath(), "last.jpg");
            ffMpeg.GetVideoThumbnail(list.LastOrDefault()?.Path, lastPath);


            BitmapImage firstImage = new BitmapImage();
            firstImage.BeginInit();
            firstImage.CacheOption = BitmapCacheOption.OnLoad;
            firstImage.UriSource = new Uri(firstPath);
            firstImage.EndInit();

            FirstImage = firstImage;

            BitmapImage lastImage = new BitmapImage();
            lastImage.BeginInit();
            lastImage.CacheOption = BitmapCacheOption.OnLoad;
            lastImage.UriSource = new Uri(lastPath);
            lastImage.EndInit();

            LastImage = lastImage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Models
{
    public class PhotoCollection : FileCollection
    {
        public PhotoCollection(IEnumerable<PhotoFileViewModel> list) : base(list)
        {
            FileType = FileType.Photo;

            BitmapImage firstImage = new BitmapImage();
            firstImage.BeginInit();
            firstImage.CacheOption = BitmapCacheOption.OnLoad;
            firstImage.UriSource = new Uri(FirstPath);
            firstImage.EndInit();

            FirstImage = firstImage;

            BitmapImage lastImage = new BitmapImage();
            lastImage.BeginInit();
            lastImage.CacheOption = BitmapCacheOption.OnLoad;
            lastImage.UriSource = new Uri(LastPath);
            lastImage.EndInit();

            LastImage = lastImage;

        }


    }
}

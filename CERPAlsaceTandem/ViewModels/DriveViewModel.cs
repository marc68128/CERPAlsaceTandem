using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.Models;

namespace CERPAlsaceTandem.ViewModels
{
    public class DriveViewModel : BaseViewModel
    {
        public DriveViewModel(DriveInfo d)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            var path = d.RootDirectory.FullName;

            var imageFilter = new[] { "*.jpg", "*.JPG", "*.png", "*.PNG" };
            var videoFilter = new[] { "*.avi", "*.AVI", "*.mkv", "*.MKV" };

            var images = imageFilter.SelectMany(f => IOExtensions.GetFilesRecursiv(path, f)).Where(p => !p.StartsWith(".")).Distinct().Select(p => new PhotoFileViewModel(p)).ToList();
            var videos = videoFilter.SelectMany(f => IOExtensions.GetFilesRecursiv(path, f)).Where(p => !p.StartsWith(".")).Distinct().Select(p => new VideoFileViewModel(p)).ToList();

            ImageCount = images.Count();
            VideoCount = videos.Count();

            SelectedPassenger = UserSelection.SelectedPassenger;

            List<PhotoCollection> photoCollection = new List<PhotoCollection>(); 
            List<VideoCollection> videoCollection = new List<VideoCollection>();

            #region Photos

            if (IOExtensions.GetDirectoriesRecursiv(path, "*CANON").Any()) //Canon folders
            {
                var grouped = images.GroupBy(i => Path.GetDirectoryName(i.Path)).ToList();
                photoCollection.AddRange(grouped.Select(g => new PhotoCollection(g.ToList())));
            }
            else
            {
                var collection = new PhotoCollection(images);
                photoCollection.Add(collection);
            }

            #endregion

            #region Videos

            var listVideo = new List<VideoFileViewModel>();
            foreach (var video in videos.OrderBy(x => x.Date))
            {
                if (video.Duration > new TimeSpan(0, 0, 3))
                {
                    listVideo.Add(video);
                }
                else
                {
                    videoCollection.Add(new VideoCollection(listVideo));
                    listVideo = new List<VideoFileViewModel>();
                }
            }

            #endregion

            Videos = videoCollection;
            Photos = photoCollection;
            
        }

        public PassengerViewModel SelectedPassenger { get; set; }


        private int _imageCount;
        public int ImageCount
        {
            get { return _imageCount; }
            set
            {
                _imageCount = value;
                OnPropertyChanged();
            }
        }

        private int _videoCount;
        public int VideoCount
        {
            get { return _videoCount; }
            set
            {
                _videoCount = value;
                OnPropertyChanged();
            }
        }


        private List<VideoCollection> _videos;
        public List<VideoCollection> Videos
        {
            get { return _videos; }
            set
            {
                OnPropertyChanged();
                _videos = value;
            }
        }


        private List<PhotoCollection> _photos;
        public List<PhotoCollection> Photos
        {
            get { return _photos; }
            set
            {
                OnPropertyChanged();
                _photos = value;
            }
        }

    }
}

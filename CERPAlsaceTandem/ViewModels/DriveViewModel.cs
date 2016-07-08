using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.Models;

namespace CERPAlsaceTandem.ViewModels
{
    public class DriveViewModel : BaseViewModel
    {
        private string _path;

        public DriveViewModel(DriveInfo d)
        {
            _path = d.RootDirectory.FullName;
            SelectedPassenger = UserSelection.SelectedPassenger;
            ReloadCommand = new MyCommand(arg =>
            {
                LoadData();
                SelectedPassenger.UpdatePhotoAndVideoCount();
            });

            LoadData();
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

        private ObservableCollection<FileCollection> _files;
        public ObservableCollection<FileCollection> Files
        {
            get { return _files; }
            set
            {
                _files = value;
                OnPropertyChanged();
            }
        }

        public MyCommand ReloadCommand { get; set; }

        private void LoadData()
        {
            var images = IOExtensions.PhotoExtensions.SelectMany(f => IOExtensions.GetFilesRecursiv(_path, f)).Where(p => !p.StartsWith(".")).Distinct().Select(p => new PhotoFileViewModel(p)).ToList();
            var videos = IOExtensions.VideoExtensions.SelectMany(f => IOExtensions.GetFilesRecursiv(_path, f)).Where(p => !p.StartsWith(".")).Distinct().Select(p => new VideoFileViewModel(p)).ToList();

            ImageCount = images.Count();
            VideoCount = videos.Count();

            List<PhotoCollection> photoCollection = new List<PhotoCollection>();
            List<VideoCollection> videoCollection = new List<VideoCollection>();

            #region Photos

            if (IOExtensions.GetDirectoriesRecursiv(_path, "*CANON").Any()) //Canon folders
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
            videoCollection.Add(new VideoCollection(listVideo));

            #endregion

            videoCollection.ToList().ForEach(x => x.Changed += (sender, args) => ReloadCommand.Execute(null));
            photoCollection.ToList().ForEach(x => x.Changed += (sender, args) => ReloadCommand.Execute(null));

            Files = new ObservableCollection<FileCollection>(videoCollection.Concat(photoCollection.Cast<FileCollection>()).ToList());

        }

    }
}

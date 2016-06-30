using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.Models;

namespace CERPAlsaceTandem.ViewModels
{
    public class PassengerViewModel : BaseViewModel
    {
        public string RootPath { get; set; }
        public string PhotoPath { get; set; }
        public string VideoPath { get; set; }
        public bool PhotoFolderExist { get; set; }
        public bool VideoFolderExist { get; set; }

        public PassengerViewModel(string path)
        {
            RootPath = path;

            PhotoPath = Path.Combine(RootPath, "photos");
            VideoPath = Path.Combine(RootPath, "video");

            PhotoFolderExist = Directory.Exists(PhotoPath);
            VideoFolderExist = Directory.Exists(VideoPath);

            var folderNameinfos = Path.GetFileName(path).Split('-').Select(s => s.Trim()).ToList();

            Date = new DateTime(int.Parse(folderNameinfos[0]), int.Parse(folderNameinfos[1]), int.Parse(folderNameinfos[2]));
            FullName = folderNameinfos[5];
            IsCEP = folderNameinfos[3].ToLower().Contains("cep");
            IsPhoto = folderNameinfos[6].ToLower().Contains("photos");
            IsVideo = folderNameinfos[6].ToLower().Contains("video");

            OpenPhotoFolderCommand = new MyCommand(null, () => Process.Start(PhotoPath));

            if (!IsVideo)
                TandemType = TandemType.Photo;
            else if (!IsPhoto)
                TandemType = TandemType.Video;
            else
                TandemType = TandemType.VideoPhoto;

            PhotoCount =
                IOExtensions.PhotoExtensions.Select(e => IOExtensions.GetFilesRecursiv(RootPath, e).Count)
                    .Sum();

            VideoCount =
                IOExtensions.VideoExtensions.Select(e => IOExtensions.GetFilesRecursiv(RootPath, e).Count)
                    .Sum();
        }

        public MyCommand OpenPhotoFolderCommand { get; set; }

        public DateTime Date { get; set; }
        public string FullName { get; set; }
        public bool IsCEP { get; set; }
        public TandemType TandemType { get; set; }

        public bool IsPhoto { get; set; }
        public bool IsVideo { get; set; }

        private int _photoCount;
        public int PhotoCount
        {
            get { return _photoCount; }
            set
            {
                _photoCount = value;
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


    }
}

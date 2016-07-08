using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CERPAlsaceTandem.Annotations;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Models
{
    public class FileCollection : List<FileViewModel>, INotifyPropertyChanged 
    {
        protected FileCollection(IEnumerable<FileViewModel> list)
        {
            this.AddRange(list);
            var first = list.OrderBy(x => x.Date).FirstOrDefault();
            var last = list.OrderBy(x => x.Date).LastOrDefault();
            FirstDate = first?.Date ?? DateTime.MinValue;
            LastDate = last?.Date ?? DateTime.MinValue;
            ElapsedTime = LastDate - FirstDate;
            FirstPath = first?.Path;
            LastPath = last?.Path;
            InitCommand();
        }

        public event ChangedEventHandler Changed;

        public FileType FileType { get; set; }

        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }

        public TimeSpan ElapsedTime { get; set; }

        public string FirstPath { get; set; }
        public string LastPath { get; set; }

        private BitmapImage _firstImage;
        public BitmapImage FirstImage
        {
            get { return _firstImage; }
            set
            {
                _firstImage = value;
                OnPropertyChanged();
            }
        }

        private BitmapImage _lastImage;
        public BitmapImage LastImage
        {
            get { return _lastImage; }
            set
            {
                _lastImage = value;
                OnPropertyChanged();
            }
        }

        public MyCommand CopyCommand { get; set; }
        public MyCommand CopyAndRemoveCommand { get; set; }
        public MyCommand RemoveCommand { get; set; }

        private void InitCommand()
        {
            RemoveCommand = new MyCommand(arg =>
            {
                FileCopyHelper.Remove(this.Select(x => x.Path));

                Changed?.Invoke(this, EventArgs.Empty);
            });

            CopyCommand = new MyCommand(async arg =>
            {
                var files = await FileCopyHelper.Copy(this, UserSelection.SelectedPassenger);

                Changed?.Invoke(this, EventArgs.Empty);
            });

            CopyAndRemoveCommand = new MyCommand(async arg =>
            {
                FirstPath = null;
                LastPath = null; 
                var files = await FileCopyHelper.CopyAndRemove(this, UserSelection.SelectedPassenger);

                Changed?.Invoke(this, EventArgs.Empty);
            });
        }

        #region INotifyProertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }

    public delegate void ChangedEventHandler(object sender, EventArgs e);

}

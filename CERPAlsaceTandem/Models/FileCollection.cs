using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CERPAlsaceTandem.Annotations;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Models
{
    public abstract class FileCollection<T> : List<T>, INotifyPropertyChanged where T : FileViewModel
    {

        protected FileCollection(List<T> list)
        {
            this.AddRange(list);
            var first = list.OrderBy(x => x.Date).FirstOrDefault();
            var last = list.OrderBy(x => x.Date).LastOrDefault();
            FirstDate = first?.Date ?? DateTime.MinValue;
            LastDate = last?.Date ?? DateTime.MinValue;
            FirstPath = first?.Path;
            LastPath = last?.Path;
            InitCommand();
        }

        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public string FirstPath { get; set; }
        public string LastPath { get; set; }

        public MyCommand CopyCommand { get; set; }
        public MyCommand CopyAndRemoveCommand { get; set; }

        private void InitCommand()
        {
            CopyCommand = new MyCommand(null, async () =>
            {
                var files = await FileCopyHelper.Copy(this, UserSelection.SelectedPassenger);
                if(typeof(T) == typeof(PhotoFileViewModel))
                    UserSelection.SelectedPassenger.PhotoCount += files.Count;
                else
                    UserSelection.SelectedPassenger.VideoCount += files.Count;
            });

            CopyAndRemoveCommand = new MyCommand(null, async () =>
            {
                FirstPath = null;
                LastPath = null; 
                var files = await FileCopyHelper.CopyAndRemove(this, UserSelection.SelectedPassenger);
                if (typeof(T) == typeof(PhotoFileViewModel))
                    UserSelection.SelectedPassenger.PhotoCount += files.Count;
                else
                    UserSelection.SelectedPassenger.VideoCount += files.Count;
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


}

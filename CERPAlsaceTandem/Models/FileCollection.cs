using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Models
{
    public abstract class FileCollection<T> : List<T> where T : FileViewModel
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

        private void InitCommand()
        {
            CopyCommand = new MyCommand(null, async () =>
            {
                var count = await FileCopyHelper.Copy(this, UserSelection.SelectedPassenger);
                if(typeof(T) == typeof(PhotoFileViewModel))
                    UserSelection.SelectedPassenger.PhotoCount += count;
                else
                    UserSelection.SelectedPassenger.VideoCount += count;
            });
        }
    }


}

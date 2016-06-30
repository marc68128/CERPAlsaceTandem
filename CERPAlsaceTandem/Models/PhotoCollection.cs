using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Models
{
    public class PhotoCollection : FileCollection<PhotoFileViewModel>
    {
        public PhotoCollection(List<PhotoFileViewModel> list) : base(list)
        {
            InitCommand();
        }

        public MyCommand CopyCommand { get; set; }

        private void InitCommand()
        {
            CopyCommand = new MyCommand(null, () =>
            {
                if (UserSelection.SelectedPassenger.IsPhoto)
                {
                    foreach (var file in this)
                    {
                        var newfile = Path.Combine(UserSelection.SelectedPassenger.PhotoPath, Path.GetFileName(file.Path));
                        if (!File.Exists(newfile))
                            File.Copy(file.Path, newfile);
                    }
                }
                else if (MessageBox.Show("Pas de prestation photo", "Attention ! \nLe passager n'a pas payé la préstation photo, souhaitez vous quand même copier les photos ?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var folder =
                        Directory.CreateDirectory(Path.Combine(UserSelection.SelectedPassenger.RootPath,
                            "Photos-NonPayées"));
                    ProgressWindow progress = new ProgressWindow();
                    progress.Show();
                    foreach (var file in this)
                    {
                        var newfile = Path.Combine(folder.FullName, Path.GetFileName(file.Path));
                        if (!File.Exists(newfile))
                            File.Copy(file.Path, newfile);
                    }
                    progress.Hide();
                }

            });
        }
    }
}

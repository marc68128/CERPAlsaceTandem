using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CERPAlsaceTandem.Models;
using CERPAlsaceTandem.Properties;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Helpers
{
    public static class FileCopyHelper
    {
        public static async Task<int> Copy<T>(FileCollection<T> files, PassengerViewModel passenger) where T : FileViewModel
        {
            var isPhoto = typeof(T) == typeof(PhotoFileViewModel);

            if (isPhoto)
            {
                if (UserSelection.SelectedPassenger.IsPhoto)
                {
                    return await CopyPrivate(files, passenger.PhotoPath);
                }
                if (MessageBox.Show("Attention ! \nLe passager n'a pas payé la préstation photo, souhaitez vous quand même copier les photos ?", "Pas de prestation photo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var folderPath = Path.Combine(UserSelection.SelectedPassenger.RootPath, "Photos-NonPayées");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    return await CopyPrivate(files, folderPath);
                }
            }
            else
            {
                if (UserSelection.SelectedPassenger.IsVideo)
                {
                    return await CopyPrivate(files, passenger.VideoPath);
                }
                if (MessageBox.Show("Attention ! \nLe passager n'a pas payé la préstation vidéo, souhaitez vous quand même copier les vidéos ?", "Pas de prestation vidéo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var folderPath = Path.Combine(UserSelection.SelectedPassenger.RootPath, "Vidéo-NonPayées");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    return await CopyPrivate(files, folderPath);
                }
            }
            
            return await Task.Run(() => 0);

        }

        private static async Task<int> CopyPrivate<T>(FileCollection<T> files, string destination) where T : FileViewModel
        {
            ProgressWindow progress = new ProgressWindow();
            progress.Show();
            return await Task.Run(() =>
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    var percentage = ((i + 1) * 100) / files.Count;
                    FileInfo f = new FileInfo(file.Path);

                    var currentAction = "Copie de " + Path.GetFileName(file.Path) + " (" + f.Length + ") en cours...";

                    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        progress.FileProgress = 0;
                        progress.TotalProgress = percentage;
                        progress.FileProgressText = currentAction;
                    }));
                    

                    var newfile = Path.Combine(destination, Path.GetFileName(file.Path));

                    if (File.Exists(newfile))
                    {
                        if ((bool) Settings.Default["ReplaceFile"])
                            File.Delete(newfile);
                        else
                            continue;
                    }

                    byte[] buffer = new byte[1024 * 1024]; // 1MB buffer


                    using (FileStream source = new FileStream(file.Path, FileMode.Open, FileAccess.Read))
                    {
                        long fileLength = source.Length;
                        using (FileStream dest = new FileStream(newfile, FileMode.Create, FileAccess.Write))
                        {
                            long totalBytes = 0;
                            int currentBlockSize = 0;

                            while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                totalBytes += currentBlockSize;
                                Application.Current.Dispatcher.BeginInvoke((Action)(() => progress.FileProgress = Convert.ToInt32(Math.Round((double)totalBytes * 100.0 / fileLength))));

                                dest.Write(buffer, 0, currentBlockSize);

                            }
                        }
                    }


                }
                Application.Current.Dispatcher.BeginInvoke((Action)(() => progress.Hide()));

                return files.Count;
            });

        }
    }
}

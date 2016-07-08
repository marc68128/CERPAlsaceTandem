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

        public static void Remove(IEnumerable<string> filesToRemove)
        {
            foreach (var file in filesToRemove)
            {
                File.Delete(file);
                if (Directory.GetFileSystemEntries(Path.GetDirectoryName(file)).Length == 0)
                    Directory.Delete(Path.GetDirectoryName(file));
            }
        }

        public static async Task<List<string>> CopyAndRemove(FileCollection files, PassengerViewModel passenger)
        {
            var filesToRemove = await Copy(files, passenger);
            Remove(filesToRemove);
            return filesToRemove;
        }

        public static async Task<List<string>> Copy(FileCollection files, PassengerViewModel passenger)
        {
            if (files.FileType == FileType.Photo)
            {
                if (UserSelection.SelectedPassenger.IsPhoto)
                {
                    return await Copy(files, passenger.PhotoPath);
                }
                if (MessageBox.Show("Attention ! \nLe passager n'a pas payé la préstation photo, souhaitez vous quand même copier les photos ?", "Pas de prestation photo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var folderPath = Path.Combine(UserSelection.SelectedPassenger.RootPath, "Photos-NonPayées");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    return await Copy(files, folderPath);
                }
            }
            else
            {
                if (UserSelection.SelectedPassenger.IsVideo)
                {
                    return await Copy(files, passenger.VideoPath);
                }
                if (MessageBox.Show("Attention ! \nLe passager n'a pas payé la préstation vidéo, souhaitez vous quand même copier les vidéos ?", "Pas de prestation vidéo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var folderPath = Path.Combine(UserSelection.SelectedPassenger.RootPath, "Vidéo-NonPayées");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    return await Copy(files, folderPath);
                }
            }

            return await Task.Run(() => new List<string>());

        }

        private static async Task<List<string>> Copy(FileCollection files, string destination) 
        {
            ProgressWindow progress = new ProgressWindow();
            progress.Show();
            return await Task.Run(() =>
            {
                List<string> copiedFiles = new List<string>();
                for (int i = 0; i < files.Count; i++)
                {
                    var fileVM = files[i];
                    int percentage = (i) * 100 / files.Count;
                    string currentAction = "Copie de " + Path.GetFileName(fileVM.Path) + " en cours...";
                    string newFilePath = Path.Combine(destination, Path.GetFileName(fileVM.Path));

                    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        progress.FileProgress = 0;
                        progress.TotalProgress = percentage;
                        progress.FileProgressText = currentAction;
                    }));


                    if (File.Exists(newFilePath))
                    {
                        if ((bool)Settings.Default["ReplaceFile"])
                            File.Delete(newFilePath);
                        else
                            continue;
                    }

                    byte[] buffer = new byte[1024 * 1024];

                    using (FileStream source = new FileStream(fileVM.Path, FileMode.Open, FileAccess.Read))
                    using (FileStream dest = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                    {
                        long totalBytes = 0;
                        int currentBlockSize;

                        while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            totalBytes += currentBlockSize;
                            var fileProgress = Convert.ToInt32(Math.Round((double)totalBytes * 100.0 / source.Length));
                            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                            {
                                progress.FileProgress = fileProgress;

                                progress.TotalProgress = percentage + (fileProgress / files.Count);
                            }));
                            dest.Write(buffer, 0, currentBlockSize);
                        }
                    }

                    //Check if file has been copied
                    if (File.Exists(newFilePath))
                        copiedFiles.Add(fileVM.Path);

                }
                Application.Current.Dispatcher.BeginInvoke((Action)(() => progress.Hide()));

                return copiedFiles;
            });

        }


    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.Properties;
using CERPAlsaceTandem.Views;
using Microsoft.WindowsAPICodePack.Shell;

namespace CERPAlsaceTandem.ViewModels
{
    public class InsertDiskViewModel : BaseViewModel
    {
        private string _rootPath;
        public InsertDiskViewModel()
        {
            _rootPath = Settings.Default["Path"].ToString();

            if (string.IsNullOrWhiteSpace(_rootPath))
                BreadcrumbHelper.GotoPage(new NoPathPage());

            SelectedPassenger = UserSelection.SelectedPassenger; 

            Drives = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable).ToList();
            ListenDrive();

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SelectedDrive")
                {
                    DriveInfo info = new DriveInfo(SelectedDrive);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        BreadcrumbHelper.GotoPage(new DrivePage(info));
                    });
                }
            };
        }


        public PassengerViewModel SelectedPassenger { get; set; }

        private async void ListenDrive()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    var drives = DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable).ToList();
                    if (drives.Count > _drives.Count)
                    {
                        var addedDrive = drives.Except(_drives).First();
                        Drives = drives;
                        SelectedDrive = addedDrive.RootDirectory.FullName;
                    }
                    if (drives.Count < _drives.Count)
                    {
                        Drives = drives;
                    }
                }
            });
        }

        private List<DriveInfo> _drives;
        public List<DriveInfo> Drives
        {
            get { return _drives; }
            set
            {
                _drives = value;
                OnPropertyChanged();
            }
        }

        private string _selectedDrive;
        public string SelectedDrive
        {
            get { return _selectedDrive; }
            set
            {
                _selectedDrive = value;
                OnPropertyChanged();
            }
        }

    }
}

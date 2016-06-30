using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.WindowsAPICodePack.Dialogs;
using Path = System.Windows.Shapes.Path;

namespace CERPAlsaceTandem.UserControls
{
    /// <summary>
    /// Logique d'interaction pour FolderPicker.xaml
    /// </summary>
    public partial class FolderPicker : UserControl
    {
        public FolderPicker()
        {
            InitializeComponent();
            this.Loaded += (sender, args) => TextBox.Text = Folder;
        }

        public static readonly DependencyProperty FolderProperty = DependencyProperty.Register("Folder", typeof(string), typeof(FolderPicker));

        public string Folder
        {
            get { return (string)GetValue(FolderProperty); }
            set { SetValue(FolderProperty, value); }
        }


        private void OpenFolderPicker(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                EnsurePathExists = true,
                EnsureFileExists = false,
                IsFolderPicker = true,
                AllowNonFileSystemItems = false,
                DefaultFileName = "Select Folder",
                Title = "Select The Folder To Process"
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Folder = dialog.FileName;
                TextBox.Text = Folder;
            }
        }
    }
}

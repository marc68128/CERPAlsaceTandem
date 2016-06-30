using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CERPAlsaceTandem.Annotations;

namespace CERPAlsaceTandem
{
    /// <summary>
    /// Logique d'interaction pour ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window, INotifyPropertyChanged
    {



        public ProgressWindow()
        {
            InitializeComponent();
            PropertyChanged += (sender, args) =>
            {
                switch (args.PropertyName)
                {
                    case "TotalProgress":
                        //Debug.WriteLine(TotalProgress);
                        TotalProgressBar.Value = TotalProgress;
                        break;

                    case "FileProgress":
                        FileProgressBar.Value = FileProgress;
                        break;
                    case "FileProgressText":
                        FileText.Text = FileProgressText;
                        break;
                }
            };
        }

        private int _totalProgress;
        public int TotalProgress
        {
            get { return _totalProgress; }
            set
            {
                _totalProgress = value;
                OnPropertyChanged();
            }
        }

        private int _fileProgress;
        public int FileProgress
        {
            get { return _fileProgress; }
            set
            {
                _fileProgress = value;
                OnPropertyChanged();
            }
        }

        private string _fileProgressText;
        public string FileProgressText
        {
            get { return _fileProgressText; }
            set
            {
                _fileProgressText = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}

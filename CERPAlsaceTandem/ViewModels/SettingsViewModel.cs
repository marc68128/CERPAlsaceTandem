using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CERPAlsaceTandem.Properties;
using MahApps.Metro;

namespace CERPAlsaceTandem.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        
        public SettingsViewModel()
        {
            Path = Settings.Default["Path"].ToString();
            SelectedTheme = Settings.Default["AppTheme"].ToString();
            SelectedAccent = Settings.Default["ThemeAccent"].ToString();

            ThemeAccents = new[]
            {
                "Red", "Green", "Blue", "Purple", "Orange", "Lime", "Emerald", "Teal", "Cyan", "Cobalt", "Indigo", "Violet",
                "Pink", "Magenta", "Crimson", "Amber", "Yellow", "Brown", "Olive", "Steel", "Mauve", "Taupe", "Sienna"
            };

            Themes = new[] { "BaseLight", "BaseDark" };

            PropertyChanged += (sender, args) =>
            {
                switch (args.PropertyName)
                {
                    case "SelectedAccent":
                    case "SelectedTheme":
                        ThemeManager.ChangeAppStyle(Application.Current,
                            ThemeManager.GetAccent(SelectedAccent),
                            ThemeManager.GetAppTheme(SelectedTheme));

                        Settings.Default["AppTheme"] = SelectedTheme;
                        Settings.Default["ThemeAccent"] = SelectedAccent;
                        Settings.Default.Save();
                        break;
                    case "Path":
                        Settings.Default["Path"] = Path;
                        Settings.Default.Save();
                        break;
                }
            }; 
        }

        private string _selectedAccent;
        public string SelectedAccent
        {
            get { return _selectedAccent; }
            set
            { 
                _selectedAccent = value;
                OnPropertyChanged();
            }
        }

        private string _selectedTheme;
        public string SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                _selectedTheme = value;
                OnPropertyChanged();
            }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }


        public string[] ThemeAccents { get; set; }
        public string[] Themes { get; set; }

    }
}

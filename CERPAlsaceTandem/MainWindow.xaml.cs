using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.Properties;
using CERPAlsaceTandem.Views;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace CERPAlsaceTandem
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var appTheme = Settings.Default["AppTheme"].ToString();
            var themeAccent = Settings.Default["ThemeAccent"].ToString();
            var path = Settings.Default["Path"].ToString(); 

            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(themeAccent), ThemeManager.GetAppTheme(appTheme));

            BreadcrumbHelper.MainWindow = this;
            if (!string.IsNullOrWhiteSpace(path))
                BreadcrumbHelper.GotoPage(new PassengersView());
            else
                BreadcrumbHelper.GotoPage(new NoPathPage());

        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            BreadcrumbHelper.GotoPage(new SettingsPage());
        }
    }
}

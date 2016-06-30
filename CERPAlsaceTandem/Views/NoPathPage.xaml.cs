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

namespace CERPAlsaceTandem.Views
{
    /// <summary>
    /// Logique d'interaction pour NoPathPage.xaml
    /// </summary>
    public partial class NoPathPage : Page
    {
        public NoPathPage()
        {
            InitializeComponent();
            var path = Settings.Default["Path"].ToString();
            if (!string.IsNullOrWhiteSpace(path))
                BreadcrumbHelper.GotoPage(new InsertDiskPage());
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            BreadcrumbHelper.GotoPage(new SettingsPage());
        }
    }
}

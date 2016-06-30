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
using System.Windows.Shapes;
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.Views
{
    /// <summary>
    /// Logique d'interaction pour DrivePage.xaml
    /// </summary>
    public partial class DrivePage : Page
    {
        public DrivePage(DriveInfo d)
        {
            InitializeComponent();
            DataContext = new DriveViewModel(d);
        }
    }
}

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
using CERPAlsaceTandem.ViewModels;
using MahApps.Metro.Controls.Dialogs;

namespace CERPAlsaceTandem.Views
{
    /// <summary>
    /// Logique d'interaction pour PassengerView.xaml
    /// </summary>
    public partial class PassengersView : Page
    {
        public PassengersView()
        {
            InitializeComponent();
            DataContext = new PassengersViewModel();
        }
    }
}

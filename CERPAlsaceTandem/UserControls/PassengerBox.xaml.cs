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
using CERPAlsaceTandem.ViewModels;

namespace CERPAlsaceTandem.UserControls
{
    /// <summary>
    /// Logique d'interaction pour PassengerBox.xaml
    /// </summary>
    public partial class PassengerBox : UserControl
    {
        public PassengerBox()
        {
            InitializeComponent();
        }

        private void OpenPhotoFolder(object sender, MouseButtonEventArgs e)
        {
            (DataContext as PassengerViewModel).OpenPhotoFolderCommand.Execute(null);
        }
    }
}

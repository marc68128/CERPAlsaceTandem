using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CERPAlsaceTandem.Annotations;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.Views;

namespace CERPAlsaceTandem.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            GoBackCommand = new MyCommand(null, () => BreadcrumbHelper.GoBack());
            GoToPassengerSelectionCommand = new MyCommand(null, () => BreadcrumbHelper.GotoPage(new PassengersView()));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand GoBackCommand { get; set; }
        public ICommand GoToPassengerSelectionCommand { get; set; }
    }
}

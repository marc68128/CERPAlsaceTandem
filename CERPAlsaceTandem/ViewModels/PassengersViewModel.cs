using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CERPAlsaceTandem.Helpers;
using CERPAlsaceTandem.Properties;
using CERPAlsaceTandem.Views;

namespace CERPAlsaceTandem.ViewModels
{
    public class PassengersViewModel : BaseViewModel
    {
        private readonly List<PassengerViewModel> _unfilteredPassengers; 
        public PassengersViewModel()
        {
            _unfilteredPassengers = Directory.GetDirectories(Settings.Default["Path"].ToString()).Select(p => new PassengerViewModel(p)).ToList();
            Passengers = _unfilteredPassengers;
            ShowPhoto = true;
            ShowVideo = true; 

            ListenPropertyChanged();
        }

        private PassengerViewModel _selectedPassenger;
        public PassengerViewModel SelectedPassenger
        {
            get { return _selectedPassenger; }
            set
            {
                _selectedPassenger = value;
                OnPropertyChanged();
            }
        }


        private List<PassengerViewModel> _passengers;   
        public List<PassengerViewModel> Passengers
        {
            get { return _passengers; }
            set
            {
                _passengers = value;
                OnPropertyChanged();
            }
        }

        private bool _showPhoto;
        public bool ShowPhoto
        {
            get { return _showPhoto; }
            set
            {
                _showPhoto = value;
                OnPropertyChanged();
            }
        }

        private bool _showVideo;
        public bool ShowVideo
        {
            get { return _showVideo; }
            set
            {
                _showVideo = value;
                OnPropertyChanged();
            }
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged();
            }
        }

        private void ListenPropertyChanged()
        {
            PropertyChanged += (sender, args) =>
            {
                switch (args.PropertyName)
                {
                    case "SelectedPassenger":
                        UserSelection.SelectedPassenger = SelectedPassenger;
                        CheckPassengerFolders(SelectedPassenger);
                        BreadcrumbHelper.GotoPage(new InsertDiskPage());
                        break;
                    case "ShowPhoto":
                    case "ShowVideo":
                    case "SearchTerm":
                        Passengers =
                            _unfilteredPassengers
                            .Where(x => (x.IsPhoto == ShowPhoto && x.IsVideo == ShowVideo) || (ShowPhoto == ShowVideo))
                            .Where(x => string.IsNullOrWhiteSpace(SearchTerm) || x.FullName.ToLower().Contains(SearchTerm.ToLower()))
                            .ToList();
                        break;
                }
            };
        }

        private void CheckPassengerFolders(PassengerViewModel passenger)
        {
            if (passenger.IsPhoto && !passenger.PhotoFolderExist)
            {
                Directory.CreateDirectory(passenger.PhotoPath);
            }
            if (passenger.IsVideo && !passenger.VideoFolderExist)
            {
                Directory.CreateDirectory(passenger.VideoPath);
            }
        }
    }
}

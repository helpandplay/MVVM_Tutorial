using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MVVM_Tutorial.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        //public ICommand MakeReservationCommand { get; private set; }

        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
        }
    }
}

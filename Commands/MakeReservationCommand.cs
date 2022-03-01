using MVVM_Tutorial.Execptions;
using MVVM_Tutorial.Models;
using MVVM_Tutorial.Services;
using MVVM_Tutorial.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace MVVM_Tutorial.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly Hotel _hotel;
        private readonly NavigationService _reservationViewNavigationService;
        private readonly MakeReservationViewModel _makeReservationViewModel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel,
            NavigationService reservationViewNavigationService)
        {
            _hotel = hotel;
            _reservationViewNavigationService = reservationViewNavigationService;
            _makeReservationViewModel = makeReservationViewModel;

            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_makeReservationViewModel.UserName) ||
                 e.PropertyName == nameof(_makeReservationViewModel.FloorNumber) ||
                 e.PropertyName == nameof(_makeReservationViewModel.FloorNumber))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            bool isUserName = !string.IsNullOrEmpty(_makeReservationViewModel.UserName);
            bool isFloorNumber = _makeReservationViewModel.FloorNumber > 0;
            bool isRoomNumber = _makeReservationViewModel.RoomNumber > 0;
            bool result = isUserName &&
                isFloorNumber &&
                isRoomNumber &&
                base.CanExecute(parameter);
            return result;
        }
        public override void Execute(object? parameter)
        {
            var reservation = new Reservation(
                    new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                    _makeReservationViewModel.UserName,
                    _makeReservationViewModel.StartDate,
                    _makeReservationViewModel.EndDate
                );
            try
            {
                _hotel.MakeReservation(reservation);
                MessageBox.Show("This room is Successfully taken.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}

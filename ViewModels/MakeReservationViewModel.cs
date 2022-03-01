using MVVM_Tutorial.Commands;
using MVVM_Tutorial.Models;
using MVVM_Tutorial.Services;
using System;
using System.Windows.Input;

namespace MVVM_Tutorial.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        #region Property
        private string _username = string.Empty;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private int _roomNumber;
        public int RoomNumber
        {
            get
            {
                return _roomNumber;
            }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        private int _floorNumber;
        public int FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        private DateTime _startDate = new DateTime(DateTime.Now.Ticks);
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate = new DateTime(DateTime.Now.Ticks).Add(new TimeSpan(1, 0, 0, 0));
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        #endregion

        public ICommand SubmitCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public MakeReservationViewModel(Hotel hotel, NavigationService reservationViewNavigationService)
        {
            // Service객체들을 Command를 생성할 때, 할당해준다.
            // Command들은 자신이 호출될 때, 할당되었던 Service에 대해 로직을 수행한다.

            // SubmitCommand는 생성될 때, 
            SubmitCommand = new MakeReservationCommand(this, hotel, reservationViewNavigationService);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
        }
    }
}

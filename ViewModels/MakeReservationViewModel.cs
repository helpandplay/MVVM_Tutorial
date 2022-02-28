using System;
using System.Windows.Input;

namespace MVVM_Tutorial.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private string _username;

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

        private DateTime _startTime;
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private DateTime _endTime;
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }

        public ICommand SubmitCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public MakeReservationViewModel()
        {

        }
    }
}

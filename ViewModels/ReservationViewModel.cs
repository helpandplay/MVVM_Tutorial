using MVVM_Tutorial.Models;

namespace MVVM_Tutorial.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;

        public string? RoomID => _reservation.RoomID?.ToString(); // view에서는 string으로 보여질 것이므로 타입이 string이다
        public string UserName => _reservation.UserName.ToString();
        public string StartDate => _reservation.StartTime.Date.ToString("yyyy-MM-dd HH:mm::ss");
        public string EndDate => _reservation.EndTime.Date.ToString("yyyy-MM-dd HH:mm::ss");

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}

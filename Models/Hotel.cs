using MVVM_Tutorial.Execptions;
using System.Collections.Generic;

namespace MVVM_Tutorial.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; }

        public Hotel(string name)
        {
            Name = name;
            _reservationBook = new ReservationBook();
        }

        /// <summary>
        /// 유저의 정보로부터 예약들을 가져옵니다.
        /// </summary>
        /// <param name="username">유저의 이름</param>
        /// <returns>유저가 예약한 예약 목록</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }
        /// <summary>
        /// 예약을 합니다.
        /// </summary>
        /// <param name="reservation">신청한 예약</param>
        /// <exception cref="ReservationConflictException"></exception>
        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}

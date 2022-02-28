using System;

namespace MVVM_Tutorial.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public string UserName { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Reservation(RoomID roomID, string username, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            StartTime = startTime;
            EndTime = endTime;
            UserName = username;
        }

        public bool Conflicts(Reservation reservation)
        {
            //예약한 방 번호와 실제 방 번호가 일치 하지 않음
            if (reservation.RoomID != RoomID)
            {
                return false;
            }

            // 기존 방에 예약 시간 ex) AM 10:00 ~ PM 6:00
            // 새로운 예약 시간 ex) PM 6:00 ~ PM 10:00
            return reservation.StartTime < EndTime || reservation.EndTime > StartTime;
        }
    }
}

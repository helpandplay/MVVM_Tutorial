﻿using System;

namespace MVVM_Tutorial.Models
{
    public class RoomID
    {
        public int FloorNumber { get; }
        public int RoomNumber { get; }

        public override string ToString()
        {
            return $"{FloorNumber}-{RoomNumber}";
        }
        public override bool Equals(object? obj)
        {
            // 안에 있는 속성값을 다 대조하면서 일치 여부 확인
            return obj is RoomID roomID &&
                FloorNumber == roomID.FloorNumber &&
                RoomNumber == roomID.RoomNumber;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, RoomNumber);
        }

        public static bool operator ==(RoomID? roomID1, RoomID? roomID2)
        {
            if (roomID1 is null && roomID2 is null) return true;

            return roomID1 is not null && roomID1.Equals(roomID2);
        }
        public static bool operator !=(RoomID? roomID1, RoomID? roomID2)
        {
            return !(roomID1 == roomID2);
        }

        public RoomID(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }
    }
}

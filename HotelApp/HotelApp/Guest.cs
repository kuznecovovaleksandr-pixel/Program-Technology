using System;

namespace HotelApp
{
    public class Guest
    {
        //Свойства
        public int Id { get; set; }
        public string FullName { get; set; }
        public int RoomId { get; set; }
        public string Passport { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Guest() { }

        public Guest(int id, string fullName, int roomId, string passport, DateTime checkIn, DateTime checkOut)
            //Конструктор 
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("ФИО не может быть пустым.", nameof(fullName));
            if (string.IsNullOrWhiteSpace(passport))
                throw new ArgumentException("Паспорт не может быть пустым.", nameof(passport));
            if (checkOut < checkIn)
                throw new ArgumentException("Дата выезда не может быть раньше даты заезда.");

            Id = id;
            FullName = fullName;
            RoomId = roomId;
            Passport = passport;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        //Особенное свойство StayDays
        public int StayDays
        {
            get
            {
                int days = (CheckOut - CheckIn).Days;
                return days < 0 ? 0 : days;
            }
        }
        //Метод
        public string GetInfo() => $"{FullName} ({StayDays} дня)";
    }
}
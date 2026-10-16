using System;

namespace HotelApp
{
    public class Room
    {
        //Свойства
        public int Id { get; set; }
        public string Number { get; set; }
        public int FloorId { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }

        public Room() { }

        public Room(int id, string number, int floorId, string type, decimal price, int capacity)

            //Конструктор 
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Номер комнаты не может быть пустым.", nameof(number));
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Тип комнаты не может быть пустым.", nameof(type));
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Цена не может быть отрицательной.");
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Вместимость должна быть больше нуля.");

            Id = id;
            Number = number;
            FloorId = floorId;
            Type = type;
            Price = price;
            Capacity = capacity;
        }


        //Свойство и методы 
        public bool IsLux => Type == "Люкс";

        public decimal GetTotalPrice(int days)
        {
            if (days <= 0) return 0;
            return Price * days;
        }

        public string GetInfo() => $"{Number} ({Type.ToLower()}, {Price} руб./сутки)";
    }
}
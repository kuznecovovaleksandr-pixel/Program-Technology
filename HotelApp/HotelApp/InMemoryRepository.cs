using System;
using System.Collections.Generic;

namespace HotelApp
{
    public class InMemoryRepository
    {
        //Поля(что хранит склад)
        private List<Floor> _floors;
        private List<Room> _rooms;
        private List<Guest> _guests;

        //Конструктор - заполнение данными 
        public InMemoryRepository()
        {
            _floors = new List<Floor>
            {
                new Floor { Id = 1, Number = 1, Description = "стандарт" },
                new Floor { Id = 2, Number = 3, Description = "стандарт" },
                new Floor { Id = 3, Number = 4, Description = "стандарт" },
                new Floor { Id = 4, Number = 5, Description = "люкс" },
                new Floor { Id = 5, Number = 6, Description = "люкс" }
            };

            _rooms = new List<Room>
            {
                new Room { Id = 1, Number = "305", FloorId = 2, Type = "Люкс",    Price = 5000, Capacity = 2 },
                new Room { Id = 2, Number = "401", FloorId = 3, Type = "Стандарт", Price = 3000, Capacity = 1 },
                new Room { Id = 3, Number = "502", FloorId = 4, Type = "Люкс",    Price = 7000, Capacity = 3 },
                new Room { Id = 4, Number = "101", FloorId = 1, Type = "Стандарт", Price = 2500, Capacity = 2 },
                new Room { Id = 5, Number = "601", FloorId = 5, Type = "Люкс",    Price = 9000, Capacity = 4 }
            };

            _guests = new List<Guest>
            {
                new Guest { Id = 1, FullName = "Иванов И.И.",  RoomId = 1, Passport = "1234 567890", CheckIn = new DateTime(2025, 9, 1), CheckOut = new DateTime(2025, 9, 4) },
                new Guest { Id = 2, FullName = "Петров П.П.",  RoomId = 1, Passport = "2345 678901", CheckIn = new DateTime(2025, 9, 2), CheckOut = new DateTime(2025, 9, 5) },
                new Guest { Id = 3, FullName = "Сидоров С.С.", RoomId = 2, Passport = "3456 789012", CheckIn = new DateTime(2025, 9, 3), CheckOut = new DateTime(2025, 9, 6) },
                new Guest { Id = 4, FullName = "Орлов А.А.",   RoomId = 3, Passport = "4567 890123", CheckIn = new DateTime(2025, 9, 4), CheckOut = new DateTime(2025, 9, 9) },
                new Guest { Id = 5, FullName = "Соколов П.П.", RoomId = 3, Passport = "5678 901234", CheckIn = new DateTime(2025, 9, 5), CheckOut = new DateTime(2025, 9, 8) }
            };
        }


        //Методы - геттеры
        public List<Floor> GetFloors()
        {
            if (_floors == null) throw new InvalidOperationException("Список этажей не инициализирован.");
            return _floors;
        }

        public List<Room> GetRooms()
        {
            if (_rooms == null) throw new InvalidOperationException("Список комнат не инициализирован.");
            return _rooms;
        }

        public List<Guest> GetGuests()
        {
            if (_guests == null) throw new InvalidOperationException("Список гостей не инициализирован.");
            return _guests;
        }
    }
}
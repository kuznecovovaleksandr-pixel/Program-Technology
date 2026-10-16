using System;
using System.Collections.Generic;
using System.IO;

namespace HotelApp
{
    public class CsvRepository
    {
        //Поле и конструтор 
        private string _basePath;

        public CsvRepository(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("Путь к папке данных не может быть пустым.", nameof(basePath));
            _basePath = basePath;
        }

        public List<Floor> GetFloors()
            //Метод GetFloors() пошагово 
        {
            List<Floor> result = new List<Floor>();
            string path = Path.Combine(_basePath, "floors.csv");
            if (!File.Exists(path)) throw new FileNotFoundException($"Файл не найден: {path}");

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3) continue;

                result.Add(new Floor
                {
                    Id = int.Parse(parts[0]),
                    Number = int.Parse(parts[1]),
                    Description = parts[2]
                });
            }
            return result;
        }

        public List<Room> GetRooms()
        {
            List<Room> result = new List<Room>();
            string path = Path.Combine(_basePath, "rooms.csv");
            if (!File.Exists(path)) throw new FileNotFoundException($"Файл не найден: {path}");

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6) continue;

                result.Add(new Room
                {
                    Id = int.Parse(parts[0]),
                    Number = parts[1],
                    FloorId = int.Parse(parts[2]),
                    Type = parts[3],
                    //Отличия в GetRooms()
                    Price = decimal.Parse(parts[4]),
                    Capacity = int.Parse(parts[5])
                });
            }
            return result;
        }

        public List<Guest> GetGuests()
        {
            List<Guest> result = new List<Guest>();
            string path = Path.Combine(_basePath, "guests.csv");
            if (!File.Exists(path)) throw new FileNotFoundException($"Файл не найден: {path}");

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6) continue;

                result.Add(new Guest
                {
                    Id = int.Parse(parts[0]),
                    FullName = parts[1],
                    RoomId = int.Parse(parts[2]),
                    Passport = parts[3],
                    //Отличия в GetGuests()
                    CheckIn = DateTime.ParseExact(parts[4], "dd.MM.yyyy", null),
                    CheckOut = DateTime.ParseExact(parts[5], "dd.MM.yyyy", null)
                });
            }
            return result;
        }
    }
}
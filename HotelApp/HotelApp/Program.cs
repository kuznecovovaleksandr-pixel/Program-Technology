using System;
using System.Collections.Generic;

namespace HotelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                Console.WriteLine("Выберите источник данных:");
                Console.WriteLine("1 — InMemoryRepository");
                Console.WriteLine("2 — CsvRepository (папка data)");
                Console.Write("Ваш выбор: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Неверный выбор");
                    return;
                }

                List<Floor> floors;
                List<Room> rooms;
                List<Guest> guests;

                switch (choice)
                {
                    case 1:
                        {
                            InMemoryRepository repo = new InMemoryRepository();
                            floors = repo.GetFloors();
                            rooms = repo.GetRooms();
                            guests = repo.GetGuests();
                            break;
                        }
                    case 2:
                        {
                            CsvRepository repo = new CsvRepository("data");
                            floors = repo.GetFloors();
                            rooms = repo.GetRooms();
                            guests = repo.GetGuests();
                            break;
                        }
                    default:
                        Console.WriteLine("Неверный выбор");
                        return;
                }

                Console.WriteLine();

                Guest foundGuest = FindGuest(guests, rooms, "305");
                Console.WriteLine(foundGuest != null
                    ? $"1. FindGuest(\"305\"): {foundGuest.GetInfo()}"
                    : "1. FindGuest(\"305\"): не найдено");

                Room room305 = null;
                foreach (Room r in rooms)
                {
                    if (r.Number == "305") { room305 = r; break; }
                }
                Floor foundFloor = FindFloor(floors, room305);
                Console.WriteLine(foundFloor != null
                    ? $"2. FindFloor(room \"305\"): {foundFloor.GetInfo()}"
                    : "2. FindFloor(room \"305\"): не найдено");

                Console.WriteLine($"3. GetTotalPrice: {GetTotalPrice(rooms)} руб./сутки");

                Console.Write("4. GetRoomsWithGuests: ");
                Dictionary<string, int> dict = GetRoomsWithGuests(rooms, guests);
                bool first = true;
                foreach (KeyValuePair<string, int> kv in dict)
                {
                    if (!first) Console.Write(", ");
                    Console.Write($"{kv.Key} — {kv.Value}");
                    first = false;
                }
                Console.WriteLine();

                Console.WriteLine("5. PrintAllRooms:");
                PrintAllRooms(rooms, floors, guests);

                Guest notFound = FindGuest(guests, rooms, "999");
                Console.WriteLine(notFound == null
                    ? "\nНе найдено: FindGuest(\"999\") → null"
                    : $"\nНайдено: {notFound.GetInfo()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return;
            }
        }

        public static Guest FindGuest(List<Guest> guests, List<Room> rooms, string roomNumber)
        {
            if (guests == null) throw new ArgumentNullException(nameof(guests));
            if (rooms == null) throw new ArgumentNullException(nameof(rooms));
            if (string.IsNullOrWhiteSpace(roomNumber)) return null;

            Room foundRoom = null;
            foreach (Room r in rooms)
            {
                if (r.Number == roomNumber) { foundRoom = r; break; }
            }
            if (foundRoom == null) return null;

            foreach (Guest g in guests)
            {
                if (g.RoomId == foundRoom.Id) return g;
            }
            return null;
        }

        public static Floor FindFloor(List<Floor> floors, Room room)
        {
            if (floors == null) throw new ArgumentNullException(nameof(floors));
            if (room == null) return null;

            foreach (Floor f in floors)
            {
                if (f.Id == room.FloorId) return f;
            }
            return null;
        }

        public static decimal GetTotalPrice(List<Room> rooms)
        {
            if (rooms == null) throw new ArgumentNullException(nameof(rooms));

            decimal sum = 0;
            foreach (Room r in rooms) sum += r.Price;
            return sum;
        }

        public static Dictionary<string, int> GetRoomsWithGuests(List<Room> rooms, List<Guest> guests)
        {
            if (rooms == null) throw new ArgumentNullException(nameof(rooms));
            if (guests == null) throw new ArgumentNullException(nameof(guests));

            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (Room r in rooms)
            {
                int count = 0;
                foreach (Guest g in guests)
                {
                    if (g.RoomId == r.Id) count++;
                }
                if (count > 0) result[r.Number] = count;
            }
            return result;
        }

        public static void PrintAllRooms(List<Room> rooms, List<Floor> floors, List<Guest> guests)
        {
            if (rooms == null) throw new ArgumentNullException(nameof(rooms));
            if (floors == null) throw new ArgumentNullException(nameof(floors));
            if (guests == null) throw new ArgumentNullException(nameof(guests));

            foreach (Room r in rooms)
            {
                Floor f = null;
                foreach (Floor fl in floors)
                {
                    if (fl.Id == r.FloorId) { f = fl; break; }
                }

                int count = 0;
                foreach (Guest g in guests)
                {
                    if (g.RoomId == r.Id) count++;
                }

                string floorNumber = f != null ? f.Number.ToString() : "—";
                Console.WriteLine($"\"{r.GetInfo()}\" — этаж {floorNumber}, гостей: {count}");
            }
        }
    }
}
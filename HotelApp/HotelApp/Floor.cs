using System;

namespace HotelApp
{
    //Карточка Этаж
    public class Floor
    {
        //Свойства(что есть у этажа)
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }

        //Конструкторы
        public Floor() { }

        public Floor(int id, int number, string description)
        {
            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Номер этажа должен быть больше нуля.");
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Описание этажа не может быть пустым.", nameof(description));

            Id = id;
            Number = number;
            Description = description;
        }


        //Вычисляемые свойства и метод 
        public bool IsUpper => Number > 5;

        public string GetInfo() => $"{Number} этаж ({Description})";
    }
}
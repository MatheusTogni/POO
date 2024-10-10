using System;
using Interfaces;

namespace Classes
{
    public class Habitat : IHabitat
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Habitat(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}\nNome: {Name}\nDescrição: {Description}\n");
        }
    }
}
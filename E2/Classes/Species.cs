using System;
using Interfaces;

namespace Classes
{
    public class Species : ISpecies
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public IHabitat Habitat { get; set; }

        public Species(int id, string name, string status, IHabitat habitat = null)
        {
            Id = id;
            Name = name;
            Status = status;
            Habitat = habitat;
        }

        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Status da espécie {Name} alterado para: {Status}");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID da Espécie: {Id}");
            Console.WriteLine($"Nome: {Name}");
            Console.WriteLine($"Status: {Status}");
            if (Habitat != null)
            {
                Console.WriteLine($"ID do Habitat: {Habitat.Id}");
                Console.WriteLine($"Nome do Habitat: {Habitat.Name}");
                Console.WriteLine($"Descrição do Habitat: {Habitat.Description}");
            }
        }
    }
}

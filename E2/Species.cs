using System;

public class Species
{
    // Propriedades da espécie
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Status { get; set; } // Ativa ou Extinta
    public Habitat Habitat { get; set; }

    // Construtor
    public Species(int id, string name, string status, Habitat habitat = null)
    {
        Id = id;
        Name = name;
        Status = status;
        Habitat = habitat;
    }

    // Método para alterar o status da espécie
    public void ChangeStatus(string newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Status da espécie {Name} alterado para: {Status}");
    }

    // Método para exibir informações da espécie
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}\nNome: {Name}\nStatus: {Status}");
        if (Habitat != null)
        {
            Console.WriteLine("Habitat:");
            Habitat.DisplayInfo();
        }
    }
}

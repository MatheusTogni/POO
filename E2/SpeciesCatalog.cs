using System;
using System.Collections.Generic;

// Catálogo para gerenciar espécies marinhas
public class SpeciesCatalog
{
    private List<Species> speciesList;

    // Construtor
    public SpeciesCatalog()
    {
        speciesList = new List<Species>();
    }

    // Método para catalogar uma nova espécie
    public void CatalogSpecies(Species species)
    {
        speciesList.Add(species);
        Console.WriteLine($"Espécie {species.Name} catalogada com sucesso!\n");
    }

    // Método para buscar espécie pelo ID
    public Species GetSpeciesById(int id)
    {
        return speciesList.Find(s => s.Id == id);
    }

    // Método para verificar se um ID já está em uso
    public bool IsIdInUse(int id)
    {
        return speciesList.Exists(s => s.Id == id);
    }

    // Método para verificar se um nome já está em uso
    public bool IsNameInUse(string name)
    {
        return speciesList.Exists(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    // Método para buscar espécie pelo ID e exibir informações
    public void DisplaySpeciesById(int id)
    {
        Species species = GetSpeciesById(id);
        if (species != null)
        {
            species.DisplayInfo();
        }
        else
        {
            Console.WriteLine("Espécie não encontrada.\n");
        }
    }

    // Método para exibir todas as espécies catalogadas
    public void DisplayAllSpecies()
    {
        if (speciesList.Count == 0)
        {
            Console.WriteLine("Nenhuma espécie catalogada.\n");
        }
        else
        {
            foreach (Species species in speciesList)
            {
                species.DisplayInfo();
            }
        }
    }
}

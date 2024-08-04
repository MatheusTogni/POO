using System;
using System.Collections.Generic;

public class HabitatCatalog
{
    private List<Habitat> habitatList;

    public HabitatCatalog()
    {
        habitatList = new List<Habitat>();
    }

    public void CatalogHabitat(Habitat habitat)
    {
        habitatList.Add(habitat);
        Console.WriteLine($"Habitat {habitat.Name} catalogado com sucesso!\n");
    }

    public Habitat GetHabitatById(int id)
    {
        return habitatList.Find(h => h.Id == id);
    }

    public bool IsIdInUse(int id)
    {
        return habitatList.Exists(h => h.Id == id);
    }

    public bool IsNameInUse(string name)
    {
        return habitatList.Exists(h => h.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void DisplayAllHabitats()
    {
        if (habitatList.Count == 0)
        {
            Console.WriteLine("Nenhum habitat catalogado.\n");
        }
        else
        {
            foreach (Habitat habitat in habitatList)
            {
                habitat.DisplayInfo();
            }
        }
    }
}

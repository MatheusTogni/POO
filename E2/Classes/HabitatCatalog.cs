using System;
using System.Collections.Generic;
using Interfaces;

namespace Classes
{
    public class HabitatCatalog : IHabitatCatalog
    {
        private List<IHabitat> habitatList;

        public HabitatCatalog()
        {
            habitatList = new List<IHabitat>();
        }

        public void CatalogHabitat(IHabitat habitat)
        {
            habitatList.Add(habitat);
            Console.WriteLine($"Habitat {habitat.Name} catalogado com sucesso!\n");
        }

        public IHabitat GetHabitatById(int id)
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

        public List<IHabitat> GetAllHabitats()
        {
            return habitatList;
        }
    }
}
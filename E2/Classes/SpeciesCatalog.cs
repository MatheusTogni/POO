using System;
using System.Collections.Generic;
using Interfaces;

namespace Classes
{
    public class SpeciesCatalog : ISpeciesCatalog
    {
        private List<ISpecies> speciesList;

        public SpeciesCatalog()
        {
            speciesList = new List<ISpecies>();
        }

        public void CatalogSpecies(ISpecies species)
        {
            speciesList.Add(species);
            Console.WriteLine($"Espécie {species.Name} catalogada com sucesso!\n");
        }

        public ISpecies GetSpeciesById(int id)
        {
            return speciesList.Find(s => s.Id == id);
        }

        public bool IsIdInUse(int id)
        {
            return speciesList.Exists(s => s.Id == id);
        }

        public bool IsNameInUse(string name)
        {
            return speciesList.Exists(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<ISpecies> GetAllSpecies()
        {
            return speciesList;
        }
    }
}

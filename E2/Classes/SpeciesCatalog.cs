using System;
using System.Collections.Generic;

namespace Classes
{
    public class SpeciesCatalog
    {
        private List<Species> speciesList;

        public SpeciesCatalog()
        {
            speciesList = new List<Species>();
        }

        public void CatalogSpecies(Species species)
        {
            speciesList.Add(species);
            Console.WriteLine($"Espécie {species.Name} catalogada com sucesso!\n");
        }

        public Species GetSpeciesById(int id)
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

        // Adicionando o método para obter todas as espécies
        public List<Species> GetAllSpecies()
        {
            return speciesList;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Classes
{
    public class Report
    {
        private SpeciesCatalog speciesCatalog;
        private HabitatCatalog habitatCatalog;

        public Report(SpeciesCatalog speciesCatalog, HabitatCatalog habitatCatalog)
        {
            this.speciesCatalog = speciesCatalog;
            this.habitatCatalog = habitatCatalog;
        }

        public void DisplaySpeciesById(int id)
        {
            Species species = speciesCatalog.GetSpeciesById(id);
            if (species != null)
            {
                species.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Espécie não encontrada.\n");
            }
        }

        public void DisplayAllSpecies()
        {
            List<Species> speciesList = speciesCatalog.GetAllSpecies();
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

        public void DisplayAllHabitats()
        {
            List<Habitat> habitatList = habitatCatalog.GetAllHabitats();
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
}

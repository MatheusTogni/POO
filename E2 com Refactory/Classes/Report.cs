using System;
using System.Collections.Generic;
using Interfaces;

namespace Classes
{
    public class Report : IReport
    {
        private ISpeciesCatalog speciesCatalog;
        private IHabitatCatalog habitatCatalog;

        public Report(ISpeciesCatalog speciesCatalog, IHabitatCatalog habitatCatalog)
        {
            this.speciesCatalog = speciesCatalog;
            this.habitatCatalog = habitatCatalog;
        }

        public void DisplaySpeciesById(int id)
        {
            ISpecies species = speciesCatalog.GetSpeciesById(id);
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
            List<ISpecies> speciesList = speciesCatalog.GetAllSpecies();
            if (speciesList.Count == 0)
            {
                Console.WriteLine("Nenhuma espécie catalogada.\n");
            }
            else
            {
                foreach (ISpecies species in speciesList)
                {
                    species.DisplayInfo();
                }
            }
        }

        public void DisplayAllHabitats()
        {
            List<IHabitat> habitatList = habitatCatalog.GetAllHabitats();
            if (habitatList.Count == 0)
            {
                Console.WriteLine("Nenhum habitat catalogado.\n");
            }
            else
            {
                foreach (IHabitat habitat in habitatList)
                {
                    habitat.DisplayInfo();
                }
            }
        }

        public ISpeciesCatalog GetSpeciesCatalog()
        {
            return speciesCatalog;
        }
    }
}
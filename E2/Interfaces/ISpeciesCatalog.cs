using System.Collections.Generic;

namespace Interfaces
{
    public interface ISpeciesCatalog
    {
        void CatalogSpecies(ISpecies species);
        ISpecies GetSpeciesById(int id);
        bool IsIdInUse(int id);
        bool IsNameInUse(string name);
        List<ISpecies> GetAllSpecies();
    }
}

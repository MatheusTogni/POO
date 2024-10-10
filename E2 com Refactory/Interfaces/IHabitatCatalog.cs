using System.Collections.Generic;

namespace Interfaces
{
    public interface IHabitatCatalog
    {
        void CatalogHabitat(IHabitat habitat);
        IHabitat GetHabitatById(int id);
        bool IsIdInUse(int id);
        bool IsNameInUse(string name);
        List<IHabitat> GetAllHabitats();
    }
}
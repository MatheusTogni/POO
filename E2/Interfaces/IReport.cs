namespace Interfaces
{
    public interface IReport
    {
        void DisplaySpeciesById(int id);
        void DisplayAllSpecies();
        void DisplayAllHabitats();
        ISpeciesCatalog GetSpeciesCatalog();
    }
}
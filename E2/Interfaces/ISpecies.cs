namespace Interfaces
{
    public interface ISpecies
    {
        int Id { get; }
        string Name { get; set; }
        string Status { get; set; }
        IHabitat Habitat { get; set; }

        void ChangeStatus(string newStatus);
        void DisplayInfo();
    }
}
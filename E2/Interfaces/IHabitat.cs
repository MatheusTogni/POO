namespace Interfaces
{
    public interface IHabitat
    {
        int Id { get; }
        string Name { get; set; }
        string Description { get; set; }

        void DisplayInfo();
    }
}
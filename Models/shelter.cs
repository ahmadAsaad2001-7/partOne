
namespace petStoreProject.Models
{
    public class Shelter : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public Pet[] Pets { get; set; }
    }
}
namespace petStoreProject.Models
{
    public class Owner : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}

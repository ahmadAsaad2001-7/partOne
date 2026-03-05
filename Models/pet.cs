namespace petStoreProject.Models
{
    public class Pet : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string HealthStatus { get; set; }
    
        public string Personality { get; set; }
    }
}
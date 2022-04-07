namespace PetStoreConsoleApp
{
    public class Pet
    {
        public long Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string[] PhotoUrls { get; set; }
        public Tag[] Tags { get; set; }

        public Status Status { get; set; }
    }
}

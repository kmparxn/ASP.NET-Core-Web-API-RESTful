namespace PedVet.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        
        // one to many
        public ICollection<Review> Reviews { get; set; }

        // many to many
        public ICollection<PetOwner> PetOwners { get; set; }
        public ICollection<PetCategory> PetCategories { get; set; }
    }
}

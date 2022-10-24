namespace PedVet.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

        // one to one
        public Country Country { get; set; }

        //many to many
        public ICollection<PetOwner> PetOwners { get; set; }
    }
}

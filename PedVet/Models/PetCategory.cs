namespace PedVet.Models
{
    public class PetCategory
    {
        public int PetId { get; set; }
        public int CategoryId { get; set; }
        public Pet Pet { get; set; }
        public Category Category { get; set; }

    }
}

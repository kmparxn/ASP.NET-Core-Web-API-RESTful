namespace PedVet.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //many to many
        public ICollection<PetCategory> PetCategories { get; set; }

    }
}

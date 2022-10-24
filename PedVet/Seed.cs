using PedVet.Data;
using PedVet.Models;

namespace PetReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PetOwners.Any())
            {
                var PetOwners = new List<PetOwner>()
                {
                    new PetOwner()
                    {
                        Pet = new Pet()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            PetCategories = new List<PetCategory>() 
                            {
                                new PetCategory { Category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Pikachu",Text = "Pickahu is the best Pet, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Age = "Brocks Age",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PetOwner()
                    {
                        Pet = new Pet()
                        {
                            Name = "Squirtle",
                            BirthDate = new DateTime(1903,1,1),
                            PetCategories = new List<PetCategory>()
                            {
                                new PetCategory { Category = new Category() { Name = "Water"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Squirtle", Text = "squirtle is the best Pet, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Harry",
                            LastName = "Potter",
                            Age = "Mistys Age",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                    new PetOwner()
                    {
                        Pet = new Pet()
                        {
                            Name = "Venasuar",
                            BirthDate = new DateTime(1903,1,1),
                            PetCategories = new List<PetCategory>()
                            {
                                new PetCategory { Category = new Category() { Name = "Leaf"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Veasaur",Text = "Venasuar is the best Pet, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Ash",
                            LastName = "Ketchum",
                            Age = "Ashs Age",
                            Country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.PetOwners.AddRange(PetOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
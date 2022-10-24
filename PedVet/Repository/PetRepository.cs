using PedVet.Data;
using PedVet.Dto;
using PedVet.Interfaces;
using PedVet.Models;

namespace PedVet.Repository 
{
    public class PetRepository : IPetRepository
    {
        private readonly DataContext _context;

        public PetRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePet(int ownerId, int categoryId, Pet pet)
        {
            var petOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var petOwner = new PetOwner()
            {
                Owner = petOwnerEntity,
                Pet = pet,
            };

            _context.Add(petOwner);

            var petCategory = new PetCategory()
            {
                Category = category,
                Pet = pet,
            };

            _context.Add(petCategory);

            _context.Add(pet);

            return Save();
        }

        public bool DeletePet(Pet pet)
        {
            _context.Remove(pet);
            return Save();
        }

        public Pet GetPet(int id)
        {
            return _context.Pet.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pet GetPet(string name)
        {
            return _context.Pet.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPetRating(int petId)
        {
            var review = _context.Reviews.Where(p => p.Pet.Id == petId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Pet> GetPets()
        {
            return _context.Pet.OrderBy(p => p.Id).ToList();
        }

        public Pet GetPetTrimToUpper(PetDto petCreate)
        {
            return GetPets().Where(c => c.Name.Trim().ToUpper() == petCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool PetExists(int petId)
        {
            return _context.Pet.Any(p => p.Id == petId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePet(int ownerId, int categoryId, Pet pet)
        {
            _context.Update(pet);
            return Save();
        }
    }
}

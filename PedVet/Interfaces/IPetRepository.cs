using PedVet.Dto;
using PedVet.Models;

namespace PedVet.Interfaces
{
    public interface IPetRepository
    {
        ICollection<Pet> GetPets();
        Pet GetPet(int id);
        Pet GetPet(string name);
        Pet GetPetTrimToUpper(PetDto PetCreate);
        decimal GetPetRating(int petId);
        bool PetExists(int petId);
        bool CreatePet(int ownerId, int categoryId, Pet Pet);
        bool UpdatePet(int ownerId, int categoryId, Pet Pet);
        bool DeletePet(Pet Pet);
        bool Save();
    }
}

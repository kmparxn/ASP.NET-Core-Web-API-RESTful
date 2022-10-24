using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PedVet.Dto;
using PedVet.Interfaces;
using PedVet.Models;

namespace PedVet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetRepository _petRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public PetController(IPetRepository petRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pet>))]
        public IActionResult GetPets()
        {
            var Pets = _mapper.Map<List<PetDto>>(_petRepository.GetPets());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Pets);
        }

        [HttpGet("{petId}")]
        [ProducesResponseType(200, Type = typeof(Pet))]
        [ProducesResponseType(400)]
        public IActionResult GetPet(int petId)
        {
            if (!_petRepository.PetExists(petId))
                return NotFound();

            var Pet = _mapper.Map<PetDto>(_petRepository.GetPet(petId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Pet);
        }

        [HttpGet("{petId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPetRating(int petId)
        {
            if (!_petRepository.PetExists(petId))
                return NotFound();

            var rating = _petRepository.GetPetRating(petId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePet([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PetDto petCreate)
        {
            if (petCreate == null)
                return BadRequest(ModelState);

            var pets = _petRepository.GetPetTrimToUpper(petCreate);

            if (pets != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var petMap = _mapper.Map<Pet>(petCreate);


            if (!_petRepository.CreatePet(ownerId, catId, petMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        
        [HttpPut("{petId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePet(int petId,
            [FromQuery] int ownerId, [FromQuery] int catId,
            [FromBody] PetDto updatedPet)
        {
            if (updatedPet == null)
                return BadRequest(ModelState);

            if (petId != updatedPet.Id)
                return BadRequest(ModelState);

            if (!_petRepository.PetExists(petId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var petMap = _mapper.Map<Pet>(updatedPet);

            if (!_petRepository.UpdatePet(ownerId, catId, petMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{petId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePet(int petId)
        {
            if (!_petRepository.PetExists(petId))
            {
                return NotFound();
            }

            var reviewsToDelete = _reviewRepository.GetReviewsOfAPet(petId);
            var petToDelete = _petRepository.GetPet(petId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }

            if (!_petRepository.DeletePet(petToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

    }
}

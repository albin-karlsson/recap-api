using ApiRecap.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRecap.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    // https://localhost:7026/v1/Dogs
    public class DogsController : ControllerBase
    {
        public static List<Dog> Dogs { get; set; } = new()
        {
                new Dog { Id = 1, Name = "Max", Breed = "Labrador", Age = 3 },
                new Dog { Id = 2, Name = "Bella", Breed = "Beagle", Age = 4 },
                new Dog { Id = 3, Name = "Charlie", Breed = "Poodle", Age = 5 },
                new Dog { Id = 4, Name = "Lucy", Breed = "Bulldog", Age = 2 },
                new Dog { Id = 5, Name = "Daisy", Breed = "Boxer", Age = 6 },
                new Dog { Id = 6, Name = "Molly", Breed = "Dachshund", Age = 1 },
                new Dog { Id = 7, Name = "Bailey", Breed = "German Shepherd", Age = 3 },
                new Dog { Id = 8, Name = "Maggie", Breed = "Golden Retriever", Age = 2 },
                new Dog { Id = 9, Name = "Buddy", Breed = "Yorkshire Terrier", Age = 4 },
                new Dog { Id = 10, Name = "Sophie", Breed = "Rottweiler", Age = 5 }
        };

        [HttpGet]
        public ActionResult<List<Dog>> Get()
        {
            // Returnera en lista med hundar

            if (Dogs != null && Dogs.Any())
            {
                return Ok(Dogs);
            }

            return NotFound("Could not find dogs");
        }

        // https://localhost:7026/v1/Dogs/{id}
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Dog> Get(int id)
        {
            Dog? dog = Dogs.FirstOrDefault(d => d.Id == id);

            if (dog == null)
            {
                // Kunde inte hitta hund med det ID:t

                // Returnera ett statusmeddelande 404
                return NotFound("Could not find dog with that ID"); // Detta är ett ActionResult
            }

            // Returnera en hund med id
            return Ok(dog);
        }

        [HttpPost]
        public ActionResult Post(Dog? dog)
        {
            if (dog == null || string.IsNullOrEmpty(dog.Name))
            {
                return BadRequest("Could not add dog. Check you JSON and try again!");
            }

            Dogs.Add(dog);

            return Ok("Dog added!");
        }
    }
}

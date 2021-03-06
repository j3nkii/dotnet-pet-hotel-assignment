using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Pet> GetAll()
        {
            return _context.pets.Include(pet => pet.petOwner);
        }

        




        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Shepard,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }

        [HttpPut("{id}")]

        public Pet Put(int id, Pet pet) {
            pet.id = id;

            _context.Update(pet);
            _context.SaveChanges();

            return pet;
        }

        [HttpDelete("{id}")]

        public void Delete(int id) {
            Pet pet = _context.pets.Find(id);

            _context.pets.Remove(pet);
            _context.SaveChanges();
        }

        [HttpPost]
        public ActionResult<Pet> Post(Pet pet)
        {
            // Add this pet to the database
            _context.Add(pet);
            _context.SaveChanges();
            //Console.WriteLine(pet);
            return pet;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebData.Models;

namespace PetAdoptionWebAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    private readonly IPetRepository _petRepository;
    public PetController(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_petRepository.Pets);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_petRepository.Pets.FirstOrDefault(p => p.PetId == id));
    }
    [HttpPost]
    public IActionResult Post([FromBody] Pet pet)
    {
        _petRepository.CreatePet(pet);
        var result = _petRepository.Pets.FirstOrDefault(a => a.Name == pet.Name && a.AccountId == pet.AccountId);
        if (result == null)
        {
            return NotFound();
        } else
        {
            return Ok(result);
        }
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Pet pet)
    {
        if (id != pet.PetId)
        {
            return BadRequest("two different id in url and body");
        }
        _petRepository.UpdatePet(pet);
        return Ok(pet);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _petRepository.DeletePet(id);
        return Ok();
    }
}
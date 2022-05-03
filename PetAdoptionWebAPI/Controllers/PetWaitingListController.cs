using Microsoft.AspNetCore.Mvc;
using WebData.Models;

namespace PetAdoptionWebAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class PetWaitingListController : ControllerBase
{
    private readonly IPetWaitingListRepository _petWaitingListRepository;
    public PetWaitingListController(IPetWaitingListRepository petWaitingListRepository)
    {
        _petWaitingListRepository = petWaitingListRepository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_petWaitingListRepository.PetWaitingLists);
    }
    [HttpGet("{petId}")]
    public IActionResult Get(int petId)
    {
        return Ok(_petWaitingListRepository.PetWaitingLists.Where(p => p.PetId == petId).ToList<PetWaitingList>());
    }
    [HttpPost]
    public IActionResult Post([FromBody] PetWaitingList petWaitingList)
    {
        _petWaitingListRepository.CreatePetWaitingList(petWaitingList);
        return Ok(petWaitingList);
    }
   
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _petWaitingListRepository.DeletePetWaitingList(id);
        return Ok();
    }
}
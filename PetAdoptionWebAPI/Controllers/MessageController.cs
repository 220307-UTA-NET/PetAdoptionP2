using Microsoft.AspNetCore.Mvc;
using WebData.Models;

namespace PetAdoptionWebAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;
    public MessageController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_messageRepository.Messages);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_messageRepository.Messages.FirstOrDefault(m => m.MessageId == id));
    }
    [HttpPost]
    public IActionResult Post([FromBody] Message message)
    {
        _messageRepository.CreateMessage(message);
        return Ok(message);
    }
    
}
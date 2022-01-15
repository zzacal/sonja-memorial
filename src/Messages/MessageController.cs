using Microsoft.AspNetCore.Mvc;

namespace SonjaMemorial.Messages;
[Route("api/[controller]")]
public class MessageController : Controller
{
  private ILogger<MessageController> _logger;
  private IMessageStore _store;
  public MessageController(ILogger<MessageController> logger, IMessageStore store)
  {
    _logger = logger;
    _store = store;
  }

  [HttpGet]
  [Route("/api/message")]
  public IEnumerable<MessageData> Get()
  {
    return _store.GetAll();
  }

  [HttpPost]
  [Route("/api/message")]
  public IActionResult Post([FromForm] MessageRequest message)
  {
    if(!string.IsNullOrWhiteSpace(message.Body)){
      var data = new MessageData(message.Body);
      _store.Add(data);
    }
    return Redirect("/");
  }
}

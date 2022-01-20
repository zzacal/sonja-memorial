using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SonjaMemorial.Messages;
using SonjaMemorial.Models;

namespace SonjaMemorial.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IMessageStore _messages;

  public HomeController(ILogger<HomeController> logger, IMessageStore messages)
  {
    _logger = logger;
    _messages = messages;
  }

  public async Task<IActionResult> Index()
  {
    var model = new HomeViewModel
		{
			Messages = (await _messages.GetAll()).Select(m => new MessageData(m.Body, m.Created)),
		};
    return View(model);
  }
	
  [Route("/sent")]
  public async Task<IActionResult> Done()
  {
    var messages = await _messages.GetAll();
    var model = new HomeViewModel
		{
			Messages = messages.Select(m => new MessageData(m.Body, m.Created)),
			IsSubmitted = true
		};
    return View("Index", model);
  }

  [HttpPost]
  [Route("/")]
  public async Task<IActionResult> Index([FromForm] MessageRequest message)
  {
    if (!string.IsNullOrWhiteSpace(message.Body))
    {
      var data = new MessageData(message.Body, DateTime.UtcNow);
      await _messages.Add(data);
    } else {
      return RedirectToAction("Index", null, null, "messages");
    }
		
		return RedirectToAction("Done", null, null, "messages");
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}

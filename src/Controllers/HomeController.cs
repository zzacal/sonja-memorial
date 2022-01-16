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

  public IActionResult Index()
  {
    var model = new HomeViewModel
		{
			Messages = _messages.GetAll().Select(m => new MessageData(m.Body)),
		};
    return View(model);
  }
	
  [Route("/sent")]
  public IActionResult Done()
  {
    var model = new HomeViewModel
		{
			Messages = _messages.GetAll().Select(m => new MessageData(m.Body)),
			IsSubmitted = true
		};
    return View("Index", model);
  }

  [HttpPost]
  [Route("/")]
  public IActionResult Index([FromForm] MessageRequest message)
  {
    if (!string.IsNullOrWhiteSpace(message.Body))
    {
      var data = new MessageData(message.Body);
      _messages.Add(data);
    }
		
		return RedirectToAction("Done");
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

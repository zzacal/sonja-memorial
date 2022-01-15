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
        var messages = _messages.GetAll().Select(m => new MessageViewModel { Body = m.Body });
        return View(messages);
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

using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyStatWebApplication.Models;
using MyStatWebApplication.Services;

namespace MyStatWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomeworkManager _homeworkManager;

    public HomeController(ILogger<HomeController> logger, IHomeworkManager homeworkManager)
    {
        _logger = logger;
        _homeworkManager = homeworkManager;
    }

    public IActionResult Index()
    {
        return View(_homeworkManager);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [ActionName("AddHomework")]
    public async Task<IActionResult> AddHomeworkAsync([FromForm] Homework? homework)
    {
        if (homework == null)
        {
            return BadRequest();
        }

        homework.DateTime = DateTime.Now;

        await _homeworkManager.AddHomeworkAsync(homework);

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ActionName("RemoveHomework")]
    public async Task<IActionResult> RemoveHomeworkAsync([FromBody] Homework? homework)
    {
        if (homework == null)
        {
            return BadRequest();
        }

        if (await _homeworkManager.RemoveHomeworkAsync(homework.Id))
        {
            return Ok();
        }

        return BadRequest();
    }

    
    [HttpGet("Home/DownloadHomework/{id:int}")]
    public async Task<IActionResult> DownloadHomeworkAsync(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        if (await _homeworkManager.GetHomeworkByIdAsync(id) is { } hw)
        {
            await System.IO.File.WriteAllTextAsync( @$"C:\Users\{Environment.UserName}\Downloads\{Path.GetRandomFileName()}.txt", hw.Description);
            return Ok();
        }

        return BadRequest();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

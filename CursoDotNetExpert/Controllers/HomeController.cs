using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CursoDotNetExpert.Models;

namespace CursoDotNetExpert.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var filme = new Filme
        {
            Titulo = "Oi",
            DataDeLancamento = DateTime.Now,
            Genero = "",
            Avaliacao = 10,
            Valor = 20000
        };

        return RedirectToAction("Privacy", filme);
        // return View();
    }

    public IActionResult Privacy(Filme filme)
    {
        // Console.WriteLine(filme.ToString());
        if (ModelState.IsValid)
        {
            Console.WriteLine("model valida");
        }
        else
        {
            Console.WriteLine("model invalida");
            foreach (var error in ModelState.Values.SelectMany(m=>m.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
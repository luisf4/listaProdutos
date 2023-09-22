using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
public class CadastroController : Controller
{
    [Route("cadastro")]
    public IActionResult Index()
    {
        return View();
    }
}
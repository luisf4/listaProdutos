using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller { 
  
    public IActionResult Index() { 
        ProdutoData db = new ProdutoData();
        List<Produto> lista = db.ReadFromJsonFile();
        return View(lista);
    }

    public ActionResult Search(IFormCollection from) {
        string? search = from["search"];
        ProdutoData db = new ProdutoData();
        List<Produto> lista = db.ReadFromJsonFile(search!);
        return View("Index",lista);
    }
}
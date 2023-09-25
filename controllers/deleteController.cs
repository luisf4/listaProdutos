using Microsoft.AspNetCore.Mvc;

public class DeleteController : Controller
{
    public IActionResult index(string produtoId)
    {
        ProdutoData db = new ProdutoData();
        db.Delete(Guid.Parse(produtoId));
        return RedirectToAction("Index", "Home");

    }
}
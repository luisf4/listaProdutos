using Microsoft.AspNetCore.Mvc;

public class DeleteController : Controller
{
    public IActionResult index(string produtoId)
    {
        // Instancea o db
        ProdutoData db = new ProdutoData();

        // Deleta o item por id
        db.Delete(Guid.Parse(produtoId));
        
        // Redireciona para home
        return RedirectToAction("Index", "Home");

    }
}
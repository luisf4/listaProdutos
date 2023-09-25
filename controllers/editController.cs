using Microsoft.AspNetCore.Mvc;

public class EditController : Controller
{
    [Route("edit")]
    public IActionResult Index(string produtoId)
    {
        // Fuckn parse the string to Guid again !
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(produtoId, out var parsedId))
        {
            id = parsedId;
        }
        else
        {
            Console.WriteLine("Error On parsing");
        }

        ProdutoData db = new ProdutoData();
        List<Produto> produto = db.SearchById(parsedId);
        return View(produto);
    }


    public IActionResult Atualizar(IFormCollection form)
    {
        ProdutoData produtoData = new ProdutoData();

        try
        {
            bool disponivel = false;
            if (form["Disponivel"] == "on")
            {
                disponivel = true;
            }
            else
            {
                disponivel = false;
            }

            // Check if the "id" field is not null or empty
            if (!string.IsNullOrEmpty(form["id"]))
            {
                decimal.TryParse(form["Preco"], out decimal preco);
                Produto newProduto = new Produto
                {
                    id = Guid.Parse(form["id"]),
                    Nome = form["Nome"],
                    Descricao = form["Descricao"],
                    Preco = preco,
                    Disponivel = disponivel
                };
                produtoData.UpdateProduto(newProduto.id, newProduto);
            }
            else
            {
                Console.WriteLine("The 'id' field is null or empty.");
            }

            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Cant update a new produto: ERROR {e}");
            return RedirectToAction("Index", "Home");
        }
    }


}
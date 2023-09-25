using Microsoft.AspNetCore.Mvc;

public class EditController : Controller
{
    [Route("edit")]
    public IActionResult Index(string produtoId)
    {
        // Parseia a string para Guid 
        if (Guid.TryParse(produtoId, out var parsedId))
        {
            Guid id = parsedId;
        }
        else
        {
            Console.WriteLine("Erro na conversão");
        }
        // Cria uma instancia do db
        ProdutoData db = new ProdutoData();

        // Busca o item com o mesmo ID
        List<Produto> produto = db.SearchById(parsedId);
        return View(produto);
    }

    // Atualiza 
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

            // Verifica se o campo "id" não está nulo ou vazio
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
                Console.WriteLine("O campo 'id' está nulo ou vazio.");
            }

            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Não foi possível atualizar o novo produto: ERRO {e}");
            return RedirectToAction("Index", "Home");
        }
    }
}

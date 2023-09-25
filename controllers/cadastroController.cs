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

    public IActionResult Criar(IFormCollection form)
    {
        ProdutoData produtoData = new ProdutoData();

        try
        {
            Console.WriteLine(form["disponivel"]);
            bool disponivel = false; 
            if (form["disponivel"] == "on") {
                disponivel = true;
            } else {
                disponivel = false;
            }
            decimal.TryParse(form["preco"], out decimal preco);
            Produto newProduto = new Produto
            {
                id = Guid.NewGuid(),
                Nome = form["nome"],
                Descricao = form["descricao"],
                Preco = preco,
                Disponivel = disponivel
            };
            produtoData.AppendToJsonFile(newProduto);
            return RedirectToAction("Index", "Home");
        }
        catch
        {
            Console.WriteLine("Cant create a new produto");
            return View();
        }
    }

}
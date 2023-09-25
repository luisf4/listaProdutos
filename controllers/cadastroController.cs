using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

public class CadastroController : Controller
{
    [Route("cadastro")]
    public IActionResult Index()
    {
        // Exibe a página de cadastro.
        return View();
    }

    public IActionResult Criar(IFormCollection form)
    {
        ProdutoData produtoData = new ProdutoData();

        try
        {
            // Verifica se o campo "disponivel" está marcado como "on" e converte para bool.
            bool disponivel = false;
            if (form["disponivel"] == "on")
            {
                disponivel = true;
            }
            else
            {
                disponivel = false;
            }

            // Tenta converter o campo "preco" para decimal.
            decimal.TryParse(form["preco"], out decimal preco);

            // Cria um novo produto com os dados do formulário.
            Produto newProduto = new Produto
            {
                id = Guid.NewGuid(),
                Nome = form["nome"],
                Descricao = form["descricao"],
                Preco = preco,
                Disponivel = disponivel
            };

            // Adiciona o novo produto ao arquivo JSON.
            produtoData.AppendToJsonFile(newProduto);

            // Redireciona para a página inicial (Index) do controlador Home após a criação.
            return RedirectToAction("Index", "Home");
        }
        catch
        {
            // Em caso de erro, exibe uma mensagem de erro e retorna à página de cadastro.
            Console.WriteLine("Cant create a new produto");
            return View();
        }
    }
}

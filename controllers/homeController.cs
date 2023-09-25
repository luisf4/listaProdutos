using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller { 
  
    // Ação para exibir a página inicial
    public IActionResult Index() { 
        // Cria uma instância do banco de dados de produtos
        ProdutoData db = new ProdutoData();
        // Lê a lista de produtos do arquivo JSON
        List<Produto> lista = db.ReadFromJsonFile();
        // Retorna a exibição da lista de produtos
        return View(lista);
    }

    // Ação para pesquisar produtos
    public ActionResult Search(IFormCollection form) {
        // Obtém o termo de pesquisa do formulário
        string? search = form["search"];
        // Cria uma instância do banco de dados de produtos
        ProdutoData db = new ProdutoData();
        // Realiza uma pesquisa na lista de produtos com base no termo de pesquisa
        List<Produto> lista = db.ReadFromJsonFile(search!);
        // Retorna a exibição da lista de produtos com base na pesquisa
        return View("Index", lista);
    }
}

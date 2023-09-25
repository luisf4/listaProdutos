using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ProdutoData
{
    private string jsonFilePath = "produtos.json"; // Caminho do arquivo JSON

    // Lê os dados de um arquivo JSON e retorna uma lista de produtos
    public List<Produto> ReadFromJsonFile()
    {
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                List<Produto> produtos = JsonSerializer.Deserialize<List<Produto>>(jsonData)!;
                return produtos!;
            }
            else
            {
                Console.WriteLine($"Arquivo JSON não encontrado em {jsonFilePath}");
                return new List<Produto>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler dados do arquivo JSON: {ex.Message}");
            return new List<Produto>();
        }
    }

    // Lê os dados de um arquivo JSON e filtra produtos com base em uma pesquisa
    public List<Produto> ReadFromJsonFile(string search)
    {
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                List<Produto> produtos = JsonSerializer.Deserialize<List<Produto>>(jsonData)!;

                List<Produto> result = new List<Produto>();

                foreach (var produto in produtos!)
                {
                    if (produto.Nome!.ToLower().Contains(search.ToLower()))
                    {
                        result.Add(produto);
                    }
                }

                return result;
            }
            else
            {
                Console.WriteLine($"Arquivo JSON não encontrado em {jsonFilePath}");
                return new List<Produto>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler dados do arquivo JSON: {ex.Message}");
            return new List<Produto>();
        }
    }

    // Lê os dados de um arquivo JSON e filtra produtos com base em um ID
    public List<Produto> SearchById(Guid id)
    {
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                List<Produto> produtos = JsonSerializer.Deserialize<List<Produto>>(jsonData)!;

                List<Produto> result = new List<Produto>();

                foreach (var produto in produtos!)
                {
                    if (produto.id == id)
                    {
                        result.Add(produto);
                    }
                }

                return result;
            }
            else
            {
                Console.WriteLine($"Arquivo JSON não encontrado em {jsonFilePath}");
                return new List<Produto>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler dados do arquivo JSON: {ex.Message}");
            return new List<Produto>();
        }
    }

    // Adiciona um produto a um arquivo JSON
    public void AppendToJsonFile(Produto produto)
    {
        try
        {
            List<Produto> produtos = ReadFromJsonFile(); // Lê os dados existentes

            if (produtos != null)
            {
                produtos.Add(produto); // Adiciona o novo produto à lista
                string jsonData = JsonSerializer.Serialize(produtos);

                File.WriteAllText(jsonFilePath, jsonData);

                Console.WriteLine($"Produto adicionado ao arquivo JSON: {jsonFilePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao adicionar o produto ao arquivo JSON: {ex.Message}");
        }
    }

    // Atualiza um produto em um arquivo JSON com base em seu ID
    public void UpdateProduto(Guid id, Produto updatedProduto)
    {
        try
        {
            List<Produto> produtos = ReadFromJsonFile(); // Lê os dados existentes

            if (produtos != null)
            {
                int index = produtos.FindIndex(p => p.id == id);

                if (index != -1)
                {
                    produtos[index] = updatedProduto; // Atualiza o produto
                    string jsonData = JsonSerializer.Serialize(produtos);

                    File.WriteAllText(jsonFilePath, jsonData);

                    Console.WriteLine($"Produto atualizado no arquivo JSON: {jsonFilePath}");
                }
                else
                {
                    Console.WriteLine($"Produto com ID {id} não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Erro ao ler dados do arquivo JSON ou o arquivo está vazio.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar o produto no arquivo JSON: {ex.Message}");
        }
    }

    // Remove um produto de um arquivo JSON com base em seu ID
    public void Delete(Guid id)
    {
        try
        {
            List<Produto> produtos = ReadFromJsonFile(); // Lê os dados existentes

            if (produtos != null)
            {
                int index = produtos.FindIndex(p => p.id == id);

                if (index != -1)
                {
                    produtos.RemoveAt(index); // Remove o produto
                    string jsonData = JsonSerializer.Serialize(produtos);

                    File.WriteAllText(jsonFilePath, jsonData);

                    Console.WriteLine($"Produto excluído no arquivo JSON: {jsonFilePath}");
                }
                else
                {
                    Console.WriteLine($"Produto com ID {id} não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Erro ao ler dados do arquivo JSON ou o arquivo está vazio.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao excluir o produto no arquivo JSON: {ex.Message}");
        }
    }
}

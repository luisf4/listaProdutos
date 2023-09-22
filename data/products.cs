using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ProdutoData
{   
    
    public List<Produto> ReadFromJsonFile()
    {
        string jsonFilePath = "produtos.json";
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                List<Produto> produtos = JsonSerializer.Deserialize<List<Produto>>(jsonData);
                return produtos;
            }
            else
            {
                Console.WriteLine($"JSON file not found at {jsonFilePath}");
                return new List<Produto>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading data from JSON file: {ex.Message}");
            return new List<Produto>();
        }
    }
        public List<Produto> ReadFromJsonFile(string search)
    {
        string jsonFilePath = "produtos.json";
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                List<Produto> produtos = JsonSerializer.Deserialize<List<Produto>>(jsonData);
            
            
                List<Produto> result = new List<Produto>();

                foreach (var produto in produtos)
                {
                    if (produto.Nome.ToLower().Contains(search.ToLower()))
                    {
                        result.Add(produto);
                    }
                }

                return result;
            }
            else
            {
                Console.WriteLine($"JSON file not found at {jsonFilePath}");
                return new List<Produto>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading data from JSON file: {ex.Message}");
            return new List<Produto>();
        }
    }
}

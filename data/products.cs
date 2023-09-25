using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ProdutoData
{
    private string jsonFilePath = "produtos.json"; // JSON file path

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

    public void AppendToJsonFile(Produto produto)
    {
        try
        {
            List<Produto> produtos = ReadFromJsonFile(); // Read existing data

            if (produtos != null)
            {
                produtos.Add(produto); // Append the new product to the list
                string jsonData = JsonSerializer.Serialize(produtos);

                File.WriteAllText(jsonFilePath, jsonData);

                Console.WriteLine($"Product appended to JSON file: {jsonFilePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error appending product to JSON file: {ex.Message}");
        }
    }

    public void UpdateProduto(Guid id, Produto updatedProduto)
    {
        try
        {
            List<Produto> produtos = ReadFromJsonFile(); // Read existing data

            if (produtos != null)
            {
                int index = produtos.FindIndex(p => p.id == id);

                if (index != -1)
                {
                    produtos[index] = updatedProduto; // Update the product
                    string jsonData = JsonSerializer.Serialize(produtos);

                    File.WriteAllText(jsonFilePath, jsonData);

                    Console.WriteLine($"Product updated in JSON file: {jsonFilePath}");
                }
                else
                {
                    Console.WriteLine($"Product with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Error reading data from JSON file or the file is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating product in JSON file: {ex.Message}");
        }
    }


    public void Delete(Guid id)
    {
        try
        {
            List<Produto> produtos = ReadFromJsonFile(); // Read existing data

            if (produtos != null)
            {
                int index = produtos.FindIndex(p => p.id == id);

                if (index != -1)
                {
                    produtos.RemoveAt(index);
                    string jsonData = JsonSerializer.Serialize(produtos);

                    File.WriteAllText(jsonFilePath, jsonData);

                    Console.WriteLine($"Product Deleted in JSON file: {jsonFilePath}");
                }
                else
                {
                    Console.WriteLine($"Product with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Error reading data from JSON file or the file is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Deleting product in JSON file: {ex.Message}");
        }
    }

}

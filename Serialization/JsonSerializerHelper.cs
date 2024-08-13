using System;
using System.Text.Json;
namespace PubgAPI.Serialization;

public class JsonSerializerHelper
{
    public static T Deserialize<T>(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Deserialization error: {ex.Message}");
            throw; // Re-lançar a exceção para tratamento adicional, se necessário
        }
    }

    public static string Serialize<T>(T obj)
    {
        try
        {
            return JsonSerializer.Serialize(obj);
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Serialization error: {ex.Message}");
            throw; // Re-lançar a exceção para tratamento adicional, se necessário
        }
    }
}
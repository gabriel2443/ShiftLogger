using ShiftLoggerUI.Models;
using System.Text.Json;

namespace ShiftLoggerUI;

public class HttpClient
{
    private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

    private static string url = "https://localhost:7090/api/Shifts";

    internal static async Task<Shift> GetShifts()
    {
        try
        {
            HttpResponseMessage res = await client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            string responseBody = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Shift>(responseBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
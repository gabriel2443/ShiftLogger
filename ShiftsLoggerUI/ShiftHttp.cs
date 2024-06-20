using ShiftsLoggerUI.Models;
using System.Text.Json;

namespace ShiftsLoggerUI;

internal static class ShiftHttp
{
    private static readonly HttpClient client = new HttpClient();

    internal static async Task<List<Shift>> GetShifts()

    {
        string url = "https://localhost:7189/api/shifts";
        try
        {
            HttpResponseMessage res = await client.GetAsync(url);

            res.EnsureSuccessStatusCode();
            string resBody = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Shift>>(resBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            throw;
        }
    }

    internal static async Task DeleteShift(int id)
    {
        try
        {
            string url = $"https://localhost:7189/api/shifts/{id}";
            HttpResponseMessage res = await client.DeleteAsync(url);
            res.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            throw;
        }
    }
}
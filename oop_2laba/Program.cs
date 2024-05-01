using System;
using System.Diagnostics;
using System.Net.Http;

class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main(string[] args)
    {
        string api = "https://api.hh.ru/openapi/redoc#section/Obshaya-informaciya/Vybor-s";
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string response = printIdAsync(api);
        stopwatch.Stop();
        Console.WriteLine(response);
        Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} ms");
    }
    public static string printIdAsync(string api)
    {
        try
        {
            HttpResponseMessage response = httpClient.GetAsync(api).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return $"Fail. Status code: {response.StatusCode}";
            }
        }
        catch (HttpRequestException ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using razorApp.models;
namespace razorApp.Pages;


    public class AnaliseService : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly HttpClient _httpClient;

    public string[] MinhaString { get; set; }

    // public Service[] MeuService {get;set;}


    public AnaliseService(ILogger<IndexModel> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task OnGet()
    {
            // var response = await _httpClient.GetAsync("https://localhost:7003/service");
            // response.EnsureSuccessStatusCode();
            // var result= await response.Content.ReadAsStringAsync();
            // // MinhaString= result;
            // MeuService = JsonSerializer.Deserialize<Service[]>(result);

            // foreach (var item in MeuService)
            // {
            //     Console.WriteLine(item.name);
            // }

            // MeuService = JsonSerializer.Deserialize<List<ServiceModel>>(result);
    }
}

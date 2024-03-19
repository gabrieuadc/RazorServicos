using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace razorApp.Pages;
    public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly HttpClient _httpClient;

    public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public void  OnGet()
    {

    }
}
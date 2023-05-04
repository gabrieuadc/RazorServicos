using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace razorApp.Pages;
    public class ServiceModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public ServiceModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
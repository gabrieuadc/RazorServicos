using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http;
using razorApp.models;
using System.Text;
using System.Text.Json;
using System.Diagnostics;
using razorApp.data;
using Microsoft.EntityFrameworkCore;

namespace razorApp.Pages;

    public class formService : PageModel
{
    private readonly ILogger<IndexModel> _logger;


    private readonly HttpClient _httpClient;
    public ServiceModel[] MeuService {get;set;}

    [BindProperty]
    public ServiceModel service {get;set;}

    private readonly ServiceDBContext _serviceDBContext;

    public formService(ILogger<IndexModel> logger, HttpClient httpClient1, ServiceDBContext serviceDBContext)
    {
        _logger = logger;
        _httpClient = httpClient1;
        _serviceDBContext= serviceDBContext;
    }

    public async Task OnGetAsync()
    {
    }
    
    public async Task<IActionResult> OnPostEnviarAsync([FromForm] ServiceModel serviceModel)
    {
        try
        {
            // return RedirectToPage("/Forms/Strategy");
            // if (!ModelState.IsValid)
            // {
            //     foreach (var modelState in ModelState.Values)
            //     {
            //         foreach (var error in modelState.Errors)
            //         {
            //             Console.WriteLine($"Model Error: {error.ErrorMessage}");
            //         }
            //     }


            // }
            await _serviceDBContext.Services.AddAsync(serviceModel);
            await _serviceDBContext.SaveChangesAsync();

            TempData["AlertMessage"] = "Serviço adicionado com sucesso!";

            return RedirectToPage("./formService");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante o processamento OnPostAsync");
            return StatusCode(500);
        }

    }

// public async Task<IActionResult> onPostEnviarAsync(){

//     if (!ModelState.IsValid)
//     {
//         return Page();
//     }
//     var service1= new ServiceModel();
//     var response = await _httpClient.PostAsJsonAsync("https://localhost:7003/service", service1);
  
//         return Page();
//     }
}
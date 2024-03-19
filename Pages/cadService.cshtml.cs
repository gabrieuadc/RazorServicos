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
using razorApp.repositories;
using razorApp.models;

namespace razorApp.Pages;

public class Service : PageModel

{
    private readonly ILogger<IndexModel> _logger;

    public string Message { get; set; }
    private readonly ServiceDBContext _serviceDBContext;

    public Service(ILogger<IndexModel> logger, ServiceDBContext serviceDBContext)
    {
        _logger = logger;
        _serviceDBContext = serviceDBContext;
    }
    public ServiceModel[] MeuService { get; set; }

    [BindProperty]
    public ServiceModel? service { get; set; }

    public async Task OnGetAsync()
    {
        var result = await _serviceDBContext.Services.OrderBy(s => s.id).ToListAsync();
        MeuService = result.ToArray();
    }

public async Task<IActionResult> OnPostPutServiceAsync(ServiceModel serviceUpdated)
{
    if (Request.Form["_method"] == "PUT")
    {
        var service1 = await _serviceDBContext.Services.FindAsync(serviceUpdated.id);
        if (service1 != null)
        {
            service1.name = serviceUpdated.name;
            service1.date = serviceUpdated.date;
            service1.service = serviceUpdated.service;
            service1.value = serviceUpdated.value;
            service1.contact = serviceUpdated.contact;
            service1.id=serviceUpdated.id;

            await _serviceDBContext.SaveChangesAsync();
        }
        else
        {
            return NotFound();
        }
        return RedirectToPage("./cadService");
    }
    else
    {
        return StatusCode(405);
    }
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
            return RedirectToPage("./cadService");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante o processamento OnPostAsync");
            return StatusCode(500);
        }

    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try
        {
            Console.WriteLine(id);
            var service = await _serviceDBContext.Services.FindAsync(id);

            if (service != null)
            {
                _serviceDBContext.Services.Remove(service);
                await _serviceDBContext.SaveChangesAsync();
            }
            return RedirectToPage("./cadService");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante o processamento do remove");
            return StatusCode(500);
        }

    }

    public async Task<IActionResult> OnPostUpdateAsync(int id)
    {
        try
        {
            Console.WriteLine(id);
            var service = await _serviceDBContext.Services.FindAsync(id);

            if (service != null)
            {
                _serviceDBContext.Services.Update(service);
                await _serviceDBContext.SaveChangesAsync();
            }
            return RedirectToPage("./cadService");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante o processamento do remove");
            return StatusCode(500);
        }

    }

}

// [FromForm] ServiceModel serviceModel

// Console.WriteLine("IF2");
// Console.WriteLine(model);
// Console.WriteLine($"Model: {model}");

// [FromForm]ServiceModel model

    // string htmlContent = "<h1>Hello, World!</h1>";

    // // Create a ContentResult with your HTML content
    // ContentResult contentResult = new ContentResult
    // {
    //     Content = htmlContent,
    //     ContentType = "text/html"
    // };

    // // Return the ContentResult
    // return contentResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace p8_c00124175.Pages;

// Paul Chu
// C00124175
// CMPS 358
// CMPS 358 Spring 2021 Programming Project #8

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
    
    [BindProperty]
    public string DisCoutProducts { get; set; }
}

public static class DisContProducts
{
    public static string disContProducts(string disCoutProducts)
    {
        using (var db = new p8_C00124175.p8_C00124175())
        {
            try
            {
                var results =
                    from products in db.Products
                    where products.IsDiscontinued.ToString() == "1"
                    select products.ProductName;

                if (!results.Any() || string.IsNullOrEmpty(disCoutProducts))
                    return $"";

                string disProducts = "";
                foreach (var c in results)
                    disProducts += $"{c}, ";
                return disProducts;

            }
            catch (Exception e)
            {
                return $"Error for searching for any discontinue products";
            }
        }
    }
}
using System.Text;
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
    
    [BindProperty]
    public string ListCustomersInCountry { get; set; }
    
    [BindProperty]
    public string ListSupplieresInCountry { get; set; }

    [BindProperty] 
    public string DisContProductsBySuppler { get; set; }
}

//Problem 3a
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
                return $"Error for searching for any discontinue products {e}";
            }
        }
    }
}

//Problem 3b
public static class CustomersInCountry
{
    public static string customersInCountry(string country)
    {
        using (var db = new p8_C00124175.p8_C00124175())
        {
            try
            {
                var results =
                    from c in db.Customers
                    where c.Country.Equals(country)
                    select new
                    {
                        firstName = c.FirstName, 
                        lastName = c.LastName, 
                        phone = c.Phone
                    };
                
                if (!results.Any() || string.IsNullOrEmpty(country))
                    return $"";

                string customers = "";
                foreach (var c in results)
                    customers += $"First Name: {c.firstName}, " +
                                 $"Last Name: {c.lastName}, " +
                                 $"Phone: {c.phone} ";
                return customers;
            }

            catch (Exception e)
            {
                return $"Country does not exist, please enter again : {e}";
            }
        }
    }
}

//Problem 3c
public static class SuppliersInCountry
{
    public static string suppliersInCountry(string country)
    {
        using (var db = new p8_C00124175.p8_C00124175())
        {
            try
            {
                var results =
                    from c in db.Suppliers
                    where c.Country.Equals(country)
                    select new {
                        id = c.Id, 
                        companyName = c.CompanyName, 
                        contactName = c.ContactName, 
                        phone = c.Phone, 
                        fax = c.Fax, 
                        city = c.City
                    };
                
                if (!results.Any() || string.IsNullOrEmpty(country))
                    return $"";

                string suppliers = "";
                foreach (var c in results)
                {
                    suppliers += $"ID: {c.id} " +
                                 $"Company Name: {c.companyName} " +
                                 $"Contact Name: {c.contactName} " +
                                 $"Phone: {c.phone} " +
                                 $"Fax: {c.fax} " +
                                 $"City:{c.city} ";
                }
                return suppliers;
            }

            catch (Exception e)
            {
                return $"Country does not exist, please enter again : {e}";
            }
        }
    }
}

//Problem 3d
public static class ProductsThatAreDisContBySupplier
{
    public static string disContProductsBySupplier(string supplierName)
    {
        using (var db = new p8_C00124175.p8_C00124175())
        {
            try
            {
                var results =
                    from s in db.Suppliers
                    join p in db.Products
                        on s.Id equals p.SupplierId
                    orderby s.CompanyName
                    where p.IsDiscontinued.ToString() == "0" && s.CompanyName == supplierName
                    select new {
                        companyName = s.CompanyName,
                        productName = p.ProductName, 
                        unitPrice = Encoding.UTF8.GetString(p.UnitPrice,0, p.UnitPrice.Length), 
                        package = p.Package
                    };

                if (!results.Any() || string.IsNullOrEmpty(supplierName))
                    return $"";
                
                string suppliers = "";
                foreach (var c in results)
                {
                    suppliers +=
                        $"Company Name: {c.companyName}" +
                        $" Product Name: {c.productName}" +
                        $" Unit Price: {c.unitPrice}" +
                        $" Package: {c.package} ";
                }
                return suppliers;
            }

            catch (Exception e)
            {
                return $"Supplier does not exist, please enter again : {e}";
            }
        }
    }
}
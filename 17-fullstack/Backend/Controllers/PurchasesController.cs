using System.Reflection.Metadata.Ecma335;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class PurchasesController : ControllerBase
{
    private readonly ProductService _productService;
    private readonly UserService _userService;
    private readonly PurchaseService _purchaseService;

    public PurchasesController(ProductService productService, UserService userService, PurchaseService purchaseService)
    {
        if (_purchaseService == null)
            throw new ArgumentNullException(nameof(purchaseService));
        if (_userService == null)
            throw new ArgumentNullException(nameof(userService));
        if (_productService == null)
            throw new ArgumentNullException(nameof(productService));

        _productService = productService;
        _userService = userService;
        _purchaseService = purchaseService;
    }

    [HttpGet]
    public ActionResult<List<PurchaseDTO>> GetAll()
    {
        List<Purchase> purchases = _purchaseService.GetAll();
        List<User> users = _userService.GetAll();
        List<Product> products = _productService.GetAll();
        List<PurchaseDTO> result = new List<PurchaseDTO>();
        foreach (Purchase p in purchases)
        {
            User user = null;
            Product product = null;
            foreach (User u in users)
            {
                if (u.Id == p.UserId)
                {
                    user = u;
                    break;
                }
            }
            foreach (Product prod in products)
            {
                if (prod.Id == p.ProductId)
                {
                    product = prod;
                    break;
                }
            }
            PurchaseDTO dto = new PurchaseDTO
            {
                Id = p.Id,
                UserName = user != null ? user.Name : "Sconosciuto",
                ProductName = product != null ? product.Name : "Sconosciuto",
                Quantity = p.Quantity,
                PurchaseDate = p.PurchaseDate
            };
            // Aggiungo il DTO alla lista dei risultati
            result.Add(dto);
        }
        return Ok(result);
    }
}

    
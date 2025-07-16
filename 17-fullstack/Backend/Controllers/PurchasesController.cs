using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/purchases")]

public class PurchasesController : ControllerBase
{
    private readonly ProductService _productservice;
    private readonly UserService _userService;
    private readonly PurchaseService _purchaseService;

    public PurchasesController(ProductService productservice, UserService userService, PurchaseService purchaseService)
    {
        _productservice = productservice;
        _userService = userService;
        _purchaseService = purchaseService;
    }
}
using Microsoft.AspNetCore.Mvc;
using InventarioSeguro.Data;
using System.Linq;

public class ProductosController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Acción para mostrar el inventario
    public IActionResult Index()
    {
        var productos = _context.Productos.ToList();
        return View(productos);
    }

    // Acción para mostrar el Dashboard
    public IActionResult Dashboard()
    {
        var productos = _context.Productos.ToList();

        var nombres = productos.Select(p => p.Nombre).ToList();
        var cantidades = productos.Select(p => p.Cantidad).ToList();

        ViewBag.Nombres = nombres;
        ViewBag.Cantidades = cantidades;

        return View();
    }
}

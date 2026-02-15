using Microsoft.AspNetCore.Mvc;
using InventarioSeguro.Data;
using InventarioSeguro.Models;
using SQLitePCL;

namespace InventarioSeguro.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Listado
        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);
        }

        //Crear Producto
        public IActionResult Create()
        {
            return View();
        }
        // Crear producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }
        // Editar Producto
        public IActionResult Edit(int id)
        {
            var producto = _context.Productos.Find(id);
            if(producto == null) return NotFound();
            return View(producto);
        }
        //Eliminar Productos
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto =_context.Productos.Find(id);
            if(producto != null )
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index));
        }
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
}
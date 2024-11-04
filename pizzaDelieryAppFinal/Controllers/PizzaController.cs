using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PizzaDeliveryApp;  
namespace PizzaDeliveryApp.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IMongoDatabase _database;

        public PizzaController(IMongoDatabase database)  // Inyección de la base de datos MongoDB
        {
            _database = database;
        }

        // CREATE (Agregar una nueva pizza)
        [HttpPost]
        public IActionResult CrearPizza(Pizza nuevaPizza)
        {
            var pizzasCollection = _database.GetCollection<Pizza>("Pizzas");
            pizzasCollection.InsertOne(nuevaPizza);
            return RedirectToAction("Index");
        }

        // READ (Obtener todas las pizzas)
        [HttpGet]
        public IActionResult ObtenerPizzas()
        {
            var pizzasCollection = _database.GetCollection<Pizza>("Pizzas");
            var pizzas = pizzasCollection.Find(FilterDefinition<Pizza>.Empty).ToList();
            return View(pizzas);
        }

        // UPDATE (Actualizar una pizza)
        [HttpPost]
        public IActionResult ActualizarPizza(Pizza pizzaActualizada)
        {
            var pizzasCollection = _database.GetCollection<Pizza>("Pizzas");
            var filtro = Builders<Pizza>.Filter.Eq(p => p.PizzaId, pizzaActualizada.PizzaId);
            var actualizacion = Builders<Pizza>.Update
                .Set(p => p.Nombre, pizzaActualizada.Nombre)
                .Set(p => p.Precio, pizzaActualizada.Precio)
                .Set(p => p.Descripcion, pizzaActualizada.Descripcion);

            pizzasCollection.UpdateOne(filtro, actualizacion);
            return RedirectToAction("Index");
        }

        // DELETE (Eliminar una pizza)
        [HttpPost]
        public IActionResult EliminarPizza(int id)
        {
            var pizzasCollection = _database.GetCollection<Pizza>("Pizzas");
            var filtro = Builders<Pizza>.Filter.Eq(p => p.PizzaId, id);

            pizzasCollection.DeleteOne(filtro);
            return RedirectToAction("Index");
        }
    }
}



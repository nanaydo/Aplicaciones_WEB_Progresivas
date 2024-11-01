using MongoDB.Driver;

namespace PizzaDeliveryApp.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration config)
        {
            // Obtén la cadena de conexión desde appsettings.json
            var connectionString = config.GetConnectionString("MongoDb");
            var mongoClient = new MongoClient(connectionString);

            // Accede a la base de datos
            _database = mongoClient.GetDatabase("PizzaDeliveryDB");
        }

        // Acceder a la colección de pizzas
        public IMongoCollection<Pizza> GetPizzasCollection()
        {
            return _database.GetCollection<Pizza>("Pizzas");
        }

        // Acceder a la colección de pedidos
        public IMongoCollection<Pedido> GetPedidosCollection()
        {
            return _database.GetCollection<Pedido>("Pedidos");
        }

        // Acceder a la colección de clientes
        public IMongoCollection<Cliente> GetClientesCollection()
        {
            return _database.GetCollection<Cliente>("Clientes");
        }
    }
}


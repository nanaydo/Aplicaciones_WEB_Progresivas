using MongoDB.Driver;
using PizzaDeliveryApp;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("PizzaDeliveryDatabase"));
        _database = client.GetDatabase("PizzaDeliveryDB"); // Nombre de la base de datos
    }

    public IMongoCollection<Pizza> Pizzas => _database.GetCollection<Pizza>("Pizzas");
    public IMongoCollection<Pedido> Pedidos => _database.GetCollection<Pedido>("Pedidos");
    public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("Clientes");
}

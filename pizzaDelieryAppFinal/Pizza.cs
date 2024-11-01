using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaDeliveryApp
{
    public class Pizza
    {
        [BsonId] // Usamos BsonId para identificar el campo como el ID
        [BsonRepresentation(BsonType.ObjectId)] // MongoDB usa ObjectId como el identificador
        public int PizzaId { get; set; }

        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
    }
}


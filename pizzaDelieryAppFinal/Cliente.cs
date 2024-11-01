using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaDeliveryApp
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClienteId { get; set; }

        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
    }
}

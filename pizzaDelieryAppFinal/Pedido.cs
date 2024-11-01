using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace PizzaDeliveryApp
{
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PedidoId { get; set; }

        public string ClienteId { get; set; }  // Referencia al cliente por su ID

        public DateTime FechaPedido { get; set; }

        public Cliente Cliente { get; set; }  // Relación con la entidad Cliente
        public List<Pizza> Pizzas { get; set; }  // Lista de pizzas pedidas
    }
}


namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class ProductoCompra
    {
        [JsonProperty("id")]
        public string ProductoCompraId { get; set; }
        [JsonProperty("producto")]
        public string Producto { get; set; }
        [JsonProperty("cantidad")]
        public string Cantidad { get; set; }
        
    }
}

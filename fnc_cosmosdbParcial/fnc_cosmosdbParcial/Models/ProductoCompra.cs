namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class ProductoCompra
    {
        [JsonProperty("id")]
        public int ProductoCompraId { get; set; }
        [JsonProperty("producto")]
        public string Producto { get; set; }
        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }
        
    }
}

namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class QuitarProducto
    {
        [JsonProperty("id")]
        public string QuitarProductoId { get; set; }
        [JsonProperty("producto")]
        public string Producto { get; set; }
        [JsonProperty("cantidad")]
        public string Cantidad { get; set; }
        [JsonProperty("estado")]
        public string Estado { get; set; }
    }
}

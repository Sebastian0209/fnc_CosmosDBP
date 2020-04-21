namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class QuitarProducto
    {
        [JsonProperty("id")]
        public int QuitarProductoId { get; set; }
        [JsonProperty("producto")]
        public string Producto { get; set; }
        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }
        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}

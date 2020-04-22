namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class ConsultaCompra
    {
        [JsonProperty("id")]
        public string ConsultaCompraId { get; set; }
        [JsonProperty("producto")]
        public string Producto { get; set; }
        [JsonProperty("cantidad")]
        public string Cantidad { get; set; }
        [JsonProperty("total")]
        public string Total { get; set; }
    }
}

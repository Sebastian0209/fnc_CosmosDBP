namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class ConsultaCompra
    {
        [JsonProperty("id")]
        public int ConsultaCompraId { get; set; }
        [JsonProperty("producto")]
        public string Producto { get; set; }
        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }
        [JsonProperty("total")]
        public double Total { get; set; }
    }
}

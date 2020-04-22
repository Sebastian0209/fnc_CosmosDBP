

namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class Compra
    {
        [JsonProperty("id")]
        public string CompraId { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("nit")]
        public string Nit { get; set; }
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty("ubicacion")]
        public string Ubicacion { get; set; }
        [JsonProperty("fecha")]
        public string Fecha { get; set; }
        [JsonProperty("total")]
        public double Total { get; set; }

    }
}

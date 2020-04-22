

namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class Cliente
    {
        [JsonProperty("id")]
        public string ClienteId { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("nit")]
        public string Nit { get; set; }
        [JsonProperty("correo")]
        public string Correo { get; set; }
        [JsonProperty("celular")]
        public string Celular { get; set; }
        [JsonProperty("ubicacion")]
        public string Ubicacion { get; set; }
        [JsonProperty("fecha")]
        public string Fecha { get; set; }


    }
}

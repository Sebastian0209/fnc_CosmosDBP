

namespace fnc_cosmosdbParcial.Models
{
    using Newtonsoft.Json;
    public class Cliente
    {
        [JsonProperty("id")]
        public int ClienteId { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("nit")]
        public int Nit { get; set; }
        [JsonProperty("correo")]
        public string Correo { get; set; }
        [JsonProperty("celular")]
        public int Celular { get; set; }
        [JsonProperty("ubicacion")]
        public string Ubicacion { get; set; }
        [JsonProperty("fecha de creacion")]
        public string Fecha { get; set; }


    }
}

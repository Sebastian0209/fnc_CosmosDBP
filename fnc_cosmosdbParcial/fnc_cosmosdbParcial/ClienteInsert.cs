namespace fnc_cosmosdbParcial
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Models;
    public class ClienteInsert
    {
        [FunctionName(nameof(ClienteInsert))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

    
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Cliente>(requestBody);
            var cliente = new Cliente
            {
                ClienteId = data.ClienteId,
                Nombre = data.Nombre,
                Nit = data.Nit,
                Correo=data.Correo,
                Celular=data.Celular,
                Ubicacion=data.Ubicacion,
                Fecha=data.Fecha

            };

            string responseMessage = cliente.Nombre; 

            return new OkObjectResult(responseMessage);
        }
    }
}

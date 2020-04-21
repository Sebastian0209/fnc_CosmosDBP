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
    using Helpers;

    public class ClienteInsert
    {
        [FunctionName(nameof(ClienteInsert))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [CosmosDB(
 
                        databaseName:Constants.COSMOS_DB_DATABASE_NAME,
                        collectionName: Constants.COSMOS_DB_CONTAINER_NAME,
                        ConnectionStringSetting ="StrCosmosCliente"
                        )] IAsyncCollector<object> clientes,

            ILogger log)
        {
            IActionResult returnValue = null;

            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<Cliente>(requestBody);
                var cliente = new Cliente
                {
                    ClienteId = data.ClienteId,
                    Nombre = data.Nombre,
                    Nit = data.Nit,
                    Correo = data.Correo,
                    Celular = data.Celular,
                    Ubicacion = data.Ubicacion,
                    Fecha = data.Fecha

                };
                await clientes.AddAsync(cliente);
                log.LogInformation($"Cliente Insertado {cliente.Nombre}");
                returnValue = new OkObjectResult(cliente);
            }

            catch(Exception ex)
            {
                log.LogError($"No se inserto el cliente.Exception:{ex.Message}");
                returnValue = new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
            return returnValue;
        }
    }
}

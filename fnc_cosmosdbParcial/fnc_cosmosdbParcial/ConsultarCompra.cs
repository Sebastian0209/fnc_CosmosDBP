using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using fnc_cosmosdbParcial.Helpers;
using fnc_cosmosdbParcial.Models;

namespace fnc_cosmosdbParcial
{
    public static class ConsultarCompra
    {
        [FunctionName("ConsultarCompra")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = null)] HttpRequest req,
            [CosmosDB(

                        databaseName:ConstantsP.COSMOS_DB_DATABASE_NAME,
                        collectionName: ConstantsP.COSMOS_DB_CONTAINER_NAME,
                        ConnectionStringSetting ="StrCosmosCliente"
                        )] IAsyncCollector<object> consultas,

            ILogger log)
        {
            IActionResult returnValue = null;

            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<ConsultaCompra>(requestBody);
                var consulta = new ConsultaCompra
                {
                    ConsultaCompraId=data.ConsultaCompraId,
                    Producto=data.Producto,
                    Cantidad=data.Cantidad,
                    Total=data.Total

                };
                await consultas.AddAsync(consulta);
                log.LogInformation($"Consulta Insertado {consulta.Producto}");
                returnValue = new OkObjectResult(consulta);
            }

            catch (Exception ex)
            {
                log.LogError($"No se realizao la consulta.Exception:{ex.Message}");
                returnValue = new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
            return returnValue;
        }
    }
}

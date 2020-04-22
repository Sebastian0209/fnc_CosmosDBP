using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using fnc_cosmosdbParcial.Models;
using fnc_cosmosdbParcial.Helpers;

namespace fnc_cosmosdbParcial
{
    public static class QuiProducto
    {
        [FunctionName("QuiProducto")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
             [CosmosDB(

                        databaseName:ConstantsQ.COSMOS_DB_DATABASE_NAME,
                        collectionName: ConstantsQ.COSMOS_DB_CONTAINER_NAME,
                        ConnectionStringSetting ="StrCosmosCliente"
                        )] IAsyncCollector<object> quitars,
            ILogger log)
        {
            IActionResult returnValue = null;

            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<QuitarProducto>(requestBody);
                var quitar = new QuitarProducto
                {
                    QuitarProductoId=data.QuitarProductoId,
                    Producto=data.Producto,
                    Cantidad=data.Cantidad,
                    Estado=data.Estado
                    

                };
                await quitars.AddAsync(quitar);
                log.LogInformation($"Cliente Insertado {quitar.Producto}");
                returnValue = new OkObjectResult(quitar);
            }

            catch (Exception ex)
            {
                log.LogError($"No se inserto el cliente.Exception:{ex.Message}");
                returnValue = new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
            return returnValue;
        }
    }
}

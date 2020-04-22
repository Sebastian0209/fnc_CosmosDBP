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
    public static class CrearCompra
    {
        [FunctionName("CrearCompra")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
             [CosmosDB(

                        databaseName:ConstantsC.COSMOS_DB_DATABASE_NAME,
                        collectionName: ConstantsC.COSMOS_DB_CONTAINER_NAME,
                        ConnectionStringSetting ="StrCosmosCliente"
                        )] IAsyncCollector<object> compras,

            ILogger log)
        {
            IActionResult returnValue = null;

            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<Compra>(requestBody);
                var compra = new Compra
                {
                    CompraId=data.CompraId,
                    Nombre=data.Nombre,
                    Nit=data.Nit,
                    Descripcion=data.Descripcion,
                    Ubicacion=data.Ubicacion,
                    Fecha=data.Fecha,
                    Total=data.Total

                };
                await compras.AddAsync(compra);
                log.LogInformation($"Cliente Insertado {compra.Nombre}");
                returnValue = new OkObjectResult(compra);
            }

            catch (Exception ex)
            {
                log.LogError($"No se inserto la compra.Exception:{ex.Message}");
                returnValue = new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
            return returnValue;
        }
    }
}

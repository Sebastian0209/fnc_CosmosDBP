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
    public static class IngresarCompra
    {
        [FunctionName("IngresarCompra")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
             [CosmosDB(

                        databaseName:Constants.COSMOS_DB_DATABASE_NAME,
                        collectionName: Constants.COSMOS_DB_CONTAINER_NAME,
                        ConnectionStringSetting ="StrCosmosCliente"
                        )] IAsyncCollector<object> productos,
            ILogger log)
        {
            IActionResult returnValue = null;

            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<ProductoCompra>(requestBody);
                var producto = new ProductoCompra
                {
                    ProductoCompraId=data.ProductoCompraId,
                    Producto=data.Producto,
                    Cantidad=data.Cantidad
                    

                };
                await productos.AddAsync(producto);
                log.LogInformation($"Cliente Insertado {producto.Producto}");
                returnValue = new OkObjectResult(producto);
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

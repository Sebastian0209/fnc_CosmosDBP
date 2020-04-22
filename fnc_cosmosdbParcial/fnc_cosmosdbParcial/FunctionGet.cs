using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using fnc_cosmosdbParcial.Helpers;
using fnc_cosmosdbParcial.Models;

namespace fnc_cosmosdbParcial
{
    public static class FunctionGet
    {
        [FunctionName("FunctionGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "FuncionGet/{id}")] HttpRequest req,
             [CosmosDB(

                        databaseName:Constants.COSMOS_DB_DATABASE_NAME,
                        collectionName: Constants.COSMOS_DB_CONTAINER_NAME,
                        ConnectionStringSetting ="StrCosmosCliente",
                        SqlQuery = "SELECT * FROM c WHERE c.id={id}"            
                         )]

             IEnumerable<Compra> supports,
            ILogger log,
        string id)
        {
            if(supports == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(supports);
        }
        
           
        
    }
}

using InventoryOperationsApis.Models.ResponseModels;
using InventoryOperationsApis.Models.SwaggerModels;
using Swashbuckle.AspNetCore.Filters;
using System.Fabric.Query;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryOperationsApis.Swagger.Examples.Responses
{
    public sealed class SwaggerExampleInventoryResponse : IExamplesProvider<SwaggerInventoryResponse>
    {
        public SwaggerInventoryResponse GetExamples()
        {

            var ExampleInventoryResponse = new SwaggerInventoryResponse
            {

                IsSuccess = true,
                ReturnID = 0,
                StatusCode = "200",
                Message = "Data received successfully",
                Data = new InventoryResponseList()
                { 
                    InventoryList = 
                     new List<InventoryResponse>()
                       {
                           new InventoryResponse
                           {
                                InventoryId = 1,
                                ItemId = 2,
                                ItemName = "Item 1",
                                BrandId = 3,
                                BrandName = "Brand 1",
                                Color = "White",
                                Size = "XL",
                                Gender = "Male",
                                Price = 100,
                                Quantity = 250
                            },
                            new InventoryResponse
                           {
                                InventoryId = 2,
                                ItemId = 2,
                                ItemName = "Item 1",
                                BrandId = 3,
                                BrandName = "Brand 1",
                                Color = "Blue",
                                Size = "Medium",
                                Gender = "Female",
                                Price = 220,
                                Quantity = 1250
                            }
                       }
                }
                                   
            };


            return ExampleInventoryResponse;
        }
    }

    public sealed class InventoryByResponseExample : IExamplesProvider<InventoryResponse>
    {
        public InventoryResponse GetExamples()
        {
            var ExampleInventoryResponse =
                                           new InventoryResponse
                                           {
                                               InventoryId = 1,
                                               ItemId = 2,
                                               ItemName = "Item 1",
                                               BrandId = 3,
                                               BrandName = "Brand 1",
                                               Color = "White",
                                               Size = "XL",
                                               Gender = "Male",
                                               Price = 100,
                                               Quantity = 250
                                           };

            return ExampleInventoryResponse;
        }
    }

    public sealed class InventoryResponseExample : IExamplesProvider<List<InventoryResponse>>
    {
        public List<InventoryResponse> GetExamples()
        {
            var ExampleInventoryResponse = new List<InventoryResponse> { 
                                               new InventoryResponse
                                               {
                                                   InventoryId = 1,
                                                   ItemId = 2,
                                                   ItemName = "Item 1",
                                                   BrandId = 3,
                                                   BrandName = "Brand 1",
                                                   Color = "White",
                                                   Size = "XL",
                                                   Gender = "Male",
                                                   Price = 100,
                                                   Quantity = 250
                                               }
                                           };

            return ExampleInventoryResponse;
        }
    }
}

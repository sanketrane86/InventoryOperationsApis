using InventoryOperationsApis.Models.ResponseModels;

using Swashbuckle.AspNetCore.Filters;
using System.Fabric.Query;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryOperationsApis.Swagger.Examples.Responses
{
    public sealed class BrandResponseExample : IExamplesProvider<List<BrandResponse>>
    {
        public List<BrandResponse> GetExamples()
        {

            var ExampleBrandResponse =

                    new List<BrandResponse>()
                       {
                           new BrandResponse
                           {    
                                BrandId = 3,
                                BrandName = "Brand 1"
                           },
                            new BrandResponse
                            {    
                                BrandId = 3,
                                BrandName = "Brand 1"                                
                            }
                       };
             
            return ExampleBrandResponse;
        }
    }

    public sealed class ItemResponseExample : IExamplesProvider<List<ItemResponse>>
    {
        public List<ItemResponse> GetExamples()
        {

            var ExampleItemResponse =

                    new List<ItemResponse>()
                       {
                           new ItemResponse
                           {
                                ItemId = 3,
                                ItemName = "Item 1"
                           },
                            new ItemResponse
                            {
                                ItemId = 3,
                                ItemName = "Item 1"
                            }
                       };

            return ExampleItemResponse;
        }
    }
}

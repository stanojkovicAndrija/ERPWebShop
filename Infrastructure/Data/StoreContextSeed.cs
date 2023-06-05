using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructue.Data;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
         if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText(path + @"/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText(path + @"/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }
        
        
        if (!context.Products.Any())
                {
                    var productsData =
                        File.ReadAllText(path + @"/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<ProductSeedModel>>(productsData);

                    foreach (var item in products)
                    {
                        var pictureFileName = item.PictureUrl.Substring(16);
                        var product = new Product
                        {
                            Name = item.Name,
                            Description = item.Description,
                            Price = item.Price,
                            ProductBrandId = item.ProductBrandId,
                            ProductTypeId = item.ProductTypeId
                           
                        };
                        product.AddPhoto(item.PictureUrl, pictureFileName);
                        context.Products.Add(product);
                    }
                }
                if (!context.DeliveryMethods.Any())
                {
                var deliveryData = File.ReadAllText(path + @"/Data/SeedData/delivery.json");
                var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                context.DeliveryMethods.AddRange(methods);
                }
                 await context.SaveChangesAsync();
        }
        
    }
}
using AutoMapper;
using GeekShoopping.ProductAPI.Data.ValueObjects;
using GeekShoopping.ProductAPI.Model;

namespace GeekShoopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}

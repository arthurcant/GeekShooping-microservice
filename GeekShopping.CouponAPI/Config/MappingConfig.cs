using AutoMapper;
using GeekShoopping.CouponAPI.Model;
using GeekShopping.CouponAPI.Data.ValueObjects;

namespace GeekShoopping.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}

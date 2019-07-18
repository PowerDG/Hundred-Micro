
using AutoMapper;
using Research.PropertyInfoes;
using Research.PropertyInfoes.Dtos;

namespace Research.PropertyInfoes.Mapper
{

	/// <summary>
    /// 配置PropertyInfo的AutoMapper
    /// </summary>
	internal static class PropertyInfoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <PropertyInfo,PropertyInfoListDto>();
            configuration.CreateMap <PropertyInfoListDto,PropertyInfo>();

            configuration.CreateMap <PropertyInfoEditDto,PropertyInfo>();
            configuration.CreateMap <PropertyInfo,PropertyInfoEditDto>();

        }
	}
}

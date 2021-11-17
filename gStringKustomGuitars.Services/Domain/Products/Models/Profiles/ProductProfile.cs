using AutoMapper;
using gStringKustomGuitars.Services.Domain.Categories.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Products.Models.Entities;

namespace gStringKustomGuitars.Services.Domain.Products.Models.Profiles
{
    public class ProductProfile : Profile
    {  
        public ProductProfile()
        {
            RecognizePrefixes("prd_", "cat_");
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<PS_PRODUCTS_Results, ProductPsResultDto>()
                .ForMember(dtoParameters => dtoParameters.id, configurationExpression => configurationExpression
                  .MapFrom(pedParameters => pedParameters.prd_id))
                .ForMember(dtoParameters => dtoParameters.code, configurationExpression => configurationExpression
                  .MapFrom(pedParameters => pedParameters.prd_code))
                .ForMember(dtoParameters => dtoParameters.name, configurationExpression => configurationExpression
                  .MapFrom(pedParameters => pedParameters.prd_name))
                .ForMember(dtoParameters => dtoParameters.description, configurationExpression => configurationExpression
                  .MapFrom(pedParameters => pedParameters.prd_description))
                .ForMember(dtoParameters => dtoParameters.price, configurationExpression => configurationExpression
                  .MapFrom(pedParameters => pedParameters.prd_price))
                .ForMember(dtoParameters => dtoParameters.image, configurationExpression => configurationExpression
                  .MapFrom(pedParameters => pedParameters.prd_image))
                .ForMember(dtoParameters => dtoParameters.categoryId, configurationExpression => configurationExpression
                  .MapFrom(pedParameters => pedParameters.cat_id))
                .ForMember(dtoParameters => dtoParameters.categoryName, configurationExpression => configurationExpression
                  .MapFrom(pedParameters => pedParameters.cat_name))
                .ReverseMap();

           CreateMap<PS_PRODUCTS_Parameters, ProductPsParamaterDto>()
              .ForMember(dtoParameters => dtoParameters.id, configurationExpression => configurationExpression
                .MapFrom(pedParameters => pedParameters.prd_id))
              .ReverseMap();

            CreateMap<PI_PRODUCTS_Parameters, ProductPiParamaterDto>()
               .ForMember(dtoParameters => dtoParameters.name, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.prd_name))
               .ForMember(dtoParameters => dtoParameters.code, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.prd_code))
               .ForMember(dtoParameters => dtoParameters.description, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.prd_description))
               .ForMember(dtoParameters => dtoParameters.image, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.prd_image))
                .ForMember(dtoParameters => dtoParameters.price, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.prd_price))
                .ForMember(dtoParameters => dtoParameters.categoryId, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.cat_id))
              .ReverseMap();

            CreateMap<PU_PRODUCTS_Parameters, ProductPuParamaterDto>()
              .ForMember(dtoParameters => dtoParameters.id, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.prd_id))
             .ForMember(dtoParameters => dtoParameters.name, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.prd_name))
             .ForMember(dtoParameters => dtoParameters.code, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.prd_code))
             .ForMember(dtoParameters => dtoParameters.description, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.prd_description))
             .ForMember(dtoParameters => dtoParameters.image, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.prd_image))
              .ForMember(dtoParameters => dtoParameters.price, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.prd_price))
              .ForMember(dtoParameters => dtoParameters.categoryId, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.cat_id))
            .ReverseMap();




        }
    }
}



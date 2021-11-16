using AutoMapper;
using gStringKustomGuitars.Api.Domain.Categories.Models.Dtos;
using gStringKustomGuitars.Api.Domain.Categories.Models.Entities;

namespace gStringKustomGuitars.Api.Domain.Categories.Models.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            RecognizePrefixes("cat_");
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<PS_CATEGORIES_Parameters, CategoryPsParamaterDto>()
              .ForMember(dtoParameters => dtoParameters.id, configurationExpression => configurationExpression
                .MapFrom(pedParameters => pedParameters.cat_id))
              .ReverseMap();

            CreateMap<PS_CATEGORIES_Results, CategoryPsResultDto>().ReverseMap();

            CreateMap<PI_CATEGORIES_Parameters, CategoryPiParamaterDto>()
             .ForMember(dtoParameters => dtoParameters.code, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.cat_code))
             .ForMember(dtoParameters => dtoParameters.name, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.cat_name))
             .ReverseMap();

            CreateMap<PU_CATEGORIES_Parameters, CategoryPuParamaterDto>()
           .ForMember(dtoParameters => dtoParameters.id, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.cat_id))
           .ForMember(dtoParameters => dtoParameters.code, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.cat_code))
           .ForMember(dtoParameters => dtoParameters.name, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.cat_name))
            .ForMember(dtoParameters => dtoParameters.isactive, configurationExpression => configurationExpression
               .MapFrom(pedParameters => pedParameters.cat_isactive))
           .ReverseMap();
        }
    }
}

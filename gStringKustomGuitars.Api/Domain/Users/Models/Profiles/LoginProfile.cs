using AutoMapper;
using gStringKustomGuitars.Api.Domain.Users.Models.Dtos;
using gStringKustomGuitars.Api.Domain.Users.Models.Entities;

namespace gStringKustomGuitars.Api.Domain.Users.Models.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            RecognizePrefixes("usr_");
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<PS_LOGIN_Results, UserPsResultsDto>().ReverseMap();

            CreateMap<PS_LOGIN_Parameters, LoginPsParametersDto>()
                .ForMember(dtoParameters => dtoParameters.email, configurationExpression => configurationExpression
                    .MapFrom(pedParameters => pedParameters.email))
                .ForMember(dtoParameters => dtoParameters.password, configurationExpression => configurationExpression
                    .MapFrom(pedParameters => pedParameters.password))
                .ReverseMap();


            CreateMap<PI_USER_Parameters, UserPiParametersDto>()
                  .ForMember(dtoParameters => dtoParameters.name, configurationExpression => configurationExpression
                    .MapFrom(pedParameters => pedParameters.usr_name))
                  .ForMember(dtoParameters => dtoParameters.surname, configurationExpression => configurationExpression
                    .MapFrom(pedParameters => pedParameters.usr_surname))
                  .ForMember(dtoParameters => dtoParameters.email, configurationExpression => configurationExpression
                    .MapFrom(pedParameters => pedParameters.usr_email))
                  .ForMember(dtoParameters => dtoParameters.password, configurationExpression => configurationExpression
                    .MapFrom(pedParameters => pedParameters.usr_password))
                  .ReverseMap();
        }
    }
}

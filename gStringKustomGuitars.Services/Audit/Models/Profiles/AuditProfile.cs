using AutoMapper;
using gStringKustomGuitars.Services.Domain.Audit.Models.Dtos;
using gStringKustomGuitars.Services.Domain.Audit.Models.Entities;

namespace gStringKustomGuitars.Services.Domain.Audit.Models.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            RecognizePrefixes("aud_");
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<PI_AUDIT_Parameters, AuditPiParamaterDto>()
             .ForMember(dtoParameters => dtoParameters.userId, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.usr_id))
             .ForMember(dtoParameters => dtoParameters.eventName, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.aud_event_name))
             .ForMember(dtoParameters => dtoParameters.eventAction, configurationExpression => configurationExpression
                 .MapFrom(pedParameters => pedParameters.aud_event_action))
             .ReverseMap();

          
        }
    }
}

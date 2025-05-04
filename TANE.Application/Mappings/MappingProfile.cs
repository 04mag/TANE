using AutoMapper;
using TANE.Application.Dtos;
using TANE.Rejseplan.Application.Models;

// using AutoMapper.EquivalencyExpression;

// using AutoMapper.Collection.EntityFrameworkCore;

namespace TANE.Rejseplan.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dag, DagReadDto>().ReverseMap();
            CreateMap<DagCreateDto, Dag>().ReverseMap();
            CreateMap<DagUpdateDto, Dag>().ReverseMap();
            CreateMap<Tur, TurReadDto>().ReverseMap();
            CreateMap<TurCreateDto, Tur>().ReverseMap();
            CreateMap<TurUpdateDto, Tur>()
              //  .EqualityComparison((src, dest) => src.RowVersion == dest.RowVersion)
                .ForMember(d => d.Dage, opt => opt.UseDestinationValue());
            CreateMap<RejsePlan, RejseplanReadDto>().ReverseMap();
            CreateMap<RejseplanCreateDto, RejsePlan>().ReverseMap();
            CreateMap<RejseplanUpdateDto, RejsePlan>()
                .ForMember(d => d.Ture, opt => opt.UseDestinationValue());
            CreateMap<DagReorderDto, Dag>().ReverseMap();
            CreateMap<TurReorderDto, Tur>().ReverseMap();

        }
    }
}
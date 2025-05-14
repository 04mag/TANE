using AutoMapper;
using TANE.Application.Dtos;
using TANE.Application.Dtos.TurDagRejseplan;
using TANE.Domain.Entities;
namespace TANE.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tur, TurUpdateDto>()
                .ForMember(d => d.Dage, opt => opt.UseDestinationValue());

            //CreateMap<Models.Rejseplan, RejseplanReadDto>()
            //    .ForMember(dto => dto.Ture, opt => opt.MapFrom(r => r.Ture));
            CreateMap<RejseplanReadDto,Domain.Entities.Rejseplan>()
                .ForMember(d => d.RejseplanStatus,
                    opt => opt.MapFrom(src =>
                        src.RejseplanStatus.HasValue
                            ? (RejseplanStatusDto)src.RejseplanStatus.Value
                            : (RejseplanStatusDto?)null
                    )
                );

            // 2) Tur → TurReadDto
            CreateMap<TurReadDto, Tur>()
                .ForMember(dto => dto.Dage, opt => opt.MapFrom(t => t.Dage));

            // 3) Dag → DagReadDto  <-- denne manglede du
            CreateMap<Dag, DagReadDto>();
            CreateMap<RejseplanUpdateDto, Domain.Entities.Rejseplan>()
                .ForMember(d => d.Ture, opt => opt.UseDestinationValue());


            CreateMap<RejseplanCreateDto, Domain.Entities.Rejseplan>().ReverseMap();
            CreateMap<DagReorderDto, Dag>().ReverseMap();
            CreateMap<TurReorderDto, Tur>().ReverseMap();
            CreateMap<DagCreateDto, Dag>().ReverseMap();
            CreateMap<DagUpdateDto, Dag>().ReverseMap();
            CreateMap<TurCreateDto, Tur>().ReverseMap();


        }
    }
}
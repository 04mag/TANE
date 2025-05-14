using AutoMapper;
using TANE.Application.Dtos;
using TANE.Application.Dtos.Skabeloner;
using TANE.Application.Dtos.TurDagRejseplan;
using TANE.Domain.Entities;
namespace TANE.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tur, TurUpdateDto>()
                .ForMember(d => d.Dage,
                    opt => opt.MapFrom(src => src.Dage));
            //CreateMap<Models.Rejseplan, Rejseplan>()
            //    .ForMember(dto => dto.Ture, opt => opt.MapFrom(r => r.Ture));
            CreateMap<RejseplanReadDto, Rejseplan>()
                .ForMember(d => d.RejseplanStatus,
                    opt => opt.MapFrom(src =>
                        src.RejseplanStatus.HasValue
                            ? (RejseplanStatusDto)src.RejseplanStatus.Value
                            : (RejseplanStatusDto?)null
                    )
                );
            
            CreateMap<TurReadDto, Tur>()
                .ForMember(dto => dto.Dage, opt => opt.MapFrom(t => t.Dage));

            // 3) Dag → Dag  <-- denne manglede du
            CreateMap<DagReadDto, Dag>();
            CreateMap<RejseplanUpdateDto, Rejseplan>()
                .ForMember(d => d.Ture, opt => opt.UseDestinationValue());
            CreateMap<RejseplanCreateDto, Rejseplan>().ReverseMap();
            CreateMap<DagReorderDto, Dag>().ReverseMap();
            CreateMap<TurReorderDto, Tur>().ReverseMap();
            CreateMap<DagCreateDto, Dag>().ReverseMap();
            CreateMap<DagUpdateDto, Dag>().ReverseMap();
            CreateMap<TurCreateDto, Tur>().ReverseMap();

            // skabeloner

            CreateMap<DagSkabelonReadDto, DagSkabelon>().ReverseMap();
            CreateMap<DagSkabelonCreateDto, DagSkabelon>().ReverseMap();
            CreateMap<DagSkabelonUpdateDto, DagSkabelon>().ReverseMap();
            CreateMap<TurSkabelonReadDto, TurSkabelon>().ReverseMap();
            CreateMap<TurSkabelonCreateDto, TurSkabelon>().ReverseMap();
            CreateMap<TurSkabelon, TurSkabelonUpdateDto>()
                //  .EqualityComparison((src, dest) => src.RowVersion == dest.RowVersion)
                .ForMember(d => d.Dage, opt => opt.UseDestinationValue());
            CreateMap<RejseplanSkabelonReadDto, RejseplanSkabelon>().ReverseMap();
            CreateMap<RejseplanSkabelonCreateDto, RejseplanSkabelon>().ReverseMap();
            CreateMap<RejseplanSkabelonUpdateDto, RejseplanSkabelon>()
                .ForMember(d => d.TurSkabeloner, opt => opt.UseDestinationValue());
        }
    }
}
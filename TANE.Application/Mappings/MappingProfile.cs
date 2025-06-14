﻿using AutoMapper;
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
            CreateMap<Tur, TurReadDto>()
                .ForMember(dto => dto.Dage, opt => opt.MapFrom(t => t.Dage));

            // 3) Dag → Dag  <-- denne manglede du
            CreateMap<DagReadDto, Dag>();
            CreateMap<Rejseplan, RejseplanUpdateDto>()
                .ForMember(d => d.Ture, opt => opt.MapFrom(t => t.Ture));
            CreateMap<RejseplanCreateDto, Rejseplan>().ReverseMap();
            CreateMap<DagReorderDto, Dag>().ReverseMap();
            CreateMap<TurReorderDto, Tur>().ReverseMap();
            CreateMap<DagCreateDto, Dag>().ReverseMap();
            CreateMap<DagUpdateDto, Dag>().ReverseMap();
            CreateMap<TurCreateDto, Tur>().ReverseMap();

            //// skabeloner

            //CreateMap<DagSkabelonReadDto, DagSkabelon>().ReverseMap();
            //CreateMap<DagSkabelonCreateDto, DagSkabelon>().ReverseMap();
            //CreateMap<DagSkabelon,DagSkabelonUpdateDto>().ReverseMap();
            //CreateMap<TurSkabelonReadDto, TurSkabelon>().ReverseMap();
            //CreateMap<TurSkabelonCreateDto, TurSkabelon>().ReverseMap();
            //CreateMap<TurSkabelon, TurSkabelonUpdateDto>()
            //    //  .EqualityComparison((src, dest) => src.RowVersion == dest.RowVersion)
            //    .ForMember(d => d.Dage, opt => opt.MapFrom(src => src.Dage));
            //CreateMap<RejseplanSkabelonReadDto, RejseplanSkabelon>().ReverseMap();
            //CreateMap<RejseplanSkabelonCreateDto, RejseplanSkabelon>().ReverseMap();
            //CreateMap<RejseplanSkabelon, RejseplanSkabelonUpdateDto >()
            //    .ForMember(d => d.Ture, opt => opt.MapFrom(src => src.Ture));
        }
    }
}
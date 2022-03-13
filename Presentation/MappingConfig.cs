using AutoMapper;
using DataAccess.Entity;
using Models;
using System;

namespace Presentation
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<SchoolModel, School>()
                .ForMember(f => f.CreatedAt, mf => mf.MapFrom(d =>Convert.ToDateTime(d.CreateDate)));

                config.CreateMap<School, SchoolModel>()
                .ForMember(f => f.CreateDate,
                mf => mf.MapFrom(d =>
                d.CreatedAt==null?"Register Date not Exsit": Convert.ToDateTime(d.CreatedAt)
                .ToString("yyyy/MMM/dd")));

                config.CreateMap<ClassRoom, ClassRoomModel>().ForMember(d => d.SchoolName, mf => mf.MapFrom(s => s.School.Name));
                config.CreateMap<ClassRoomModel, ClassRoom>();
            });
            return mappingConfig;
        }
    }
}

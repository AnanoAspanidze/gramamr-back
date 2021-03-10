using AutoMapper;
using Grammar.Data.Entities;
using Grammar.Data.Models.Admin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grammar.Core.Profiles
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                //cfg.ForAllMaps((typeMap, mappingExpression) => mappingExpression.MaxDepth(1));
                cfg.AddProfile<MappingProfile>();

            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region SubCategories profiles
            CreateMap<SubCategories, AdminSubCategoryModel>()
               .ForMember(dto => dto.Category, opt => opt.MapFrom(x => x.Category.Name))
               .MaxDepth(1);

            CreateMap<Categories, AdminCategoryModel>()
              .MaxDepth(1)
              .ReverseMap();

            CreateMap<Type, AdminTypeModel>()
             .MaxDepth(1)
             .ReverseMap();
            #endregion
        }
    }
  }

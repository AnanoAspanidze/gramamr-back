using AutoMapper;
using Grammar.Data.Entities;
using Grammar.Data.Models.Admin.Models;
using Grammar.Data.Models.Admin.Models.Exercises;
using Grammar.Data.Models.Admin.Models.Exercises.Answers;
using Grammar.Data.Models.Admin.Models.Exercises.Quersions;
using Grammar.Data.Models.Admin.Models.SubCategories;
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
                cfg.ForAllMaps((typeMap, mappingExpression) => mappingExpression.MaxDepth(1));
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
            #region Categories profiles
       
            CreateMap<Categories, AdminCategoryModel>()
              .MaxDepth(1)
              .ReverseMap();

            #endregion

            #region SubCategories profiles
            CreateMap<SubCategories, AdminSubCategoryModel>()
               .ForMember(dto => dto.Category, opt => opt.MapFrom(x => x.Category.Name))
               .MaxDepth(1);

            CreateMap<AdminSubCategoryCreateModel, SubCategories>()
           .MaxDepth(1)
           .ReverseMap();

            CreateMap<AdminSubCategoryEditModel, SubCategories>()
              .MaxDepth(1)
              .ReverseMap();

            CreateMap<Type, AdminTypeModel>()
             .MaxDepth(1)
             .ReverseMap();

            CreateMap<Categories, AdminCategoryModel>()
            .MaxDepth(1)
            .ReverseMap();
            #endregion


            #region Types profiles

            CreateMap<Types, AdminTypeModel>()
              .MaxDepth(1)
              .ReverseMap();

            #endregion

            #region exercises


            CreateMap<Exercises, AdminExerciseModel>()
                .ForMember(dto => dto.Type, opt => opt.MapFrom(x => x.Type.Title))
                .ForMember(dto => dto.SubCategory, opt => opt.MapFrom(x => x.SubCategory.Name))
                .ForMember(dto => dto.Category, opt => opt.MapFrom(x => x.SubCategory.Category.Name));

            CreateMap<Exercises, AdminExerciseModel>()
             .ReverseMap();


            CreateMap<AdminExerciseCreateModel, Exercises>()
            .ReverseMap();

            CreateMap<AdminCreateQuestionModel, Questions>()
              .ReverseMap();


            CreateMap<AdminCreateAnswerModel, Answers>()
            .ReverseMap();

            CreateMap<Exercises, AdminExerciseDetailsModel>()
                .ReverseMap();

            CreateMap<Questions, AdminQuestionDetailsModel>()
                .ReverseMap();

            CreateMap<Answers, AdminAnswerDetailsModel>()
                .ReverseMap();
            #endregion


        }
    }
  }

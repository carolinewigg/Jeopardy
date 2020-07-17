using AutoMapper;
using JeopardyService.Models;
using static JeopardyApi.Models.GameBoardDto;
using static JeopardyApi.Models.GameBoardDto.CategoryDto;

namespace JeopardyService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetQuestionsByCategoryResult, QuestionDto>();
            CreateMap<GetValidCategoriesByRoundResult, CategoryDto>();
        }
    }
}

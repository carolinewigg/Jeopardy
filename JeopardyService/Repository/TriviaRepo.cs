using AutoMapper;
using JeopardyApi.Models;
using JeopardyService.Database;
using JeopardyService.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static JeopardyApi.Models.GameBoardDto;
using static JeopardyApi.Models.GameBoardDto.CategoryDto;

namespace JeopardyService.Repository
{
    public class TriviaRepo : ITriviaRepo
    {
        private readonly JeopardyContext _context;
        private readonly IMapper _mapper;

        public TriviaRepo(JeopardyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetCategoriesByRound(int roundId)
        {
            try
            {
                var SelectedCats = await _context.Set<GetValidCategoriesByRoundResult>().FromSqlRaw($"GetValidCategoriesByRound {roundId}").ToListAsync();
                return _mapper.Map<List<CategoryDto>>(SelectedCats);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<List<QuestionDto>> GetQuestionsByCategory(int categoryId)
        {
            try
            {
                var CategoryQuestions = await _context.Set<GetQuestionsByCategoryResult>().FromSqlRaw($"GetQuestionsByCategory {categoryId}").ToListAsync();
                return _mapper.Map<List<QuestionDto>>(CategoryQuestions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}


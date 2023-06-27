using AutoMapper;
using HomeAccountingBLL.Dtos;
using HomeAccountingDAL.Entities;
using HomeAccountingPL.Models;
using HomeAccountingPL.ViewModels;

namespace HomeAccountingPL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
            CreateMap<ExpensesEntity, ExpensesDto>();
            CreateMap<ExpensesStatisticViewModelEntity, ExpensesStatisticViewModelDto>();
            CreateMap<ExpensesViewModelEntity, ExpensesViewModelDto>();

            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ExpensesStatisticViewModelDto, ExpensesStatisticViewModel>();
            CreateMap<ExpensesViewModelDto, ExpensesViewModel>();
        }
    }
}

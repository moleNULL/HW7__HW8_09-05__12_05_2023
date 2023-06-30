using AutoMapper;
using HomeAccounting.BLL.Dtos;
using HomeAccounting.DAL.Entities;
using HomeAccounting.PL.Models;
using HomeAccounting.PL.ViewModels;

namespace HomeAccounting.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
            CreateMap<ExpensesEntity, ExpensesDto>();
            CreateMap<ExpensesStatisticEntity, ExpensesStatisticDto>();
            CreateMap<ExpensesViewModelEntity, ExpensesViewModelDto>();

            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ExpensesStatisticViewModelDto, ExpensesStatisticViewModel>();
            CreateMap<ExpensesViewModelDto, ExpensesViewModel>();

            CreateMap<ExpensesStatisticViewModelDto, ExpensesStatisticViewModel>();
            CreateMap<ExpensesStatisticDto, ExpensesStatistic>();
            CreateMap<ExpensesStatisticDateDto, ExpensesStatisticDate>();
        }
    }
}

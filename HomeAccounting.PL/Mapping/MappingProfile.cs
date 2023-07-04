using AutoMapper;
using HomeAccounting.BLL.Models;
using HomeAccounting.BLL.Models.Dtos;
using HomeAccounting.DAL.Models.DataModels;
using HomeAccounting.DAL.Models.Entities;
using HomeAccounting.PL.Models;
using HomeAccounting.PL.ViewModels;

namespace HomeAccounting.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapCategories();
            MapExpenses();
            MapStatistic();
        }

        private void MapCategories()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }

        private void MapExpenses()
        {
            CreateMap<ExpensesDataModel, ExpensesModel>();
            CreateMap<ExpensesModel, ExpensesViewModel>();
        }

        private void MapStatistic()
        {
            CreateMap<StatisticDataModel, StatisticModel>();
            CreateMap<StatisticModel, StatisticViewModel>();
            CreateMap<StatisticDateModel, StatisticDateViewModel>();
            CreateMap<StatisticCompositeModel, StatisticCompositeViewModel>();
        }
    }
}

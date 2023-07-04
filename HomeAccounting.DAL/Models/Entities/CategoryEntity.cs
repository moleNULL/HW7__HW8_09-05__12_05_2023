namespace HomeAccounting.DAL.Models.Entities
{
    public class CategoryEntity
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public ICollection<ExpensesEntity> Expenses { get; init; } = new List<ExpensesEntity>();
    }
}

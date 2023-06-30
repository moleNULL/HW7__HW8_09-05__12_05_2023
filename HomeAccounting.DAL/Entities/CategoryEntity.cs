namespace HomeAccounting.DAL.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ExpensesEntity> Expenses { get; set; } = new List<ExpensesEntity>();
    }
}

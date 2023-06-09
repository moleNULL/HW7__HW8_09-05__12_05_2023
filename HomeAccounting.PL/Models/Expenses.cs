﻿namespace HomeAccounting.PL.Models
{
    public class Expenses
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public decimal Cost { get; init; }
        public DateTime Date { get; init; }
        public int CategoryId { get; init; }
        public string? Comment { get; init; }
    }
}

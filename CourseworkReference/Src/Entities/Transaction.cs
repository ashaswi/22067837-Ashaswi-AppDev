namespace CourseworkReference.Entities;


public class Transaction
{
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } // Income, Expense, Debt
    public string? TagName { get; set; }
    public string? Note { get; set; }
}
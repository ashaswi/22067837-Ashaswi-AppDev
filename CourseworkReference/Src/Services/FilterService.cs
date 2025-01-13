namespace CourseworkReference.Services;
using CourseworkReference.Entities;

public class FilterService
{
    public List<Entities.Transaction> Filter(List<Entities.Transaction> transactions, string? typeFilter = null, string? tagFilter = null)
    {
        if (typeFilter != null && !string.IsNullOrEmpty(typeFilter))
        {
            transactions = transactions.Where(t => t.Type == typeFilter).ToList();
        }

        if (tagFilter != null && !string.IsNullOrEmpty(tagFilter))
        {
            transactions = transactions.Where(t => t.TagName == tagFilter).ToList();
        }

        return transactions;
    }
}
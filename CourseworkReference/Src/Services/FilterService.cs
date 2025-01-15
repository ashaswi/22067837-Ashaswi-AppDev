namespace CourseworkReference.Services;
using CourseworkReference.Entities;

public class FilterService
{
    public List<Entities.Transaction> Filter(List<Entities.Transaction> transactions, string? typeFilter = null, string? tagFilter = null) // transaction list of transaction objects, typefilter tagfilter string, returns list of filtered trans
    {
        if (typeFilter != null && !string.IsNullOrEmpty(typeFilter)) // Checking if typefilyer is not null or empty string
        {
            transactions = transactions.Where(t => t.Type == typeFilter).ToList(); // Using LINQ
        }

        if (tagFilter != null && !string.IsNullOrEmpty(tagFilter))
        {
            transactions = transactions.Where(t => t.TagName == tagFilter).ToList();
        }

        return transactions;
    }
}
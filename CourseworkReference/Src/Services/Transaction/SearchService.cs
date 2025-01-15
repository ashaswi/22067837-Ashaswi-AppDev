namespace CourseworkReference.Services.Transaction;

public class SearchService
{
    public List<Entities.Transaction> ApplySearch(List<Entities.Transaction> transactions, string? searchTerm) // transaction object and search team string, returns the filtered list
    {
        // Search transactions
        if (!string.IsNullOrEmpty(searchTerm))
        {
            transactions = transactions.Where(t => t.Description.Contains(searchTerm)).ToList();
        }

        return transactions;
    }
}
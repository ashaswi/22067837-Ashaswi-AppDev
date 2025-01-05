namespace CourseworkReference.Services.Transaction;

using Newtonsoft.Json;
using CourseworkReference.Entities;
public class ListTransactionService(GetJsonFilePathService getJsonFilePathService)
{
    public List<Transaction> ListTransactions()
    {
        String filePath = getJsonFilePathService.GetTransactionPath();
        Console.WriteLine($"File path: {filePath}");
        // Check if the file exists
        List<Transaction> transactions;
        if (File.Exists(filePath))
        {
            // Read and deserialize existing transactions
            var json = File.ReadAllText(filePath);
            transactions = JsonConvert.DeserializeObject<List<Transaction>>(json) ?? new List<Transaction>();
        }
        else
        {
            // Initialize a new list if file doesn't exist
            transactions = new List<Transaction>();
        }

        return transactions;
    }
}
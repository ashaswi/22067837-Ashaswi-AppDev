namespace CourseworkReference.Services.Transaction;

using Newtonsoft.Json;
using CourseworkReference.Entities;
public class ListTransactionService(GetJsonFilePathService getJsonFilePathService)
{
    public List<Transaction> ListTransactions() // Method to retrive list of transaction from Json
    {
        String filePath = getJsonFilePathService.GetTransactionPath();
        Console.WriteLine($"File path: {filePath}");
        // Checking if the file exists
        List<Transaction> transactions;
        if (File.Exists(filePath))
        {
            // Reading and deserialize existing transactions
            var json = File.ReadAllText(filePath);
            transactions = JsonConvert.DeserializeObject<List<Transaction>>(json) ?? new List<Transaction>();
        }
        else
        {
            // Initializing a new list if file doesn't exist
            transactions = new List<Transaction>();
        }

        return transactions;
    }
}
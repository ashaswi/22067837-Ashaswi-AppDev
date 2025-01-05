namespace CourseworkReference.Services.Transaction;
using Newtonsoft.Json;
using CourseworkReference.Entities;


public class AddTransactionService(GetJsonFilePathService getJsonFilePathService)
{
    public void AddTransaction(Transaction transaction)
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

        // Add the new transaction
        transactions.Add(transaction);

        // Serialize the updated list back to JSON
        var updatedJson = JsonConvert.SerializeObject(transactions, Formatting.Indented);

        // Write the JSON back to the file
        File.WriteAllText(filePath, updatedJson);
    }
}
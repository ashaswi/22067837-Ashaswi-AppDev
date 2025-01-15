namespace CourseworkReference.Services.Transaction;
using Newtonsoft.Json;
using CourseworkReference.Entities;


public class AddTransactionService(GetJsonFilePathService getJsonFilePathService)
{
    public void AddTransaction(Transaction transaction) // Method to add new transaction to Json file
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

        // Adding the new transaction
        transactions.Add(transaction);

        // Serializing the updated list back to JSON
        var updatedJson = JsonConvert.SerializeObject(transactions, Formatting.Indented);

        // Writing the JSON back to the file
        File.WriteAllText(filePath, updatedJson);
    }
}
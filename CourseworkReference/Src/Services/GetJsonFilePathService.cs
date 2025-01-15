namespace CourseworkReference.Services;

public class GetJsonFilePathService
{
    public String GetTransactionPath() // Mthod to get the file path returns string of full file path
    {
        return Path.Combine(FileSystem.AppDataDirectory, "transactions.json");
    }

    public String GetTagPath() //Method to get the file path for tag
    {
        return Path.Combine(FileSystem.AppDataDirectory, "tags.json");
    }
}
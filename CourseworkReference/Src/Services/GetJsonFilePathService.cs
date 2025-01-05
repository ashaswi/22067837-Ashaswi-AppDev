namespace CourseworkReference.Services;

public class GetJsonFilePathService
{
    public String GetTransactionPath()
    {
        return Path.Combine(FileSystem.AppDataDirectory, "transactions.json");
    }
    
    public String GetTagPath()
    {
        return Path.Combine(FileSystem.AppDataDirectory, "tags.json");
    }
}
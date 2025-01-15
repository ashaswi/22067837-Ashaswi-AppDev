using Newtonsoft.Json;

namespace CourseworkReference.Services.Tag;
using Entities;

public class ListTagService(GetJsonFilePathService getJsonFilePathService) //  Constructor takes `GetJsonFilePathService` instance 
{
    public List<Tag> ListTags() //  // Method to retrieve a list of tags from a JSON file
    {
        String filePath = getJsonFilePathService.GetTagPath();
        Console.WriteLine($"File path: {filePath}");
        // Checking if the file exists
        List<Tag> tags;
        if (File.Exists(filePath))
        {
            // Reading and deserialize existing tags
            var json = File.ReadAllText(filePath);
            tags = JsonConvert.DeserializeObject<List<Tag>>(json) ?? new List<Tag>();
        }
        else
        {
            // Initializing a new list if file doesn't exist
            tags = new List<Tag>();
        }

        return tags;
    }
}
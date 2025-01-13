using Newtonsoft.Json;

namespace CourseworkReference.Services.Tag;
using Entities;

public class ListTagService(GetJsonFilePathService getJsonFilePathService)
{
    public List<Tag> ListTags()
    {
        String filePath = getJsonFilePathService.GetTagPath();
        Console.WriteLine($"File path: {filePath}");
        // Check if the file exists
        List<Tag> tags;
        if (File.Exists(filePath))
        {
            // Read and deserialize existing tags
            var json = File.ReadAllText(filePath);
            tags = JsonConvert.DeserializeObject<List<Tag>>(json) ?? new List<Tag>();
        }
        else
        {
            // Initialize a new list if file doesn't exist
            tags = new List<Tag>();
        }

        return tags;
    }
}
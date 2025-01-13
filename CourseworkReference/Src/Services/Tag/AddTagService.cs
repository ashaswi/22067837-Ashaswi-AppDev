using CourseworkReference.Services.Transaction;
using Newtonsoft.Json;

namespace CourseworkReference.Services.Tag;

public class AddTagService(GetJsonFilePathService getJsonFilePathService)
{
    public void AddTag(Entities.Tag tag)
    {
        String filePath = getJsonFilePathService.GetTagPath();
        Console.WriteLine($"File path: {filePath}");
        // Check if the file exists
        List<Entities.Tag> tags;
        if (File.Exists(filePath))
        {
            // Read and deserialize existing tags
            var json = File.ReadAllText(filePath);
            tags = JsonConvert.DeserializeObject<List<Entities.Tag>>(json) ?? new List<Entities.Tag>();
        }
        else
        {
            // Initialize a new list if file doesn't exist
            tags = new List<Entities.Tag>();
        }

        // Add the new tag
        tags.Add(tag);

        // Serialize and write the updated list of tags
        var updatedJson = JsonConvert.SerializeObject(tags);
        File.WriteAllText(filePath, updatedJson);
    }
}
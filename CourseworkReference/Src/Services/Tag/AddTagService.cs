using CourseworkReference.Services.Transaction;
using Newtonsoft.Json; // Library to handle Json data

namespace CourseworkReference.Services.Tag;

public class AddTagService(GetJsonFilePathService getJsonFilePathService)
{
    public void AddTag(Entities.Tag tag) //Adding new tag to the Json file
    {
        String filePath = getJsonFilePathService.GetTagPath(); //Using method from getjsonfilepathservice to get file path
        Console.WriteLine($"File path: {filePath}");
        // Checking if the file exists
        List<Entities.Tag> tags; // Creating list to store the tags
        if (File.Exists(filePath))
        {
            // Reading and deserialize existing tags
            var json = File.ReadAllText(filePath);
            tags = JsonConvert.DeserializeObject<List<Entities.Tag>>(json) ?? new List<Entities.Tag>();
        }
        else
        {
            // Initializing a new list if file doesn't exist
            tags = new List<Entities.Tag>();
        }

        // Adding the new tag
        tags.Add(tag);

        // Serializing and writing the updated list of tags
        var updatedJson = JsonConvert.SerializeObject(tags);
        File.WriteAllText(filePath, updatedJson);
    }
}
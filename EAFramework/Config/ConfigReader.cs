using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EAFramework.Config
{
    public class ConfigReader
    //adding this class to read application settings data from appsettings.json file
    {
        public static TestSettings ReadConfig()
        {
            //open text file, read all content from the file, close the file
            var configFile =
                File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appsettings.json");

            //make property name non case sensitive
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            //adding this to convert browzer type to an enum
            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            
            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerOptions);
        }
    }
}
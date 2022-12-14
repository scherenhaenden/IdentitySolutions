using Helpers.Configuration.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Helpers.Configuration.Core;

public class ConfigurationLoad:IConfigurationLoad
{
    
    public ConfigurationOfApplication LoadAndGetConfiguration()
    {
        /*var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var configurationOfApplication = new ConfigurationOfApplication();
        configuration.Bind(configurationOfApplication);

        return configurationOfApplication;*/
        throw new NotImplementedException();
    }

    public ConfigurationOfApplication LoadAndGetConfiguration(string environment)
    {
        // get current directory
        var currentDirectory = Directory.GetCurrentDirectory();
        
        // get configuration file
        var configurationFile = Path.Combine(currentDirectory, $"appsettings.{environment}.json");
        
        // check if configuration file exists
        if (!File.Exists(configurationFile))
        {
            throw new FileNotFoundException($"Configuration file {configurationFile} not found");
        }
        
        // read configuration file
        var configurationFileContent = File.ReadAllText(configurationFile);
        
        var parsedObject = JObject.Parse(configurationFileContent);
        
        var popupJson = parsedObject["ConfigurationOfApplication"].ToString();
        
        // parse json to object
        var configurationOfApplication = JsonConvert.DeserializeObject<ConfigurationOfApplication>(
            popupJson);

        return configurationOfApplication;
    }
}
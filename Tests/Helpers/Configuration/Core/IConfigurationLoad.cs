using Helpers.Configuration.Models;

namespace Helpers.Configuration.Core;

public interface IConfigurationLoad
{
    ConfigurationOfApplication LoadAndGetConfiguration();
    
    ConfigurationOfApplication LoadAndGetConfiguration(string environment);
}
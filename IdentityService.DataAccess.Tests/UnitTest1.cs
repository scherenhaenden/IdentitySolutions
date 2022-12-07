using IdentityService.DataAccess.Tests._Setup;

namespace IdentityService.DataAccess.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        IConfigurationLoad configurationLoader = new ConfigurationLoad();
        configurationLoader.LoadAndGetConfiguration("sqlite");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
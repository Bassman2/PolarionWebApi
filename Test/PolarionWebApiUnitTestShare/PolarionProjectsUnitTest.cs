namespace PolarionWebApiUnitTest;

[TestClass]
public class PolarionProjectsUnitTest : PolarionBaseUnitTest
{
    //[TestMethod]
    //public async Task TestMethodGetProjectsAsync()
    //{
    //    using var polarion = new Polarion(storeKey, appName);

    //    var list = await polarion.GetProjectsAsync();
    //}

    [TestMethod]
    public async Task TestMethodGetProjectAsync()
    {
        using var polarion = new Polarion(storeKey, appName);

        var item = await polarion.GetProjectAsync(projectId);
        
        Assert.IsNotNull(item, nameof(item));
        Assert.AreEqual(projectId, item.Id, nameof(item.Id));
        Assert.AreEqual(projectName, item.Name, nameof(item.Name));
        Assert.AreEqual("", item.Start, nameof(item.Start));
        Assert.AreEqual("", item.TrackerPrefix, nameof(item.TrackerPrefix));
        Assert.AreEqual("", item.Icon, nameof(item.Icon));
        Assert.AreEqual("", item.Color, nameof(item.Color));
    }
}

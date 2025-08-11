namespace PolarionWebApiUnitTest;

public abstract class PolarionBaseUnitTest
{
    protected static readonly CultureInfo culture = new CultureInfo("en-US");

    protected const string storeKey = "polarion";
    protected const string appName = "UnitTest";

    protected readonly static string polarionHost = KeyStore.Key(storeKey)?.Host!;

    protected const string projectId = "PolarionTraining";
    protected const string projectName = "Polarion Training";
}

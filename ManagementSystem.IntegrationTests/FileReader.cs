using System.Reflection;

namespace ManagementSystem.IntegrationTests;

public static class FileReader
{
    public static string GetFileContent(this string filename)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = assembly.GetManifestResourceNames().First(x => x.EndsWith(filename));

        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}

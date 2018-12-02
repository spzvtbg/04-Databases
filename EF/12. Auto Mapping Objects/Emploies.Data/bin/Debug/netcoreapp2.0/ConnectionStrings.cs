namespace Emploies.Connection
{
    using System.IO;
    using System.Reflection;

    using Newtonsoft.Json;

    public static class ConnectionStrings
    {
        public static string Own = GetJsonContent().MyString;

        public static string Common = GetJsonContent().CommonString;

        private static JsonContent GetJsonContent()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\ConnectionNames.json";
            var jsonText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<JsonContent>(jsonText);
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AppiumCSharp
{
    public static class Startup
    {
          private static IConfigurationRoot ConfigurePlatform { get; set; }

  static Startup()
  {
      var basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
      var configPath = Path.Combine(basePath, "ConfigFiles", "appsettings.Android.json");

      if (!File.Exists(configPath))
      {
          throw new FileNotFoundException($"The configuration file '{configPath}' was not found and is not optional.");
      }

      var builder = new ConfigurationBuilder()
          .SetBasePath(basePath)
          .AddJsonFile(configPath, optional: false, reloadOnChange: true);

      ConfigurePlatform = builder.Build();
  }

  //private static IConfiguration ConfigurePlatform() =>
  //    new ConfigurationBuilder()
  //        .AddJsonFile(@$"ConfigFiles\appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Android"}.json")
  //        .Build();

      
        public static string ReadFromAppSettings(string value) => ConfigurePlatform().GetSection(value).Value;
    }
}

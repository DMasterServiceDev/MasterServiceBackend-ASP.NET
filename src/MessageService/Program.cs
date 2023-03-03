using MessageService;

public class Program
{
  public static void Main(string[] args)
  {
    var configuration = new ConfigurationBuilder()
     .AddJsonFile("appsettings.json")
     .Build();

    try
    {
      CreateHostBuilder(args).Build().Run();
    }
    catch (Exception exc)
    {
      //Log.Fatal(exc, "Can not properly start ClientService.");
    }
    finally
    {
      // Log.CloseAndFlush();
    }

  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
            webBuilder.UseStartup<Startup>();
          });
}

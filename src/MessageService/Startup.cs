using System.Text.RegularExpressions;
using MessageService.Business.Commands.Message;
using MessageService.Business.Commands.Message.Interfaces;
using MessageService.Data;
using MessageService.Data.Interface;
using MessageService.Data.Provider.Ef;
using MessageService.Mappers.Db;
using MessageService.Mappers.Db.Interfaces;
using MessageService.Mappers.Models;
using MessageService.Mappers.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace MessageService;

public class Startup
{
  public const string CorsPolicyName = "MasterDoCorsPolicy";

  public IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddServiceDiscovery(o => o.UseEureka());

    services.AddDiscoveryClient(Configuration);

    services.AddHttpContextAccessor();

    string dbConnStr = ConnectionStringHandler.Get(Configuration);

    services.AddDbContext<MessageDbContext>(options =>
      {
        options.UseNpgsql(dbConnStr);
      });

    services.BuildServiceProvider()
            .GetService<MessageDbContext>()
            .Database
            .Migrate();

    services.AddTransient<ICreateMessageCommand, CreateMessageCommand>();
    services.AddTransient<IGetMessageCommand, GetMessageCommand>();
    services.AddTransient<IDbMessageMapper, DbMessageMapper>();
    services.AddTransient<IMessageInfoMapper, MessageInfoMapper>();
    services.AddTransient<IMessageRepository, MessageRepository>();

    services.AddEndpointsApiExplorer();

    services.AddControllers();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MessageService API", Version = "v1" });
    });
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
  {
    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();

    });

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
  }
}

public static class ConnectionStringHandler
{
  public static string Get(IConfiguration configuration)
  {
    string text = Environment.GetEnvironmentVariable("ConnectionString");
    if (string.IsNullOrEmpty(text))
    {
      text = configuration.GetConnectionString("SQLConnectionString");
      Log.Information("SQL connection string from appsettings.json was used. Value '" + PasswordHider.Hide(text) + "'.");
    }
    else
    {
      Log.Information("SQL connection string from environment was used. Value '" + PasswordHider.Hide(text) + "'.");
    }

    return text;
  }
}

public static class PasswordHider
{
  public static string Hide(string line)
  {
    string text = "Password";
    if (line.IndexOf(text, 0, StringComparison.OrdinalIgnoreCase) != -1)
    {
      string[] array = Regex.Split(line, "[=,; ]");
      for (int i = 0; i < array.Length; i++)
      {
        if (string.Equals(text, array[i], StringComparison.OrdinalIgnoreCase))
        {
          line = line.Replace(array[i + 1], "****");
          break;
        }
      }
    }

    return line;
  }
}

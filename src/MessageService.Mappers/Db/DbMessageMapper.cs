using MessageService.Mappers.Db.Interfaces;
using MessageService.Models.Db;
using MessageService.Models.Db.Requests;
using Microsoft.AspNetCore.Http;

namespace MessageService.Mappers.Db;

public class DbMessageMapper : IDbMessageMapper
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public DbMessageMapper(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public DbMessage Map(CreateMessageRequest request)
  {
    DbMessage message = new();
    message.Content = request.Content;
    message.CreatedAtUtc = DateTime.UtcNow;
    message.CreatedBy = long.Parse(_httpContextAccessor.HttpContext.Request.Headers["id"]);
    message.ReceiverId = request.ReceiverId;
    return message;
  }
}

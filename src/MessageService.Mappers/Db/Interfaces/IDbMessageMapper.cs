using MessageService.Models.Db;
using MessageService.Models.Db.Requests;

namespace MessageService.Mappers.Db.Interfaces;

public interface IDbMessageMapper
{
  DbMessage Map(CreateMessageRequest request);
}

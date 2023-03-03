using MessageService.Models.Db;
using MessageService.Models.Dto.Responses.Message;

namespace MessageService.Mappers.Models.Interfaces;

public interface IMessageInfoMapper
{
  public MessageInfo Map(DbMessage dbMessage);
}

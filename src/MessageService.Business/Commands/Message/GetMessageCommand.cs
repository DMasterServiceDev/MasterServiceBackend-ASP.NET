using MessageService.Business.Commands.Message.Interfaces;
using MessageService.Data.Interface;
using MessageService.Mappers.Models.Interfaces;
using MessageService.Models.Db;
using MessageService.Models.Dto.Responses;
using MessageService.Models.Dto.Responses.Message;

namespace MessageService.Business.Commands.Message;

public class GetMessageCommand : IGetMessageCommand
{
  private readonly IMessageInfoMapper _mapper;
  private readonly IMessageRepository _repo;

  public GetMessageCommand(
    IMessageInfoMapper mapper,
    IMessageRepository repo)
  {
    _mapper = mapper;
    _repo = repo;
  }

  public async Task<OperationResultResponse<MessageInfo?>> ExecuteAsync(long messageId)
  {
    DbMessage dbMessage = await _repo.GetAsync(messageId);

    if (dbMessage == null)
    {
      return new OperationResultResponse<MessageInfo?>() { Body = null };
    }

    return new OperationResultResponse<MessageInfo?>() { Body = _mapper.Map(dbMessage) };
  }
}

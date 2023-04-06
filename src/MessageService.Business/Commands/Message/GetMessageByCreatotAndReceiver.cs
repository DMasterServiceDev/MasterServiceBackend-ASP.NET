using MessageService.Business.Commands.Message.Interfaces;
using MessageService.Data.Interface;
using MessageService.Mappers.Models.Interfaces;
using MessageService.Models.Db;
using MessageService.Models.Dto.Responses;
using MessageService.Models.Dto.Responses.Message;

namespace MessageService.Business.Commands.Message;

public class GetMessageByCreatotAndReceiver : IGetMessageByCreatotAndReceiver
{

  private readonly IMessageInfoMapper _mapper;
  private readonly IMessageRepository _repo;

  public GetMessageByCreatotAndReceiver(
    IMessageInfoMapper mapper,
    IMessageRepository repo)
  {
    _mapper = mapper;
    _repo = repo;
  }

  public async Task<OperationResultResponse<List<MessageInfo>>> ExecuteAsync(long creatorId, long receiverId)
  {
    List<DbMessage> dbMessages = await _repo.GetByIdsAsync(creatorId, receiverId);

    return new OperationResultResponse<List<MessageInfo>>() { Body = _mapper.MapList(dbMessages) };
  }
}

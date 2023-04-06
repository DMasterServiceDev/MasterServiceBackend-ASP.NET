using MessageService.Models.Dto.Responses;
using MessageService.Models.Dto.Responses.Message;

namespace MessageService.Business.Commands.Message.Interfaces;

public interface IGetMessageByCreatotAndReceiver
{
  Task<OperationResultResponse<List<MessageInfo>>> ExecuteAsync(long creatorId, long receiverId);
}

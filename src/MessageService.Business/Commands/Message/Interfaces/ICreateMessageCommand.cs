using MessageService.Models.Db.Requests;
using MessageService.Models.Dto.Responses;

namespace MessageService.Business.Commands.Message.Interfaces;

public interface ICreateMessageCommand
{
  Task<OperationResultResponse<long?>> ExecuteAsync(CreateMessageRequest request);
}

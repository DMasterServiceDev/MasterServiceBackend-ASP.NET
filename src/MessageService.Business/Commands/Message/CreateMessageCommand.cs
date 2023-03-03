using MessageService.Business.Commands.Message.Interfaces;
using MessageService.Data.Interface;
using MessageService.Mappers.Db.Interfaces;
using MessageService.Models.Db.Requests;
using MessageService.Models.Dto.Responses;

namespace MessageService.Business.Commands.Message;

public class CreateMessageCommand : ICreateMessageCommand
{
  private readonly IDbMessageMapper _mapper;
  private readonly IMessageRepository _repository;

  public CreateMessageCommand(
    IDbMessageMapper mapper,
    IMessageRepository repository)
  {
    _mapper = mapper;
    _repository = repository;
  }
  public async Task<OperationResultResponse<long?>> ExecuteAsync(CreateMessageRequest request)
  {
    var messageDb = _mapper.Map(request);
    return new OperationResultResponse<long?>() { Body = await _repository.CreateAsync(messageDb) };
  }
}


using MessageService.Business.Commands.Message.Interfaces;
using MessageService.Models.Db.Requests;
using MessageService.Models.Dto.Responses;
using MessageService.Models.Dto.Responses.Message;
using Microsoft.AspNetCore.Mvc; 

namespace MessageService.Controllers;

[Route("[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<long?>> CreateAsync(
    [FromServices] ICreateMessageCommand command,
    [FromBody] CreateMessageRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("Get")]
  public async Task<OperationResultResponse<MessageInfo?>> GetAsync(
    [FromServices] IGetMessageCommand command,
    [FromQuery] long messageId)
  {
    return await command.ExecuteAsync(messageId);
  }
}

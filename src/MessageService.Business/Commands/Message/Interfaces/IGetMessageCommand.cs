using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageService.Models.Db.Requests;
using MessageService.Models.Dto.Responses;
using MessageService.Models.Dto.Responses.Message;

namespace MessageService.Business.Commands.Message.Interfaces;

public interface IGetMessageCommand
{
    Task<OperationResultResponse<MessageInfo?>> ExecuteAsync(long messageId);
}

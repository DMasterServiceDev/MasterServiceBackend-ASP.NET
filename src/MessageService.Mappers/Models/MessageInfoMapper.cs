using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MessageService.Mappers.Models.Interfaces;
using MessageService.Models.Db;
using MessageService.Models.Dto.Responses.Message;

namespace MessageService.Mappers.Models;

public class MessageInfoMapper : IMessageInfoMapper
{
  public MessageInfo Map(DbMessage dbMessage)
  {
     return new MessageInfo()
            {
              Id = dbMessage.Id,
              Content = dbMessage.Content,
              ReceiverId = dbMessage.ReceiverId,
              CreatedBy = dbMessage.CreatedBy,
              CreatedAtUtc = dbMessage.CreatedAtUtc,
              ModifiedAtUtc = dbMessage.ModifiedAtUtc
            };

  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageService.Models.Dto.Responses.Message;

public class MessageInfo
{
  public long Id { get; set; }

  public string Content { get; set; }

  public long ReceiverId { get; set; }

  public long CreatedBy { get; set; }

  public DateTime CreatedAtUtc { get; set; }

  public DateTime? ModifiedAtUtc { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageService.Models.Db;

[Table("messages")]
public class DbMessage
{

  public const string TableName = "messages";
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Column("id")]
  public long Id { get; set; }

  [Column("content")]
  public string Content { get; set; }

  [Column("receiver_id")]
  public long ReceiverId { get; set; }

  [Column("created_by")] 
  public long CreatedBy { get; set; }

  [Column("created_at_utc")] 
  public DateTime CreatedAtUtc { get; set; }

  [Column("modified_at_utc")] 
  public DateTime? ModifiedAtUtc { get; set; }
}

using MessageService.Data.Interface;
using MessageService.Data.Provider.Ef;
using MessageService.Models.Db;

namespace MessageService.Data;

public class MessageRepository : IMessageRepository
{
  private readonly MessageDbContext _context;

  public MessageRepository(MessageDbContext context)
  {
    _context = context;
  }

  public async Task<long?> CreateAsync(DbMessage dbMessage)
  {
    if (dbMessage is null)
    {
      return null;
    }

    _context.Messages.Add(dbMessage);
    _context.SaveChanges();
    return dbMessage.Id;
  }

  public async Task<DbMessage?> GetAsync(long id)
  {
    return _context.Messages.FirstOrDefault(message => message.Id == id); ;
  }

  public async Task<List<DbMessage>> GetByIdsAsync(long creatorId, long receiverId)
  {
    return _context.Messages.Where(message => message.CreatedBy == creatorId && message.ReceiverId == receiverId).ToList();
  }
}

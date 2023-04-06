using MessageService.Models.Db;

namespace MessageService.Data.Interface;

public interface IMessageRepository
{
  Task<long?> CreateAsync(DbMessage request);

  Task<DbMessage?> GetAsync(long id);

  Task<List<DbMessage>> GetByIdsAsync(long creatorId, long receiverId);
}

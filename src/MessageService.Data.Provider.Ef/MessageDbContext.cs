using MessageService.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Data.Provider.Ef;

public class MessageDbContext : DbContext { 
  public MessageDbContext(DbContextOptions<MessageDbContext> options)
  : base(options)
  {
  }

  public DbSet<DbMessage> Messages { get; set; }
}



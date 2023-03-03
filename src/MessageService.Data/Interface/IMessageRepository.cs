using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageService.Models.Db;

namespace MessageService.Data.Interface;

public interface IMessageRepository
{
  Task<long?> CreateAsync(DbMessage request);

  Task<DbMessage?> GetAsync(long id);
}


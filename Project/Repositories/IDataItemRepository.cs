using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface IDataItemRepository
    {
        Task<IEnumerable<DataItem>> GetAllDataItems();
    }
}

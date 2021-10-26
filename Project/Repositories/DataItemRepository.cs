using Microsoft.EntityFrameworkCore;
using Project.DbContexts;
using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class DataItemRepository: IDataItemRepository
    {
        private readonly DataItemContext _context;
        public DataItemRepository(DataItemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DataItem>> GetAllDataItems()
        {
            return await _context.DataItems.ToArrayAsync();
        }
    }
}

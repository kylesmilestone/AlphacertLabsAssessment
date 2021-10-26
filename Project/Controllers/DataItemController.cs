using Microsoft.AspNetCore.Mvc;
using Project.Repositories;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/dataitems")]
    public class DataItemController : Controller
    {
        private readonly IDataItemRepository _dataItemRepository;
        public DataItemController(IDataItemRepository dataItemRepository)
        {
            _dataItemRepository = dataItemRepository;
        }

        // GET api/values  
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _dataItemRepository.GetAllDataItems();
            return Ok(response);
        }
    }
}

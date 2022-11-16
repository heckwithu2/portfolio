using Microsoft.AspNetCore.Mvc;
using portfolioApi.Models;

namespace portfolioApi.Controllers
{
    [ApiController]
    [Route("portfolio/[controller]")]
    public class eventController : ControllerBase
    {
        private readonly portfolioApiContext _context;
        
        public eventController(portfolioApiContext context)
        {
            _context = context;
        }

        [HttpGet("event/{id}")]
        public ActionResult<List<eventModel>> Get(int id)
        {
            return _context.eventModel
                .Where(i => i.Id == id).ToList();
        }

        [HttpGet("event/all")]
        public ActionResult<List<eventModel>> GetAll()
        {
            return _context.eventModel.ToList();
        }       
    }

}
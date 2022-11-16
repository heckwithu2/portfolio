using System.Data;
using Microsoft.AspNetCore.Mvc;
using portfolioApi.Models;

namespace portfolioApi.Controllers
{
    [ApiController]
    [Route("portfolio/[controller]")]
    public class informationController : Controller
    {       
        
        //private readonly ILogger<informationController> _logger;
        private readonly portfolioApiContext _context;
        public informationController(portfolioApiContext context)
        {
            //_logger = logger;
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<List<information>> Get(int id)
        {
            return _context.information
                .Where(i => i.Id == id).ToList();
        }

        [HttpGet("all")]
        public ActionResult<List<information>> GetAll()
        {
            return _context.information.ToList();
        }

        [HttpPost("add")]
        public void add(information info) {
            try {
                _context.Add(info);
                _context.SaveChanges();
            }catch(DataException DataException){
                Console.Write(DataException.ToString());
            }
        }

        [HttpPut("update/{id}")]
        public void update(int id, information info) {
            var recordToUpdate = _context.information
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToUpdate != null) {
                recordToUpdate.firstName = info.firstName;
                recordToUpdate.lastName = info.lastName;
                recordToUpdate.introduction = info.introduction;
                _context.SaveChanges();
            }
        }

        [HttpDelete("delete/{id}")]
        public void delete(int id) {
            var recordToDelete = _context.information
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToDelete != null) {
                _context.information.Remove(recordToDelete);
                _context.SaveChanges();
            }
        }
    }
}
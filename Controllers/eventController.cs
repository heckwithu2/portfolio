using Microsoft.AspNetCore.Mvc;
using portfolioApi.Models;
using System.Data;

namespace portfolioApi.Controllers
{
    [ApiController]
    [Route("portfolio/[controller]")]
    public class eventModelController : ControllerBase
    {
        private readonly portfolioApiContext _context;
        
        public eventModelController(portfolioApiContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<List<eventModel>> Get(int id)
        {
            return _context.eventModel
                .Where(i => i.Id == id).ToList();
        }

        [HttpGet("all")]
        public ActionResult<List<eventModel>> GetAll()
        {
            return _context.eventModel.ToList();
        }       
        [HttpPost("add")]
        public void add(eventModel eventModelModel) {
            try {
                _context.Add(eventModelModel);
                _context.SaveChanges();
            }catch(DataException DataException){
                Console.Write(DataException.ToString());
            }
        }

        [HttpPut("update/{id}")]
        public void update(int id, eventModel eventModel) {
            var recordToUpdate = _context.eventModel
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToUpdate != null) {
                recordToUpdate.title = eventModel.title;
                recordToUpdate.description = eventModel.description;
                recordToUpdate.startDate = eventModel.startDate;
                recordToUpdate.startDate = eventModel.startDate;
                _context.SaveChanges();
            }
        }

        [HttpDelete("delete/{id}")]
        public void delete(int id) {
            var recordToDelete = _context.eventModel
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToDelete != null) {
                _context.eventModel.Remove(recordToDelete);
                _context.SaveChanges();
            }
        }
    }

}
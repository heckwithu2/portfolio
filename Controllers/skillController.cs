using Microsoft.AspNetCore.Mvc;
using portfolioApi.Models;
using System.Data;

namespace portfolioApi.Controllers
{
    [ApiController]
    [Route("portfolio/[controller]")]
    public class skillController : ControllerBase
    {
        private readonly portfolioApiContext _context;
        
        public skillController(portfolioApiContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<List<skill>> Get(int id)
        {
            return _context.skill
                .Where(i => i.Id == id).ToList();
        }

        [HttpGet("all")]
        public ActionResult<List<skill>> GetAll()
        {
            return _context.skill.ToList();
        }       
        [HttpPost("add")]
        public void add(skill skillModel) {
            try {
                _context.Add(skillModel);
                _context.SaveChanges();
            }catch(DataException DataException){
                Console.Write(DataException.ToString());
            }
        }

        [HttpPut("update/{id}")]
        public void update(int id, skill skill) {
            var recordToUpdate = _context.skill
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToUpdate != null) {
                recordToUpdate.title = skill.title;
                recordToUpdate.description = skill.description;
                _context.SaveChanges();
            }
        }

        [HttpDelete("delete/{id}")]
        public void delete(int id) {
            var recordToDelete = _context.skill
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToDelete != null) {
                _context.skill.Remove(recordToDelete);
                _context.SaveChanges();
            }
        }
    }

}
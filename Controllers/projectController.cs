using Microsoft.AspNetCore.Mvc;
using portfolioApi.Models;
using System.Data;

namespace portfolioApi.Controllers
{
    [ApiController]
    [Route("portfolio/[controller]")]
    public class projectController : ControllerBase
    {
        private readonly portfolioApiContext _context;
        
        public projectController(portfolioApiContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<List<project>> Get(int id)
        {
            return _context.project
                .Where(i => i.Id == id).ToList();
        }

        [HttpGet("all")]
        public ActionResult<List<project>> GetAll()
        {
            return _context.project.ToList();
        }       
        [HttpPost("add")]
        public void add(project projectModel) {
            try {
                _context.Add(projectModel);
                _context.SaveChanges();
            }catch(DataException DataException){
                Console.Write(DataException.ToString());
            }
        }

        [HttpPut("update/{id}")]
        public void update(int id, project project) {
            var recordToUpdate = _context.project
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToUpdate != null) {
                recordToUpdate.title = project.title;
                recordToUpdate.description = project.description;
                recordToUpdate.startDate = project.startDate;
                recordToUpdate.startDate = project.startDate;
                _context.SaveChanges();
            }
        }

        [HttpDelete("delete/{id}")]
        public void delete(int id) {
            var recordToDelete = _context.project
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToDelete != null) {
                _context.project.Remove(recordToDelete);
                _context.SaveChanges();
            }
        }
    }

}
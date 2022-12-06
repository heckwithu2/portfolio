using Microsoft.AspNetCore.Mvc;
using portfolioApi.Data_Transfer;
using portfolioApi.Models;
using portfolioApi.Services;
using System.Data;

namespace portfolioApi.Controllers
{
    [ApiController]
    [Route("portfolio/[controller]")]
    public class uriModelController : ControllerBase
    {
        private readonly portfolioApiContext _context;
        
        public uriModelController(portfolioApiContext context)        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<List<uriModel>> Get(int id)
        {
            return _context.uriModel
                .Where(i => i.Id == id).ToList();
        }

        [HttpGet("all")]
        public ActionResult<List<uriModel>> GetAll()
        {
            return _context.uriModel.ToList();
        }       
        [HttpPost("add")]
        public void add(uriModel uriModelModel) {
            try {
                _context.Add(uriModelModel);
                _context.SaveChanges();
            }catch(DataException DataException){
                Console.Write(DataException.ToString());
            }
        }

        [HttpPut("update/{id}")]
        public void update(int id, uriModel uriModel) {
            var recordToUpdate = _context.uriModel
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToUpdate != null) {
                recordToUpdate.title = uriModel.title;
                recordToUpdate.uri = uriModel.uri;
                recordToUpdate.description = uriModel.description;
                _context.SaveChanges();
            }
        }

        [HttpDelete("delete/{id}")]
        public void delete(int id) {
            var recordToDelete = _context.uriModel
                .Where(i => i.Id == id).FirstOrDefault();

            if (recordToDelete != null) {
                _context.uriModel.Remove(recordToDelete);
                _context.SaveChanges();
            }
        }

        [HttpPost("uriThisMapperService")]
        public async Task uriService(uriMapperDTO _uriMapperDTO) {
            uriService _uriService= new uriService();
            await _uriService.uriMapper(_uriMapperDTO);
            //return "hello";
        }
    }

}
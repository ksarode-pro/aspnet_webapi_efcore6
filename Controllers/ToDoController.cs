using Microsoft.AspNetCore.Mvc;
using aspnet_webapi_efcore6.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace aspnet_webapi_efcore6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        AppDbContext _dbcontext;
        public ToDoController(AppDbContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll([FromQuery] string? loadingType)
        {
            var all_todos = default(IQueryable<TodoItem>);
            if (loadingType == "eager")
            {
                all_todos = _dbcontext.TodoItems.Include(x => x.User).AsNoTracking();
                return Ok(all_todos);
            }
            else if (loadingType == "lazy")
            {
                all_todos = _dbcontext.TodoItems;
                foreach (var todo in all_todos)
                {
                    var user = _dbcontext.User.FirstOrDefault(x => x.Id == todo.UserId);
                    if (user != null)
                    {
                        todo.User = user;
                    }
                }
                return Ok(all_todos);
            }
            all_todos = _dbcontext.TodoItems.AsNoTracking();
            return Ok(all_todos);
        }

        [HttpGet]
        public IActionResult Get([FromRoute] long id)
        {
            var item = _dbcontext.TodoItems.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem item)
        {
            await _dbcontext.TodoItems.AddAsync(item);
            _dbcontext.SaveChanges();
            return Ok(item);
        }

        [HttpPost]
        [Route("bulk")]
        public async Task<IActionResult> BulkPost([FromBody] List<TodoItem> items)
        {
            await _dbcontext.TodoItems.AddRangeAsync(items);
            _dbcontext.SaveChanges();
            return Ok(items);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] long id, [FromBody] TodoItem item)
        {
            _dbcontext.TodoItems.Update(item);
            _dbcontext.SaveChanges();
            return Ok(item);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var item = new TodoItem { Id = id };
            _dbcontext.TodoItems.Remove(item);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}



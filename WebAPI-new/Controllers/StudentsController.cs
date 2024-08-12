using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_new.Model;

namespace WebAPI_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext context;
        public StudentsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students_new.ToListAsync();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var data = await context.Students_new.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student std)
        {
            await context.Students_new.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(Student std)
        {
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> RemoveStudentById(int id)
        {
            var data = await context.Students_new.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            context.Students_new.Remove(data);
            await context.SaveChangesAsync();
            return Ok();

        }

    }
}


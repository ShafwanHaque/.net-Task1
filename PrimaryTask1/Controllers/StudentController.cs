using PrimaryTask1.Model;
using Microsoft.AspNetCore.Mvc;



namespace PrimaryTask1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly DbHelper _dbHelper;

        public StudentController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        // POST: api/Student/CreateStudent
        [HttpPost]
        [Route("CreateStudent")]
        public IActionResult CreateStudent([FromBody] StudentModel studentModel)
        {
            try
            {
                _dbHelper.SaveStudent(studentModel);
                return Ok("Student created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating student: {ex.Message}");
            }
        }

        // PUT: api/Student/UpdateStudent/5
        [HttpPut("{id}")]
        [Route("UpdateStudent/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentModel studentModel)
        {
            try
            {
                _dbHelper.UpdateStudent(id, studentModel);
                return Ok("Student updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating student: {ex.Message}");
            }
        }

        // DELETE: api/Student/DeleteStudent/5
        [HttpDelete("{id}")]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _dbHelper.DeleteStudent(id);
                return Ok("Student deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting student: {ex.Message}");
            }
        }

        // GET: api/Student/GetStudentById/5
        [HttpGet("{id}")]
        [Route("GetStudentById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _dbHelper.GetStudentById(id);
                if (student == null)
                    return NotFound("Student not found.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving student: {ex.Message}");
            }
        }

        // GET: api/Student/GetStudents
        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _dbHelper.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving students: {ex.Message}");
            }
        }
    }
}

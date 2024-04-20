using DAL.EF;
using BLL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PrimaryTask1.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly DbHelper dbHelper;

        public StudentController(EF_DataContext eF_DataContext)
        {
            dbHelper = new DbHelper(eF_DataContext);
        }


        // GET (Read all student)
        [HttpGet]
        [Route("api/[controller]/GetStudents")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<StudentModel> data = dbHelper.GetStudents();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        // GET (Read student by ID)
        [HttpGet]
        [Route("api/[controller]/GetStudentById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                StudentModel data = dbHelper.GetStudentById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST (Create student)
        [HttpPost]
        [Route("api/[controller]/CreateStudent")]
        public IActionResult Post([FromBody] StudentModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                dbHelper.SaveStudent(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT (Update student)
        [HttpPut]
        [Route("api/[controller]/UpdateStudent/{id}")]
        public IActionResult Put(int id,[FromBody] StudentModel model)
        {

            try
            {
                
                ResponseType type = ResponseType.Success;
                dbHelper.UpdateStudent(id,model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        // DELETE (Delete Student)
        [HttpDelete]
        [Route("api/[controller]/DeleteStudent/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                dbHelper.DeleteStudent(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}

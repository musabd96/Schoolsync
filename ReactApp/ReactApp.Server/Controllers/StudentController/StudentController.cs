using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }


    
        //GetAllStudents
        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<IActionResult>GetAllStudents()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetStudentById(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // AddStudents
        [HttpPost]
        [Route("addNewStudent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //UpdateStudent
        [HttpPost]
        [Route("updateStudent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudent()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Delete Student
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteStudent()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

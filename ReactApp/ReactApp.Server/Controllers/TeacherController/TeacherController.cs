
using Application.Commands.Teachers.AddTeacher;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.TeacherController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GetAllStudents
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult>GetAllTeachers()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetStudentById(Guid id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        // AddStudents
        [HttpPost]
        [Route("add")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>AddTeacher(TeacherDto newTeacher)
        {
            try
            {
                var command = new AddTeacherCommand(newTeacher);
                var student = await _mediator.Send(command);
                if (student != null)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //UpdateStudent
        [HttpPost]
        [Route("update")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateTeacher(TeacherDto updatedTeacher,Guid updatedTeacherId)
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
        public async Task<ActionResult> DeleteTeacherById(Guid id)
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

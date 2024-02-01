using Application.Commands.Classrooms.AddClassroom;
using Application.Commands.Classrooms.DeleteClassroom;
using Application.Commands.Classrooms.UpdateClassroom;
using Application.Commands.Students.AddStudent;
using Application.Commands.Students.UpdateStudent;
using Application.Dtos;
using Application.Queries.Classrooms.GetAllClassrooms;
using Domain.Models.Classrooms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.ClassroomController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : Controller
    {
        internal readonly IMediator _mediator;

        public ClassroomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllClassrooms")]

        public async Task<IActionResult> GetAllClassrooms()
        {
            try
            {
                var query = new GetAllClassroomQuery();
                var result = await _mediator.Send(query);

                if (!(result is not List<Classroom> classroom || classroom.Count == 0))
                {
                    return Ok(classroom);
                }
                else { return Ok(); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // Add a new Classroom
        [HttpPost]
        [Route("addClassroom")]
        public async Task<IActionResult> AddClassroom([FromBody] ClassroomDto classroomDto)
        {
            try
            {
                var command = new AddClassroomCommand(classroomDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // Delete a classroom by id
        [HttpDelete]
        [Route("deleteClassroomById/{classroomId}")]
        public async Task<IActionResult> DeleteClassroomById(Guid classroomId)
        {
            try
            {
                var query = new DeleteClassroomCommand(classroomId);
                var classroom = await _mediator.Send(query);
                return classroom != null ? Ok(classroom) : NotFound($"No classroom found with ID: {classroomId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in DeleteClassroomById: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }



        // Update a specific classroom
        [HttpPut]
        [Route("updateClassroom/{updatedClassroomId}")]
        public async Task<IActionResult> UpdateClassroom([FromBody] ClassroomDto updatedClassroom, Guid updatedClassroomId)
        {
            try
            {
                var command = new UpdateClassroomCommand(updatedClassroom, updatedClassroomId);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

﻿using Application.Commands.Teachers.DeleteTeacher;
using Application.Commands.Teachers.UpdateTeacher;
using Application.Queries.Teachers.GetTeacherById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.TeacherController
{
    public class TeacherController : Controller
    {
        internal readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GetTeacherById
        [HttpGet]
        [Route("getTeacherById/{teacherId}")]
        public async Task<IActionResult> GetTeacherById(Guid teacherId)
        {
            try
            {
                var query = new GetTeacherByIdQuery(teacherId);
                var teacher = await _mediator.Send(query);
                return teacher != null ? Ok(teacher) : NotFound($"No teacher found with ID: {teacherId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTeacherById: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }

        // Update a teacher
        [HttpPut]
        [Route("updateTeacher/{teacherId}")]
        public async Task<IActionResult> UpdateTeacher(Guid teacherId, [FromBody] UpdateTeacherCommand updateTeacherCommand)
        {
            try
            {
                updateTeacherCommand.Id = teacherId;
                var updatedTeacher = await _mediator.Send(updateTeacherCommand);
                return updatedTeacher != null ? Ok(updatedTeacher) : NotFound($"No teacher found with ID: {teacherId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateTeacher: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }

        //Delete a teacher by id
        [HttpGet]
        [Route("deleteTeacherById/{teacherId}")]
        public async Task<IActionResult> DeleteTeacherById(Guid teacherId)
        {
            try
            {
                var query = new DeleteTeacherCommand(teacherId);
                var teacher = await _mediator.Send(query);
                return teacher != null ? Ok(teacher) : NotFound($"No teacher found with ID: {teacherId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetTeacherById: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

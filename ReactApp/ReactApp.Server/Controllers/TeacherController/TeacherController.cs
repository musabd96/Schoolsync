﻿using Application.Commands.Teachers.AddTeacher;
using Application.Queries.Teachers.GetAllTeachers;
using Application.Commands.Teachers.DeleteTeacher;
using Application.Queries.Teachers.GetTeacherById;
using Domain.Models.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Application.Commands.Teachers.UpdateTeacher;
using Application.Validators.GuidValidation;
using Application.Validators.Teachers;

namespace ReactApp.Server.Controllers.TeacherController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        internal readonly IMediator _mediator;
        internal readonly TeacherValidator _teacherValidator;
        internal readonly GuidValidator _guidValidator;

        public TeacherController(IMediator mediator, TeacherValidator teacherValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _teacherValidator = teacherValidator;
            _guidValidator = guidValidator;
        }
        //Get all Teachers
        [HttpGet]
        [Route("getAllTeachers")]

        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var query = new GetAllTeachersQuery();
                var result = await _mediator.Send(query);

                // Check if the result is a valid list of teachers
                if (result is List<Teacher> Teachers && Teachers.Any())
                {
                    // Return OkObjectResult with the list of teachers
                    return Ok(Teachers);
                }
                else
                {
                    // Return OkResult with an empty result or handle accordingly
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
        public async Task<IActionResult> UpdateTeacher([FromBody] TeacherDto updatedTeacher, Guid teacherId)
        {
            try
            {
                var validationResult = _guidValidator.Validate(teacherId);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                validationResult = _teacherValidator.Validate(updatedTeacher);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new UpdateTeacherCommand(updatedTeacher, teacherId);
                var result = await _mediator.Send(command);

                return result != null ? Ok(result) : NotFound($"No teacher found with ID: {teacherId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateTeacher: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        //Delete a teacher by id
        [HttpDelete]
        [Route("deleteTeacherById/{teacherId}")]
        public async Task<IActionResult> DeleteTeacherById(Guid teacherId)
        {
            try
            {
                var validationResult = _guidValidator.Validate(teacherId);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var query = new DeleteTeacherCommand(teacherId);
                var teacher = await _mediator.Send(query);

                return teacher != null ? Ok(teacher) : NotFound($"No teacher found with ID: {teacherId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in DeleteTeacherById: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        // Add a new Teacher
        [HttpPost]
        [Route("addTeacher")]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherDto teacherDto)
        {
            try
            {
                var validationResult = _teacherValidator.Validate(teacherDto);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new AddTeacherCommand(teacherDto);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in AddTeacher: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

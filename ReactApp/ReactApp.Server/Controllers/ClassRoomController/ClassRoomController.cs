﻿using Application.Commands.Classrooms.UpdateClassroom;
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

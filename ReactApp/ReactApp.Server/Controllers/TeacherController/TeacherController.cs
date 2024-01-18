
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Queries.Teachers.GetAllTeachers;
using MediatR;
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

        // Get all Teachers
        [HttpGet]
        [Route("getAllTeachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var query = new GetAllTeachersQuery();
                var result = await _mediator.Send(query);

                // Check if the result is a valid list of teachers
                if (result is List<TeacherDto> teachers && teachers.Any())
                {
                    // Return OkObjectResult with the list of teachers
                    return Ok(teachers);
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
    }
}


﻿using Domain.Models.Student;
using MediatR;

namespace Application.Queries.Students.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public GetStudentByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}

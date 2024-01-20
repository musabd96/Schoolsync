
using Application.Dtos;
using Domain.Models.Student;
using MediatR;
using System;

namespace Application.Commands.Students.AddStudent
{
    public class AddStudentCommand : IRequest<Student>
    {
        public AddStudentCommand(StudentDto student)
        {
            Student = student;
        }
        public StudentDto Student { get; set; }
    }
}

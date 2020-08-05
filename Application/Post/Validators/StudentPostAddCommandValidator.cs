using System;
using System.Collections.Generic;
using System.Text;
using Application.Post.Commands;
using FluentValidation;

namespace Application.Post.Validators
{
public class StudentPostAddCommandValidator:AbstractValidator<StudentPostAddCommand>
    {
        public StudentPostAddCommandValidator()
        {
            RuleFor(x => x.PostText).NotEmpty();
            RuleFor(x => x.StudentId).NotEmpty();
        }
    }
}

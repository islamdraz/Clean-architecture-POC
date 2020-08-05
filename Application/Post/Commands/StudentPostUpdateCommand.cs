using System;
using System.Collections.Generic;
using System.Text;
using Domain.Post;
using MediatR;

namespace Application.Post.Commands
{
    public class StudentPostUpdateCommand:IRequest<StudentPost>
    {
        public Guid Id { get; set; }
        public string PostText { get; set; }
        public DateTime DateTime { get; set; }
        public int StudentId { get; set; }
    }
}

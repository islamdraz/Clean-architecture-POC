using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Post.Commands
{
    class StudentPostDeleteCommand:IRequest<bool>
    {
        public Guid Id { get; set; }

    }
}

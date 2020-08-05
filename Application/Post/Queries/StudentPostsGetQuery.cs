using System;
using System.Collections.Generic;
using System.Text;
using Domain.Post;
using MediatR;

namespace Application.Post.Queries
{
   public class StudentPostsGetQuery:IRequest<List<StudentPost>>
    {

    }
}

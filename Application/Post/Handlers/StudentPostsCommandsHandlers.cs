using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Post.Commands;
using Domain.Post;
using MediatR;

namespace Application.Post.Handlers
{
public    class StudentPostsCommandsHandlers:IRequestHandler<StudentPostAddCommand,StudentPost>
{
        private readonly IStudentsPortalContext _context;
        public StudentPostsCommandsHandlers(IStudentsPortalContext context)
        {
            _context = context;
        }
        public async Task<StudentPost> Handle(StudentPostAddCommand request, CancellationToken cancellationToken)
        {

            
                var studentPost = new StudentPost(request.PostText, request.DateTime, request.StudentId);

                 _context.StudentPosts.Add(studentPost);

                 await _context.SaveChangesAsync(cancellationToken);
               // _context.SaveChanges();

                return studentPost;
         
        }
    }
}

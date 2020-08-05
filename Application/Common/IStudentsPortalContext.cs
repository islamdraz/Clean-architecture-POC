using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Post;
using Microsoft.EntityFrameworkCore;

namespace Application.Common
{
   public interface IStudentsPortalContext
    {
         DbSet<StudentPost> StudentPosts { get; set; }
         DbSet<InstructorPost> InstructorPosts { get; set; }

         Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

         int SaveChanges();

         Task<int> Complete(CancellationToken cancellationToken = new CancellationToken());


    }
}

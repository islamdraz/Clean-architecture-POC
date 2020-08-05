using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Domain.Kernal;
using Domain.Post;
using Microsoft.EntityFrameworkCore;

namespace Persistance.StudentsPortal
{
    public class StudentsPortalContext:DbContext,IStudentsPortalContext
    {

        public DbSet<InstructorPost> InstructorPosts { get; set; }
        public DbSet<StudentPost> StudentPosts { get; set; }
        public StudentsPortalContext(DbContextOptions options):base(options)
        {
            
        }


        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public Task<int> Complete(CancellationToken cancellationToken = new CancellationToken())
        {
            AddAuitInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddAuitInfo();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Domain.Kernal;

namespace Domain.Post
{
   public class InstructorPost:BaseEntity
    {
        public string PostText { get; set; }
        public DateTime DateTime { get; set; }

        public string InstructorId { get; set; }

    }
}

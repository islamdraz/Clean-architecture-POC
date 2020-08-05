using System;
using System.Collections.Generic;
using System.Text;
using Domain.Kernal;

namespace Domain.Post
{
    public class StudentPost:BaseEntity
    {
        private StudentPost()
        {
            
        }

        public StudentPost(string postText,DateTime dateTime,int studentId)
        {
            PostText = postText;
            DateTime = dateTime;
            StudentId = studentId;
        }
        public string PostText { get; set; }
        public DateTime DateTime { get; set; }
        public int StudentId { get; set; }

    }
}

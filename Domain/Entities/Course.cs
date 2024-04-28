﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

using System.Collections.Generic;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseReporitory : ICourseRepository
    {
        private readonly UniversityDbContext _dbContext;

        public CourseReporitory(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Course> GetCourses()
        {
            return _dbContext.Courses;
        }
    }
}
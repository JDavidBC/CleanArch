using System.Collections.Generic;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _dbContext;

        public CourseRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Course course)
        {
            _dbContext.Add(course);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dbContext.Courses;
        }


    }
}
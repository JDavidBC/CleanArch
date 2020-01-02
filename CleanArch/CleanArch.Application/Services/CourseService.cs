using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMediatorHandler _bus;


        public CourseService(ICourseRepository repository, IMediatorHandler bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public CourseViewModel GetCourses()
        {
            return new CourseViewModel
            {
                Courses = _repository.GetCourses()
            };

        }

        public void Create(CourseViewModel course)
        {
            var createCourseCommand = new CreateCourseCommand(course.Name, course.Description, course.ImageUrl);

            _bus.SendCommand(createCourseCommand);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;

namespace CleanArch.Domain.CommandsHandler
{
    public class CourseCommandHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        private readonly ICourseRepository _repository;

        public CourseCommandHandler(ICourseRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            };

            _repository.Add(course);

            return Task.FromResult(true);
        }
    }
}
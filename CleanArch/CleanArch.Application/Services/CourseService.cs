using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using AutoMapper.QueryableExtensions;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _autoMapper;


        public CourseService(ICourseRepository repository, IMediatorHandler bus, IMapper autoMapper)
        {
            _repository = repository;
            _bus = bus;
            _autoMapper = autoMapper;
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            return _repository.GetCourses().AsQueryable()
                .ProjectTo<CourseViewModel>(_autoMapper.ConfigurationProvider);

        }

        public void Create(CourseViewModel course)
        {
            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(course));
        }
    }
}
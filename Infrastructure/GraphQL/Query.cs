using WebApi.Interfaces;

namespace Infrastructure.GraphQL
{
    public class Query(ICourseService courseService)
    {
        private readonly ICourseService _courseService = courseService;


        [GraphQLName("getCourses")]

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseService.GetAllCourses();
        }
    }
}

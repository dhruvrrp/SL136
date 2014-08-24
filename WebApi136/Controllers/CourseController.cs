namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class CourseController : ApiController
    {
        private readonly CourseService service = new CourseService(new CourseRepository());

        private List<string> errors = new List<string>();

        [HttpGet]
        public List<Course> GetCourseList()
        {
            //// we could log the errors here if there are any...
            return service.GetCourseList(ref errors);
        }

        [HttpPost]
        public string InsertCourse(Course course)
        {
            this.service.InsertCourse(course, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string UpdateCourse(Course course)
        {
            this.service.UpdateCourse(course, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteCourse(string id)
        {
            this.service.DeleteCourse(id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        //// you can add more [HttpGet] and [HttpPost] methods as you need
    }
}
namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class InstructorController : ApiController
    {
        private readonly InstructorService service = new InstructorService(new InstructorRepository());

        private List<string> errors = new List<string>();

        [HttpPost]
        public Instructor GetInstructor(int id)
        {
            return this.service.GetInstructor(id, ref this.errors);
        }

        [HttpPost]
        public string InsertInstructor(Instructor instructor)
        {
            this.service.InsertInstructor(instructor, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string UpdateInstructor(Instructor instructor)
        {
            this.service.UpdateInstructor(instructor, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteInstructor(int id)
        {
            this.service.DeleteInstructor(id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string AssignInstructorToClass(int instructor_id, int schedule_id)
        {
            this.service.AssignInstructorToClass(instructor_id, schedule_id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }
    }
}
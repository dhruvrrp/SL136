namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class StaffController : ApiController
    {
        private readonly StaffService service = new StaffService(new StaffRepository());

        private List<string> errors = new List<string>();

        [HttpGet]
        public Staff GetStaff(string id)
        {
            return this.service.GetStaff(id, ref this.errors);
        }

        [HttpPost]
        public string UpdateStaff(Staff student)
        {
            this.service.UpdateStaff(student, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }
    }
}
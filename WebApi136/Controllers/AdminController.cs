namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class AdminController : ApiController
    {
        private readonly AdminService service = new AdminService(new AdminRepository());

        private List<string> errors = new List<string>();

        [HttpPost]
        public Admin GetAdmin(int id)
        {
            return this.service.GetAdmin(id, ref this.errors);
        }

        [HttpPost]
        public string InsertAdmin(Admin admin)
        {
            this.service.InsertAdmin(admin, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string UpdateAdmin(Admin admin)
        {
            this.service.UpdateAdmin(admin, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteAdmin(int id)
        {
            this.service.DeleteAdmin(id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }
    }
}
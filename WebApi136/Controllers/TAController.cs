namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class TAController : ApiController
    {
        private readonly TAService service = new TAService(new TARepository());

        private List<string> errors = new List<string>();

        [HttpGet]
        public TA GetTA(int id)
        {
            return this.service.GetTA(id, ref this.errors);
        }

        [HttpPost]
        public string InsertTA(TA ta)
        {
            this.service.InsertTA(ta, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string UpdateTA(TA ta)
        {
            this.service.UpdateTA(ta, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteTA(int id)
        {
            this.service.DeleteTA(id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpGet]
        public List<TA> GetTAForClass(int scheduleID)
        {
            return this.service.GetTAsForClass(scheduleID, ref this.errors);
        }

        [HttpPost]
        public void AddTAtoClass(int TAId, int scheduleId)
        {
            this.service.AddTAtoClass(TAId, scheduleId, ref this.errors);
        }

        [HttpPost]
        public void RemoveTAFromCLass(int TAId, int scheduleId)
        {
            this.service.RemoveTAFromClass(TAId, scheduleId, ref this.errors);
        }
    }
}
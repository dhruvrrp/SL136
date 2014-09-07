namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;
 
    using Service;

    public class ScheduleController : ApiController
    {
        [HttpGet]
        public List<Schedule> GetScheduleList(string year, string quarter)
        {
            var service = new ScheduleService(new ScheduleRepository());
            var errors = new List<string>();
            return service.GetScheduleList(year, quarter, ref errors);
        }

        [HttpGet]
        public List<string> GetScheduleYear()
        {
            var service = new ScheduleService(new ScheduleRepository());
            var errors = new List<string>();

            return service.GetScheduleYear(ref errors);
        }

        [HttpPost]
        public List<string> GetQuarterForYear(int year)
        {
            var service = new ScheduleService(new ScheduleRepository());
            var errors = new List<string>();
            return service.GetQuarterForYear(year, ref errors);
        }

        [HttpGet]
        public List<string> GetScheduleQuarters()
        {
            var service = new ScheduleService(new ScheduleRepository());
            var errors = new List<string>();

            return service.GetScheduleQuarters(ref errors);
        }
    }
}
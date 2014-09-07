namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class StaffService
    {
        private readonly IStaffRepository repository;
        private Regex emailCheck = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");

        private Regex ssnregex = new Regex(@"(^\d{3}-?\d{2}-?\d{4}$|^XXX-XX-XXXX$)");

        public StaffService(IStaffRepository repository)
        {
            this.repository = repository;
        }

        public void UpdateStaff(Staff staff, ref List<string> errors)
        {
            if (staff == null)
            {
                errors.Add("Staff cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(staff.StaffId))
            {
                errors.Add("Invalid staff id");
                throw new ArgumentException();
            }

            if (staff.StaffId.Length < 5)
            {
                errors.Add("Invalid staff id");
                throw new ArgumentException();
            }

            if (!this.emailCheck.IsMatch(staff.Email))
            {
                errors.Add("Invalid email");
                throw new ArgumentException();
            }

            this.repository.UpdateStaff(staff, ref errors);
        }

        public Staff GetStaff(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid staff id");
                throw new ArgumentException();
            }

            return this.repository.GetStaff(id, ref errors);
        }
    }
}

namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class AdminService
    {
        private readonly IAdminRepository repository;

        public AdminService(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public void InsertAdmin(Admin admin, ref List<string> errors)
        {
            if (admin == null)
            {
                errors.Add("Admin cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.FirstName) || string.IsNullOrEmpty(admin.LastName))
            {
                errors.Add("Invalid Admin name");
                throw new ArgumentException();
            }

            this.repository.InsertAdmin(admin, ref errors);
        }

        public void UpdateAdmin(Admin admin, ref List<string> errors)
        {
            if (admin == null)
            {
                errors.Add("Student cannot be null");
                throw new ArgumentException();
            }

            if (admin.Id == null || admin.Id == 0)
            {
                errors.Add("Invalid Admin id");
                throw new ArgumentException();
            }

            this.repository.UpdateAdmin(admin, ref errors);
        }

        public Admin GetAdmin(int id, ref List<string> errors)
        {
            if (id == null || id == 0)
            {
                errors.Add("Invalid Admin id");
                throw new ArgumentException();
            }

            return this.repository.GetAdminInfo(id, ref errors);
        }

        public void DeleteAdmin(int id, ref List<string> errors)
        {
            if (id == null || id == 0)
            {
                errors.Add("Invalid Admin id");
                throw new ArgumentException();
            }

            this.repository.DeleteAdmin(id, ref errors);
        }
    }
}


namespace IRepository
{
    using POCO;

    using System.Collections.Generic;

    public interface IAdminRepository
    {
        void InsertAdmin(Admin a, ref List<string> errors);

        void UpdateAdmin(Admin ta, ref List<string> errors);

        void DeleteAdmin(int admin_id, ref List<string> errors);

        Admin GetAdminInfo(int admin_id, ref List<string> errors);

    }
}

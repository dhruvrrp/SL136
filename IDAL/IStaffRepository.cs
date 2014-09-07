namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IStaffRepository
    {
        void UpdateStaff(Staff staff, ref List<string> errors);

        Staff GetStaff(string id, ref List<string> errors);
    }
}

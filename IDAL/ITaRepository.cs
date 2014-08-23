namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ITARepository
    {
        void InsertTA(TA ta, ref List<string> errors);

        void UpdateTA(TA ta, ref List<string> errors);

        void DeleteTA(int id, ref List<string> errors);

        TA GetTaInfo(int id, ref List<string> errors);

        void AssignTaToClass(int idOfTA, int scheduleID, ref List<string> errors);

        void RemoveTaFromClass(int idOfTA, int scheduleID, ref List<string> errors);

        List<TA> ViewTasForClass(int scheduleId, ref List<string> errors);
    }
}

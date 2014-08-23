namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ITARepository
    {
        void InsertTA(int idOfTA, string firstName, string lastName, ref List<string> errors);

        void UpdateTaInfomation(int idOfTA, string firstName, string lastName, ref List<string> errors);

        void DeleteTa(int id, ref List<string> errors);

        System.Tuple<string, string> GetTaInfo(int id, ref List<string> errors);

        void AssignTaToClass(int idOfTA, int scheduleID, ref List<string> errors);

        void RemoveTaFromClass(int idOfTA, int scheduleID, ref List<string> errors);

        List<System.Tuple<string, string>> ViewTasForClass(int scheduleId, ref List<string> errors);
    }
}

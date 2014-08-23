namespace POCO
{
    using System.Collections.Generic;

    public class TA
    {
        public int TAId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return this.TAId + "-"
                + this.FirstName + "-"
                + this.LastName;
        }
    }
}

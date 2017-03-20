using System;

namespace ClsAppTypeColumn
{
    public class People
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Guid? GuidId { get; set; }        
        public DateTime? DateCreated { get; set; }
        public TimeSpan? TimeCreated { get; set; }
        public Boolean? Active { get; set; }
        public decimal? Value { get; set; }
    }
}
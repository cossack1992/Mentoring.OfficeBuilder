using System;

namespace Mentoring.OfficeBuilder.DAL.DbModels
{
    public class DbTransition
    {
        public int Id { get; set; }

        public DbSvg Svg { get; set; }

        public string ElementId {get; set;}
    }
}
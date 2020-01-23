using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mentoring.OfficeBuilder.DAL.DbModels
{
    public class DbTransition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DbSvg Svg { get; set; }

        public Guid ElementId {get; set; }

        public bool IsActive { get; set; }
    }
}
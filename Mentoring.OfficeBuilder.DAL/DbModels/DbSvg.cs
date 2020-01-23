using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL.DbModels
{
    public class DbSvg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Html { get; set; }

        public virtual List<DbTransition> Transitions { get; set; }

        public bool IsActive { get; set; }
    }
}

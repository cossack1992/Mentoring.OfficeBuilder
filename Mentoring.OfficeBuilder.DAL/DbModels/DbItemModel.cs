using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL.DbModels
{
    public class DbItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Svg { get; set; }

        public virtual DbAreaModel Area { get; set; }

        public virtual DbAreaModel MoveToArea { get; set; }
    }
}

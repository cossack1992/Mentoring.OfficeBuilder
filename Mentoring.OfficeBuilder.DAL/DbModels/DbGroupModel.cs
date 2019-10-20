using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL.DbModels
{
    public class DbGroupModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;  set; }

        public List<DbItemModel> Items { get; set; }

        public DbAreaModel Area { get; set; }
    }
}

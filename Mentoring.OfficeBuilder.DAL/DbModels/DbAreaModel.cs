using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL.DbModels
{
    public class DbAreaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public virtual List<DbItemModel> Items { get; set; }

        public virtual List<DbItemModel> MovedFromItems { get; set; }

    }
}

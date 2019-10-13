using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.Models
{
    public class OfficeItemModel
    {
        public int Id { get; set; }

        public string Svg { get; set; }

        public int AreaToMove { get; set; }
    }
}

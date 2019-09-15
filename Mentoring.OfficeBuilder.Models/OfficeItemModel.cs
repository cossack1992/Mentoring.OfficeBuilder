using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.Models
{
    public class OfficeItemModel
    {
        public int Id { get; set; }

        public string Svg { get; set; }

        public List<int> Children { get; set; }

        public int? Parent { get; set; }
    }
}

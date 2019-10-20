using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.Models
{
    public class OfficeItemGroup
    {
        public int Id { get; set; }

        public string Svg { get; set; }

        public List<OfficeItemModel> Items { get; set; }

    }
}

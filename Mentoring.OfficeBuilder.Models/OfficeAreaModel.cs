using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.Models
{
    public class OfficeAreaModel
    {       
        public int Id { get; set; }

        public string Name { get; set; }

        public Position Position { get; set; }

        public Size Size { get; set; }

        public List<OfficeItemGroup> Groups { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.Models
{
    public class Transition
    {
        public Guid Id { get; set; }

        public Guid SvgId { get; set; }

        public Guid ElementId { get; set; }
    }
}

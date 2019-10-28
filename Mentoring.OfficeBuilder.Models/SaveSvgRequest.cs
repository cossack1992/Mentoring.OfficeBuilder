using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.Models
{
    public class SaveSvgRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Html { get; set; }
    }
}

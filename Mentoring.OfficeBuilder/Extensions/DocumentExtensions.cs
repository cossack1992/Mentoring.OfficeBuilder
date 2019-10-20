using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Mentoring.OfficeBuilder.Extensions
{
    public static class DocumentExtensions
    {
        public static (int value, decimal unitRatio) GetAttributeValue(this HtmlNode documentElement, string attributeName)
        {

            foreach (var attr in documentElement.Attributes)
            {
                Console.WriteLine("Attr" + attr.Value);
            }

            var attribute = documentElement.Attributes[attributeName].Value;

            return attribute.ConvertAttribute();
        }
    }
}

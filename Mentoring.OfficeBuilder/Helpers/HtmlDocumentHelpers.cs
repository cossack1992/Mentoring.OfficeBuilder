using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.Helpers
{
    public static class HtmlDocumentHelpers
    {
        public static HtmlNode ReadHtml(string file)
        {
            var svgDocument = new HtmlDocument();

            svgDocument.LoadHtml(file);

            return svgDocument.DocumentNode;
        }

        public static void LoopAllNodes(HtmlNode node, Action<HtmlNode> action)
        {
            action(node);

            foreach (HtmlNode n in node.ChildNodes)
            {
                LoopAllNodes(n, action);
            }
        }

        public static void LoopAllNodes(HtmlNode node, Func<HtmlNode> func)
        {
            
        }
    }
}

using HtmlAgilityPack;
using Mentoring.OfficeBuilder.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.Helpers
{
    public class SvgRender : ComponentBase
    {
        [Parameter]
        public SvgModel Model { get; set; }

        [Parameter]
        public EventCallback<string> OnClick { get; set; }

        private void OnEvent(string id)
        {
            OnClick.InvokeAsync(id);
        }

        protected HtmlNode Node { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            int seq;
            Node = HtmlDocumentHelpers.ReadHtml(Model.Html);

            foreach (var childNode in Node.ChildNodes)
            {
                BuildRenderNode(builder, childNode, out seq);
            }
        }

        private void BuildRenderNode(RenderTreeBuilder builder, HtmlNode node, out int seq)
        {
            seq = 0;
            Console.WriteLine(node.Name);
            Console.WriteLine(node.NodeType);
            Console.WriteLine(node.XPath);
            builder.OpenElement(seq++, node.Name);
            foreach (var attribute in node.Attributes)
            {
                builder.AddAttribute(seq++, attribute.Name, attribute.Value);
            }

            if (!node.HasChildNodes)
            {
                Action onclick = () => OnEvent(node.Id);

                builder.AddAttribute(seq++, "onclick", onclick);
            }
            else
            {
                foreach (var childNode in node.ChildNodes)
                {
                    BuildRenderNode(builder, childNode, out seq);
                }
            }
            
            builder.CloseElement();
        }
    }
}

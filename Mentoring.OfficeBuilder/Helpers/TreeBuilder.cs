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
    public class TreeBuilder : ComponentBase
    {
        [Parameter]
        public SvgModel Model { get; set; }

        [Parameter]
        public EventCallback<string> OnClick { get; set; }

        protected HtmlNode Node { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var seq = 0;
            Node = HtmlDocumentHelpers.ReadHtml(Model.Html);

            builder.OpenElement(0, "p");
            builder.OpenElement(1, "strong");
            builder.AddContent(2, "hello");
            builder.CloseElement();
            builder.CloseElement();
        }
    }
}

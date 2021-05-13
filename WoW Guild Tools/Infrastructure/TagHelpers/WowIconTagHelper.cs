using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoW_Guild_Tools.Models;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Infrastructure.TagHelpers
{
    [HtmlTargetElement("i", Attributes = "wow-class")]
    public class WowIconTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        [HtmlAttributeName("wow-class")]
        public WowClass WowClass { get; set; }
        [HtmlAttributeName("wow-spec")]
        public WowSpec WowSpec { get; set; }

        // Expected output: "<i class="wow-icon__class--spec"></i> example: <i class="wow-icon__paladin--retribution"></i>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output != null)
            {
                TagBuilder iconTag = new TagBuilder("i");

                // Create Class Icon
                if (output.Attributes.ContainsName(nameof(WowClass)) && !output.Attributes.ContainsName(nameof(WowSpec)))
                {
                    iconTag.AddCssClass(WowClass.ToString().CreateSlug());
                }
                

                // Create Spec Icon


                output.Content.AppendHtml(iconTag);
            }
            else
            {
                throw new Exception("Output was null when creating TagHelper");
            }

            base.Process(context, output);
        }

        //public string GetSpecIcon(WowSpec spec)
        //{
        //    TagBuilder iconTag = new TagBuilder("i");
        //    string iconCssClass = "";

        //    return iconCssClass;
        //}
    }
}

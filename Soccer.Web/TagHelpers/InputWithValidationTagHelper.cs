using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Soccer.Web.TagHelpers
{
    /// <summary>
    /// Server side validation. 
    /// Adds the 'is-valid' attribute to the input control if it passes validation
    /// Adds the 'is-invalid' attribute to the input control if it does not pass validation
    /// </summary>
    [HtmlTargetElement("input", Attributes = "asp-validate, asp-for")]
    public class InputWithValidationTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;

        public ModelExpression AspFor { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var modelState = ViewContext.ViewData.ModelState;
            var fieldName = AspFor.Name;

            if (string.IsNullOrWhiteSpace(fieldName))
            {
                return;
            }

            modelState.TryGetValue(fieldName, out var entry);

            if (entry == null || !entry.Errors.Any())
            {
                output.RemoveClass("is-invalid", HtmlEncoder.Default);
            }
            else
            {
                output.AddClass("is-invalid", HtmlEncoder.Default);
            }
        }
    }
}

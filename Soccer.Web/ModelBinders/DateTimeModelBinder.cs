using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Soccer.Web.ModelBinders
{
    public class DateTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var displayFormatString = bindingContext.ModelMetadata.DisplayFormatString;
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!string.IsNullOrEmpty(displayFormatString) && !string.IsNullOrEmpty(value.FirstValue))
            {
                displayFormatString = displayFormatString.Replace("{0:", "").Replace("}", "");
                var date = DateTime.ParseExact(value.FirstValue, displayFormatString, CultureInfo.InvariantCulture);
                bindingContext.Result = ModelBindingResult.Success(date);
            }
            return Task.CompletedTask;
        }
    }
}

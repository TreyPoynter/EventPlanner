using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace EventManager.Utilities
{
    public static class SelectListHelper
    {
        public static SelectList GenerateSelectList<T>(IEnumerable<T> items, 
            string textProperty, string valueProperty, string currentOption = "")
        {
            List<SelectListItem> selectListItemList = new List<SelectListItem>();

            // Get properties by name using reflection
            PropertyInfo? textProp = typeof(T).GetProperty(textProperty);
            PropertyInfo? valueProp = typeof(T).GetProperty(valueProperty);

            if (textProp == null || valueProp == null)
            {
                throw new ArgumentException("Text or value property not found");
            }

            // Iterate through items and populate the select list
            foreach (var item in items)
            {
                selectListItemList.Add(new SelectListItem
                {
                    Text = textProp.GetValue(item).ToString(),
                    Value = valueProp.GetValue(item).ToString()
                });
            }
            return new SelectList(selectListItemList, "Value", "Text", currentOption);
        }
    }
}

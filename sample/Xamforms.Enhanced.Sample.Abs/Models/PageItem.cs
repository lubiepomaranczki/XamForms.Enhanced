using System;

namespace Xamforms.Enhanced.Sample.Models
{
    public class PageItem
    {
        public PageItem(string displayName, Type pageType)
        {
            DisplayName = displayName;
            PageType = pageType;
        }
        
        public string DisplayName { get; }
        
        public Type PageType { get; }
    }
}
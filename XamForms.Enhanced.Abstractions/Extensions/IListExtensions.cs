using System.Collections.Generic;

namespace XamForms.Enhanced.Extensions
{
    public static class IListExtensions
    {
        public static void AddRange<T>(this IList<T> collection, IEnumerable<T> itemsToAdd)
        {
            if (itemsToAdd.IsNullOrEmpty())
            {
                return;
            }

            foreach (var item in itemsToAdd)
            {
                collection.Add(item);
            }
        }
    }
}


using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XamForms.Enhanced.Extensions
{
    public static class IListExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }
    }
}

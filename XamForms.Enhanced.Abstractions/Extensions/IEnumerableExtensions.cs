using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace XamForms.Enhanced.Extensions
{
    public static class IEnumerable
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }

        public static bool IsNullOrEMpty<T>(this IEnumerable<T> source)
        {
            if (source == null || !source.Any())
            {
                return true;
            }

            return false;
        }

        public static IList<T> CopyToList<T>(this IEnumerable<T> source)
        {
            if (source.IsNullOrEMpty())
            {
                return new List<T>();
            }

            return new List<T>(source);
        }
    }
}

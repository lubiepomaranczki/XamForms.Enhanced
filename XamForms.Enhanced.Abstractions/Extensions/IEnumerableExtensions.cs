﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace XamForms.Enhanced.Extensions
{
    public static class IEnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null || !source.Any())
            {
                return true;
            }

            return false;
        }

        public static IList<T> CopyToList<T>(this IEnumerable<T> source)
        {
            if (source.IsNullOrEmpty())
            {
                return new List<T>();
            }

            return new List<T>(source);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Restauranter.Shared.Extensions
{
    public static class IDisposableListExtensions
    {
        public static void Dispose(this IList<IDisposable> disposeBag)
        {
            if (disposeBag == null)
            {
                throw new ArgumentNullException();
            }

            var copyOfBag = new List<IDisposable>(disposeBag);

            foreach (var item in copyOfBag)
            {
				disposeBag.Remove(item);
                item.Dispose();
            }
        }
    }
}
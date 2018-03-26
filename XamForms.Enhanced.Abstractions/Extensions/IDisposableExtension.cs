using System;
using System.Collections.Generic;

namespace Restauranter.Shared.Extensions
{
    public static class IDisposableExtension
    {
        public static IDisposable DisposeIn(this IDisposable disposable, IList<IDisposable> disposeBag)
        {
            if (disposeBag == null || disposable == null)
            {
                throw new ArgumentNullException();
            }

            disposeBag.Add(disposable);

            return disposable;
        }
    }
}
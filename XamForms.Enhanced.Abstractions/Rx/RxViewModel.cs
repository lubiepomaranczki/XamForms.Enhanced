using System;
using System.Collections.Generic;
using Restauranter.Shared.Extensions;
using XamForms.Enhanced.ViewModels;

namespace XamForms.Enhanced.Rx
{
    public abstract class RxBaseViewModel : BaseViewModel
    {
        #region Fields

        protected IList<IDisposable> DisposeBag;

        #endregion

        #region Properties

        #endregion

        #region Constructor(s)

        protected RxBaseViewModel()
        {
            DisposeBag = new List<IDisposable>();
        }

        #endregion

        #region Methods

        public virtual void ViewAppearing()
        {
         
        }

        public virtual void ViewDisappearing()
        {
            DisposeBag?.Dispose();
        }

        protected abstract void Observe();

        #endregion
    }
}

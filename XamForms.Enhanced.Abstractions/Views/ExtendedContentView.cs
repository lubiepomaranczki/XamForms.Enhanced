using System.Collections.Generic;
using Xamarin.Forms;
using XamForms.Enhanced.Extensions;

namespace XamForms.Enhanced.Views
{
    public class ExtendedContentView : ContentView
    {
        private bool _didAppear;
        private bool _wasToolbarAvailable;

        private List<ToolbarItem> _originalToolbar;
        private Page _currentPage;

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (IsVisible && !_didAppear)
            {
                _didAppear = true;
                OnViewAppeared();
            }

            var navigationPage = Application.Current.MainPage as NavigationPage;
            if (propertyName=="Renderer" && _didAppear && navigationPage != null )
            {
                OnViewDisappeared();
                _didAppear = false;
                _wasToolbarAvailable = false;
            }

            if (navigationPage != null && IsVisible && navigationPage.CurrentPage != null && !_wasToolbarAvailable && _didAppear)
            {
                _wasToolbarAvailable = true;
                _currentPage = navigationPage.CurrentPage;
                OnToolbarAvailable(navigationPage.CurrentPage.ToolbarItems);
            }
        }

        /// <summary>
        /// Method being called after ContentView appeared.
        /// </summary>
        protected virtual void OnViewAppeared()
        {
        }

        /// <summary>
        /// Method being called after ContentView disappeared.
        /// </summary>
        protected virtual void OnViewDisappeared()
        {
            var copyOfToolbar = new List<ToolbarItem>(_currentPage.ToolbarItems); 
            foreach (var toolbarItem in copyOfToolbar)
            {
                _currentPage.ToolbarItems.Remove(toolbarItem);
            }
            _currentPage.ToolbarItems.AddRange(_originalToolbar);
        }

        /// <summary>
        /// Method being called when Toolbar is available. You can add ToolbarItems in here.
        /// </summary>
        protected virtual void OnToolbarAvailable(IList<ToolbarItem> toolbar)
        {
            _originalToolbar = new List<ToolbarItem>(toolbar);
        }
    }
}
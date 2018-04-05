using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamforms.Enhanced.Sample.Models;
using XamForms.Enhanced.ViewModels;
using System.Collections.Generic;
using XamForms.Enhanced.Extensions;

namespace Xamforms.Enhanced.Sample.ViewModels
{
    public class SampleExtendedListViewViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<TodoModel> listOfTodos;

        #endregion

        #region Properties

        public ObservableCollection<TodoModel> ListOfTodos
        {
            get { return listOfTodos; }
            set
            {

                listOfTodos = value;
                OnPropertyChanged(nameof(ListOfTodos));

            }
        }

        #endregion

        #region Commands

        private Command<TodoModel> todoSelectedCmd;
        public Command<TodoModel> TodoSelectedCmd => todoSelectedCmd ?? (todoSelectedCmd = new Command<TodoModel>(TodoSelected));

        private void TodoSelected(object obj)
        {
            if (!(obj is TodoModel model))
            {
                return;
            }

            System.Diagnostics.Debug.WriteLine(model.Name + " was clicked");
        }

        #endregion

        #region Constructor(s)

        public SampleExtendedListViewViewModel()
        {
            Title = "Sample ExtendedListView";

            ListOfTodos = new List<TodoModel>
            {
                new TodoModel{Name="test1", Description="1. test description"},
                new TodoModel{Name="test2", Description="2. test description"},
                new TodoModel{Name="test3", Description="3. test description"},
                new TodoModel{Name="test4", Description="4. test description"},
                new TodoModel{Name="test5", Description="5. test description"},
                new TodoModel{Name="test6", Description="6. test description"},
                new TodoModel{Name="test7", Description="7. test description"},
                new TodoModel{Name="test8", Description="8. test description"},
            }.ToObservableCollection();
        }

        #endregion

        #region Methods



        #endregion       
    }
}

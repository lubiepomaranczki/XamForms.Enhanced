using Xamforms.Enhanced.Sample.Models;
using XamForms.Enhanced.ViewModels;
using System;
using Xamarin.Forms;

namespace Xamforms.Enhanced.Sample.ViewModels
{
    public class SampleExtendedStackViewModel : BaseViewModel
    {
        #region Fields

        private ObservableModel model;

        private Command changeDateCmd;
        private Command<string> changeTextCmd;

        #endregion

        #region Properties

        public ObservableModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        #endregion

        #region Commands

        public Command ChangeDateCmd => changeDateCmd ?? (changeDateCmd = new Command(ChangeDate));

        public Command<string> ChangeTextCmd => changeTextCmd ?? (changeTextCmd = new Command<string>(ChangeText));

        #endregion

        #region Constructor(s)

        public SampleExtendedStackViewModel()
        {
            Title = "Binding Title";

            Model = new ObservableModel();
        }

        #endregion

        #region Methods

        private void ChangeDate(object obj)
        {
            Model.Name.Value = "Date: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            System.Diagnostics.Debug.WriteLine("I've just changed name");
        }

        private void ChangeText(string text)
        {
            model.Text.Value = text;
        }

        #endregion
    }
}

using Xamforms.Enhanced.Sample.Models;
using XamForms.Enhanced.ViewModels;
using XamForms.Enhanced.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Xamforms.Enhanced.Sample.ViewModels
{
    public class SampleExtendedStackViewModel : BaseViewModel
    {
        #region Fields

        private ObservableModel model;

        private RelayCommand changeDateCmd;

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

        public RelayCommand ChangeDateCmd => changeDateCmd ?? (changeDateCmd = new RelayCommand(ChangeDate));

        #endregion

        #region Constructor(s)

        public SampleExtendedStackViewModel()
        {
            Title = "Binding Title";

            Model = new ObservableModel();
        }

        #endregion

        #region Methods

        private async Task ChangeDate(CancellationToken arg)
        {
            //Do your API call or whatever you need
            await Task.Delay(300);

            Model.Name.Value = "Date: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            System.Diagnostics.Debug.WriteLine("I've just changed name");
        }

        #endregion
    }
}

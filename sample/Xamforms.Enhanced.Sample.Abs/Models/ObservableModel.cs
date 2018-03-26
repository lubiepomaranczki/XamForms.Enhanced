using XamForms.Enhanced.Observable;

namespace Xamforms.Enhanced.Sample.Models
{
    public class ObservableModel
    {
        public ObservableProperty<string> Name { get; set; } = new ObservableProperty<string>("Name");

        public ObservableProperty<string> Text { get; set; } = new ObservableProperty<string>("Text");
    }
}

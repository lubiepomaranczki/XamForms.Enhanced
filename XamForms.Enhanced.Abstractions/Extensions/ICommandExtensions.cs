using System.Windows.Input;

namespace XamForms.Enhanced.Extensions
{
    public static class ICommandExtensions
    {
        public static void Execute(this ICommand command)
        {
            if (command != null && command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
    }
}


using System;
using System.Threading;
using System.Threading.Tasks;

namespace XamForms.Enhanced.Commands
{
    /// <summary>
    /// Represents a parameter command.
    /// </summary>
    /// <typeparam name="TEventArgs">Command output parameter type.</typeparam>
    public class InputRelayCommand<TEventArgs> : RelayCommand<TEventArgs, object>
    {
        #region Constructor(s)

        public InputRelayCommand(Func<TEventArgs, CancellationToken, Task> action)
            : this(action, null)
        {
        }

        public InputRelayCommand(Func<TEventArgs, CancellationToken, Task> action, Predicate<TEventArgs> canExecute)
            : base(async (args, token) => { await action(args, token); return Task.FromResult(0); }, canExecute)
        {
        }

        #endregion
    }
}

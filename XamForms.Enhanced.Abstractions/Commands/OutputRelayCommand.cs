using System;
using System.Threading;
using System.Threading.Tasks;

namespace XamForms.Enhanced.Commands
{
    /// <summary>
    /// Represents a parameterless command.
    /// </summary>
    /// <typeparam name="TEventArgs">Command output parameter type.</typeparam>
    public class OutputRelayCommand<TEventArgs> : RelayCommand<object, TEventArgs>
    {
        #region Constructor(s)

        public OutputRelayCommand(Func<CancellationToken, Task<TEventArgs>> action)
            : this(action, null)
        {
        }

        public OutputRelayCommand(Func<CancellationToken, Task<TEventArgs>> action, Predicate<object> canExecute)
            : base((args, token) => action(token), canExecute)
        {

        }

        #endregion
    }
}

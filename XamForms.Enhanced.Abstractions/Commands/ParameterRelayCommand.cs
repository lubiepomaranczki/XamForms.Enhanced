using System;
using System.Threading;
using System.Threading.Tasks;

namespace XamForms.Enhanced.Commands
{
    public class ParameterRelayCommand<TEventArgs> : RelayCommand<TEventArgs, object>
    {
        #region Constructor(s)

        [Obsolete("ParameterRelayCommand is obsolete. Use InputRelayCommand instead")]
        public ParameterRelayCommand(Func<TEventArgs, CancellationToken, Task> action)
            : this(action, null)
        {
        }

        [Obsolete("ParameterRelayCommand is obsolete. Use InputRelayCommand instead")]
        public ParameterRelayCommand(Func<TEventArgs, CancellationToken, Task> action, Predicate<TEventArgs> canExecute)
            : base(async (args, token) => { await action(args, token); return Task.FromResult(0); }, canExecute)
        {
        }

        #endregion
    }
}

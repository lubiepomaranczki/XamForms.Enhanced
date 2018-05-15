using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using XamForms.Enhanced.Extensions;

namespace XamForms.Enhanced.Commands
{
    #region RelayCommand Generic Overload(s)

    /// <summary>
    /// Represents a parameterless command that does not return any values.
    /// </summary>
    public class RelayCommand : RelayCommand<object, object>
    {
        #region Constructor(s)

        public RelayCommand(Func<CancellationToken, Task> action)
            : this(action, null)
        {

        }

        public RelayCommand(Func<CancellationToken, Task> action, Predicate<object> canExecute)
            : base(async (args, token) => { await action(token); return Task.FromResult(0); }, canExecute)
        {
        }

        #endregion
    }

    /// <summary>
    /// Represents a parameterless command.
    /// </summary>
    /// <typeparam name="TEventArgs">Command output parameter type.</typeparam>
    public class RelayCommand<TEventArgs> : RelayCommand<object, TEventArgs>
    {
        #region Constructor(s)

        public RelayCommand(Func<CancellationToken, Task<TEventArgs>> action)
            : this(action, null)
        {
        }

        public RelayCommand(Func<CancellationToken, Task<TEventArgs>> action, Predicate<object> canExecute)
            : base((args, token) => action(token), canExecute)
        {

        }

        #endregion
    }

    /// <summary>
    /// Represents a parameterless command.
    /// </summary>
    /// <typeparam name="TEventArgs">Command output parameter type.</typeparam>
    public class ParameterRelayCommand<TEventArgs> : RelayCommand<TEventArgs, object>
    {
        #region Constructor(s)

        public ParameterRelayCommand(Func<TEventArgs, CancellationToken, Task> action)
            : this(action, null)
        {
        }

        public ParameterRelayCommand(Func<TEventArgs, CancellationToken, Task> action, Predicate<TEventArgs> canExecute)
            : base(async (args, token) => { await action(args, token); return Task.FromResult(0); }, canExecute)
        {
        }

        #endregion
    }

    #endregion

    /// <summary>
    /// Represents a generic command obtaining a single TCommand parameter value and returns TEventsArgs wrapped in a async task.
    /// </summary>
    /// <typeparam name="TCommand">Command input parameter type.</typeparam>
    /// <typeparam name="TEventArgs">Command output parameter type.</typeparam>
    public class RelayCommand<TCommand, TEventArgs> : ICommand
    {
        #region Private Members

        protected readonly CancellationTokenSource source = new CancellationTokenSource();
        protected readonly Func<TCommand, CancellationToken, Task<TEventArgs>> action;
        protected readonly Predicate<TCommand> canExecute;
        protected readonly SynchronizationContext context;

        protected ManualResetEvent resetEvent;

        #endregion

        #region Public Properties

        public bool IsExecuting { get; protected set; }

        public bool IsCancelled { get; protected set; }

        #endregion

        #region Events

        public event CommandHandler<CommandStateType> Executing;

        public event CommandHandler<TEventArgs> Success;

        public event CommandHandler<Exception> Error;

        public event CommandHandler<TaskCanceledException> Cancelled;

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructor(s)

        public RelayCommand(Func<TCommand, CancellationToken, Task<TEventArgs>> action)
            : this(action, null)
        {
        }

        public RelayCommand(Func<TCommand, CancellationToken, Task<TEventArgs>> action, Predicate<TCommand> canExecute)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.action = action;
            this.canExecute = canExecute;
            this.context = SynchronizationContext.Current ?? new SynchronizationContext();
        }

        #endregion

        #region Execute

        public void Execute(object parameter = null)
        {
            new TaskFactory().StartNew(async () => await ExecuteAsync((TCommand)parameter));
        }

        public async Task ExecuteAsync(TCommand parameter)
        {
            if (!CanExecute(parameter) || IsExecuting)
            {
                return;
            }

            IsExecuting = true;
            RelayCommandExecuting(CommandStateType.Executing);

            try
            {
                var args = await action(parameter, source.Token);
                context.Post(o => Success.Raise(args), null);
            }
            catch (TaskCanceledException ex)
            {
                if (!IsCancelled)
                {
                    IsCancelled = true;
                    context.Post(o => Cancelled.Raise(ex), null);
                }
            }
            catch (Exception ex)
            {
                context.Post(o => Error.Raise(ex), null);
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                // HACK: fix for pull-to-refresh control
                await Task.Delay(250);

                IsExecuting = false;
                RelayCommandExecuting(CommandStateType.Finished);
            }
        }

        private void RelayCommandExecuting(CommandStateType type)
        {
            context.Post(o =>
            {
                Executing.Raise(type);
                if (resetEvent != null && type == CommandStateType.Finished)
                {
                    resetEvent.Set();
                }
            }, null);
        }

        #endregion

        #region CanExecute

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute((TCommand)parameter);
        }

        #endregion

        #region ManualResetEvent

        public ManualResetEvent ConfigureManualResetEvent()
        {
            return resetEvent = new ManualResetEvent(false);
        }

        #endregion

        #region Cancel

        public void CancelCommand()
        {
            if (IsExecuting && !IsCancelled && !source.IsCancellationRequested)
            {
                source.Cancel();
            }
        }

        #endregion
    }

    public delegate void CommandHandler<T>(T args);

    [Flags]
    public enum CommandStateType
    {
        Executing,
        Finished
    }
}

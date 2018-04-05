using XamForms.Enhanced.Commands;

namespace XamForms.Enhanced.Extensions
{
    public static class CommandHandlerExtensions
    {
        public static void Raise<T>(this CommandHandler<T> handler, T args)
        {
            handler?.Invoke(args);
        }
    }
}

using System;

namespace XamForms.Enhanced.Shared
{
    public class DataEventArgs : EventArgs
    {
        #region Properties

        public object Parameter { get; set; }

        #endregion

        #region Constructor(s)

        public DataEventArgs()
        {

        }

        public DataEventArgs(object parameter)
        {
            Parameter = parameter;
        }

        #endregion
    }
}

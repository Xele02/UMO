using System;

namespace UnityEngine.Localization.SmartFormat.Core.Formatting
{
    /// <summary>
    /// An exception designed to halt further processing for a specific format item.
    /// This exception can be raised from an <see cref="ISource"/> to prevent additional processing,
    /// particularly in scenarios where the data's state is not yet prepared or deemed valid.
    /// </summary>
    internal class DataNotReadyException : Exception
    {
        /// <summary>
        /// An optional message to be used in the output string.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="DataNotReadyException"/>.
        /// </summary>
        public DataNotReadyException() { }

        /// <summary>
        /// Creates a new instance of <see cref="DataNotReadyException"/>.
        /// </summary>
        /// <param name="text">Optional text to be used in the output string.</param>
        public DataNotReadyException(string text)
        {
            Text = text;
        }
    }
}

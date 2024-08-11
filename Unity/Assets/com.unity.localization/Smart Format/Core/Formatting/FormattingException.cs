using System;
using UnityEngine.Localization.SmartFormat.Core.Parsing;

namespace UnityEngine.Localization.SmartFormat.Core.Formatting
{
    /// <summary>
    /// An exception caused while attempting to output the format.
    /// </summary>
    public class FormattingException : Exception
    {
        /// <summary>
        /// Creates a new <c>FormattingException</c> exception instance.
        /// </summary>
        /// <param name="errorItem"></param>
        /// <param name="formatException"></param>
        /// <param name="index"></param>
        public FormattingException(FormatItem errorItem, Exception formatException, int index)
        {
            Format = errorItem.baseString;
            ErrorItem = errorItem;
            Issue = formatException.Message;
            Index = index;
        }

        /// <summary>
        /// Creates a new <c>FormattingException</c> exception instance.
        /// </summary>
        /// <param name="errorItem"></param>
        /// <param name="issue"></param>
        /// <param name="index"></param>
        public FormattingException(FormatItem errorItem, string issue, int index)
        {
            Format = errorItem.baseString;
            ErrorItem = errorItem;
            Issue = issue;
            Index = index;
        }

        /// <summary>
        /// The string being formatted.
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// The <see cref="FormatItem"/> causing the error.
        /// </summary>
        public FormatItem ErrorItem { get; }

        /// <summary>
        /// The reported issue.
        /// </summary>
        public string Issue { get; }

        /// <summary>
        /// Index of the error.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// Returns a string representation of the exception.
        /// </summary>
        public override string Message => $"Error parsing format string: {Issue} at {Index}\n{Format}\n{new string('-', Index) + "^"}";
    }
}

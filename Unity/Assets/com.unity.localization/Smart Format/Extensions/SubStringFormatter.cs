using System;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Formatter to access part of a string.
    /// </summary>
    [Serializable]
    public class SubStringFormatter : FormatterBase
    {
        /// <summary>
        /// Specify behavior when start index and/or length is out of range
        /// </summary>
        public enum SubStringOutOfRangeBehavior
        {
            /// <summary>
            /// Returns string.Empty
            /// </summary>
            ReturnEmptyString,

            /// <summary>
            /// Returns the remainder of the string, starting at StartIndex
            /// </summary>
            ReturnStartIndexToEndOfString,

            /// <summary>
            /// Throws <see cref="SmartFormat.Core.Formatting.FormattingException"/>
            /// </summary>
            ThrowException
        }

        [SerializeField]
        char m_ParameterDelimiter = ',';

        [SerializeField]
        string m_NullDisplayString = "(null)";

        [SerializeField]
        SubStringOutOfRangeBehavior m_OutOfRangeBehavior = SubStringOutOfRangeBehavior.ReturnEmptyString;

        /// <summary>
        /// Get or set the behavior for when start index and/or length is too great, defaults to <see cref="SubStringOutOfRangeBehavior.ReturnEmptyString"/>.
        /// </summary>
        public SubStringOutOfRangeBehavior OutOfRangeBehavior
        {
            get => m_OutOfRangeBehavior;
            set => m_OutOfRangeBehavior = value;
        }

        /// <summary>
        /// Creates a new instance of the formatter.
        /// </summary>
        public SubStringFormatter()
        {
            Names = DefaultNames;
        }

        /// <inheritdoc/>
        public override string[] DefaultNames => new[] {"substr"};

        /// <summary>
        /// The delimiter to separate parameters, defaults to comma.
        /// </summary>
        public char ParameterDelimiter
        {
            get => m_ParameterDelimiter;
            set => m_ParameterDelimiter = value;
        }

        /// <summary>
        /// Get or set the string to display for NULL values, defaults to "(null)".
        /// </summary>
        public string NullDisplayString
        {
            get => m_NullDisplayString;
            set => m_NullDisplayString = value;
        }

        /// <summary>
        /// Tries to process the given <see cref="IFormattingInfo"/>.
        /// </summary>
        /// <param name="formattingInfo">Returns true if processed, otherwise false.</param>
        /// <returns></returns>
        public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            if (formattingInfo.FormatterOptions == string.Empty) return false;
            var parameters = formattingInfo.FormatterOptions.Split(ParameterDelimiter);

            var currentValue = formattingInfo.CurrentValue?.ToString();
            if (currentValue == null)
            {
                formattingInfo.Write(NullDisplayString);
                return true;
            }

            var startPos = int.Parse(parameters[0]);
            var length = parameters.Length > 1 ? int.Parse(parameters[1]) : 0;
            if (startPos < 0)
                startPos = currentValue.Length + startPos;
            if (startPos > currentValue.Length)
                startPos = currentValue.Length;
            if (length < 0)
                length = currentValue.Length - startPos + length;

            switch (OutOfRangeBehavior)
            {
                case SubStringOutOfRangeBehavior.ReturnEmptyString:
                    if (startPos + length > currentValue.Length)
                        length = 0;
                    break;
                case SubStringOutOfRangeBehavior.ReturnStartIndexToEndOfString:
                    if (startPos > currentValue.Length)
                        startPos = currentValue.Length;
                    if (startPos + length > currentValue.Length)
                        length = (currentValue.Length - startPos);
                    break;
            }

            var substring = parameters.Length > 1
                ? currentValue.Substring(startPos, length)
                : currentValue.Substring(startPos);

            formattingInfo.Write(substring);

            return true;
        }
    }
}

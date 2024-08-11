using System;
using System.Text.RegularExpressions;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Formatter with evaluation of regular expressions.
    /// </summary>
    /// <remarks>
    /// Syntax:
    /// {value:ismatch(regex): format | default}
    /// Or in context of a list:
    /// {myList:list:{:ismatch(^regex$):{:format}|'no match'}|, | and }
    /// </remarks>
    [Serializable]
    public class IsMatchFormatter : FormatterBase, IFormatterLiteralExtractor
    {
        /// <summary>
        /// Creates a new instance of the formatter.
        /// </summary>
        public IsMatchFormatter()
        {
            Names = DefaultNames;
        }

        /// <inheritdoc/>
        public override string[] DefaultNames => new[] {"ismatch"};

        /// <inheritdoc/>
        public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var expression = formattingInfo.FormatterOptions;
            var formats = formattingInfo.Format.Split('|');

            if (formats.Count == 0)
                return true;

            if (formats.Count != 2)
                throw new FormatException("Exactly 2 format options are required.");

            var regEx = new Regex(expression, RegexOptions);

            if (regEx.IsMatch(formattingInfo.CurrentValue.ToString()))
                formattingInfo.Write(formats[0], formattingInfo.CurrentValue);
            else if (formats.Count == 2)
                formattingInfo.Write(formats[1], formattingInfo.CurrentValue);

            return true;
        }

        /// <inheritdoc/>
        public void WriteAllLiterals(IFormattingInfo formattingInfo)
        {
            var formats = formattingInfo.Format.Split('|');

            if (formats.Count == 0)
                return;

            if (formats.Count != 2)
                return;

            formattingInfo.Write(formats[0], formattingInfo.CurrentValue);
            formattingInfo.Write(formats[1], formattingInfo.CurrentValue);
        }

        /// <summary>
        /// The options that are provided when evaluating the expression.
        /// </summary>
        public RegexOptions RegexOptions { get; set; }
    }
}

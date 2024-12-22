using System;
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Core.Output;
using UnityEngine.Localization.SmartFormat.Core.Parsing;
using UnityEngine.Localization.SmartFormat.Core.Settings;

namespace UnityEngine.Localization.SmartFormat.Core.Formatting
{
    /// <summary>
    /// Contains extra information about the item currently being formatted.
    /// These objects are not often used, so they are all wrapped up here.
    /// </summary>
    public class FormatDetails
    {
        public void Init(SmartFormatter formatter, Format originalFormat, IList<object> originalArgs,
            FormatCache formatCache, IFormatProvider provider, IOutput output)
        {
            Formatter = formatter;
            OriginalFormat = originalFormat;
            OriginalArgs = originalArgs;
            FormatCache = formatCache;
            Provider = provider;
            Output = output;
        }

        internal void Clear()
        {
            Formatter = null;
            OriginalFormat = null;
            OriginalArgs = null;
            FormatCache = null;
            Provider = null;
            Output = null;
            FormattingException = null;
        }

        /// <summary>
        /// The original formatter responsible for formatting this item.
        /// It can be used for evaluating nested formats.
        /// </summary>
        public SmartFormatter Formatter { get; private set; }

        /// <summary>
        /// Gets the original <see cref="Format"/> returned by the parser.
        /// </summary>
        public Format OriginalFormat { get; private set; }

        /// <summary>
        /// The original set of arguments passed to the format function.
        /// These provide global-access to the original arguments.
        /// </summary>
        public IList<object> OriginalArgs { get; private set; }

        /// <summary>
        /// This object can be used to cache resources between formatting calls.
        /// It will be null unless FormatWithCache is called.
        /// </summary>
        public FormatCache FormatCache { get; private set; }

        /// <summary>
        /// The Format Provider that can be used to determine how to
        /// format items such as numbers, dates, and anything else that
        /// might be culture-specific.
        /// </summary>
        public IFormatProvider Provider { get; private set; }

        /// <summary>
        /// Gets the <see cref="IOutput"/> where the result is written.
        /// </summary>
        public IOutput Output { get; private set; }

        /// <summary>
        /// If ErrorAction is set to OutputErrorsInResult, this will
        /// contain the exception that caused the formatting error.
        /// </summary>
        public FormattingException FormattingException { get; set; }

        /// <summary>
        /// Contains case-sensitivity settings
        /// </summary>
        public SmartSettings Settings => Formatter.Settings;
    }
}

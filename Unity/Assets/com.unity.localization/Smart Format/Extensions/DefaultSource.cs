using System;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Provides the ability to reference an argument by its index, the same as [String.Format](https://docs.microsoft.com/en-us/dotnet/api/system.string.format).
    /// </summary>
    [Serializable]
    public class DefaultSource : ISource
    {
        /// <summary>
        /// Creates a new instance of the formatter.
        /// </summary>
        /// <param name="formatter">The formatter that the source is added to.</param>
        public DefaultSource(SmartFormatter formatter)
        {
            formatter.Parser.AddOperators(","); // This is for alignment.
            formatter.Parser.AddAdditionalSelectorChars("-"); // This is for alignment.
        }

        /// <summary>
        /// Performs the default index-based selector, same as String.Format.
        /// </summary>
        /// <param name="selectorInfo"></param>
        /// <returns></returns>
        public bool TryEvaluateSelector(ISelectorInfo selectorInfo)
        {
            var current = selectorInfo.CurrentValue;
            var selector = selectorInfo.SelectorText;
            var formatDetails = selectorInfo.FormatDetails;

            if (int.TryParse(selector, out var selectorValue))
            {
                // Argument Index:
                // Just like String.Format, the arg index must be in-range,
                // should be the first item, and shouldn't have any operator:
                if (selectorInfo.SelectorIndex == 0
                    && selectorValue < formatDetails.OriginalArgs.Count
                    && selectorInfo.SelectorOperator == "")
                {
                    // This selector is an argument index.
                    selectorInfo.Result = formatDetails.OriginalArgs[selectorValue];
                    return true;
                }

                // Alignment:
                // An alignment item should be preceded by a comma
                if (selectorInfo.SelectorOperator == ",")
                {
                    // This selector is actually an Alignment modifier.
                    if (selectorInfo.Placeholder != null) selectorInfo.Placeholder.Alignment = selectorValue;
                    selectorInfo.Result = current; // (don't change the current item)
                    return true;
                }
            }

            return false;
        }
    }
}

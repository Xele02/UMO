using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.Core.Settings;
using UnityEngine.Pool;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// If the source value is an array (or supports ICollection),
    /// then each item will be custom formatted.
    /// Syntax:
    /// <list type="number">
    /// <item><term>"format|spacer"</term></item>
    /// <item><term>"format|spacer|last spacer"</term></item>
    /// <item><term>"format|spacer|last spacer|two spacer"</term></item>
    /// </list>
    /// </summary>
    /// <example>
    /// The format will be used for each item in the collection, the spacer will be between all items, and the last spacer
    /// will replace the spacer for the last item only. In this example, format = "D", spacer = "; ", and last spacer = "; and ".<br/>
    /// Format: <c>{Dates:D|; |; and }</c><br/>
    /// Arguments: <c>{#1/1/2000#, #12/31/2999#, #9/9/9999#}</c><br/>
    /// Result: "January 1, 2000; December 31, 2999"<br/><br/>
    /// Composite Formatting is allowed in the format by using nested braces. If a nested item is detected, Composite formatting will
    /// be used. In this example, format = "{Width}x{Height}". Notice the nested braces.<br/>
    /// Format: <c>{Sizes:{Width}x{Height}|, }</c><br/>
    /// Arguments: <c>{new Size(4,3), new Size(16,9)}</c><br/>
    /// Result: "4x3, 16x9"<br/>
    /// </example>
    [Serializable]
    public class ListFormatter : FormatterBase, ISource, IFormatterLiteralExtractor
    {
        //[SerializeReference, HideInInspector]
        SmartSettings m_SmartSettings;

        /// <summary>
        /// Creates a new instance of the formatter.
        /// </summary>
        /// <param name="formatter"></param>
        public ListFormatter(SmartFormatter formatter)
        {
            formatter.Parser.AddOperators("[]()");
            m_SmartSettings = formatter.Settings;
            Names = DefaultNames;
        }

        /// <inheritdoc/>
        public override string[] DefaultNames => new[] {"list", "l", ""};

        /// <summary>
        /// This allows an integer to be used as a selector to index an array (or list).
        /// This is better described using an example:
        /// CustomFormat("{Dates.2.Year}", {#1/1/2000#, #12/31/2999#, #9/9/9999#}) = "9999"
        /// The ".2" selector is used to reference Dates[2].
        /// </summary>
        /// <param name="selectorInfo"></param>
        /// <returns></returns>
        public bool TryEvaluateSelector(ISelectorInfo selectorInfo)
        {
            var current = selectorInfo.CurrentValue;
            var selector = selectorInfo.SelectorText;

            if (!(current is IList currentList)) return false;

            // See if we're trying to access a specific index:
            var isAbsolute = selectorInfo.SelectorIndex == 0 && selectorInfo.SelectorOperator.Length == 0;
            if (!isAbsolute && int.TryParse(selector, out var itemIndex) &&
                itemIndex < currentList.Count)
            {
                // The current is a List, and the selector is a number;
                // let's return the List item:
                // Example: {People[2].Name}
                //           ^List  ^itemIndex
                selectorInfo.Result = currentList[itemIndex];
                return true;
            }


            // We want to see if there is an "Index" property that was supplied.
            if (selector.Equals("index", StringComparison.OrdinalIgnoreCase))
            {
                // Looking for "{Index}"
                if (selectorInfo.SelectorIndex == 0)
                {
                    selectorInfo.Result = CollectionIndex;
                    return true;
                }

                // Looking for 2 lists to sync: "{List1: {List2[Index]} }"
                if (0 <= CollectionIndex && CollectionIndex < currentList.Count)
                {
                    selectorInfo.Result = currentList[CollectionIndex];
                    return true;
                }
            }

            return false;
        }

        // This does not work, because CollectionIndex will be initialized only once
        // NOT once per thread.
        // [ThreadStatic] private static int CollectionIndex = -1;
        // same with: private static ThreadLocal<int> CollectionIndex2 = new ThreadLocal<int>(() => -1);
        // Good example: https://msdn.microsoft.com/en-us/library/dn906268(v=vs.110).aspx

        /// <remarks>
        /// Wrap, so that CollectionIndex can be used without code changes.
        /// </remarks>
        //private static readonly AsyncLocal<int?> _collectionIndex = new AsyncLocal<int?>();

        /// <remarks>
        /// System.Runtime.Remoting.Messaging and CallContext.Logical[Get|Set]Data
        /// not supported by .Net Core. Instead .Net Core provides AsyncLocal&lt;T&gt;
        /// Good examples are: https://msdn.microsoft.com/en-us/library/dn906268(v=vs.110).aspx
        /// and https://github.com/StephenCleary/AsyncLocal/blob/master/src/UnitTests/UnitTests.cs
        /// </remarks>
        private static int CollectionIndex
        {
            // Removed multi threading support as AsyncLocal generates garbage and our object pools are not thread safe.
            get;
            set;
            //get { return _collectionIndex.Value ?? -1; }
            //set { _collectionIndex.Value = value; }
        } = -1;

        /// <inheritdoc/>
        public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var format = formattingInfo.Format;
            var current = formattingInfo.CurrentValue;

            // This method needs the Highest priority so that it comes before the PluralLocalizationExtension and ConditionalExtension

            // This extension requires at least IEnumerable
            if (!(current is IEnumerable enumerable))
                return false;
            // Ignore Strings, because they're IEnumerable.
            // This issue might actually need a solution
            // for other objects that are IEnumerable.
            if (current is string) return false;
            // If the object is IFormattable, ignore it
            if (current is IFormattable) return false;

            // This extension requires a | to specify the spacer:
            if (format == null) return false;
            var parameters = format.Split('|', 4);
            if (parameters.Count < 2) return false;

            // Grab all formatting options:
            // They must be in one of these formats:
            // itemFormat|spacer
            // itemFormat|spacer|lastSpacer
            // itemFormat|spacer|lastSpacer|twoSpacer
            var itemFormat = parameters[0];
            var spacer = parameters.Count >= 2 ? parameters[1].GetLiteralText() : "";
            var lastSpacer = parameters.Count >= 3 ? parameters[2].GetLiteralText() : spacer;
            var twoSpacer = parameters.Count >= 4 ? parameters[3].GetLiteralText() : lastSpacer;

            if (!itemFormat.HasNested)
            {
                // The format is not nested,
                // so we will treat it as an itemFormat:
                var newItemFormat = FormatItemPool.GetFormat(m_SmartSettings, itemFormat.baseString, itemFormat.startIndex, itemFormat.endIndex, true);
                var newPlaceholder = FormatItemPool.GetPlaceholder(m_SmartSettings, newItemFormat, itemFormat.startIndex, 0, itemFormat, itemFormat.endIndex);
                newItemFormat.Items.Add(newPlaceholder);
                itemFormat = newItemFormat;
            }

            // Let's buffer all items from the enumerable (to ensure the Count without double-enumeration):
            List<object> bufferItems = null;
            if (!(current is ICollection items))
            {
                bufferItems = ListPool<object>.Get();
                foreach (var item in enumerable)
                {
                    bufferItems.Add(item);
                }
                items = bufferItems;
            }

            var oldCollectionIndex = CollectionIndex; // In case we have nested arrays, we might need to restore the CollectionIndex
            CollectionIndex = -1;
            foreach (var item in items)
            {
                CollectionIndex += 1; // Keep track of the index

                // Determine which spacer to write:
                if (spacer == null || CollectionIndex == 0)
                {
                    // Don't write the spacer.
                }
                else if (CollectionIndex < items.Count - 1)
                {
                    formattingInfo.Write(spacer);
                }
                else if (CollectionIndex == 1)
                {
                    formattingInfo.Write(twoSpacer);
                }
                else
                {
                    formattingInfo.Write(lastSpacer);
                }

                // Output the nested format for this item:
                formattingInfo.Write(itemFormat, item);
            }

            CollectionIndex = oldCollectionIndex; // Restore the CollectionIndex

            if (bufferItems != null)
                ListPool<object>.Release(bufferItems);

            return true;
        }

        /// <inheritdoc/>
        public void WriteAllLiterals(IFormattingInfo formattingInfo)
        {
            var format = formattingInfo.Format;
            if (format == null)
                return;

            var parameters = format.Split('|', 4);
            if (parameters.Count < 2)
                return;

            var itemFormat = parameters[0];

            for (int i = 0; i < Math.Min(parameters.Count, 4); i++)
            {
                formattingInfo.Write(parameters[i], null);
            }

            if (!itemFormat.HasNested)
            {
                // The format is not nested,
                // so we will treat it as an itemFormat:
                var newItemFormat = FormatItemPool.GetFormat(m_SmartSettings, itemFormat.baseString, itemFormat.startIndex, itemFormat.endIndex, true);
                var newPlaceholder = FormatItemPool.GetPlaceholder(m_SmartSettings, newItemFormat, itemFormat.startIndex, 0, itemFormat, itemFormat.endIndex);
                newItemFormat.Items.Add(newPlaceholder);
                itemFormat = newItemFormat;
            }

            formattingInfo.Write(itemFormat, null);
        }
    }
}

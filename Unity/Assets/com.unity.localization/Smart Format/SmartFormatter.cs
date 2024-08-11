using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.Core.Formatting;
using UnityEngine.Localization.SmartFormat.Core.Output;
using UnityEngine.Localization.SmartFormat.Core.Parsing;
using UnityEngine.Localization.SmartFormat.Core.Settings;

namespace UnityEngine.Localization.SmartFormat
{
    /// <summary>
    /// This class contains the Format method that constructs
    /// the composite string by invoking each extension.
    /// </summary>
    [Serializable]
    public class SmartFormatter : ISerializationCallbackReceiver
    {
        //[SerializeReference]
        SmartSettings m_Settings;

        //[SerializeReference]
        Parser m_Parser;

        //[SerializeReference]
        List<ISource> m_Sources;

        //[SerializeReference]
        List<IFormatter> m_Formatters;

        List<string> m_NotEmptyFormatterExtensionNames;

        static readonly object[] k_Empty = { null };

        /// <summary>
        /// Event raising, if an error occurs during formatting.
        /// </summary>
        public event EventHandler<FormattingErrorEventArgs> OnFormattingFailure;

        /// <summary>
        /// Gets the list of <see cref="ISource" /> source extensions.
        /// </summary>
        public List<ISource> SourceExtensions { get => m_Sources; }

        /// <summary>
        /// Gets the list of <see cref="IFormatter" /> formatter extensions.
        /// </summary>
        public List<IFormatter> FormatterExtensions => m_Formatters;

        /// <summary>
        /// Creates a new instance of SmartFormatter.
        /// </summary>
        public SmartFormatter()
        {
            m_Settings = new SmartSettings();
            m_Parser = new Parser(m_Settings);
            m_Sources = new List<ISource>();
            m_Formatters = new List<IFormatter>();
        }

        /// <summary>
        /// Gets all names of registered formatter extensions which are not empty.
        /// </summary>
        /// <returns></returns>
        public List<string> GetNotEmptyFormatterExtensionNames()
        {
            if (m_NotEmptyFormatterExtensionNames != null)
                return m_NotEmptyFormatterExtensionNames;

            m_NotEmptyFormatterExtensionNames = new List<string>();
            foreach (var extension in FormatterExtensions)
            {
                if (extension?.Names != null)
                {
                    foreach (var name in extension.Names)
                    {
                        if (!string.IsNullOrEmpty(name))
                            m_NotEmptyFormatterExtensionNames.Add(name);
                    }
                }
            }
            return m_NotEmptyFormatterExtensionNames;
        }

        /// <summary>
        /// Adds each extensions to this formatter.
        /// Each extension must implement ISource.
        /// </summary>
        /// <param name="sourceExtensions"></param>
        public void AddExtensions(params ISource[] sourceExtensions)
        {
            SourceExtensions.InsertRange(0, sourceExtensions);
        }

        /// <summary>
        /// Adds each extensions to this formatter.
        /// Each extension must implement IFormatter.
        /// </summary>
        /// <param name="formatterExtensions"></param>
        public void AddExtensions(params IFormatter[] formatterExtensions)
        {
            m_NotEmptyFormatterExtensionNames = null;
            FormatterExtensions.InsertRange(0, formatterExtensions);
        }

        /// <summary>
        /// Searches for a Source Extension of the given type, and returns it.
        /// This can be used to easily find and configure extensions.
        /// Returns null if the type cannot be found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetSourceExtension<T>() where T : class, ISource
        {
            return SourceExtensions.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Searches for a Formatter Extension of the given type, and returns it.
        /// This can be used to easily find and configure extensions.
        /// Returns null if the type cannot be found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetFormatterExtension<T>() where T : class, IFormatter
        {
            return FormatterExtensions.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Gets or set the instance of the <see cref="Core.Parsing.Parser" />
        /// </summary>
        public Parser Parser
        {
            get => m_Parser;
            set => m_Parser = value;
        }

        /// <summary>
        /// Get the <see cref="Core.Settings.SmartSettings" /> for Smart.Format
        /// </summary>
        public SmartSettings Settings
        {
            get => m_Settings;
            set => m_Settings = value;
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specific object.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">The object to format.</param>
        /// <returns>Returns the formatted input with items replaced with their string representation.</returns>
        public string Format(string format, params object[] args)
        {
            return Format(null, args, format);
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specific object.
        /// </summary>
        /// <param name="args">The list of objects to format.</param>
        /// <param name="format">A composite format string.</param>
        /// <returns>Returns the formatted input with items replaced with their string representation.</returns>
        public string Format(IList<object> args, string format)
        {
            return Format(null, args, format);
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specific object.
        /// </summary>
        /// <param name="provider">The <see cref="IFormatProvider" /> to use.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">The object to format.</param>
        /// <returns>Returns the formatted input with items replaced with their string representation.</returns>
        public string Format(IFormatProvider provider, string format, params object[] args)
        {
            return Format(provider, args, format);
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specific object.
        /// </summary>
        /// <param name="provider">The <see cref="IFormatProvider" /> to use.</param>
        /// <param name="args">The object to format.</param>
        /// <param name="format">A composite format string.</param>
        /// <returns>Returns the formatted input with items replaced with their string representation.</returns>
        public string Format(IFormatProvider provider, IList<object> args, string format)
        {
            args = args ?? k_Empty;
            using (StringOutputPool.Get(format.Length + args.Count * 8, out var output))
            {
                var formatParsed = Parser.ParseFormat(format, GetNotEmptyFormatterExtensionNames());
                var current = args.Count > 0 ? args[0] : args; // The first item is the default.

                var formatDetails = FormatDetailsPool.Get(this, formatParsed, args, null, provider, output);
                Format(formatDetails, formatParsed, current);

                FormatDetailsPool.Release(formatDetails);
                FormatItemPool.ReleaseFormat(formatParsed);

                return output.ToString();
            }
        }

        /// <summary>
        /// Writes the formatting result into an <see cref="IOutput"/> instance.
        /// </summary>
        /// <param name="output">The <see cref="IOutput"/> where the result is written to.</param>
        /// <param name="format">The format string.</param>
        /// <param name="args">The objects to format.</param>
        public void FormatInto(IOutput output, string format, params object[] args)
        {
            args = args ?? k_Empty;
            var formatParsed = Parser.ParseFormat(format, GetNotEmptyFormatterExtensionNames());
            var current = args.Length > 0 ? args[0] : args; // The first item is the default.

            var formatDetails = FormatDetailsPool.Get(this, formatParsed, args, null, null, output);
            Format(formatDetails, formatParsed, current);

            FormatDetailsPool.Release(formatDetails);
            FormatItemPool.ReleaseFormat(formatParsed);
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specific object,
        /// using the <see cref="FormatCache"/>.
        /// </summary>
        /// <param name="cache">The <see cref="FormatCache" /> to use.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">The objects to format.</param>
        /// <returns>Returns the formatted input with items replaced with their string representation.</returns>
        public string FormatWithCache(ref FormatCache cache, string format, IList<object> args)
        {
            return FormatWithCache(ref cache, format, null, args);
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specific object,
        /// using the <see cref="FormatCache"/>.
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string FormatWithCache(ref FormatCache cache, string format, IFormatProvider formatProvider, IList<object> args)
        {
            args = args ?? k_Empty;
            using (StringOutputPool.Get(format.Length + args.Count * 8, out var output))
            {
                if (cache == null)
                    cache = FormatCachePool.Get(Parser.ParseFormat(format, GetNotEmptyFormatterExtensionNames()));
                var current = args.Count > 0 ? args[0] : args; // The first item is the default.
                var formatDetails = FormatDetailsPool.Get(this, cache.Format, args, cache, formatProvider, output);
                Format(formatDetails, cache.Format, current);
                FormatDetailsPool.Release(formatDetails);

                return output.ToString();
            }
        }

        /// <summary>
        /// Writes the formatting result into an <see cref="IOutput"/> instance, using the <see cref="FormatCache"/>.
        /// </summary>
        /// <param name="cache">The <see cref="FormatCache"/> to use.</param>
        /// <param name="output">The <see cref="IOutput"/> where the result is written to.</param>
        /// <param name="format">The format string.</param>
        /// <param name="args">The objects to format.</param>
        public void FormatWithCacheInto(ref FormatCache cache, IOutput output, string format, params object[] args)
        {
            args = args ?? k_Empty;
            if (cache == null)
                cache = FormatCachePool.Get(Parser.ParseFormat(format, GetNotEmptyFormatterExtensionNames()));
            var current = args.Length > 0 ? args[0] : args; // The first item is the default.

            var formatDetails = FormatDetailsPool.Get(this, cache.Format, args, cache, null, output);
            Format(formatDetails, cache.Format, current);
            FormatDetailsPool.Release(formatDetails);
        }

        void Format(FormatDetails formatDetails, Format format, object current)
        {
            var formattingInfo = FormattingInfoPool.Get(formatDetails, format, current);
            Format(formattingInfo);
            FormattingInfoPool.Release(formattingInfo);
        }

        /// <summary>
        /// Format the <see cref="FormattingInfo" /> argument.
        /// </summary>
        /// <param name="formattingInfo"></param>
        public virtual void Format(FormattingInfo formattingInfo)
        {
            if (formattingInfo.Format is null) return;

            // Before we start, make sure we have at least one source extension and one formatter extension:
            CheckForExtensions();
            foreach (var item in formattingInfo.Format.Items)
            {
                if (item is LiteralText literalItem)
                {
                    formattingInfo.Write(literalItem.ToString());
                    continue;
                }

                // Otherwise, the item must be a placeholder.
                var placeholder = (Placeholder)item;
                var childFormattingInfo = formattingInfo.CreateChild(placeholder);
                try
                {
                    EvaluateSelectors(childFormattingInfo);
                }
                catch (DataNotReadyException ex)
                {
                    // Handle async data not being ready (LOC-1087)
                    if (!string.IsNullOrEmpty(ex.Text))
                        formattingInfo.Write(ex.Text);
                    continue;
                }
                catch (Exception ex)
                {
                    // An error occurred while evaluation selectors
                    var errorIndex = placeholder.Format?.startIndex ?? placeholder.Selectors.Last().endIndex;
                    FormatError(item, ex, errorIndex, childFormattingInfo);
                    continue;
                }

                try
                {
                    EvaluateFormatters(childFormattingInfo);
                }
                catch (Exception ex)
                {
                    // An error occurred while evaluating formatters
                    var errorIndex = placeholder.Format?.startIndex ?? placeholder.Selectors.Last().endIndex;
                    FormatError(item, ex, errorIndex, childFormattingInfo);
                }
            }
        }

        private void FormatError(FormatItem errorItem, Exception innerException, int startIndex,
            FormattingInfo formattingInfo)
        {
            OnFormattingFailure?.Invoke(this,
                new FormattingErrorEventArgs(errorItem.RawText, startIndex,
                    Settings.FormatErrorAction != ErrorAction.ThrowError));
            switch (Settings.FormatErrorAction)
            {
                case ErrorAction.Ignore:
                    return;
                case ErrorAction.ThrowError:
                    throw innerException as FormattingException ??
                          new FormattingException(errorItem, innerException, startIndex);
                case ErrorAction.OutputErrorInResult:
                    formattingInfo.FormatDetails.FormattingException =
                        innerException as FormattingException ??
                        new FormattingException(errorItem, innerException, startIndex);
                    formattingInfo.Write(innerException.Message);
                    formattingInfo.FormatDetails.FormattingException = null;
                    break;
                case ErrorAction.MaintainTokens:
                    formattingInfo.Write(formattingInfo.Placeholder.RawText);
                    break;
            }
        }

        private void CheckForExtensions()
        {
            if (SourceExtensions.Count == 0)
                throw new InvalidOperationException(
                    "No source extensions are available. Please add at least one source extension, such as the DefaultSource.");
            if (FormatterExtensions.Count == 0)
                throw new InvalidOperationException(
                    "No formatter extensions are available. Please add at least one formatter extension, such as the DefaultFormatter.");
        }

        private void EvaluateSelectors(FormattingInfo formattingInfo)
        {
            if (formattingInfo.Placeholder == null) return;

            var firstSelector = true;
            foreach (var selector in formattingInfo.Placeholder.Selectors)
            {
                formattingInfo.Selector = selector;
                formattingInfo.Result = null;
                var handled = InvokeSourceExtensions(formattingInfo);
                if (handled) formattingInfo.CurrentValue = formattingInfo.Result;

                if (firstSelector)
                {
                    firstSelector = false;
                    // Handle "nested scopes" by traversing the stack:
                    var parentFormattingInfo = formattingInfo;
                    while (!handled && parentFormattingInfo.Parent != null)
                    {
                        parentFormattingInfo = parentFormattingInfo.Parent;
                        parentFormattingInfo.Selector = selector;
                        parentFormattingInfo.Result = null;
                        handled = InvokeSourceExtensions(parentFormattingInfo);
                        if (handled) formattingInfo.CurrentValue = parentFormattingInfo.Result;
                    }
                }

                if (!handled)
                    throw formattingInfo.FormattingException($"Could not evaluate the selector \"{selector.RawText}\"",
                        selector);
            }
        }

        private bool InvokeSourceExtensions(FormattingInfo formattingInfo)
        {
            foreach (var sourceExtension in SourceExtensions)
            {
                var handled = sourceExtension.TryEvaluateSelector(formattingInfo);
                if (handled)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Try to get a suitable formatter.
        /// </summary>
        /// <param name="formattingInfo"></param>
        /// <exception cref="FormattingException"></exception>
        private void EvaluateFormatters(FormattingInfo formattingInfo)
        {
            var handled = InvokeFormatterExtensions(formattingInfo);
            if (!handled)
                throw formattingInfo.FormattingException("No suitable Formatter could be found", formattingInfo.Format);
        }

        /// <summary>
        /// First check whether the named formatter name exist in of the <see cref="FormatterExtensions" />,
        /// next check whether the named formatter is able to process the format.
        /// </summary>
        /// <param name="formattingInfo"></param>
        /// <returns>True if an FormatterExtension was found, else False.</returns>
        private bool InvokeFormatterExtensions(FormattingInfo formattingInfo)
        {
            if (formattingInfo.Placeholder == null) return false;
            var formatterName = formattingInfo.Placeholder.FormatterName;

            // Evaluate the named formatter (or, evaluate all "" formatters)
            foreach (var formatterExtension in FormatterExtensions)
            {
                if (!formatterExtension.Names.Contains(formatterName)) continue;
                var handled = formatterExtension.TryEvaluateFormat(formattingInfo);
                if (handled) return true;
            }

            return false;
        }

        public void OnBeforeSerialize()
        {
            m_NotEmptyFormatterExtensionNames = null;
        }

        public void OnAfterDeserialize()
        {
            m_NotEmptyFormatterExtensionNames = null;
        }
    }
}

using System;
using UnityEngine.Localization.SmartFormat.Extensions;

namespace UnityEngine.Localization.SmartFormat
{
    /// <summary>
    /// This class holds a Default instance of the SmartFormatter.
    /// The default instance has all extensions registered.
    /// </summary>
    public static class Smart
    {
        /// <inheritdoc cref="SmartFormatter.Format(string, object[])"/>
        public static string Format(string format, params object[] args)
        {
            return Default.Format(format, args);
        }

        /// <inheritdoc cref="SmartFormatter.Format(IFormatProvider, string, object[])"/>
        public static string Format(IFormatProvider provider, string format, params object[] args)
        {
            return Default.Format(provider, format, args);
        }

        /// <inheritdoc cref="Format(string, object[])"/>
        public static string Format(string format, object arg0, object arg1, object arg2)
        {
            return Format(format, new[] { arg0, arg1, arg2 });
        }

        /// <inheritdoc cref="Format(string, object[])"/>
        public static string Format(string format, object arg0, object arg1)
        {
            return Format(format, new[] { arg0, arg1 });
        }

        /// <inheritdoc cref="SmartFormatter.Format(string, object[])"/>
        public static string Format(string format, object arg0)
        {
            return Default.Format(format, arg0); // call Default.Format in order to avoid infinite recursive method call
        }

        /// <summary>
        /// The default formatter that is used when no formatter is explicitly used.
        /// </summary>
        public static SmartFormatter Default { get; set; } = CreateDefaultSmartFormat();

        /// <summary>
        /// Creates a new formatter with default settings.
        /// </summary>
        /// <returns>The new formatter.</returns>
        public static SmartFormatter CreateDefaultSmartFormat()
        {
            // Register all default extensions here:
            var formatter = new SmartFormatter();
            // Add all extensions:
            // Note, the order is important; the extensions
            // will be executed in this order:

            var listFormatter = new ListFormatter(formatter);

            // sources for specific types must be in the list before ReflectionSource
            formatter.AddExtensions(
                listFormatter, // ListFormatter MUST be first
                new PersistentVariablesSource(formatter),
                new DictionarySource(formatter),
                new ValueTupleSource(formatter),
                new XmlSource(formatter),
                new ReflectionSource(formatter),

                // The DefaultSource reproduces the string.Format behavior:
                new DefaultSource(formatter)
            );
            formatter.AddExtensions(
                listFormatter,
                new PluralLocalizationFormatter(),
                new ConditionalFormatter(),
                new TimeFormatter(),
                new XElementFormatter(),
                new ChooseFormatter(),
                new SubStringFormatter(),
                new IsMatchFormatter(),
                new DefaultFormatter()
            );

            return formatter;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.Core.Formatting;
using UnityEngine.Localization.SmartFormat.Utilities;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Provides the ability to handle plural forms.
    /// </summary>
    [Serializable]
    public class PluralLocalizationFormatter : FormatterBase, IFormatterLiteralExtractor
    {
        [SerializeField]
        string m_DefaultTwoLetterISOLanguageName = "en";

        PluralRules.PluralRuleDelegate m_DefaultPluralRule;

        /// <summary>
        /// The default language to use for plurals if one can not be found.
        /// </summary>
        public string DefaultTwoLetterISOLanguageName
        {
            get => m_DefaultTwoLetterISOLanguageName;
            set
            {
                m_DefaultTwoLetterISOLanguageName = value;
                m_DefaultPluralRule = PluralRules.GetPluralRule(value);
            }
        }

        /// <summary>
        /// Creates a new instance of the formatter.
        /// </summary>
        public PluralLocalizationFormatter()
        {
            Names = DefaultNames;
        }

        /// <inheritdoc/>
        public override string[] DefaultNames => new[] { "plural", "p", "" };

        /// <inheritdoc/>
        public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var format = formattingInfo.Format;
            var current = formattingInfo.CurrentValue;

            // Ignore formats that start with "?" (this can be used to bypass this extension)
            if (format == null || format.baseString[format.startIndex] == ':') return false;

            // Extract the plural words from the format string:
            var pluralWords = format.Split('|');
            // This extension requires at least two plural words:
            if (pluralWords.Count == 1) return false;

            decimal value;

            // remove xml tags
            if(current is string)
            {
                string str = current as string;
                if(str.Contains("<"))
                {
                    str = System.Text.RegularExpressions.Regex.Replace(str, "<.*?>", String.Empty);
                    int v;
                    if(int.TryParse(str, out v))
                    {
                        current = v;
                    }
                }
            }

            // We can format numbers, and IEnumerables. For IEnumerables we look at the number of items
            // in the collection: this means the user can e.g. use the same parameter for both plural and list, for example
            // 'Smart.Format("The following {0:plural:person is|people are} impressed: {0:list:{}|, |, and}", new[] { "bob", "alice" });'
            if (current is IConvertible convertible &&
                // Supporting these breaks tests and changes the default behaviour
                !(current is DateTime) && !(current is string) && !(current is bool) && !(current is Enum))
                value = convertible.ToDecimal(null);
            else if (current is IEnumerable<object> objects)
                value = objects.Count();
            else
                return false;

            // Get the plural rule:
            var pluralRule = GetPluralRule(formattingInfo);

            if (pluralRule == null) return false;

            var pluralCount = pluralWords.Count;
            var pluralIndex = pluralRule(value, pluralCount);

            if (pluralIndex < 0 || pluralWords.Count <= pluralIndex)
            {
                Debug.LogError(new FormattingException(format, "Invalid number of plural parameters, missing idx : "+pluralIndex,
                    pluralWords.Last().endIndex));
                pluralIndex = pluralWords.Count - 1; // return the last one if missing plurals
            }

            // Output the selected word (allowing for nested formats):
            var pluralForm = pluralWords[pluralIndex];
            formattingInfo.Write(pluralForm, current);
            return true;
        }

        /// <summary>
        /// Returns the plural rule for the formatting info.
        /// </summary>
        /// <param name="formattingInfo"></param>
        /// <returns></returns>
        protected virtual PluralRules.PluralRuleDelegate GetPluralRule(IFormattingInfo formattingInfo)
        {
            // See if the language was explicitly passed:
            var pluralOptions = formattingInfo.FormatterOptions;
            if (pluralOptions.Length != 0) return PluralRules.GetPluralRule(pluralOptions);

            // See if a CustomPluralRuleProvider is available from the FormatProvider:
            var provider = formattingInfo.FormatDetails.Provider;
            var pluralRuleProvider =
                (CustomPluralRuleProvider)provider?.GetFormat(typeof(CustomPluralRuleProvider));
            if (pluralRuleProvider != null) return pluralRuleProvider.GetPluralRule();

            // Use the CultureInfo, if provided:
            if (provider is CultureInfo cultureInfo)
            {
                var culturePluralRule = PluralRules.GetPluralRule(cultureInfo.TwoLetterISOLanguageName);
                return culturePluralRule;
            }

            // If the AvailableLocales requires preloading and it is not ready then we can not get the SelectedLocale and must skip this step.
            /*Locale selectedLocale = null;
            var localeOp = LocalizationSettings.SelectedLocaleAsync;
            if (localeOp.IsValid() && localeOp.IsDone)
            {
                selectedLocale = localeOp.Result;
            }

            if (selectedLocale != null)*/
            if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
            {
                string isoCode = RuntimeSettings.CurrentSettings.Language;
                /*var localeCultureInfo = selectedLocale.Identifier.CultureInfo;
                if (localeCultureInfo != null)
                {
                    isoCode = localeCultureInfo.TwoLetterISOLanguageName;
                }
                else
                {
                    isoCode = selectedLocale.Identifier.Code;
                    if (selectedLocale.Identifier.Code.Length > 2)
                        isoCode = selectedLocale.Identifier.Code.Substring(0, 2);
                }*/

                var culturePluralRule = PluralRules.GetPluralRule(isoCode);
                return culturePluralRule;
            }

            return m_DefaultPluralRule ?? (m_DefaultPluralRule = PluralRules.GetPluralRule(DefaultTwoLetterISOLanguageName));
        }

        /// <inheritdoc/>
        public void WriteAllLiterals(IFormattingInfo formattingInfo)
        {
            var format = formattingInfo.Format;

            // Ignore formats that start with "?" (this can be used to bypass this extension)
            if (format == null || format.baseString[format.startIndex] == ':')
                return;

            // Extract the plural words from the format string:
            var pluralWords = format.Split('|');
            // This extension requires at least two plural words:
            if (pluralWords.Count == 1)
                return;

            for (int i = 0; i < pluralWords.Count; ++i)
            {
                formattingInfo.Write(pluralWords[i], null);
            }
        }
    }

    /// <summary>
    /// Use this class to provide custom plural rules to Smart.Format
    /// </summary>
    public class CustomPluralRuleProvider : IFormatProvider
    {
        private readonly PluralRules.PluralRuleDelegate _pluralRule;

        /// <summary>
        /// Creates a new instance of the plural rule provider.
        /// </summary>
        /// <param name="pluralRule">The plural rule to use for this provider.</param>
        public CustomPluralRuleProvider(PluralRules.PluralRuleDelegate pluralRule)
        {
            _pluralRule = pluralRule;
        }

        /// <summary>
        /// Returns the formatter when <paramref name="formatType"/> is <see cref="CustomPluralRuleProvider"/>, otherwise returns <see langword="null"/>.
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(CustomPluralRuleProvider) ? this : null;
        }

        /// <summary>
        /// Returns the custom plural rule delegate.
        /// </summary>
        /// <returns></returns>
        public PluralRules.PluralRuleDelegate GetPluralRule()
        {
            return _pluralRule;
        }
    }
}

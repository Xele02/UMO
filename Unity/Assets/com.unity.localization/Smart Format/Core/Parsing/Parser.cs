using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization.SmartFormat.Core.Settings;

namespace UnityEngine.Localization.SmartFormat.Core.Parsing
{
    /// <summary>
    /// Parses a format string.
    /// </summary>
    [Serializable]
    public class Parser
    {
        [SerializeField]
        char m_OpeningBrace = '{';

        [SerializeField]
        char m_ClosingBrace = '}';

        [/*SerializeReference, */HideInInspector]
        SmartSettings m_Settings;

        // The following fields are points of extensibility

        [Tooltip("If false, only digits are allowed as selectors. If true, selectors can be alpha-numeric. " +
            "This allows optimized alpha-character detection. Specify any additional selector chars " +
            "in AllowedSelectorChars.")]
        [SerializeField]
        bool m_AlphanumericSelectors;

        [Tooltip("A list of allowable selector characters, to support additional selector syntaxes such as math. " +
            "Digits are always included, and letters can be included with AlphanumericSelectors.")]
        [SerializeField]
        string m_AllowedSelectorChars = "";

        [Tooltip("A list of characters that come between selectors. This can be \".\" for dot-notation, \"[]\" for " +
            "arrays, or even math symbols. By default, there are no operators.")]
        [SerializeField]
        string m_Operators = "";

        [Tooltip("If false, double-curly braces are escaped. If true, the AlternativeEscapeChar is used for escaping braces.")]
        [SerializeField]
        bool m_AlternativeEscaping;

        [Tooltip("If AlternativeEscaping is true, then this character is used to escape curly braces.")]
        [SerializeField]
        private char m_AlternativeEscapeChar = '\\';

        [Tooltip("The character literal escape character e.g. for \t (TAB) and others. This is kind of overlapping " +
            "functionality with `UseAlternativeEscapeChar` Note: In a future release escape characters for placeholders " +
            " and character literals should become the same.")]
        [SerializeField]
        internal const char m_CharLiteralEscapeChar = '\\';

        static ParsingErrorText s_ParsingErrorText;

        /// <summary>
        /// Gets or sets the <seealso cref="Core.Settings.SmartSettings" /> for Smart.Format
        /// </summary>
        public SmartSettings Settings
        {
            get => m_Settings;
            set => m_Settings = value;
        }

        /// <summary>
        /// Event raising, if an error occurs during parsing.
        /// </summary>
        public event EventHandler<ParsingErrorEventArgs> OnParsingFailure;

        public Parser(SmartSettings settings)
        {
            m_Settings = settings;
        }

        /// <summary>
        /// Includes a-z and A-Z in the list of allowed selector chars.
        /// </summary>
        public void AddAlphanumericSelectors()
        {
            m_AlphanumericSelectors = true;
        }

        /// <summary>
        /// Adds specific characters to the allowed selector chars.
        /// </summary>
        /// <param name="chars"></param>
        public void AddAdditionalSelectorChars(string chars)
        {
            foreach (var c in chars)
                if (m_AllowedSelectorChars.IndexOf(c) == -1)
                    m_AllowedSelectorChars += c;
        }

        /// <summary>
        /// Adds specific characters to the allowed operator chars.
        /// An operator is a character that is in the selector string
        /// that splits the selectors.
        /// </summary>
        /// <param name="chars"></param>
        public void AddOperators(string chars)
        {
            foreach (var c in chars)
                if (m_Operators.IndexOf(c) == -1)
                    m_Operators += c;
        }

        /// <summary>
        /// Sets the AlternativeEscaping option to True
        /// so that braces will only be escaped after the
        /// specified character.
        /// </summary>
        /// <param name="alternativeEscapeChar">Defaults to backslash</param>
        public void UseAlternativeEscapeChar(char alternativeEscapeChar = '\\')
        {
            m_AlternativeEscapeChar = alternativeEscapeChar;
            m_AlternativeEscaping = true;
        }

        /// <summary>
        /// [Default]
        /// Uses {{ and }} for escaping braces for compatibility with String.Format.
        /// However, this does not work very well with nested placeholders,
        /// so it is recommended to use an alternative escape char.
        /// </summary>
        public void UseBraceEscaping()
        {
            m_AlternativeEscaping = false;
        }

        /// <summary>
        /// Set the closing and opening braces for the parser.
        /// </summary>
        /// <param name="opening"></param>
        /// <param name="closing"></param>
        public void UseAlternativeBraces(char opening, char closing)
        {
            m_OpeningBrace = opening;
            m_ClosingBrace = closing;
        }

        /// <summary>
        /// Parses a format string.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatterExtensionNames"></param>
        /// <returns>Returns the <see cref="Format"/> for the parsed string.</returns>
        public Format ParseFormat(string format, IList<string> formatterExtensionNames)
        {
            var result = FormatItemPool.GetFormat(Settings, format);
            var current = result;
            Placeholder currentPlaceholder = null;
            var namedFormatterStartIndex = -1;
            var namedFormatterOptionsStartIndex = -1;
            var namedFormatterOptionsEndIndex = -1;

            // Store parsing errors until the end:
            var parsingErrors = ParsingErrorsPool.Get(result);
            if (s_ParsingErrorText == null)
                s_ParsingErrorText = new ParsingErrorText();

            // Cache properties:
            var openingBrace = m_OpeningBrace;
            var closingBrace = m_ClosingBrace;


            var nestedDepth = 0;
            var lastI = 0;
            var operatorIndex = 0;
            var selectorIndex = 0;
            for (int i = 0, length = format.Length; i < length; i++)
            {
                var c = format[i];
                if (currentPlaceholder == null)
                {
                    if (c == openingBrace)
                    {
                        // Finish the last text item:
                        if (i != lastI) current.Items.Add(FormatItemPool.GetLiteralText(Settings, current, lastI, i));
                        lastI = i + 1;

                        // See if this brace should be escaped:
                        if (!m_AlternativeEscaping)
                        {
                            var nextI = lastI;
                            if (nextI < length && format[nextI] == openingBrace)
                            {
                                i++;
                                continue;
                            }
                        }

                        // New placeholder:
                        nestedDepth++;
                        currentPlaceholder = FormatItemPool.GetPlaceholder(Settings, current, i, nestedDepth);
                        current.Items.Add(currentPlaceholder);
                        current.HasNested = true;
                        operatorIndex = i + 1;
                        selectorIndex = 0;
                        namedFormatterStartIndex = -1;
                    }
                    else if (c == closingBrace)
                    {
                        // Finish the last text item:
                        if (i != lastI)
                            current.Items.Add(FormatItemPool.GetLiteralText(Settings, current, lastI, i));
                        lastI = i + 1;

                        // See if this brace should be escaped:
                        if (!m_AlternativeEscaping)
                        {
                            var nextI = lastI;
                            if (nextI < length && format[nextI] == closingBrace)
                            {
                                i++;
                                continue;
                            }
                        }

                        // Make sure that this is a nested placeholder before we un-nest it:
                        if (current.parent == null)
                        {
                            // Don't swallow-up redundant closing braces, but treat them as literals
                            current.Items.Add(FormatItemPool.GetLiteralText(Settings, current, i, i + 1));
                            parsingErrors.AddIssue(s_ParsingErrorText[ParsingError.TooManyClosingBraces], i,
                                i + 1);
                            continue;
                        }

                        // End of the placeholder's Format:
                        nestedDepth--;
                        current.endIndex = i;
                        current.parent.endIndex = i + 1;
                        current = current.parent.Parent as Format;
                        namedFormatterStartIndex = -1;
                    }
                    else if (c == m_CharLiteralEscapeChar && Settings.ConvertCharacterStringLiterals ||
                             m_AlternativeEscaping && c == m_AlternativeEscapeChar)
                    {
                        namedFormatterStartIndex = -1;

                        // See that is the next character
                        var nextI = i + 1;

                        // **** Alternative brace escaping with { or } following the escape character ****
                        if (nextI < length && (format[nextI] == openingBrace || format[nextI] == closingBrace))
                        {
                            // Finish the last text item:
                            if (i != lastI) current.Items.Add(FormatItemPool.GetLiteralText(Settings, current, lastI, i));
                            lastI = i + 1;

                            i++;
                        }
                        else
                        {
                            // **** Escaping of character literals like \t, \n, \v etc. ****

                            // Finish the last text item:
                            if (i != lastI) current.Items.Add(FormatItemPool.GetLiteralText(Settings, current, lastI, i));

                            // Is this a unicode escape sequence?
                            if (i + 1 < format.Length && format[i + 1] == 'u')
                                lastI = i + 6; // \u0000 format
                            else
                                lastI = i + 2;

                            if (lastI > length) lastI = length;

                            // Next add the character literal INCLUDING the escape character, which LiteralText will expect
                            current.Items.Add(FormatItemPool.GetLiteralText(Settings, current, i, lastI));

                            i++;
                        }
                    }
                    else if (namedFormatterStartIndex != -1)
                    {
                        if (c == '(')
                        {
                            var emptyName = namedFormatterStartIndex == i;
                            if (emptyName)
                            {
                                namedFormatterStartIndex = -1;
                                continue;
                            }

                            namedFormatterOptionsStartIndex = i;
                        }
                        else if (c == ')' || c == ':')
                        {
                            if (c == ')')
                            {
                                var hasOpeningParenthesis = namedFormatterOptionsStartIndex != -1;

                                // ensure no trailing chars past ')'
                                var nextI = i + 1;
                                var nextCharIsValid = nextI < format.Length &&
                                    (format[nextI] == ':' || format[nextI] == closingBrace);

                                if (!hasOpeningParenthesis || !nextCharIsValid)
                                {
                                    namedFormatterStartIndex = -1;
                                    continue;
                                }

                                namedFormatterOptionsEndIndex = i;

                                if (format[nextI] == ':') i++; // Consume the ':'
                            }

                            var nameIsEmpty = namedFormatterStartIndex == i;
                            var missingClosingParenthesis =
                                namedFormatterOptionsStartIndex != -1 && namedFormatterOptionsEndIndex == -1;
                            if (nameIsEmpty || missingClosingParenthesis)
                            {
                                namedFormatterStartIndex = -1;
                                continue;
                            }


                            lastI = i + 1;

                            var parentPlaceholder = current.parent;

                            if (namedFormatterOptionsStartIndex == -1)
                            {
                                var formatterName = format.Substring(namedFormatterStartIndex,
                                    i - namedFormatterStartIndex);

                                if (FormatterNameExists(formatterName, formatterExtensionNames))
                                    parentPlaceholder.FormatterName = formatterName;
                                else
                                    lastI = current.startIndex;
                            }
                            else
                            {
                                var formatterName = format.Substring(namedFormatterStartIndex,
                                    namedFormatterOptionsStartIndex - namedFormatterStartIndex);

                                if (FormatterNameExists(formatterName, formatterExtensionNames))
                                {
                                    parentPlaceholder.FormatterName = formatterName;
                                    parentPlaceholder.FormatterOptions = format.Substring(
                                        namedFormatterOptionsStartIndex + 1,
                                        namedFormatterOptionsEndIndex - (namedFormatterOptionsStartIndex + 1));
                                }
                                else
                                {
                                    lastI = current.startIndex;
                                }
                            }

                            current.startIndex = lastI;

                            namedFormatterStartIndex = -1;
                        }
                    }
                }
                else
                {
                    // Placeholder is NOT null, so that means
                    // we're parsing the selectors:
                    if (m_Operators.IndexOf(c) != -1)
                    {
                        // Add the selector:
                        if (i != lastI)
                        {
                            currentPlaceholder.Selectors.Add(FormatItemPool.GetSelector(Settings, currentPlaceholder, format, lastI, i, operatorIndex, selectorIndex));
                            selectorIndex++;
                            operatorIndex = i;
                        }

                        lastI = i + 1;
                    }
                    else if (c == ':')
                    {
                        // Add the selector:
                        if (i != lastI)
                            currentPlaceholder.Selectors.Add(FormatItemPool.GetSelector(Settings, currentPlaceholder, format, lastI, i, operatorIndex, selectorIndex));
                        else if (operatorIndex != i)
                            parsingErrors.AddIssue($"'0x{Convert.ToByte(c):X}': {s_ParsingErrorText[ParsingError.TrailingOperatorsInSelector]}", operatorIndex, i);
                        lastI = i + 1;

                        // Start the format:
                        currentPlaceholder.Format = FormatItemPool.GetFormat(Settings, currentPlaceholder, i + 1);
                        current = currentPlaceholder.Format;
                        currentPlaceholder = null;
                        namedFormatterStartIndex = lastI;
                        namedFormatterOptionsStartIndex = -1;
                        namedFormatterOptionsEndIndex = -1;
                    }
                    else if (c == closingBrace)
                    {
                        // Add the selector:
                        if (i != lastI)
                            currentPlaceholder.Selectors.Add(FormatItemPool.GetSelector(Settings, currentPlaceholder, format, lastI, i, operatorIndex, selectorIndex));
                        else if (operatorIndex != i)
                            parsingErrors.AddIssue($"'0x{Convert.ToByte(c):X}': {s_ParsingErrorText[ParsingError.TrailingOperatorsInSelector]}", operatorIndex, i);
                        lastI = i + 1;

                        // End the placeholder with no format:
                        nestedDepth--;
                        currentPlaceholder.endIndex = i + 1;
                        current = currentPlaceholder.Parent as Format;
                        currentPlaceholder = null;
                    }
                    else
                    {
                        // Let's make sure the selector characters are valid:
                        // Make sure it's alphanumeric:
                        var isValidSelectorChar =
                            '0' <= c && c <= '9'
                            || m_AlphanumericSelectors && ('a' <= c && c <= 'z' || 'A' <= c && c <= 'Z')
                            || m_AllowedSelectorChars.IndexOf(c) != -1;
                        if (!isValidSelectorChar)
                            parsingErrors.AddIssue($"'0x{Convert.ToByte(c):X}': {s_ParsingErrorText[ParsingError.TrailingOperatorsInSelector]}", i, i + 1);
                    }
                }
            }

            // We're at the end of the input string

            // 1. Is the last item a placeholder, that is not finished yet?
            if (current.parent != null || currentPlaceholder != null)
            {
                parsingErrors.AddIssue(s_ParsingErrorText[ParsingError.MissingClosingBrace], format.Length,
                    format.Length);
                current.endIndex = format.Length;
            }
            else if (lastI != format.Length)
            {
                // 2. The last item must be a literal, so add it
                current.Items.Add(FormatItemPool.GetLiteralText(Settings, current, lastI, format.Length));
            }

            // Todo v2.7.0: There is no unit test for this condition!
            while (current.parent != null)
            {
                current = current.parent.Parent as Format;
                current.endIndex = format.Length;
            }

            // Check for any parsing errors:
            if (parsingErrors.HasIssues)
            {
                OnParsingFailure?.Invoke(this,
                    new ParsingErrorEventArgs(parsingErrors, Settings.ParseErrorAction == ErrorAction.ThrowError));

                return HandleParsingErrors(parsingErrors, result);
            }
            else
            {
                ParsingErrorsPool.Release(parsingErrors);
            }

            return result;
        }

        /// <summary>
        /// Handles <see cref="ParsingError"/>s as defined in <see cref="SmartSettings.ParseErrorAction"/>.
        /// </summary>
        /// <param name="parsingErrors"></param>
        /// <param name="currentResult"></param>
        /// <returns>The <see cref="Format"/> which will be further processed by the formatter.</returns>
        Format HandleParsingErrors(ParsingErrors parsingErrors, Format currentResult)
        {
            switch (Settings.ParseErrorAction)
            {
                case ErrorAction.ThrowError:
                    throw parsingErrors;
                case ErrorAction.MaintainTokens:
                    // Replace erroneous Placeholders with tokens as LiteralText
                    // Placeholder without issues are left unmodified
                    for (var i = 0; i < currentResult.Items.Count; i++)
                    {
                        if (currentResult.Items[i] is Placeholder ph && parsingErrors.Issues.Any(errItem => errItem.Index >= currentResult.Items[i].startIndex && errItem.Index <= currentResult.Items[i].endIndex))
                        {
                            currentResult.Items[i] = FormatItemPool.GetLiteralText(Settings, ph.Format ?? FormatItemPool.GetFormat(Settings, ph.baseString), ph.startIndex, ph.endIndex);
                        }
                    }
                    return currentResult;
                case ErrorAction.Ignore:
                    // Replace erroneous Placeholders with an empty LiteralText
                    for (var i = 0; i < currentResult.Items.Count; i++)
                    {
                        if (currentResult.Items[i] is Placeholder ph && parsingErrors.Issues.Any(errItem => errItem.Index >= currentResult.Items[i].startIndex && errItem.Index <= currentResult.Items[i].endIndex))
                        {
                            currentResult.Items[i] = FormatItemPool.GetLiteralText(Settings, ph.Format ?? FormatItemPool.GetFormat(Settings, ph.baseString), ph.startIndex, ph.startIndex);
                        }
                    }
                    return currentResult;
                case ErrorAction.OutputErrorInResult:
                    var fmt = FormatItemPool.GetFormat(Settings, parsingErrors.Message, 0, parsingErrors.Message.Length);
                    fmt.Items.Add(FormatItemPool.GetLiteralText(Settings, fmt, 0));
                    return fmt;
                default:
                    throw new ArgumentException("Illegal type for ParsingErrors", parsingErrors);
            }
        }

        static bool FormatterNameExists(string name, IList<string> formatterExtensionNames)
        {
            foreach (var fen in formatterExtensionNames)
            {
                if (fen == name)
                    return true;
            }
            return false;
        }

        public enum ParsingError
        {
            /// <summary>
            /// Too many closing braces.
            /// </summary>
            TooManyClosingBraces = 1,

            /// <summary>
            /// Trailing operators in the selector.
            /// </summary>
            TrailingOperatorsInSelector,

            /// <summary>
            /// Invalid characters in the selector.
            /// </summary>
            InvalidCharactersInSelector,

            /// <summary>
            /// Missing closing brace.
            /// </summary>
            MissingClosingBrace
        }

        /// <summary>
        /// Supplies error text for the <see cref="Parser"/>.
        /// </summary>
        internal class ParsingErrorText
        {
            private readonly Dictionary<ParsingError, string> _errors = new Dictionary<ParsingError, string>
            {
                {ParsingError.TooManyClosingBraces, "Format string has too many closing braces"},
                {ParsingError.TrailingOperatorsInSelector, "There are trailing operators in the selector"},
                {ParsingError.InvalidCharactersInSelector, "Invalid character in the selector"},
                {ParsingError.MissingClosingBrace, "Format string is missing a closing brace"}
            };

            /// <summary>
            /// CTOR.
            /// </summary>
            internal ParsingErrorText()
            {
            }

            /// <summary>
            /// Gets the string representation of the ParsingError enum.
            /// </summary>
            /// <param name="parsingErrorKey"></param>
            /// <returns>The string representation of the ParsingError enum</returns>
            public string this[ParsingError parsingErrorKey] => _errors[parsingErrorKey];
        }
    }
}

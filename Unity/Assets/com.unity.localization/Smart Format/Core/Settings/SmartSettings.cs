using System;
using System.Collections.Generic;

namespace UnityEngine.Localization.SmartFormat.Core.Settings
{
    /// <summary>
    /// <see cref="SmartFormat" /> settings to be applied for parsing and formatting.
    /// </summary>
    [Serializable]
    public class SmartSettings
    {
        [SerializeField]
        ErrorAction m_FormatErrorAction = ErrorAction.ThrowError;

        [SerializeField]
        ErrorAction m_ParseErrorAction = ErrorAction.ThrowError;

        [Tooltip("Determines whether placeholders are case-sensitive or not.")]
        [SerializeField]
        CaseSensitivityType m_CaseSensitivity = CaseSensitivityType.CaseSensitive;

        [Tooltip(@"This setting is relevant for the 'Parsing.LiteralText', If true (the default), character string literals " +
            "are treated like in normal string.Format: string.Format(\"\t\") will return a \"TAB\" character " +
            "If false, character string literals are not converted, just like with this string.Format: " +
            "string.Format(@\"\t\") will return the 2 characters \"\" and \"t\"")]
        [SerializeField]
        bool m_ConvertCharacterStringLiterals = true;

        internal SmartSettings()
        {
            CaseSensitivity = CaseSensitivityType.CaseSensitive;
            ConvertCharacterStringLiterals = true;
            FormatErrorAction = ErrorAction.ThrowError;
            ParseErrorAction = ErrorAction.ThrowError;
        }

        /// <summary>
        /// Gets or sets the <see cref="ErrorAction" /> to apply for the <see cref="SmartFormatter" />.
        /// </summary>
        public ErrorAction FormatErrorAction
        {
            get => m_FormatErrorAction;
            set => m_FormatErrorAction = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="ErrorAction" /> to apply for the <see cref="SmartFormat.Core.Parsing.Parser" />.
        /// </summary>
        public ErrorAction ParseErrorAction
        {
            get => m_ParseErrorAction;
            set => m_ParseErrorAction = value;
        }

        /// <summary>
        /// Determines whether placeholders are case-sensitive or not.
        /// </summary>
        public CaseSensitivityType CaseSensitivity
        {
            get => m_CaseSensitivity;
            set => m_CaseSensitivity = value;
        }

        /// <summary>
        /// This setting is relevant for the <see cref="Parsing.LiteralText" />.
        /// If true (the default), character string literals are treated like in "normal" string.Format:
        /// string.Format("\t")   will return a "TAB" character
        /// If false, character string literals are not converted, just like with this string.Format:
        /// string.Format(@"\t")  will return the 2 characters "\" and "t"
        /// </summary>
        public bool ConvertCharacterStringLiterals
        {
            get => m_ConvertCharacterStringLiterals;
            set => m_ConvertCharacterStringLiterals = value;
        }

        internal IEqualityComparer<string> GetCaseSensitivityComparer()
        {
            {
                switch (CaseSensitivity)
                {
                    case CaseSensitivityType.CaseSensitive:
                        return StringComparer.Ordinal;
                    case CaseSensitivityType.CaseInsensitive:
                        return StringComparer.OrdinalIgnoreCase;
                    default:
                        throw new InvalidOperationException(
                            $"The case sensitivity type [{CaseSensitivity}] is unknown.");
                }
            }
        }

        internal StringComparison GetCaseSensitivityComparison()
        {
            {
                switch (CaseSensitivity)
                {
                    case CaseSensitivityType.CaseSensitive:
                        return StringComparison.Ordinal;
                    case CaseSensitivityType.CaseInsensitive:
                        return StringComparison.OrdinalIgnoreCase;
                    default:
                        throw new InvalidOperationException(
                            $"The case sensitivity type [{CaseSensitivity}] is unknown.");
                }
            }
        }
    }
}

using UnityEngine.Localization.SmartFormat.Core.Settings;

namespace UnityEngine.Localization.SmartFormat.Core.Parsing
{
    /// <summary>
    /// Represents a single selector
    /// in the text in a <see cref="Placeholder" />
    /// that comes before the colon.
    /// </summary>
    public class Selector : FormatItem
    {
        string m_Operator = null;

        /// <summary>
        /// Keeps track of where the "operators" started for this item.
        /// </summary>
        internal int operatorStart;

        public override void Clear()
        {
            base.Clear();
            m_Operator = null;
        }

        /// <summary>
        /// The index of the selector in a multi-part selector.
        /// Example: {Person.Birthday.Year} has 3 seletors,
        /// and Year has a SelectorIndex of 2.
        /// </summary>
        public int SelectorIndex { get; internal set; }

        /// <summary>
        /// The operator that came before the selector; typically "."
        /// </summary>
        public string Operator
        {
            get
            {
                if (m_Operator == null)
                    m_Operator = baseString.Substring(operatorStart, startIndex - operatorStart);
                return m_Operator;
            }
        }
    }
}

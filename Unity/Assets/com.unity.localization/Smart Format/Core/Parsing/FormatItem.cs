using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Core.Settings;

namespace UnityEngine.Localization.SmartFormat.Core.Parsing
{
    /// <summary>
    /// Base class that represents a substring
    /// of text from a parsed format string.
    /// </summary>
    public abstract class FormatItem
    {
        public string baseString;
        public int endIndex;
        protected SmartSettings SmartSettings;
        public int startIndex;
        protected string m_RawText;

        public FormatItem Parent { get; private set; }

        public void Init(SmartSettings smartSettings, FormatItem parent, int startIndex)
        {
            Init(smartSettings, parent, parent.baseString, startIndex, parent.baseString.Length);
        }

        public void Init(SmartSettings smartSettings, FormatItem parent, int startIndex, int endIndex)
        {
            Init(smartSettings, parent, parent.baseString, startIndex, endIndex);
        }

        public void Init(SmartSettings smartSettings, FormatItem parent, string baseString, int startIndex, int endIndex)
        {
            Parent = parent;
            SmartSettings = smartSettings;
            this.baseString = baseString;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }

        public virtual void Clear()
        {
            baseString = null;
            endIndex = 0;
            startIndex = 0;
            SmartSettings = null;
            m_RawText = null;
            Parent = null;
        }

        /// <summary>
        /// Retrieves the raw text that this item represents.
        /// </summary>
        public string RawText
        {
            get
            {
                if (m_RawText == null)
                    m_RawText = baseString.Substring(startIndex, endIndex - startIndex);
                return m_RawText;
            }
        }

        struct PartialCharEnumerator : IEnumerable<char>
        {
            string m_BaseString;
            int m_From, m_To;

            public PartialCharEnumerator(string s, int from, int to)
            {
                m_BaseString = s;
                m_From = from;
                m_To = to;
            }

            public IEnumerator<char> GetEnumerator()
            {
                for (int i = m_From; i < m_To; ++i)
                {
                    yield return m_BaseString[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public IEnumerable<char> ToEnumerable()
        {
            // We need to copy the data as this instance may be returned back to the pool before the IEnumerable has completed which would clear the values.
            return new PartialCharEnumerator(baseString, startIndex, endIndex);
        }

        public override string ToString()
        {
            return endIndex <= startIndex
                ? $"Empty ({baseString.Substring(startIndex)})"
                : $"{RawText}";
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Pool;

namespace UnityEngine.Localization.SmartFormat.Core.Parsing
{
    /// <summary>
    /// Represents a parsed format string.
    /// Contains a list of <see cref="FormatItem" />s,
    /// including <see cref="LiteralText" />s
    /// and <see cref="Placeholder" />s.
    /// </summary>
    public class Format : FormatItem
    {
        public void ReleaseToPool()
        {
            Clear();

            foreach (var i in Items)
            {
                // Only release items we own
                if (ReferenceEquals(this, i.Parent))
                    FormatItemPool.Release(i);
            }

            foreach (var s in m_Splits)
            {
                SplitListPool.Release(s);
            }

            parent = null;
            Items.Clear();
            HasNested = false;
            splitCache = null;
            m_Splits.Clear();
        }

        public Placeholder parent;
        public List<FormatItem> Items { get; } = new List<FormatItem>();
        public bool HasNested { get; set; }

        List<SplitList> m_Splits = new List<SplitList>();

        /// <summary>Returns a substring of the current Format.</summary>
        public Format Substring(int startIndex)
        {
            return Substring(startIndex, endIndex - this.startIndex - startIndex);
        }

        /// <summary>Returns a substring of the current Format.</summary>
        public Format Substring(int startIndex, int length)
        {
            startIndex = this.startIndex + startIndex;
            var endIndex = startIndex + length;
            // Validate the arguments:
            if (startIndex < this.startIndex || startIndex > this.endIndex) // || endIndex > this.endIndex)
                throw new ArgumentOutOfRangeException("startIndex");
            if (endIndex > this.endIndex)
                throw new ArgumentOutOfRangeException("length");

            // If startIndex and endIndex already match this item, we're done:
            if (startIndex == this.startIndex && endIndex == this.endIndex) return this;

            var substring = FormatItemPool.GetFormat(SmartSettings, baseString, startIndex, endIndex);
            foreach (var item in Items)
            {
                if (item.endIndex <= startIndex)
                    continue; // Skip first items
                if (endIndex <= item.startIndex)
                    break; // Done

                var newItem = item;
                if (item is LiteralText) // See if we need to slice the LiteralText:
                {
                    if (startIndex > item.startIndex || item.endIndex > endIndex)
                        newItem = FormatItemPool.GetLiteralText(SmartSettings, substring, Math.Max(startIndex, item.startIndex), Math.Min(endIndex, item.endIndex));
                }
                else
                {
                    // item is a placeholder -- we can't split a placeholder though.
                    substring.HasNested = true;
                }

                substring.Items.Add(newItem);
            }

            return substring;
        }

        /// <summary>
        /// Searches the literal text for the search char.
        /// Does not search in nested placeholders.
        /// </summary>
        /// <param name="search"></param>
        public int IndexOf(char search)
        {
            return IndexOf(search, 0);
        }

        /// <summary>
        /// Searches the literal text for the search char.
        /// Does not search in nested placeholders.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="startIndex"></param>
        public int IndexOf(char search, int startIndex)
        {
            startIndex = this.startIndex + startIndex;
            foreach (var item in Items)
            {
                if (item.endIndex < startIndex) continue;
                var literalItem = item as LiteralText;
                if (literalItem == null) continue;

                if (startIndex < literalItem.startIndex) startIndex = literalItem.startIndex;
                var literalIndex =
                    literalItem.baseString.IndexOf(search, startIndex, literalItem.endIndex - startIndex);
                if (literalIndex != -1) return literalIndex - this.startIndex;
            }

            return -1;
        }

        private List<int> FindAll(char search)
        {
            return FindAll(search, -1);
        }

        private List<int> FindAll(char search, int maxCount)
        {
            var results = ListPool<int>.Get();
            var index = 0; // this.startIndex;
            while (maxCount != 0)
            {
                index = IndexOf(search, index);
                if (index == -1) break;
                results.Add(index);
                index++;
                maxCount--;
            }

            return results;
        }

        private char splitCacheChar;
        private IList<Format> splitCache;

        public IList<Format> Split(char search)
        {
            if (splitCache == null || splitCacheChar != search)
            {
                splitCacheChar = search;
                splitCache = Split(search, -1);
            }

            return splitCache;
        }

        public IList<Format> Split(char search, int maxCount)
        {
            var splits = FindAll(search, maxCount);
            var sl = SplitListPool.Get(this, splits);

            // Keep track of the split lists we create so that they can be returned for reuse in the future.
            m_Splits.Add(sl);
            return sl;
        }

        /// <summary>
        /// Contains the results of a Split operation.
        /// This allows deferred splitting of items.
        /// </summary>
        internal class SplitList : IList<Format>
        {
            Format m_Format;
            List<int> m_Splits;
            List<Format> m_FormatCache = new List<Format>();

            public void Init(Format format, List<int> splits)
            {
                m_Format = format;
                m_Splits = splits;

                // Resize the cache to match
                for (int i = 0; i < Count; ++i)
                    m_FormatCache.Add(null);
            }

            public Format this[int index]
            {
                get
                {
                    if (index > m_Splits.Count) throw new ArgumentOutOfRangeException("index");

                    if (m_Splits.Count == 0) return m_Format;

                    // Return cached version?
                    if (m_FormatCache[index] != null)
                        return m_FormatCache[index];

                    if (index == 0)
                    {
                        var f = m_Format.Substring(0, m_Splits[0]);
                        m_FormatCache[index] = f;
                        return f;
                    }

                    if (index == m_Splits.Count)
                    {
                        var f = m_Format.Substring(m_Splits[index - 1] + 1);
                        m_FormatCache[index] = f;
                        return f;
                    }

                    // Return the format between the splits:
                    var startIndex = m_Splits[index - 1] + 1;
                    var format = m_Format.Substring(startIndex, m_Splits[index] - startIndex);
                    m_FormatCache[index] = format;
                    return format;
                }
                set => throw new NotSupportedException();
            }

            public void CopyTo(Format[] array, int arrayIndex)
            {
                var length = m_Splits.Count + 1;
                for (var i = 0; i < length; i++) array[arrayIndex + i] = this[i];
            }

            public int Count => m_Splits.Count + 1;

            public bool IsReadOnly => true;

            public int IndexOf(Format item)
            {
                throw new NotSupportedException();
            }

            public void Insert(int index, Format item)
            {
                throw new NotSupportedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            public void Add(Format item)
            {
                throw new NotSupportedException();
            }

            public void Clear()
            {
                m_Format = null;
                ListPool<int>.Release(m_Splits);
                m_Splits = null;

                // Return the Formats we created
                for (int i = 0; i < m_FormatCache.Count; ++i)
                {
                    if (m_FormatCache[i] != null)
                        FormatItemPool.ReleaseFormat(m_FormatCache[i]);
                }
                m_FormatCache.Clear();
            }

            public bool Contains(Format item)
            {
                throw new NotSupportedException();
            }

            public bool Remove(Format item)
            {
                throw new NotSupportedException();
            }

            public IEnumerator<Format> GetEnumerator()
            {
                throw new NotSupportedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Retrieves the literal text contained in this format.
        /// Excludes escaped chars, and does not include the text
        /// of placeholders
        /// </summary>
        /// <returns></returns>
        public string GetLiteralText()
        {
            using (StringBuilderPool.Get(out var sb))
            {
                foreach (var item in Items)
                {
                    var literalItem = item as LiteralText;
                    if (literalItem != null)
                        sb.Append(literalItem);
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Reconstructs the format string, but doesn't include escaped chars
        /// and tries to reconstruct placeholders.
        /// </summary>
        public override string ToString()
        {
            using (StringBuilderPool.Get(out var sb))
            {
                int size = endIndex - startIndex;
                if (sb.Capacity < size)
                    sb.Capacity = size;

                foreach (var item in Items)
                    sb.Append(item);
                return sb.ToString();
            }
        }
    }
}

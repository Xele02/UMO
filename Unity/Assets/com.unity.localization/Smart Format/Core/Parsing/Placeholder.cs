using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine.Localization.SmartFormat.Core.Parsing
{
    /// <summary>
    /// A placeholder is the part of a format string between the { braces }.
    /// </summary>
    /// <example>
    /// For example, in "{Items.Length,10:choose(1,2,3):one|two|three}",
    /// the <see cref="Alignment" />s is "10",
    /// the <see cref="Selector" />s are "Items" and "Length",
    /// the <see cref="FormatterName" /> is "choose",
    /// the <see cref="FormatterOptions" /> is "1,2,3",
    /// and the <see cref="Format" /> is "one|two|three".
    /// </example>
    public class Placeholder : FormatItem
    {
        public void ReleaseToPool()
        {
            Clear();

            if (Format != null)
                FormatItemPool.ReleaseFormat(Format);
            Format = null;

            NestedDepth = 0;
            Alignment = 0;

            foreach (var sel in Selectors)
            {
                FormatItemPool.ReleaseSelector(sel);
            }
            Selectors.Clear();
        }

        public int NestedDepth { get; set; }

        public List<Selector> Selectors { get; } = new List<Selector>();
        public int Alignment { get; set; }
        public string FormatterName { get; set; }
        public string FormatterOptions { get; set; }
        public Format Format { get; set; }

        public override string ToString()
        {
            using (StringBuilderPool.Get(out var result))
            {
                int size = endIndex - startIndex;
                if (result.Capacity < size)
                    result.Capacity = size;

                result.Append('{');
                foreach (var s in Selectors)
                    result.Append(s.baseString, s.operatorStart, s.endIndex - s.operatorStart);
                if (Alignment != 0)
                {
                    result.Append(',');
                    result.Append(Alignment);
                }

                if (FormatterName != "")
                {
                    result.Append(':');
                    result.Append(FormatterName);
                    if (FormatterOptions != "")
                    {
                        result.Append('(');
                        result.Append(FormatterOptions);
                        result.Append(')');
                    }
                }

                if (Format != null)
                {
                    result.Append(':');
                    result.Append(Format);
                }

                result.Append('}');
                return result.ToString();
            }
        }
    }
}

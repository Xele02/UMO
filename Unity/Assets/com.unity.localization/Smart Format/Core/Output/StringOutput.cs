using System.Text;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Core.Output
{
    /// <summary>
    /// Wraps a StringBuilder so it can be used for output.
    /// This is used for the default output.
    /// </summary>
    public class StringOutput : IOutput
    {
        private readonly StringBuilder output;

        public StringOutput()
        {
            output = new StringBuilder();
        }

        public StringOutput(int capacity)
        {
            output = new StringBuilder(capacity);
        }

        public StringOutput(StringBuilder output)
        {
            this.output = output;
        }

        public void SetCapacity(int capacity)
        {
            if (output.Capacity < capacity)
                output.Capacity = capacity;
        }

        public void Write(string text, IFormattingInfo formattingInfo)
        {
            output.Append(text);
        }

        public void Write(string text, int startIndex, int length, IFormattingInfo formattingInfo)
        {
            output.Append(text, startIndex, length);
        }

        public void Clear()
        {
            output.Clear();
        }

        /// <summary>
        /// Returns the results of the StringBuilder.
        /// </summary>
        public override string ToString()
        {
            return output.ToString();
        }
    }
}

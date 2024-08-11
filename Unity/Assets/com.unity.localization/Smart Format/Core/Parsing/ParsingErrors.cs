using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.Localization.SmartFormat.Core.Parsing
{
    /// <summary>
    /// Represents parsing errors in a Format string.
    /// This exception only gets thrown when Parser.ErrorAction is set to ThrowError.
    /// </summary>
    public class ParsingErrors : Exception
    {
        private Format result;

        public void Init(Format result)
        {
            this.result = result;
        }

        public void Clear()
        {
            Issues.Clear();
        }

        public List<ParsingIssue> Issues { get; } = new List<ParsingIssue>();
        public bool HasIssues => Issues.Count > 0;

        public string MessageShort => $"The format string has {Issues.Count} issue{(Issues.Count == 1 ? "" : "s")}: {string.Join(", ", Issues.Select(i => i.Issue).ToArray())}";

        public override string Message
        {
            get
            {
                var arrows = "";
                var lastArrow = 0;
                foreach (var issue in Issues)
                {
                    arrows += new string('-', issue.Index - lastArrow);
                    if (issue.Length > 0)
                    {
                        arrows += new string('^', Math.Max(issue.Length, 1));
                        lastArrow = issue.Index + issue.Length;
                    }
                    else
                    {
                        arrows += '^';
                        lastArrow = issue.Index + 1;
                    }
                }

                return $"The format string has {Issues.Count} issue{(Issues.Count == 1 ? "" : "s")}:\n{string.Join(", ", Issues.Select(i => i.Issue).ToArray())}\nIn: \"{result.baseString}\"\nAt:  {arrows} ";
            }
        }

        public void AddIssue(string issue, int startIndex, int endIndex)
        {
            Issues.Add(new ParsingIssue(issue, startIndex, endIndex - startIndex));
        }

        public class ParsingIssue
        {
            public ParsingIssue(string issue, int index, int length)
            {
                Issue = issue;
                Index = index;
                Length = length;
            }

            public int Index { get; }
            public int Length { get; }
            public string Issue { get; }
        }
    }
}

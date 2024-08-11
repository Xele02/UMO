using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Provides the ability to write the contents of [XElement](https://docs.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement) values into a format string.
    /// </summary>
    [Serializable]
    public class XElementFormatter : FormatterBase
    {
        /// <summary>
        /// Creates a new instance of the formatter.
        /// </summary>
        public XElementFormatter()
        {
            Names = DefaultNames;
        }

        /// <inheritdoc/>
        public override string[] DefaultNames => new[] {"xelement", "xml", "x", ""};

        /// <inheritdoc/>
        public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var format = formattingInfo.Format;
            var current = formattingInfo.CurrentValue;

            XElement currentXElement = null;
            if (format != null && format.HasNested) return false;
            // if we need to format list of XElements then we just take and format first
            var xElmentsAsList = current as IList<XElement>;
            if (xElmentsAsList != null && xElmentsAsList.Count > 0) currentXElement = xElmentsAsList[0];

            var currentAsXElement = currentXElement ?? current as XElement;
            if (currentAsXElement != null)
            {
                formattingInfo.Write(currentAsXElement.Value);
                return true;
            }

            return false;
        }
    }
}

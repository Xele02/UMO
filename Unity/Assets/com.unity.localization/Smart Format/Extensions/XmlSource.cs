using System;
using System.Linq;
using System.Xml.Linq;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Provides the ability to extract elements from an [XElement](https://docs.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement) object.
    /// </summary>
    [Serializable]
    public class XmlSource : ISource
    {
        /// <summary>
        /// Creates a new instance of the source.
        /// </summary>
        /// <param name="formatter"></param>
        public XmlSource(SmartFormatter formatter)
        {
            // Add some special info to the parser:
            formatter.Parser.AddAlphanumericSelectors(); // (A-Z + a-z)
            formatter.Parser.AddAdditionalSelectorChars("_");
            formatter.Parser.AddOperators(".");
        }

        /// <inheritdoc/>
        public bool TryEvaluateSelector(ISelectorInfo selectorInfo)
        {
            var element = selectorInfo.CurrentValue as XElement;
            if (element != null)
            {
                var selector = selectorInfo.SelectorText;
                // Find elements that match a selector
                var selectorMatchedElements = element.Elements()
                    .Where(x => x.Name.LocalName == selector).ToList();
                if (selectorMatchedElements.Any())
                {
                    selectorInfo.Result = selectorMatchedElements;
                    return true;
                }
            }

            return false;
        }
    }
}

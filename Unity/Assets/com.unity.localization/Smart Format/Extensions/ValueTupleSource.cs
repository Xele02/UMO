using System;
//using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.Core.Formatting;
using UnityEngine.Localization.SmartFormat.Utilities;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Provides the ability to iterate through a [Tuple](https://docs.microsoft.com/en-us/dotnet/api/system.tuple-7?view=net-5.0) values.
    /// </summary>
    [Serializable]
    public class ValueTupleSource : ISource
    {
        SmartFormatter m_Formatter;

        /// <summary>
        /// Creates a new instance of the source.
        /// </summary>
        /// <param name="formatter"></param>
        public ValueTupleSource(SmartFormatter formatter)
        {
            m_Formatter = formatter;
        }

        /// <inheritdoc/>
        public bool TryEvaluateSelector(ISelectorInfo selectorInfo)
        {
            if (!(selectorInfo is FormattingInfo formattingInfo)) return false;
            if (!(formattingInfo.CurrentValue != null && formattingInfo.CurrentValue.IsValueTuple())) return false;

            var savedCurrentValue = formattingInfo.CurrentValue;
            foreach (var obj in formattingInfo.CurrentValue.GetValueTupleItemObjectsFlattened())
            {
                var formatter = m_Formatter ?? RuntimeSettings.CurrentSettings.SmartFormatter;
                foreach (var sourceExtension in m_Formatter.SourceExtensions)
                {
                    formattingInfo.CurrentValue = obj;
                    var handled = sourceExtension.TryEvaluateSelector(formattingInfo);
                    if (handled)
                    {
                        formattingInfo.CurrentValue = savedCurrentValue;
                        return true;
                    }
                }
            }

            formattingInfo.CurrentValue = savedCurrentValue;

            return false;
        }
    }
}

using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Core.Parsing;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace UnityEngine.Localization.SmartFormat.Core.Formatting
{
    /// <summary>
    /// Caches information about a format operation
    /// so that repeat calls can be optimized to run faster.
    /// </summary>
    public class FormatCache
    {
        /// <summary>
        /// Caches the parsed format.
        /// </summary>
        public Format Format { get; set; }

        /// <summary>
        /// Storage for any misc objects.
        /// This can be used by extensions that want to cache data,
        /// such as reflection information.
        /// </summary>
        public Dictionary<string, object> CachedObjects { get; } = new Dictionary<string, object>();

        /// <summary>
        /// When applying Smart Format to a string, the entry will record its table.
        /// Any nested <see cref="LocalizedString"/> will use this to determine the <see cref="Locale"/> that should be
        /// used and will also record their table for any further <see cref="LocalizedString"/> that may be nested within them.
        /// </summary>
        //public LocalizationTable Table;

        /// <summary>
        /// Storage for local variables that may be used during formatting by the <see cref="SmartFormat.Extensions.PersistentVariablesSource"/>.
        /// </summary>
        public IVariableGroup LocalVariables { get; set; }

        /// <summary>
        /// Any <see cref="IVariableValueChanged"/> that may have been used during formatting.
        /// This can then be used to subscribe to update events in order to trigger a regeneration of the string.
        /// </summary>
        public List<IVariableValueChanged> VariableTriggers { get; } = new List<IVariableValueChanged>();
    }
}

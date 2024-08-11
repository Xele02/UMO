using System;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Can be used to provide global values that do not need to be passed in as arguments when formatting a string.
    /// The smart string should take the format {groupName.variableName}. e.g {global.player-score}.
    /// Note: The group name and variable names must not contain any spaces.
    /// </summary>
    [Serializable]
    [Obsolete("Please use PersistentVariablesSource instead (UnityUpgradable) -> PersistentVariablesSource")]
    public class GlobalVariablesSource : PersistentVariablesSource
    {
        /// <summary>
        /// Creates a new instance of the source,
        /// </summary>
        /// <param name="formatter"></param>
        public GlobalVariablesSource(SmartFormatter formatter) :
            base(formatter)
        {
        }
    }
}

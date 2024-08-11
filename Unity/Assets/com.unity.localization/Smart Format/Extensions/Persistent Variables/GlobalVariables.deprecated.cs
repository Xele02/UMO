using System;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace UnityEngine.Localization.SmartFormat.GlobalVariables
{
    /// <inheritdoc/>
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.IVariableGroup instead.")]
    public interface IVariableGroup : PersistentVariables.IVariableGroup {}

    /// <inheritdoc/>
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable instead.")]
    public interface IGlobalVariable : IVariable {}

    /// <inheritdoc/>
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.IVariableValueChanged instead.")]
    public interface IGlobalVariableValueChanged : IVariableValueChanged {}

    /// <inheritdoc/>
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup instead (UnityUpgradable) -> UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup")]
    public class NestedGlobalVariablesGroup : NestedVariablesGroup {}

    /// <summary>
    /// Collection of <see cref="IVariable"/> that can be used during formatting of a localized string.
    /// </summary>
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.VariablesGroupAsset instead.")]
    public class GlobalVariablesGroup : VariablesGroupAsset {}

    /// <inheritdoc/>
    [Serializable]
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.Variable instead.")]
    public class GlobalVariable<T> : Variable<T> {}

    /// <inheritdoc/>
    [Serializable]
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.FloatVariable instead (UnityUpgradable) -> UnityEngine.Localization.SmartFormat.PersistentVariables.FloatVariable")]
    public class FloatGlobalVariable : FloatVariable {}

    /// <inheritdoc/>
    [Serializable]
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.StringVariable instead (UnityUpgradable) -> UnityEngine.Localization.SmartFormat.PersistentVariables.StringVariable")]
    public class StringGlobalVariable : StringVariable {}

    /// <inheritdoc/>
    [Serializable]
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.IntVariable instead (UnityUpgradable) -> UnityEngine.Localization.SmartFormat.PersistentVariables.IntVariable")]
    public class IntGlobalVariable : IntVariable {}

    /// <inheritdoc/>
    [Serializable]
    [Obsolete("Please use UnityEngine.Localization.SmartFormat.PersistentVariables.BoolVariable instead (UnityUpgradable) -> UnityEngine.Localization.SmartFormat.PersistentVariables.BoolVariable")]
    public class BoolGlobalVariable : BoolVariable {}
}

using System;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.PersistentVariables
{
    /// <summary>
    /// Collection that contains <see cref="IVariable"/>.
    /// </summary>
    public interface IVariableGroup
    {
        /// <summary>
        /// Gets the variable with the matching key if one exists.
        /// </summary>
        /// <param name="key">The variable key or name to match.</param>
        /// <param name="value">The found variable or <see langword="null"/> if one could not be found.</param>
        /// <returns><see langword="true"/> if a variable cound be found or <see langword="false"/> if one could not.</returns>
        bool TryGetValue(string key, out IVariable value);
    }

    /// <summary>
    /// Represents a variable that can be provided through a global <see cref="VariablesGroupAsset"/> or as a local
    /// variable through <see cref="LocalizedString"/> instead of as a string format argument.
    /// A variable can be a single variable, in which case the value should be returned in <see cref="GetSourceValue(ISelectorInfo)"/> or a
    /// class with multiple variables which can then be further extracted with additional string format arguments.
    /// </summary>
    /// <example>
    /// This shows how to create a custom variable to represent a Date and Time.
    /// <code source="../../../../DocCodeSamples.Tests/PersistentVariablesSamples.cs" region="custom-date-time-example"/>
    /// </example>
    /// <example>
    /// This shows how to create a custom variable to represent a list of localized strings.
    /// <code source="../../../../DocCodeSamples.Tests/PersistentVariablesSamples.cs" region="custom-list-loc-strings"/>
    /// </example>
    public interface IVariable
    {
        /// <summary>
        /// The value that will be used when the smart string matches this variable. This value can then be further used by additional sources/formatters.
        /// </summary>
        /// <param name="selector">The details about the current format operation.</param>
        /// <returns></returns>
        object GetSourceValue(ISelectorInfo selector);
    }

    /// <summary>
    /// Adds support for querying the Metadata in a Smart String.
    /// </summary>
    /// <example>
    /// In some languages, such as Spanish, all nouns have a gender, that means they are either masculine or feminine.
    /// The structure of the sentence will change according to the gender of the item.
    /// This example shows how metadata can be used to mark an entry with a gender which can
    /// then be queried to create a dynamic string with the correct gender forms.
    /// This shows how the following metadata could be used in a Smart String, where `item` is a <see cref="LocalizedString"/> local variable:
    /// <c>{item.gender:choose(Male|Female):El|La}</c>
    /// <code source="../../../../DocCodeSamples.Tests/PersistentVariablesSamples.cs" region="metadata-variable2"/>
    /// </example>
    public interface IMetadataVariable : IVariable
    {
        /// <summary>
        /// The named placeholder that will match this metdata when querying a <see cref="LocalizedString"/> as a local or global variable.
        /// </summary>
        string VariableName { get; }
    }

    /// <summary>
    /// Provides the ability to trigger an automatic update of a <see cref="LocalizedString"/> when <see cref="ValueChanged"/> is invoked.
    /// </summary>
    public interface IVariableValueChanged : IVariable
    {
        /// <summary>
        /// This event is sent when the global variable has changed or wishes to trigger an update to any <see cref="LocalizedString"/> that is currently using it.
        /// </summary>
        event Action<IVariable> ValueChanged;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.PersistentVariables
{
    /// <summary>
    /// Provides a reference to a <see cref="VariablesGroupAsset"/>.
    /// </summary>
    //[DisplayName("Nested Variables Group")]
    public class NestedVariablesGroup : Variable<VariablesGroupAsset>, IVariableGroup
    {
        /// <inheritdoc/>
        public bool TryGetValue(string name, out IVariable value)
        {
            if (Value != null)
                return Value.TryGetValue(name, out value);
            value = default;
            return false;
        }
    }

    [Serializable]
    internal class VariableNameValuePair
    {
        public string name;

        //[SerializeReference]
        public IVariable variable;

        public override string ToString() => $"{name} - {variable?.GetType().Name}";
    }

    /// <summary>
    /// Collection of <see cref="IVariable"/> that can be used during formatting of a localized string.
    /// </summary>
    [CreateAssetMenu(menuName = "Localization/Variables Group")]
    public class VariablesGroupAsset : ScriptableObject, IVariableGroup, IVariable, IDictionary<string, IVariable>, ISerializationCallbackReceiver
    {
        [SerializeField]
        internal List<VariableNameValuePair> m_Variables = new List<VariableNameValuePair>();

        Dictionary<string, VariableNameValuePair> m_VariableLookup = new Dictionary<string, VariableNameValuePair>();

        /// <inheritdoc/>
        /// <summary>
        /// Returns the number of variables in the group.
        /// </summary>
        public int Count => m_VariableLookup.Count;

        /// <summary>
        /// Returns a collection containing all the unique variable names.
        /// </summary>
        public ICollection<string> Keys => m_VariableLookup.Keys;

        /// <summary>
        /// Returns all the variables for this group.
        /// </summary>
        public ICollection<IVariable> Values => m_VariableLookup.Values.Select(s => s.variable).ToList();

        /// <summary>
        /// Implemented as part of IDictionary but not used. Always returns <see langword="false"/>.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="IVariable"/> with the specified name.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <returns>The found variable.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if a variable with the specified name does not exist.</exception>
        /// <example>
        /// This example shows how to get a variable group named "globals".
        /// <code source="../../../../DocCodeSamples.Tests/PersistentVariablesSamples.cs" region="add-global-variable"/>
        /// </example>
        public IVariable this[string name]
        {
            get => m_VariableLookup[name].variable;
            set => Add(name, value);
        }

        /// <inheritdoc/>
        public object GetSourceValue(ISelectorInfo _) => this;

        /// <summary>
        /// Gets the <see cref="IVariable"/> with the specified name.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The variable that was found or <see langword="default"/>.</param>
        /// <returns><see langword="true"/> if a variable was found and <see langword="false"/> if one could not.</returns>
        /// <example>
        /// This example shows how to get a variable named "my-float" from a <see cref="VariablesGroupAsset"/> named "global".
        /// <code source="../../../../DocCodeSamples.Tests/PersistentVariablesSamples.cs" region="try-get-add-global-variable"/>
        /// </example>
        public bool TryGetValue(string name, out IVariable value)
        {
            if (m_VariableLookup.TryGetValue(name, out var v))
            {
                value = v.variable;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Adds a new Global Variable to use during formatting.
        /// </summary>
        /// <param name="name">The name of the variable, must be unique. Note the name should not contain any whitespace, if any is found then it will be replaced with with '-'.</param>
        /// <param name="variable">The variable to use when formatting. See also <seealso cref="BoolVariable"/>, <seealso cref="FloatVariable"/>, <seealso cref="IntVariable"/>, <seealso cref="StringVariable"/>, <seealso cref="ObjectVariable"/>.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when variable is null.</exception>
        /// <example>
        /// This example shows how to add a variable named "my-int" to a <see cref="VariablesGroupAsset"/> named "globals".
        /// <code source="../../../../DocCodeSamples.Tests/PersistentVariablesSamples.cs" region="add-global-variable"/>
        /// </example>
        public void Add(string name, IVariable variable)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name), "Name must not be null or empty.");
            if (variable == null)
                throw new ArgumentNullException(nameof(variable));

            name = name.ReplaceWhiteSpaces("-");
            var v = new VariableNameValuePair { name = name, variable = variable };
            m_VariableLookup.Add(name, v);
            m_Variables.Add(v);
        }

        /// <summary>
        /// <inheritdoc cref="Add(string, IVariable)"/>
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<string, IVariable> item) => Add(item.Key, item.Value);

        /// <summary>
        /// Removes a variable with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns><see langword="true"/> if a variable with the specified name was removed, <see langword="false"/> if one was not.</returns>
        public bool Remove(string name)
        {
            if (m_VariableLookup.TryGetValue(name, out var v))
            {
                m_Variables.Remove(v);
                m_VariableLookup.Remove(name);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a variable with the specified key.
        /// </summary>
        /// <param name="item">The item to be removed, only the Key field will be considered.</param>
        /// <returns><see langword="true"/> if a variable with the specified name was removed, <see langword="false"/> if one was not.</returns>
        public bool Remove(KeyValuePair<string, IVariable> item) => Remove(item.Key);

        /// <summary>
        /// Returns <see langword="true"/> if a variable with the specified name exists.
        /// </summary>
        /// <param name="name">The variable name to check for.</param>
        /// <returns><see langword="true"/> if a matching variable could be found or <see langword="false"/> if one could not.</returns>
        public bool ContainsKey(string name) => m_VariableLookup.ContainsKey(name);

        /// <summary>
        /// <inheritdoc cref="ContainsKey(string)"/>
        /// </summary>
        /// <param name="item">The item to check for. Both the Key and Value must match.</param>
        /// <returns><see langword="true"/> if a matching variable could be found or <see langword="false"/> if one could not.</returns>
        public bool Contains(KeyValuePair<string, IVariable> item) => TryGetValue(item.Key, out var v) && v == item.Value;

        /// <summary>
        /// Copies the variables into an array starting at <paramref name="arrayIndex"/>.
        /// </summary>
        /// <param name="array">The array to copy the variables into.</param>
        /// <param name="arrayIndex">The index to start copying the items into.</param>
        /// <exception cref="ArgumentNullException">Thrown when the array is null.</exception>
        public void CopyTo(KeyValuePair<string, IVariable>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            foreach (var entry in m_VariableLookup)
            {
                array[arrayIndex++] = new KeyValuePair<string, IVariable>(entry.Key, entry.Value.variable);
            }
        }

        /// <summary>
        /// <inheritdoc cref="GetEnumerator"/>
        /// </summary>
        /// <returns>The enumerator that can be used to iterate through all the variables.</returns>
        IEnumerator<KeyValuePair<string, IVariable>> IEnumerable<KeyValuePair<string, IVariable>>.GetEnumerator()
        {
            foreach (var v in m_VariableLookup)
            {
                yield return new KeyValuePair<string, IVariable>(v.Key, v.Value.variable);
            }
        }

        /// <summary>
        /// Returns an enumerator for all variables in this group.
        /// </summary>
        /// <returns>The enumerator that can be used to iterate through all the variables.</returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var v in m_VariableLookup)
            {
                yield return new KeyValuePair<string, IVariable>(v.Key, v.Value.variable);
            }
        }

        /// <summary>
        /// <inheritdoc cref="ContainsKey(string)"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Obsolete("Please use ContainsKey instead.", false)]
        public bool ContainsName(string name) => ContainsKey(name);

        /// <summary>
        /// Removes all variables in the group.
        /// </summary>
        public void Clear()
        {
            m_VariableLookup.Clear();
            m_Variables.Clear();
        }

        public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
            if (m_VariableLookup == null)
                m_VariableLookup = new Dictionary<string, VariableNameValuePair>();

            m_VariableLookup.Clear();
            foreach (var v in m_Variables)
            {
                if (!string.IsNullOrEmpty(v.name))
                {
                    m_VariableLookup[v.name] = v;
                }
            }
        }
    }
}

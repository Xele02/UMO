using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Can be used to provide global or local values that do not need to be passed in as arguments when formatting a string.
    /// The smart string should take the format {groupName.variableName}. e.g {global.player-score}.
    /// Note: The group name and variable names must not contain any spaces.
    /// </summary>
    [Serializable]
    public class PersistentVariablesSource : ISource, IDictionary<string, VariablesGroupAsset>, ISerializationCallbackReceiver
    {
        [Serializable]
        class NameValuePair
        {
            public string name;

            //[SerializeReference]
            public VariablesGroupAsset group;
        }

        /// <summary>
        /// Encapsulates a <see cref="BeginUpdating"/> and <see cref="EndUpdating"/> call.
        /// </summary>
        public struct ScopedUpdate : IDisposable
        {
            /// <summary>
            /// Calls <see cref="EndUpdating"/>.
            /// </summary>
            public void Dispose() => EndUpdating();
        }

        [SerializeField]
        List<NameValuePair> m_Groups = new List<NameValuePair>();

        Dictionary<string, NameValuePair> m_GroupLookup = new Dictionary<string, NameValuePair>();

        internal static int s_IsUpdating;

        /// <summary>
        /// Has <see cref="BeginUpdating"/> been called?
        /// This can be used when updating the value of multiple <see cref="IVariable"/> in order to do
        /// a single update after the updates instead of 1 per change.
        /// </summary>
        public static bool IsUpdating => s_IsUpdating != 0;

        /// <summary>
        /// The number of <see cref="VariablesGroupAsset"/> that are used for global variables.
        /// </summary>
        public int Count => m_Groups.Count;

        /// <summary>
        /// Implmented as part of IDictionary but not used. Will always return <see langword="false"/>.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Returns the global variable group names.
        /// </summary>
        public ICollection<string> Keys => m_GroupLookup.Keys;

        /// <summary>
        /// Returns the global variable groups for this source.
        /// </summary>
        public ICollection<VariablesGroupAsset> Values => m_GroupLookup.Values.Select(k => k.group).ToList();

        /// <summary>
        /// Returns the global variable group that matches <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the group to return.</param>
        /// <returns></returns>
        public VariablesGroupAsset this[string name]
        {
            get => m_GroupLookup[name].group;
            set => Add(name, value);
        }

        /// <summary>
        /// Called after the final <see cref="EndUpdating"/> has been called.
        /// This can be used when you wish to respond to value change events but wish to do a
        /// single update at the end instead of 1 per change.
        /// For example, if you wanted to change the value of multiple global variables
        /// that a smart string was using then changing each value would result in a new string
        /// being generated, by using begin and end  the string generation can be deferred until the
        /// final change so that only 1 update is performed.
        /// </summary>
        public static event Action EndUpdate;

        /// <summary>
        /// Creates a new instance and adds the "." operator to the parser.
        /// </summary>
        /// <param name="formatter"></param>
        public PersistentVariablesSource(SmartFormatter formatter)
        {
            formatter.Parser.AddOperators(".");
        }

        /// <summary>
        /// Indicates that multiple <see cref="IVariable"/> will be changed and <see cref="LocalizedString"/> should wait for <see cref="EndUpdate"/> before updating.
        /// See <seealso cref="EndUpdating"/> and <seealso cref="EndUpdate"/>.
        /// Note: <see cref="BeginUpdating"/> and <see cref="EndUpdating"/> can be nested, <see cref="EndUpdate"/> will only be called after the last <see cref="EndUpdate"/>.
        /// </summary>
        public static void BeginUpdating() => s_IsUpdating++;

        /// <summary>
        /// Indicates that updates to <see cref="IVariable"/> have finished and sends the <see cref="EndUpdate"/> event.
        /// Note: <see cref="BeginUpdating"/> and <see cref="EndUpdating"/> can be nested, <see cref="EndUpdate"/> will only be called after the last <see cref="EndUpdate"/>.
        /// </summary>
        public static void EndUpdating()
        {
            s_IsUpdating--;
            if (s_IsUpdating == 0)
            {
                EndUpdate?.Invoke();
            }
            else if (s_IsUpdating < 0)
            {
                Debug.LogWarning($"Incorrect number of Begin and End calls to {nameof(PersistentVariablesSource)}. {nameof(BeginUpdating)} must be called before {nameof(EndUpdating)}.");
                s_IsUpdating = 0;
            }
        }

        /// <summary>
        /// Can be used to create a <see cref="BeginUpdating"/> and <see cref="EndUpdating"/> scope.
        /// </summary>
        /// <returns></returns>
        public static IDisposable UpdateScope()
        {
            BeginUpdating();
            return new ScopedUpdate();
        }

        /// <summary>
        /// Returns <see langword="true"/> if a global variable group could be found with a matching name, or <see langword="false"/> if one could not.
        /// </summary>
        /// <param name="name">The name of the global variable group to find.</param>
        /// <param name="value">The found global variable group or <see langword="null"/> if one could not be found with a matching name.</param>
        /// <returns><see langword="true"/> if a group could be found or <see langword="false"/> if one could not.</returns>
        public bool TryGetValue(string name, out VariablesGroupAsset value)
        {
            if (m_GroupLookup.TryGetValue(name, out var v))
            {
                value = v.group;
                return true;
            }
            value = null;
            return false;
        }

        /// <summary>
        /// Add a global variable group to the source.
        /// </summary>
        /// <param name="name">The name of the group to add.</param>
        /// <param name="group">The group to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="group"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is <see langword="null"/> or empty.</exception>
        public void Add(string name, VariablesGroupAsset group)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name), "Name must not be null or empty.");
            if (group == null)
                throw new ArgumentNullException(nameof(group));
            var pair = new NameValuePair { name = name, group = group };

            name = name.ReplaceWhiteSpaces("-");
            m_GroupLookup[name] = pair;
            m_Groups.Add(pair);
        }

        /// <inheritdoc cref="Add(string, VariablesGroupAsset)"/>
        public void Add(KeyValuePair<string, VariablesGroupAsset> item) => Add(item.Key, item.Value);

        /// <summary>
        /// Removes the group with the matching name.
        /// </summary>
        /// <param name="name">The name of the group to remove.</param>
        /// <returns><see langword="true"/> if a group with a matching name was found and removed, or <see langword="false"/> if one was not.</returns>
        public bool Remove(string name)
        {
            if (m_GroupLookup.TryGetValue(name, out var v))
            {
                m_Groups.Remove(v);
                m_GroupLookup.Remove(name);
                return true;
            }
            return false;
        }

        /// <inheritdoc cref="Remove(string)"/>
        public bool Remove(KeyValuePair<string, VariablesGroupAsset> item) => Remove(item.Key);

        /// <summary>
        /// Removes all global variables.
        /// </summary>
        public void Clear()
        {
            m_GroupLookup.Clear();
            m_Groups.Clear();
        }

        /// <summary>
        /// Returns <see langword="true"/> if a global variable group is found with the same name.
        /// </summary>
        /// <param name="name">The name of the global variable group to check for.</param>
        /// <returns><see langword="true"/> if a group with the name is found or <see langword="false"/> if one is not.</returns>
        public bool ContainsKey(string name) => m_GroupLookup.ContainsKey(name);

        /// <inheritdoc cref="ContainsKey(string)"/>
        public bool Contains(KeyValuePair<string, VariablesGroupAsset> item) => TryGetValue(item.Key, out var v) && v == item.Value;

        /// <summary>
        /// Copy all global variable groups into the provided array starting at <paramref name="arrayIndex"/>.
        /// </summary>
        /// <param name="array">The array to copy the global variables into.</param>
        /// <param name="arrayIndex">The index to start copying into.</param>
        public void CopyTo(KeyValuePair<string, VariablesGroupAsset>[] array, int arrayIndex)
        {
            foreach (var entry in m_GroupLookup)
            {
                array[arrayIndex++] = new KeyValuePair<string, VariablesGroupAsset>(entry.Key, entry.Value.group);
            }
        }

        /// <summary>
        /// Returns an enumerator for all the global variables in the source.
        /// </summary>
        /// <returns></returns>
        IEnumerator<KeyValuePair<string, VariablesGroupAsset>> IEnumerable<KeyValuePair<string, VariablesGroupAsset>>.GetEnumerator()
        {
            foreach (var v in m_GroupLookup)
            {
                yield return new KeyValuePair<string, VariablesGroupAsset>(v.Key, v.Value.group);
            }
        }

        /// <summary>
        /// Returns an enumerator for all the global variables in the source.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var v in m_GroupLookup)
            {
                yield return new KeyValuePair<string, VariablesGroupAsset>(v.Key, v.Value.group);
            }
        }

        /// <inheritdoc/>
        public bool TryEvaluateSelector(ISelectorInfo selectorInfo)
        {
            var selector = selectorInfo.SelectorText;

            // First we test the current value
            if (selectorInfo.CurrentValue is IVariableGroup grp && EvaluateLocalGroup(selectorInfo, grp))
                return true;

            // If we are at the root we also test the local variables
            if (selectorInfo.SelectorOperator == "" && EvaluateLocalGroup(selectorInfo, selectorInfo.FormatDetails.FormatCache?.LocalVariables))
                return true;

            if (TryGetValue(selector, out var group))
            {
                selectorInfo.Result = group;
                return true;
            }

            return false;
        }

        static bool EvaluateLocalGroup(ISelectorInfo selectorInfo, IVariableGroup variablleGroup)
        {
            if (variablleGroup == null)
                return false;

            if (variablleGroup != null && variablleGroup.TryGetValue(selectorInfo.SelectorText, out var variable))
            {
                // Add the variable to the cache
                var cache = selectorInfo.FormatDetails.FormatCache;
                if (cache != null && variable is IVariableValueChanged valueChanged)
                {
                    if (!cache.VariableTriggers.Contains(valueChanged))
                        cache.VariableTriggers.Add(valueChanged);
                }

                selectorInfo.Result = variable.GetSourceValue(selectorInfo);
                return true;
            }

            return false;
        }

        public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
            if (m_GroupLookup == null)
                m_GroupLookup = new Dictionary<string, NameValuePair>();

            m_GroupLookup.Clear();
            foreach (var v in m_Groups)
            {
                if (!string.IsNullOrEmpty(v.name))
                {
                    m_GroupLookup[v.name] = v;
                }
            }
        }
    }
}

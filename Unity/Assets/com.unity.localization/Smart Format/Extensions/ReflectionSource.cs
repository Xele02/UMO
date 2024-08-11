using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Provides the ability to select objects using reflection.
    /// </summary>
    [Serializable]
    public class ReflectionSource : ISource
    {
        static readonly object[] k_Empty = new object[0];

        Dictionary<(Type, string), (FieldInfo field, MethodInfo method)> m_TypeCache;

        Dictionary<(Type, string), (FieldInfo field, MethodInfo method)> TypeCache
        {
            get
            {
                if (m_TypeCache == null)
                    m_TypeCache = new Dictionary<(Type, string), (FieldInfo field, MethodInfo method)>();
                return m_TypeCache;
            }
        }

        /// <summary>
        /// Creates a new instance of the source.
        /// </summary>
        /// <param name="formatter"></param>
        public ReflectionSource(SmartFormatter formatter)
        {
            // Add some special info to the parser:
            formatter.Parser.AddAlphanumericSelectors(); // (A-Z + a-z)
            formatter.Parser.AddAdditionalSelectorChars("_");
            formatter.Parser.AddOperators(".");
        }

        /// <inheritdoc/>
        public bool TryEvaluateSelector(ISelectorInfo selectorInfo)
        {
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

            var current = selectorInfo.CurrentValue;
            var selector = selectorInfo.SelectorText;

            if (current == null) return false;

            // REFLECTION:
            // Let's see if the argSelector is a Selectors/Field/ParseFormat:
            var sourceType = current.GetType();

            // Check the type cache
            if (TypeCache.TryGetValue((sourceType, selector), out var found))
            {
                if (found.field != null)
                {
                    selectorInfo.Result = found.field.GetValue(current);
                    return true;
                }

                if (found.method != null)
                {
                    selectorInfo.Result = found.method.Invoke(current, k_Empty);
                    return true;
                }

                return false;
            }

            // Important:
            // GetMembers (opposite to GetMember!) returns all members,
            // both those defined by the type represented by the current T:System.Type object
            // AS WELL AS those inherited from its base types.
            var members = sourceType.GetMembers(bindingFlags).Where(m =>
                string.Equals(m.Name, selector, selectorInfo.FormatDetails.Settings.GetCaseSensitivityComparison()));
            foreach (var member in members)
                switch (member.MemberType)
                {
                    case MemberTypes.Field:
                        //  Selector is a Field; retrieve the value:
                        var field = (FieldInfo)member;
                        selectorInfo.Result = field.GetValue(current);
                        TypeCache[(sourceType, selector)] = (field, null);
                        return true;
                    case MemberTypes.Property:
                    case MemberTypes.Method:
                        MethodInfo method;
                        if (member.MemberType == MemberTypes.Property)
                        {
                            //  Selector is a Property
                            var prop = (PropertyInfo)member;
                            //  Make sure the property is not WriteOnly:
                            if (prop.CanRead)
                                method = prop.GetGetMethod();
                            else
                                continue;
                        }
                        else
                        {
                            //  Selector is a method
                            method = (MethodInfo)member;
                        }

                        if (method == null) continue;

                        //  Check that this method is valid -- it needs to return a value and has to be parameterless:
                        //  We are only looking for a parameterless Function/Property:
                        if (method.GetParameters().Length > 0) continue;

                        //  Make sure that this method is not void!  It has to be a Function!
                        if (method.ReturnType == typeof(void)) continue;

                        // Add to cache
                        TypeCache[(sourceType, selector)] = (null, method);

                        //  Retrieve the Selectors/ParseFormat value:
                        selectorInfo.Result = method.Invoke(current, k_Empty);
                        return true;
                }

            // We also cache failures so we dont need to call GetMembers again
            TypeCache[(sourceType, selector)] = (null, null);

            return false;
        }
    }
}

using System;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace UnityEngine.Localization.SmartFormat.PersistentVariables
{
    /// <summary>
    /// Base class for all single source variables.
    /// Inhterit from this class for storage for a single serialized source value that will send a value changed event when <see cref="Value"/> is changed.
    /// This will trigger any <see cref="LocalizedString"/> that is currently using the variable to update.
    /// </summary>
    /// <typeparam name="T">The value type to store in this variable.</typeparam>
    [Serializable]
    public partial class Variable<T> : IVariableValueChanged
    #if UNITY_EDITOR
        , ISerializationCallbackReceiver
    #endif
    {
        [SerializeField]
        T m_Value;

        /// <summary>
        /// Called when <see cref="Value"/> is changed.
        /// </summary>
        public event Action<IVariable> ValueChanged;

        /// <summary>
        /// The value for this variable.
        /// Changing this will trigger the <see cref="ValueChanged"/> event.
        /// </summary>
        public T Value
        {
            get => m_Value;
            set
            {
                if (m_Value != null && m_Value.Equals(value))
                    return;

                m_Value = value;
                SendValueChangedEvent();
            }
        }

        /// <inheritdoc/>
        public object GetSourceValue(ISelectorInfo _) => Value;

        void SendValueChangedEvent() => ValueChanged?.Invoke(this);

        public override string ToString() => Value.ToString();

        #if UNITY_EDITOR
        T m_OldValue;

        public void OnBeforeSerialize()
        {
            m_OldValue = m_Value;
        }

        public void OnAfterDeserialize()
        {
            // This lets us send value changed events when the user makes changes through the inspector.
            // If an Undo event occurs we will lose the ValueChanged reference though.
            if (m_OldValue != null && !m_OldValue.Equals(m_Value))
            {
                // We need to defer the event as it may call internal Unity api and this is not allowed from within OnAfterDeserialize.
                UnityEditor.EditorApplication.delayCall += SendValueChangedEvent;
                m_OldValue = m_Value;
            }
        }

        #endif
    }

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single bool value.
    /// </summary>
    [Serializable]
    //[DisplayName("Boolean")]
    public partial class BoolVariable : Variable<bool> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single signed byte value.
    /// </summary>
    [Serializable]
    //[DisplayName("Signed Byte")]
    public partial class SByteVariable : Variable<sbyte> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single byte value.
    /// </summary>
    [Serializable]
    //[DisplayName("Byte")]
    public partial class ByteVariable : Variable<byte> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single short value.
    /// </summary>
    [Serializable]
    //[DisplayName("Short")]
    public partial class ShortVariable : Variable<short> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single unsigned short value.
    /// </summary>
    [Serializable]
    //[DisplayName("Unsigned Short")]
    public partial class UShortVariable : Variable<ushort> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single integer value.
    /// </summary>
    [Serializable]
    //[DisplayName("Integer")]
    public partial class IntVariable : Variable<int> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single unsigned integer value.
    /// </summary>
    [Serializable]
    //[DisplayName("Unsigned Integer")]
    public partial class UIntVariable : Variable<uint> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single long value.
    /// </summary>
    [Serializable]
    //[DisplayName("Long")]
    public partial class LongVariable : Variable<long> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single unsigned long value.
    /// </summary>
    [Serializable]
    //[DisplayName("Unsigned Long")]
    public partial class ULongVariable : Variable<ulong> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single string value.
    /// </summary>
    [Serializable]
    //[DisplayName("String")]
    public partial class StringVariable : Variable<string> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single float value.
    /// </summary>
    [Serializable]
    //[DisplayName("Float")]
    public partial class FloatVariable : Variable<float> {}

    /// <summary>
    /// A <see cref="IVariable"/> that holds a single double value.
    /// </summary>
    [Serializable]
    //[DisplayName("Double")]
    public partial class DoubleVariable : Variable<double> {}

    /// <summary>
    /// A <see cref="IVariable"/> that can reference an <see cref="Object"/> instance.
    /// </summary>
    [Serializable]
    //[DisplayName("Object Reference")]
    public partial class ObjectVariable : Variable<Object> {}
}

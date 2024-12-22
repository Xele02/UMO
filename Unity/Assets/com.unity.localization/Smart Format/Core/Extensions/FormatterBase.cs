namespace UnityEngine.Localization.SmartFormat.Core.Extensions
{
    /// <summary>
    /// Base class that implements common <see cref="IFormatter"/> functionality.
    /// </summary>
    /// <example>
    /// This example shows how to create a formatter to format an integer that represents bytes.
    /// <code source="../../../../DocCodeSamples.Tests/ByteFormatter.cs"/>
    /// </example>
    public abstract class FormatterBase : IFormatter, ISerializationCallbackReceiver
    {
        [SerializeField]
        string[] m_Names;

        /// <inheritdoc/>
        public string[] Names
        {
            get => m_Names;
            set => m_Names = value;
        }

        /// <summary>
        /// Default names to use when <see cref="Names"/> is <see langword="null"/>.
        /// </summary>
        public abstract string[] DefaultNames { get; }

        /// <inheritdoc/>
        public abstract bool TryEvaluateFormat(IFormattingInfo formattingInfo);

        public virtual void OnAfterDeserialize()
        {
            if (Names == null || Names.Length == 0)
            {
                Names = DefaultNames;
            }
        }

        public void OnBeforeSerialize()
        {
        }
    }
}

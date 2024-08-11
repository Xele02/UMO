namespace UnityEngine.Localization.SmartFormat.Core.Extensions
{
    /// <summary>
    /// Evaluates a selector.
    /// </summary>
    public interface ISource
    {
        /// <summary>
        /// Evaluates the <see cref="ISelectorInfo" /> based on the <see cref="ISelectorInfo.CurrentValue" />.
        /// If this extension cannot evaluate the Selector, returns False.
        /// Otherwise, sets the <see cref="ISelectorInfo.Result" /> and returns true.
        /// </summary>
        /// <param name="selectorInfo"></param>
        /// <returns></returns>
        /// <example>
        /// The following example shows how to create a source that generates a random number.
        /// This could then be combined with a <see cref="SmartFormat.Extensions.ChooseFormatter"/> to produce different random responses.
        /// <code source="../../../../DocCodeSamples.Tests/RandomValueSource.cs"/>
        /// </example>
        bool TryEvaluateSelector(ISelectorInfo selectorInfo);
    }
}

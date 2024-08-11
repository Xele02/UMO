namespace UnityEngine.Localization.SmartFormat.Core.Extensions
{
    /// <summary>
    /// Extracts the literal characters from a Format string
    /// </summary>
    public interface IFormatterLiteralExtractor
    {
        /// <summary>
        /// Ignores the format arguments and writes every possible literal value.
        /// This is used to extract all possible values so that we can determine the distinct characters for font generation etc.
        /// </summary>
        /// <param name="formattingInfo"></param>
        void WriteAllLiterals(IFormattingInfo formattingInfo);
    }
}

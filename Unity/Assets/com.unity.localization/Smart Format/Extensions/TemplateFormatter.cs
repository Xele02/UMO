using System;
using System.Collections.Generic;
using System.Linq;
//using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.Core.Parsing;

namespace UnityEngine.Localization.SmartFormat.Extensions
{
    /// <summary>
    /// Template Formatter allows for registering reusable templates, and use them by name.
    /// </summary>
    [Serializable]
    public class TemplateFormatter : FormatterBase
    {
        [Serializable]
        class Template
        {
            public string name;
            public string text;
            public Format Format { get; set; }
        }

        [SerializeField]
        List<Template> m_Templates = new List<Template>();

        IDictionary<string, Format> m_TemplatesDict;

        [NonSerialized]
        SmartFormatter m_Formatter;

        IDictionary<string, Format> Templates
        {
            get
            {
                if (m_TemplatesDict == null)
                {
                    var stringComparer = Formatter.Settings.GetCaseSensitivityComparer();
                    m_TemplatesDict = new Dictionary<string, Format>(stringComparer);

                    foreach (var t in m_Templates)
                    {
                        if (!string.IsNullOrEmpty(t.name))
                        {
                            try
                            {
                                m_TemplatesDict[t.name] = Formatter.Parser.ParseFormat(t.text, Formatter.GetNotEmptyFormatterExtensionNames());
                            }
                            catch (Exception e)
                            {
                                Debug.LogException(e);
                            }
                        }
                    }
                }

                return m_TemplatesDict;
            }
        }

        /// <summary>
        /// The <see cref="SmartFormatter"/> that the formatter is part of.
        /// </summary>
        public SmartFormatter Formatter
        {
            get => m_Formatter ?? RuntimeSettings.CurrentSettings.SmartFormatter;
            set => m_Formatter = value;
        }

        /// <summary>
        /// Creates a new instance of the formatter.
        /// </summary>
        public TemplateFormatter()
        {
            Names = DefaultNames;
        }

        /// <inheritdoc/>
        public override string[] DefaultNames => new[] { "template", "t" };

        /// <summary>
        /// This method is called by the <see cref="SmartFormatter" /> to obtain the formatting result of this extension.
        /// </summary>
        /// <param name="formattingInfo"></param>
        /// <returns>Returns true if successful, else false.</returns>
        public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var templateName = formattingInfo.FormatterOptions;
            if (templateName == string.Empty)
            {
                if (formattingInfo.Format.HasNested) return false;
                templateName = formattingInfo.Format.RawText;
            }

            if (!Templates.TryGetValue(templateName, out var template))
            {
                if (Names.Contains(formattingInfo.Placeholder.FormatterName))
                    throw new FormatException(
                        $"Formatter '{formattingInfo.Placeholder.FormatterName}' found no registered template named '{templateName}'");

                return false;
            }

            formattingInfo.Write(template, formattingInfo.CurrentValue);
            return true;
        }

        /// <summary>
        /// Register a new template.
        /// </summary>
        /// <param name="templateName">A name for the template, which is not already registered.</param>
        /// <param name="template">The string to be used as a template.</param>
        public void Register(string templateName, string template)
        {
            var parsed = Formatter.Parser.ParseFormat(template, Formatter.GetNotEmptyFormatterExtensionNames());
            Templates.Add(templateName, parsed);
        }

        /// <summary>
        /// Remove a template by its name.
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public bool Remove(string templateName)
        {
            return Templates.Remove(templateName);
        }

        public override void OnAfterDeserialize()
        {
            base.OnAfterDeserialize();
            m_TemplatesDict = null;
        }

        /// <summary>
        /// Remove all templates.
        /// </summary>
        public void Clear()
        {
            Templates.Clear();
        }
    }
}

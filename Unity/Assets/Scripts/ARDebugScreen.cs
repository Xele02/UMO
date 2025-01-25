using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

public class ARDebugScreen : MonoBehaviour
{
    public Text m_Text;

    public enum TextType
    {
        Result,
        CameraRotation,
        SensorRotation,
        ScreenRotation,
        EffectorTranform,
        Scale,
        PhysicalScale,
    }

    private Dictionary<TextType, string> m_texts = new Dictionary<TextType, string>();

    private static ARDebugScreen m_Instance;

    public static ARDebugScreen Instance { get { return m_Instance; } }

    public void Awake()
    {
        m_Instance = this;
        gameObject.SetActive(RuntimeSettings.CurrentSettings.EnableARDebugInfo);
    }

    public void AddText(TextType t, string text)
    {
        if(!m_texts.ContainsKey(t))
            m_texts.Add(t, "");
        m_texts[t] = text;
    }

    public void Update()
    {
        m_Text.text = string.Join("\n", m_texts.Values);
    }
}
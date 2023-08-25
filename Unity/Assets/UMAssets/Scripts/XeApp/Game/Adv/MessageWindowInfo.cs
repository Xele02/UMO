using System;
using UnityEngine.UI;
using XeApp.Game;
using UnityEngine;
using System.Collections;

namespace XeApp.Game.Adv
{
	[Serializable]
	public class MessageWindowInfo
	{
		public Text m_name; // 0x8
		public AdvMessageBase m_message; // 0xC
		public ColorTween[] m_windowTween; // 0x10
		public RectTransform m_messageWindow; // 0x14

		//// RVA: 0xE51938 Offset: 0xE51938 VA: 0xE51938
		public void SetName(string name)
		{
			if (m_name != null)
				m_name.text = name;
		}

		//// RVA: 0xE519FC Offset: 0xE519FC VA: 0xE519FC
		//public void StartMessage(string message, float speed, AdvMessageBase.TagConvertFunc func) { }

		//// RVA: 0xE52208 Offset: 0xE52208 VA: 0xE52208
		//public bool IsPlay() { }

		//// RVA: 0xE521D4 Offset: 0xE521D4 VA: 0xE521D4
		//public void Skip() { }

		//// RVA: 0xE521A8 Offset: 0xE521A8 VA: 0xE521A8
		public int GetNotRichTextLength(string message)
		{
			TodoLogger.LogError(0, "GetNotRichTextLength");
			return 0;
		}

		//// RVA: 0xE518E4 Offset: 0xE518E4 VA: 0xE518E4
		public void SetActive(bool isActive)
		{
			m_messageWindow.gameObject.SetActive(isActive);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x74384C Offset: 0x74384C VA: 0x74384C
		//// RVA: 0xE54BC8 Offset: 0xE54BC8 VA: 0xE54BC8
		public IEnumerator Co_Show()
		{
			//0xE58FA0
			m_message.StartMessage("", 0, null);
			for(int i = 0; i < m_windowTween.Length; i++)
			{
				m_windowTween[i].ResetTime();
			}
			do
			{
				for (int i = 0; i < m_windowTween.Length; i++)
				{
					m_windowTween[i].UpdateCurve();
				}
				yield return null;
			} while (!m_windowTween[0].IsEnd());
		}

		//// RVA: 0xE58E24 Offset: 0xE58E24 VA: 0xE58E24
		public void Hide()
		{
			for(int i = 0; i < m_windowTween.Length; i++)
			{
				m_windowTween[i].ResetTime();
				m_windowTween[i].UpdateValue();
			}
		}
	}
}

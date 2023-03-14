using System.Collections;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Adv
{
	public class AdvMessage : AdvMessageBase
	{
		private bool m_is_play; // 0x1C
		private IEnumerator coroutine; // 0x20
		private float m_message_spd = 0.2f; // 0x24

		//// RVA: 0xE54CEC Offset: 0xE54CEC VA: 0xE54CEC Slot: 6
		public override bool IsPlay()
		{
			return m_is_play;
		}

		//// RVA: 0xE54CF4 Offset: 0xE54CF4 VA: 0xE54CF4 Slot: 4
		public override void Skip()
		{
			if(m_is_play)
			{
				this.StopCoroutineWatched(coroutine);
			}
			m_is_play = false;
			Text.text = m_message.ToString();
		}

		//// RVA: 0xE54E5C Offset: 0xE54E5C VA: 0xE54E5C Slot: 5
		public override void StartMessage(string message, float message_spd, TagConvertFunc func)
		{
			m_message_spd = message_spd;
			if(message.Length > 0)
			{
				coroutine = UpdateMessage(message, func);
				this.StartCoroutineWatched(coroutine);
			}
			else
			{
				Text.text = "";
				m_is_play = false;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x743914 Offset: 0x743914 VA: 0x743914
		//// RVA: 0xE54F58 Offset: 0xE54F58 VA: 0xE54F58
		private IEnumerator UpdateMessage(string message, TagConvertFunc func)
		{
			int message_length; // 0x1C
			int current_count; // 0x20
			float time; // 0x24

			//0xE550F8
			m_is_play = true;
			m_message.Clear();
			m_message.Append(message);
			ConvertMessage(m_message, func);
			message_length = GetNotRichTextLength(m_message);
			Text.text = "";
			time = 0;
			current_count = 0;
			do
			{
				time += TimeWrapper.deltaTime;
				float f = Mathf.Clamp01(time / m_message_spd);
				if (f >= 1)
				{
					current_count++;
					string str = ConvartTextStrCount(m_message, current_count);
					Text.text = str;
					time = 0;
				}
				if (current_count <= message_length)
					yield return null;
				else
					break;
			} while (true);
			m_is_play = false;
		}
	}
}

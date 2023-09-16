using System.Collections;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Adv
{
	public class AdvFadeMessage : AdvMessageBase
	{
		private float m_message_spd = 0.2f; // 0x1C
		private bool m_is_play; // 0x20
		private IEnumerator m_messCoroutine; // 0x24

		// RVA: 0xBC4870 Offset: 0xBC4870 VA: 0xBC4870 Slot: 4
		public override void Skip()
		{
			if(m_is_play)
			{
				this.StopCoroutineWatched(m_messCoroutine);
				m_messCoroutine = null;
			}
			m_is_play = false;
			Text.color = new Color(1, 1, 1, 1);
		}

		// RVA: 0xBC491C Offset: 0xBC491C VA: 0xBC491C Slot: 6
		public override bool IsPlay()
		{
			return m_is_play;
		}

		// RVA: 0xBC4924 Offset: 0xBC4924 VA: 0xBC4924 Slot: 5
		public override void StartMessage(string message, float message_spd, TagConvertFunc func)
		{
			m_message_spd = message_spd;
			if(message.Length < 1)
			{
				Text.text = "";
				m_is_play = false;
			}
			else
			{
				m_message.Clear();
				m_message.Append(message);
				ConvertMessage(m_message, func);
				Text.text = m_message.ToString();
				m_messCoroutine = UpdateMessage();
				this.StartCoroutineWatched(m_messCoroutine);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x74250C Offset: 0x74250C VA: 0x74250C
		//// RVA: 0xBC4AD8 Offset: 0xBC4AD8 VA: 0xBC4AD8
		private IEnumerator UpdateMessage()
		{
			Color baseColor; // 0x14
			float time; // 0x24

			//0xBC4B9C
			m_is_play = true;
			baseColor = Text.color;
			Color col = baseColor;
			col.a = 0;
			Text.color = col;
			time = 0;
			do
			{
				yield return null;
				time += TimeWrapper.deltaTime;
				col.a = Mathf.Clamp01(time / m_message_spd);
				Text.color = col;
			} while (col.a < 1);
			m_is_play = false;
		}
	}
}

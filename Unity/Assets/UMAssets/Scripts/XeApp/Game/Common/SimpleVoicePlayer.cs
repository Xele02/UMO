using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class SimpleVoicePlayer : VoicePlayerBase
	{
		public class VoiceSetting
		{
			public string m_queName = ""; // 0x8
			public string m_queFormat = ""; // 0xC
			public int m_randomNum = -1; // 0x10
			public int m_randomStart; // 0x14
			public float m_delayTime; // 0x18
		}

		public bool m_isStop; // 0x20

		//// RVA: 0x139363C Offset: 0x139363C VA: 0x139363C
		public int PlayVoiceRandom(VoiceSetting setting, int exclusionId = -1)
		{
			int num = setting.m_randomNum;
			if(num != -1)
			{
				num = UnityEngine.Random.Range(setting.m_randomStart, num);
			}
			if(exclusionId > -1)
			{
				List<int> l = new List<int>();
				for(int i = 0; i < setting.m_randomNum - setting.m_randomStart; i++)
				{
					if(setting.m_randomStart - exclusionId + i != 0)
					{
						l.Add(setting.m_randomStart + i);
					}
				}
				if(l.Count > 0)
				{
					num = l[UnityEngine.Random.Range(0, l.Count)];
				}
			}
			PlayVoice(setting, num);
			return num;
		}

		//// RVA: 0x1393838 Offset: 0x1393838 VA: 0x1393838
		public void PlayVoice(VoiceSetting setting, int id)
		{
			m_isStop = false;
			StringBuilder str = new StringBuilder();
			if (id == -1)
				str.SetFormat(setting.m_queFormat, Array.Empty<object>());
			else
				str.SetFormat(setting.m_queFormat, id);
			setting.m_queName = str.ToString();
			this.StartCoroutineWatched(Co_DivaVoiceDelayedPlay(setting));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x737910 Offset: 0x737910 VA: 0x737910
		//// RVA: 0x1393978 Offset: 0x1393978 VA: 0x1393978
		public IEnumerator Co_DivaVoiceDelayedPlay(VoiceSetting setting)
		{
			float time;

			//0x1393A90
			time = 0;
			while(time <= setting.m_delayTime)
			{
				time += Time.deltaTime;
				yield return null;
			}
			if (!m_isStop)
				PlayCue(setting.m_queName);
		}

		//// RVA: 0x1393A40 Offset: 0x1393A40 VA: 0x1393A40
		public void StopVoice()
		{
			m_isStop = true;
			source.Stop();
		}
	}
}

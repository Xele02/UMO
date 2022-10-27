using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RNoteLaneManager
	{
		public delegate void LineAlphaCallback(int lineNo, float alpha);

		private class KeyData
		{
			public float m_alpha; // 0x8
			public int m_milliSec; // 0xC

			// RVA: 0xDAA16C Offset: 0xDAA16C VA: 0xDAA16C
			public KeyData(float alpha, int milliSec)
			{
				m_alpha = alpha;
				m_milliSec = milliSec;
			}
		}

		private const int FadeMilliSec = 100;
		private const int AppearMilliSec = 0;
		private List<List<KeyData>> m_keyDataList; // 0x8
		private LineAlphaCallback m_lineAlphaCallback; // 0xC

		//// RVA: 0xDA98E4 Offset: 0xDA98E4 VA: 0xDA98E4
		//public void SetLineAlphaCallback(RNoteLaneManager.LineAlphaCallback callback) { }

		//// RVA: 0xDA98EC Offset: 0xDA98EC VA: 0xDA98EC
		public void Initialize(List<RNote> noteList)
		{
			m_keyDataList = new List<List<KeyData>>(RhythmGameConsts.LineNum);
			KeyData k1 = new KeyData(1, 0);
			KeyData k2 = new KeyData(0, 0);
			for(int i = 0; i < RhythmGameConsts.LineNum; i++)
			{
				List<KeyData> l = new List<KeyData>();
				l.Add(RhythmGameConsts.IsWingLine(i) ? k2 : k1);
				m_keyDataList.Add(l);
			}
			for(int i = 0; i < noteList.Count; i++)
			{
				if(noteList[i].noteInfo.isWing)
				{
					if(RhythmGameConsts.IsWingLine(noteList[i].noteInfo.trackID))
					{
						KeyData k3 = new KeyData(1.0f, noteList[i].noteInfo.time);
						m_keyDataList[noteList[i].noteInfo.trackID].Add(k3);
						k3 = new KeyData(0.0f, noteList[i].noteInfo.time + 100);
						m_keyDataList[noteList[i].noteInfo.trackID].Add(k3);
					}
					else
					{
						KeyData k3 = new KeyData(0.0f, noteList[i].noteInfo.time);
						m_keyDataList[noteList[i].noteInfo.wingTrackID].Add(k3);
						k3 = new KeyData(1.0f, noteList[i].noteInfo.time + 100);
						m_keyDataList[noteList[i].noteInfo.wingTrackID].Add(k3);
					}
				}
			}
			for(int i = 0; i < m_keyDataList.Count; i++)
			{
				if(m_keyDataList[i].Count > 1)
				{
					KeyData k3 = new KeyData(m_keyDataList[i][m_keyDataList[i].Count - 1].m_alpha, 0x7fffffff);
					m_keyDataList[i].Add(k3);
				}
			}
		}

		//// RVA: 0xDAA194 Offset: 0xDAA194 VA: 0xDAA194
		//public void Update(int musicMilliSec) { }
	}
}

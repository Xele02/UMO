using System.Collections.Generic;

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
			//public void .ctor(float alpha, int milliSec) { }
		}

		private const int FadeMilliSec = 100;
		private const int AppearMilliSec = 0;
		private List<List<RNoteLaneManager.KeyData>> m_keyDataList; // 0x8
		private RNoteLaneManager.LineAlphaCallback m_lineAlphaCallback; // 0xC

		//// RVA: 0xDA98E4 Offset: 0xDA98E4 VA: 0xDA98E4
		//public void SetLineAlphaCallback(RNoteLaneManager.LineAlphaCallback callback) { }

		//// RVA: 0xDA98EC Offset: 0xDA98EC VA: 0xDA98EC
		//public void Initialize(List<RNote> noteList) { }

		//// RVA: 0xDAA194 Offset: 0xDAA194 VA: 0xDAA194
		//public void Update(int musicMilliSec) { }
	}
}

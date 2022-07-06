using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfoSLive : MonoBehaviour
	{
		public enum ModeType
		{
			Simulation = 0,
			Prism = 1,
		}

		public delegate void EventOnClickItem(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber);

		// [TooltipAttribute] // RVA: 0x6846D8 Offset: 0x6846D8 VA: 0x6846D8
		[SerializeField]
		private UGUIEnterLeave m_animeControl; // 0xC
		// [TooltipAttribute] // RVA: 0x684720 Offset: 0x684720 VA: 0x684720
		[SerializeField]
		private List<SetDeckDivaCardControl> m_divas; // 0x10
		// [TooltipAttribute] // RVA: 0x684770 Offset: 0x684770 VA: 0x684770
		[SerializeField]
		private List<SetDeckDivaCardControl> m_additionDivas; // 0x14
		public SetDeckUnitInfoSLive.EventOnClickItem OnClickItem; // 0x18
		// private List<FFHPBEPOMAK> m_divaDatas = new List<FFHPBEPOMAK>(); // 0x1C

		// public UGUIEnterLeave AnimeControl { get; } 0xC36818

		// // RVA: 0xC36820 Offset: 0xC36820 VA: 0xC36820
		private void Awake()
		{
			int cnt = 0;
			foreach(SetDeckDivaCardControl diva in m_divas)
			{
				diva.OnClickDivaButton = () =>
				{
					//0xC37D58
					if (OnClickItem != null)
						OnClickItem(PopupMvModeSelectListContent.SelectTarget.Diva, cnt);
				};
				diva.OnClickCostumeButton = () =>
				{
					//0xC37D94
					OnClickCostumeButton(cnt);
				};
				cnt++;
			}
			foreach (SetDeckDivaCardControl diva in m_additionDivas)
			{
				diva.OnClickDivaButton = () =>
				{
					//0xC37DC4
					OnClickDivaButton(cnt);
				};
				diva.OnClickCostumeButton = () =>
				{
					//0xC37E00
					OnClickCostumeButton(cnt);
				};
				cnt++;
			}
		}

		// // RVA: 0xC36D44 Offset: 0xC36D44 VA: 0xC36D44
		// public void UpdateContent(AOJGDNFAIJL.AMIECPBIALP prismData, GameSetupData.MusicInfo musicInfo) { }

		// // RVA: 0xC37444 Offset: 0xC37444 VA: 0xC37444
		// public bool IsUpdatingContent() { }

		// // RVA: 0xC3739C Offset: 0xC3739C VA: 0xC3739C
		// private SetDeckDivaCardControl GetDivaControlBySlotNumber(int divaSlotNumber) { }

		// // RVA: 0xC377D8 Offset: 0xC377D8 VA: 0xC377D8
		private void OnClickDivaButton(int divaSlotNumber)
		{
			if (OnClickItem != null)
				OnClickItem(PopupMvModeSelectListContent.SelectTarget.Diva, divaSlotNumber);
		}

		// // RVA: 0xC37C74 Offset: 0xC37C74 VA: 0xC37C74
		private void OnClickCostumeButton(int divaSlotNumber)
		{
			UnityEngine.Debug.LogError("TODO OnClickCostumeButton");
		}
	}
}

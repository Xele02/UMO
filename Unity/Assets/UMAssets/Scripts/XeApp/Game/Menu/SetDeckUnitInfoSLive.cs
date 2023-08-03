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
		private List<FFHPBEPOMAK_DivaInfo> m_divaDatas = new List<FFHPBEPOMAK_DivaInfo>(); // 0x1C

		public UGUIEnterLeave AnimeControl { get { return m_animeControl; } } //0xC36818

		// // RVA: 0xC36820 Offset: 0xC36820 VA: 0xC36820
		private void Awake()
		{
			int cnt = 0;
			foreach(SetDeckDivaCardControl diva in m_divas)
			{
				int slot = cnt;
				diva.OnClickDivaButton = () =>
				{
					//0xC37D58
					OnClickDivaButton(slot);
				};
				diva.OnClickCostumeButton = () =>
				{
					//0xC37D94
					OnClickCostumeButton(slot);
				};
				cnt++;
			}
			foreach (SetDeckDivaCardControl diva in m_additionDivas)
			{
				int slot = cnt;
				diva.OnClickDivaButton = () =>
				{
					//0xC37DC4
					OnClickDivaButton(slot);
				};
				diva.OnClickCostumeButton = () =>
				{
					//0xC37E00
					OnClickCostumeButton(slot);
				};
				cnt++;
			}
		}

		// // RVA: 0xC36D44 Offset: 0xC36D44 VA: 0xC36D44
		public void UpdateContent(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData, GameSetupData.MusicInfo musicInfo)
		{
			int maxDiva = Mathf.Max(m_divas.Count + m_additionDivas.Count, 5);
			int numDiva = Mathf.Clamp(musicInfo.onStageDivaNum, 1, 5);
			for(int i = m_divaDatas.Count; i < maxDiva; i++)
			{
				m_divaDatas.Add(new FFHPBEPOMAK_DivaInfo());
			}
			for(int i = 0; i < numDiva; i++)
			{
				FFHPBEPOMAK_DivaInfo divaData = null;
				if (prismData.PNBKLGKCKGO_GetPrismDivaIdForSlot(i) > 0)
				{
					m_divaDatas[i].KHEKNNFCAOI(prismData.PNBKLGKCKGO_GetPrismDivaIdForSlot(i), 0, prismData.OCNHIHMAGMJ_GetPrismCostumeIdForSlot(i), prismData.DOIGAGAAAOP_GetPrismCostumeColorIdForSlot(i), null, null, false);
					divaData = m_divaDatas[i];
				}
				GetDivaControlBySlotNumber(i).SetForPrism(divaData);
				GetDivaControlBySlotNumber(i).SetImp(SetDeckDivaCardControl.ImpType.Off);
				GetDivaControlBySlotNumber(i).DivaButton.Disable = false;
			}
			for(int i = numDiva; i < maxDiva; i++)
			{
				GetDivaControlBySlotNumber(i).SetForPrism(null);
				GetDivaControlBySlotNumber(i).SetImp(SetDeckDivaCardControl.ImpType.Prism);
				GetDivaControlBySlotNumber(i).DivaButton.Disable = true;
			}
			foreach(var d in m_divas)
			{
				d.SetShowMultiIcon(false);
			}
			foreach(var d in m_additionDivas)
			{
				d.SetShowMultiIcon(false);
			}
		}

		// // RVA: 0xC37444 Offset: 0xC37444 VA: 0xC37444
		public bool IsUpdatingContent()
		{
			foreach(SetDeckDivaCardControl d in m_divas)
			{
				if(d != null)
				{
					if (d.IsLoading)
						return true;
				}
			}
			foreach(SetDeckDivaCardControl d in m_additionDivas)
			{
				if(d != null)
				{
					if(d.IsLoading)
						return true;
				}
			}
			return false;
		}

		// // RVA: 0xC3739C Offset: 0xC3739C VA: 0xC3739C
		private SetDeckDivaCardControl GetDivaControlBySlotNumber(int divaSlotNumber)
		{
			if(divaSlotNumber < 3)
				return m_divas[divaSlotNumber];
			return m_additionDivas[divaSlotNumber - 3];
		}

		// // RVA: 0xC377D8 Offset: 0xC377D8 VA: 0xC377D8
		private void OnClickDivaButton(int divaSlotNumber)
		{
			if (OnClickItem != null)
				OnClickItem(PopupMvModeSelectListContent.SelectTarget.Diva, divaSlotNumber);
		}

		// // RVA: 0xC37C74 Offset: 0xC37C74 VA: 0xC37C74
		private void OnClickCostumeButton(int divaSlotNumber)
		{
			FFHPBEPOMAK_DivaInfo divaData = GetDivaControlBySlotNumber(divaSlotNumber).DivaData;
			if(divaData != null && OnClickItem != null)
			{
				OnClickItem(PopupMvModeSelectListContent.SelectTarget.Costume, divaSlotNumber);
			}
		}
	}
}

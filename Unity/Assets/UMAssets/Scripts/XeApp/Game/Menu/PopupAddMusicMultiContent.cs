using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAddMusicMultiContent : UIBehaviour, IPopupContent
	{
		private Transform parent; // 0xC
		private LayoutPopAddMusicMulti popupLayout; // 0x10
		private List<PopupUnlock.UnlockParam> unlockList; // 0x14

		public Transform Parent { get { return parent; } } //0x133160C

		// RVA: 0x1330F3C Offset: 0x1330F3C VA: 0x1330F3C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupAddMusicMultiSetting psetting = setting as PopupAddMusicMultiSetting;
			parent = setting.m_parent;
			unlockList = psetting.UnlockInfo.paramList;
			popupLayout = setting.Content.GetComponent<LayoutPopAddMusicMulti>();
			popupLayout.SetUpdateFunc(ListUpdateFunc);
			popupLayout.SetItemCount(unlockList.Count);
			popupLayout.VisibleRegionUpdate();
		}

		//// RVA: 0x1331134 Offset: 0x1331134 VA: 0x1331134
		private void ListUpdateFunc(int index, SwapScrollListContent content)
		{
			LayoutPopAddMusicListItem lcontent = content as LayoutPopAddMusicListItem;
			PopupUnlock.UnlockParam param = unlockList[index];
			EONOEHOKBEB_Music mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(param.id);
			lcontent.SetJacket(mData.JNCPEGJGHOG_Cov);
			lcontent.SetLogo(mData.EMIKBGHIOMN_SerieLogoId);
			lcontent.SetMusicAttribute(mData.FKDCCLPGKDK_Ma);
			lcontent.SetMusicName(Database.Instance.musicText.Get(mData.KNMGEEFGDNI_Nam).musicName, mData.FKDCCLPGKDK_Ma);
			if (param.unlockType == PopupUnlock.eUnlockType.Line6Music)
			{
				lcontent.SetDifficulty(param.difficulty6LineBit, param.isLine6);
				return;
			}
			if (param.unlockType != PopupUnlock.eUnlockType.MultiDivaMusic)
				return;
			lcontent.SetMultiUnit(mData.PECMGDOMLAF_DivaMulti);
		}

		// RVA: 0x13314C8 Offset: 0x13314C8 VA: 0x13314C8 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x13314D0 Offset: 0x13314D0 VA: 0x13314D0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1331508 Offset: 0x1331508 VA: 0x1331508 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1331540 Offset: 0x1331540 VA: 0x1331540 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x13315E0 Offset: 0x13315E0 VA: 0x13315E0 Slot: 22
		public void CallOpenEnd()
		{
			popupLayout.Show();
		}
	}
}

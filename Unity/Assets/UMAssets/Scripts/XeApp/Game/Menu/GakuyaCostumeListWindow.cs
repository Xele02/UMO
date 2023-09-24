using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GakuyaCostumeListWindow : MonoBehaviour
	{ 
		public class ItemInfo
		{
			// Fields
			public int m_index; // 0x8
			public int m_cosId; // 0xC
			public int m_cosModelId; // 0x10
			public int m_cosColor; // 0x14
			public int m_lvMax; // 0x18
			public int m_lv; // 0x1C
			public bool m_isHave; // 0x20
			public bool m_isNew; // 0x21
			public bool m_isSet; // 0x22
			public bool m_isTry; // 0x23
			public string m_name; // 0x24
			public string m_nameBase; // 0x28
			public FFHPBEPOMAK_DivaInfo m_viewDiva; // 0x2C
			public ItemInfo m_srcItem; // 0x30
		}

		[SerializeField]
		private UGUISwapScrollList m_scrollList; // 0xC
		public Action<int> OnClickItemCallback; // 0x10
		private bool m_isSetup; // 0x14
		private int m_divaId; // 0x18
		private int m_indexTry; // 0x1C
		private bool m_isTaped; // 0x20
		private List<ItemInfo> m_itemList = new List<ItemInfo>(); // 0x24

		public ItemInfo CurrentItem { get { return m_itemList[m_indexTry]; } } //0xB6DAE4
		public int ItemCount { get { return m_itemList.Count; } } //0xB6DB64
		public bool IsTaped { get { return m_isTaped; } } //0xB6D89C

		//// RVA: 0xB6DBDC Offset: 0xB6DBDC VA: 0xB6DBDC
		public ItemInfo GetItem(int index)
		{
			if (index > -1 && index < ItemCount)
				return m_itemList[index];
			return null;
		}

		// RVA: 0xB6DC80 Offset: 0xB6DC80 VA: 0xB6DC80
		public void Setup(GameObject content)
		{
			if(!m_isSetup)
			{
				content.name += "_00";
				m_scrollList.AddScrollObject(content.GetComponentInChildren<SwapScrollListContent>());
				GakuyaCostumeListContent g = content.GetComponentInChildren<GakuyaCostumeListContent>();
				g.OnClickCallback = OnClickItem;
				g.SetParent(this);
				for(int i = 1; i < m_scrollList.RowCount; i++)
				{
					GameObject g2 = Instantiate(content);
					g2.name = content.name.Replace("_00", i.ToString("D2"));
					m_scrollList.AddScrollObject(g2.GetComponentInChildren<SwapScrollListContent>());
					GakuyaCostumeListContent g3 = g2.GetComponentInChildren<GakuyaCostumeListContent>();
					g3.OnClickCallback = OnClickItem;
					g3.SetParent(this);
				}
				m_scrollList.SetContentEscapeMode(true);
				m_scrollList.OnUpdateItem.AddListener(OnUpdateList);
				m_scrollList.Apply();
				m_isSetup = true;
			}
		}

		//// RVA: 0xB6E190 Offset: 0xB6E190 VA: 0xB6E190
		public void SetScrollTop()
		{
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
			m_scrollList.ResetScrollVelocity();
		}

		//// RVA: 0xB6E21C Offset: 0xB6E21C VA: 0xB6E21C
		public void SetItems(int divaId, int modelId = 0, int colorId = 0, bool debugAllOpen = false)
		{
			m_divaId = divaId;
			m_indexTry = 0;
			FFHPBEPOMAK_DivaInfo d = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[m_divaId - 1];
			List<ItemInfo> l = new List<ItemInfo>();
			List<ItemInfo> l3 = new List<ItemInfo>();
			List<FFHPBEPOMAK_DivaInfo> l2 = FFHPBEPOMAK_DivaInfo.DNAIGDHCILM_GetCostumeList(divaId, debugAllOpen);
			foreach(var k in l2)
			{
				ItemInfo info = new ItemInfo();
				info.m_index = 0;
				info.m_viewDiva = k;
				info.m_name = k.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(0);
				info.m_nameBase = k.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(0);
				info.m_cosId = k.FFKMJNHFFFL_Costume.JPIDIENBGKH_CostumeId;
				info.m_cosModelId = k.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
				info.m_cosColor = 0;
				info.m_lv = k.FFKMJNHFFFL_Costume.GKIKAABHAAD_Level;
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(divaId, info.m_cosId);
				info.m_lvMax = dbCos.LLLCMHENKKN_LevelMax;
				info.m_isHave = k.JLKPGDEKPEO_IsHave;
				info.m_isNew = k.MBFADDHOEOK_IsNew;
				info.m_isTry = CheckIsSetCostume(d, k.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, info.m_cosColor);
				info.m_isSet = info.m_isTry;
				if(modelId > 0)
				{
					info.m_isTry = k.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId == modelId && info.m_cosColor == colorId;
				}
				info.m_srcItem = null;
				if(!info.m_isSet)
				{
					if (!info.m_isHave)
						l3.Add(info);
					else
						l.Add(info);
				}
				else
				{
					l.Insert(0, info);
				}
				short[] allCols = dbCos.CHDBGFLFPNC_GetAllAvaiableColors();
				short[] unlockCols = dbCos.KKLPLPGBOFD_GetAvaiableColor(k.FFKMJNHFFFL_Costume.GKIKAABHAAD_Level);
				for(int i = 0; i < allCols.Length; i++)
				{
					ItemInfo info2 = new ItemInfo();
					info2.m_index = 0;
					info2.m_viewDiva = k;
					info2.m_name = k.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(allCols[i]);
					info2.m_nameBase = k.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(0);
					info2.m_cosId = k.FFKMJNHFFFL_Costume.JPIDIENBGKH_CostumeId;
					info2.m_cosModelId = k.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
					info2.m_cosColor = allCols[i];
					info2.m_lv = k.FFKMJNHFFFL_Costume.GKIKAABHAAD_Level;
					info2.m_lvMax = dbCos.LLLCMHENKKN_LevelMax;
					info2.m_isHave = k.JLKPGDEKPEO_IsHave;
					info2.m_isTry = CheckIsSetCostume(d, k.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, info2.m_cosColor);
					info2.m_isSet = info2.m_isTry;
					if(modelId > 0)
					{
						info2.m_isTry = k.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId == modelId && info2.m_cosColor == colorId;
					}
					info2.m_srcItem = info;
					info2.m_isHave = false;
					for(int j = 0; j < unlockCols.Length; j++)
					{
						if (info2.m_cosColor == unlockCols[j])
						{
							info2.m_isHave = true;
							if (k.FFKMJNHFFFL_Costume.EJODLFBKFDK_ColNewflags.Length == 0)
								info2.m_isNew = false;
							else
								info2.m_isNew = k.FFKMJNHFFFL_Costume.EJODLFBKFDK_ColNewflags[j];
							break;
						}
					}
					if(!info2.m_isSet)
					{
						if(!info2.m_isHave)
						{
							l3.Add(info);
						}
						else
						{
							l.Add(info);
						}
					}
					else
					{
						l.Insert(0, info);
					}
				}
			}
			m_itemList.Clear();
			m_itemList.AddRange(l);
			m_itemList.AddRange(l3);
			for(int i = 0; i < m_itemList.Count; i++)
			{
				m_itemList[i].m_index = i;
			}
			m_isTaped = false;
			foreach(var k in m_itemList)
			{
				if (!k.m_isTry)
					m_isTaped = true;
			}
			m_scrollList.SetItemCount(m_itemList.Count);
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0xB6F0DC Offset: 0xB6F0DC VA: 0xB6F0DC
		private bool CheckIsSetCostume(FFHPBEPOMAK_DivaInfo divaData, int modelId, int colorId)
		{
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId == 0)
			{
				if (GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId == divaData.AHHJLDLAPAN_DivaId)
				{
					if (divaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId != modelId)
						return false;
					return divaData.EKFONBFDAAP_ColorId == colorId;
				}
			}
			if (divaData.EGAFMGDFFCH_HomeDivaCostume.DAJGPBLEEOB_PrismCostumeId != modelId)
				return false;
			return divaData.JFFLFIMIMOI_HomeColorId == colorId;
		}

		//// RVA: 0xB6F360 Offset: 0xB6F360 VA: 0xB6F360
		public void SetTryIndex(int index)
		{
			if(index < ItemCount)
			{
				foreach(var item in m_itemList)
				{
					item.m_isTry = false;
				}
				m_itemList[index].m_isTry = true;
				if (!m_itemList[index].m_isSet)
					m_isTaped = true;
				m_scrollList.VisibleRegionUpdate();
			}
		}

		//// RVA: 0xB6F58C Offset: 0xB6F58C VA: 0xB6F58C
		public void SetInputEnable()
		{
			SetInput(true);
		}

		//// RVA: 0xB6F854 Offset: 0xB6F854 VA: 0xB6F854
		public void SetInputDisable()
		{
			SetInput(false);
		}

		//// RVA: 0xB6F594 Offset: 0xB6F594 VA: 0xB6F594
		private void SetInput(bool enable)
		{
			ScrollRect[] srs = GetComponentsInChildren<ScrollRect>();
			for(int i = 0; i < srs.Length; i++)
			{
				srs[i].enabled = true;
				if (srs[i].verticalScrollbar != null)
					srs[i].verticalScrollbar.interactable = enable;
				if (srs[i].horizontalScrollbar != null)
					srs[i].horizontalScrollbar.interactable = enable;
			}
			ButtonBase[] btns = GetComponentsInChildren<ButtonBase>();
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].IsInputOff = !enable;
			}
		}

		//// RVA: 0xB6F85C Offset: 0xB6F85C VA: 0xB6F85C
		private void OnUpdateList(int index, SwapScrollListContent content)
		{
			GakuyaCostumeListContent c = content as GakuyaCostumeListContent;
			if (c != null)
				c.SetItem(m_divaId, GetItem(index));
		}

		//// RVA: 0xB6F970 Offset: 0xB6F970 VA: 0xB6F970
		private void OnClickItem(int index)
		{
			ItemInfo item = GetItem(index);
			Debug.Log(string.Format(JpStringLiterals.StringLiteral_16155, index, item.m_name));
			if (item.m_isHave)
				m_isTaped = true;
			if (OnClickItemCallback != null)
				OnClickItemCallback(index);
		}
	}
}

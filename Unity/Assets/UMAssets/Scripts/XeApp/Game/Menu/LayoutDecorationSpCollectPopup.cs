using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSpCollectPopup : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_pop_m_02_layout_root"; // 0x0
		private const int LvNoMaxAnimFrame = 0;
		private const int LvMaxAnimFrame = 1;
		private const int ExistNextAnimFrame = 1;
		private const int NoExistNextAnimFrame = 0;
		private const int NoneAnimFrame = 2;
		[SerializeField]
		private Text m_restTimeText; // 0x14
		[SerializeField]
		private Text m_lvText; // 0x18
		[SerializeField]
		private Text m_nextLvText; // 0x1C
		[SerializeField]
		private Text m_collectTimeText; // 0x20
		[SerializeField]
		private Text m_collectNextTimeText; // 0x24
		[SerializeField]
		private Text m_collectItemText; // 0x28
		[SerializeField]
		private Text m_collectNextItemText; // 0x2C
		[SerializeField]
		private Text m_lvUpRestItemNumText; // 0x30
		[SerializeField]
		private RawImageEx m_itemImage; // 0x34
		private AbsoluteLayout m_lvTbl; // 0x38
		private AbsoluteLayout m_timeTbl; // 0x3C
		private AbsoluteLayout m_itemTbl; // 0x40
		private AbsoluteLayout m_collectTimeTbl; // 0x44
		private AbsoluteLayout m_receiveTbl; // 0x48
		private bool m_isLoadedTexture; // 0x4C

		// RVA: 0x18B9B18 Offset: 0x18B9B18 VA: 0x18B9B18 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_lvTbl = layout.FindViewById("swtbl_pop_02_item_lv") as AbsoluteLayout;
			m_timeTbl = layout.FindViewById("swtbl_pop_02_item_time") as AbsoluteLayout;
			m_itemTbl = layout.FindViewById("swtbl_pop_02_item_cl") as AbsoluteLayout;
			m_collectTimeTbl = layout.FindViewByExId("swtbl_pop_02_item_time_time_frm") as AbsoluteLayout;
			m_receiveTbl = layout.FindViewByExId("swtbl_pop_02_item_cl_cl_frm") as AbsoluteLayout;
			return true;
		}

		// // RVA: 0x18B9DC4 Offset: 0x18B9DC4 VA: 0x18B9DC4
		public void Setting(DecorationSpCollectInfo info)
		{
			LoadItem(info.itemId);
			m_restTimeText.text = info.restTime;
			SetLv(info.lv, info.lvNext, info.lvMax, info.isAvailableLevelup);
			SetTime(info.nowTime, info.nextTime, info.lv == info.lvNext, info.isDiffrentTime, info.isAvailableLevelup);
			SetItem(info.nowPoint, info.nextPoint, info.lv == info.lvNext, info.isDiffrentPoint, info.isCannon, info.isAvailableLevelup);
			SetLvUpRestItemNum(info.lvUpRestItemNum, info.lv == info.lvNext, info.isReceivable, info.isAvailableLevelup);
			m_receiveTbl.StartChildrenAnimGoStop(info.isCannon ? "02" : "01");
			m_collectTimeTbl.StartChildrenAnimGoStop(info.isCannon ? "02" : "01");
		}

		// // RVA: 0x18BA4FC Offset: 0x18BA4FC VA: 0x18BA4FC
		public bool IsLoading()
		{
			return !m_isLoadedTexture;
		}

		// // RVA: 0x18BA510 Offset: 0x18BA510 VA: 0x18BA510
		// public bool IsPlayingEnd() { }

		// // RVA: 0x18B9FB4 Offset: 0x18B9FB4 VA: 0x18B9FB4
		private void LoadItem(int itemId)
		{
			m_isLoadedTexture = false;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x18BA5FC
				texture.Set(m_itemImage);
				m_isLoadedTexture = true;
			});
		}

		// // RVA: 0x18BA518 Offset: 0x18BA518 VA: 0x18BA518
		// private int GetLvTblFrame(int currentLevel, int nextLevel, int maxLevel, bool isAvailableLevelup) { }

		// // RVA: 0x18BA544 Offset: 0x18BA544 VA: 0x18BA544
		// private int GetTblFrame(bool isLvMax, bool isIsDiffrent, bool isCannon, bool isAvailable) { }

		// // RVA: 0x18BA564 Offset: 0x18BA564 VA: 0x18BA564
		// private int GetCollectTimeFrame(bool isMax, bool isIsDiffrent, bool isAvailable) { }

		// // RVA: 0x18BA0CC Offset: 0x18BA0CC VA: 0x18BA0CC
		// private void SetRestTime(string restTime) { }

		// // RVA: 0x18BA108 Offset: 0x18BA108 VA: 0x18BA108
		private void SetLv(int lv, int next, int max, bool isAvailable)
		{
			m_lvText.text = lv.ToString();
			m_nextLvText.text = next.ToString();
			int v = 0;
			int v2 = 1;
			if(next == max)
				v2 = 2;
			if(lv == max)
				v = 3;
			if(isAvailable)
				v = v2;
			m_lvTbl.StartChildrenAnimGoStop(v, v);
		}

		// // RVA: 0x18BA1F8 Offset: 0x18BA1F8 VA: 0x18BA1F8
		private void SetTime(string nowTime, string nextTime, bool isLvMax, bool isDiffrent, bool isAvailable)
		{
			m_collectTimeText.text = nowTime;
			m_collectNextTimeText.text = nextTime;
			int v = isAvailable && isDiffrent && !isLvMax ? 1 : 0;
			m_timeTbl.StartChildrenAnimGoStop(v, v);
		}

		// // RVA: 0x18BA2AC Offset: 0x18BA2AC VA: 0x18BA2AC
		private void SetItem(string nowPoint, string nextPoint, bool isLvMax, bool isDiffrent, bool isCannon, bool isAvailable)
		{
			m_collectItemText.text = nowPoint;
			m_collectNextItemText.text = nextPoint;
			int v = 2;
			if(isAvailable && isDiffrent && !isLvMax)
				v = 3;
			if(!isCannon)
				v = isAvailable && isDiffrent && !isLvMax ? 1 : 0;
			m_itemTbl.StartChildrenAnimGoStop(v, v);
		}

		// // RVA: 0x18BA37C Offset: 0x18BA37C VA: 0x18BA37C
		private void SetLvUpRestItemNum(int num, bool isMax, bool isReceivable, bool isAvailable)
		{
			if(isAvailable)
			{
				m_lvUpRestItemNumText.text = MessageManager.Instance.GetMessage("menu", isReceivable ? "pop_deco_sp_item_004" : "pop_deco_sp_item_002");
			}
			else
			{
				m_lvUpRestItemNumText.text = string.Format(MessageManager.Instance.GetMessage("menu", isMax ? "pop_deco_sp_item_003" : "pop_deco_sp_item_001"), num);
			}
		}
	}
}

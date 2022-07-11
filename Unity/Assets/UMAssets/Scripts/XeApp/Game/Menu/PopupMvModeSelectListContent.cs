using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupMvModeSelectListContent : UIBehaviour, IPopupContent
	{
		public enum SelectTarget
		{
			Diva = 0,
			Costume = 1,
			Valkyrie = 2,
		}

		private class ScrollListItem : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public bool IsSet { get; set; } // 0x1C
			public int ListIndex { get; set; } // 0x20
		}

		private class ScrollDivaListItem : ScrollListItem
		{
			public FFHPBEPOMAK DivaData { get; private set; } // 0x24

			// RVA: 0x1699EEC Offset: 0x1699EEC VA: 0x1699EEC
			public ScrollDivaListItem(int divaId)
			{ 
				DivaData = new FFHPBEPOMAK();
				DivaData.KHEKNNFCAOI(divaId, null, false);
			}
		}

		private class ScrollCostumeListItem : ScrollListItem
		{
			public CKFGMNAIBNG CostumeData { get; private set; } // 0x24
			public int ColorId { get; private set; } // 0x28

			// RVA: 0x169A10C Offset: 0x169A10C VA: 0x169A10C
			public ScrollCostumeListItem(int divaId, int costumeId, int colorId)
			{
				CostumeData = new CKFGMNAIBNG();
				CostumeData.KHEKNNFCAOI(divaId, costumeId, 0, false);
				ColorId = colorId;
			}
		}

		private class ScrollValkyrieListItem : ScrollListItem
		{
			public PNGOLKLFFLH ValkyrieData { get; private set; } // 0x24

			// RVA: 0x169A1E0 Offset: 0x169A1E0 VA: 0x169A1E0
			public ScrollValkyrieListItem(int valkyrieId)
			{
				ValkyrieData = new PNGOLKLFFLH();
				ValkyrieData.KHEKNNFCAOI_Init(valkyrieId, 0, 0);
			}
		}

		public const int RowCount = 5;
		public const int ColumnCount = 2;
		private static readonly Vector2 StartPos = new Vector2(10, 15); // 0x0
		private static readonly Vector2 Space = new Vector2(16, 22); // 0x8
		private static readonly Vector2 IconSize = new Vector2(458, 118); // 0x10
		private FlexibleItemScrollView m_scrollView = new FlexibleItemScrollView(); // 0xC
		private ScrollRect m_scrollRect; // 0x10
		private AOJGDNFAIJL.AMIECPBIALP m_prismData = new AOJGDNFAIJL.AMIECPBIALP(); // 0x14
		private PopupMvModeSelectListContent.SelectTarget m_selectTarget; // 0x18
		private int m_selectIndex; // 0x1C
		private int m_selectListIndex; // 0x20
		private Transform m_parent; // 0x24
		private List<IFlexibleListItem> m_scrollItem = new List<IFlexibleListItem>(); // 0x28
		private PopupWindowControl m_control; // 0x2C
		private PNGOLKLFFLH m_valkyrieData = new PNGOLKLFFLH(); // 0x30
		private CKFGMNAIBNG m_costumeData = new CKFGMNAIBNG(); // 0x34
		private FFHPBEPOMAK m_divaData = new FFHPBEPOMAK(); // 0x38

		public Transform Parent { get { return m_parent; } }//0x169BB80

		// RVA: 0x1698F04 Offset: 0x1698F04 VA: 0x1698F04
		private void Awake()
		{
			m_scrollRect = GetComponent<ScrollRect>();
			m_scrollView.Initialize(m_scrollRect);
		}

		// RVA: 0x1698F94 Offset: 0x1698F94 VA: 0x1698F94 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupMvModeSelectListSetting set = setting as PopupMvModeSelectListSetting;
			m_prismData.OBKGEDCKHHE(set.MusicId, 1 < Database.Instance.gameSetup.musicInfo.onStageDivaNum);
			m_selectTarget = set.SelectTarget;
			m_selectIndex = set.SelectIndex;
			m_control = control;
			m_parent = setting.m_parent;
			GetComponent<RectTransform>().sizeDelta = size;
			m_scrollRect.content.anchoredPosition = new Vector2(0, 0);
			m_scrollItem.Clear();
			if(m_selectTarget == SelectTarget.Diva)
			{
				List<AOJGDNFAIJL.LLHDHKLACJA> l = m_prismData.IANKDOFJLGB(m_selectIndex);
				bool noSelection = true;
				for(int i = 0; i < l.Count; i++)
				{
					ScrollDivaListItem item = new ScrollDivaListItem(l[i].PPFNGGCBJKC_DivaId);
					SetIconPosition(0, i, item);
					item.ListIndex = i;
					item.IsSet = l[i].CBLHLEKLLDE_IsSet;
					if(item.IsSet)
					{
						m_selectListIndex = i;
						noSelection = false;
					}
					m_scrollItem.Add(item);
					GameManager.Instance.DivaIconCache.TryLoadDivaSmallBustupIcon(l[i].PPFNGGCBJKC_DivaId, 1);
				}
				if(noSelection)
				{
					if(m_scrollItem.Count > 0)
					{
						(m_scrollItem[0] as ScrollDivaListItem).IsSet = true;
						m_selectListIndex = 0;
					}
				}
			}
			else if(m_selectTarget == SelectTarget.Costume)
			{
				UnityEngine.Debug.LogError("TODO fill costume list");
			}
			else if(m_selectTarget == SelectTarget.Valkyrie)
			{
				UnityEngine.Debug.LogError("TODO fill valkyrie list");
			}
			m_scrollView.UpdateItemListener += this.OnUpdateScrollItem;
			m_scrollView.SetupListItem(m_scrollItem);
			m_scrollView.SetlistTop(0);
			m_scrollView.SetZeroVelocity();
			m_scrollView.VisibleRangeUpdate();
		}

		// // RVA: 0x1699FA0 Offset: 0x1699FA0 VA: 0x1699FA0
		private void SetIconPosition(int x, int y, PopupMvModeSelectListContent.ScrollListItem item)
		{
			item.Top = new Vector2(StartPos.x + (Space.x + IconSize.x) * x, -(Space.y + IconSize.y) * y - StartPos.y);
			item.Height = IconSize.y + Space.y;
		}

		// // RVA: 0x169A2B4 Offset: 0x169A2B4 VA: 0x169A2B4
		public void Apply()
		{
			if(m_selectTarget == SelectTarget.Diva)
			{
				m_prismData.FLEMGCNKLIH(m_selectIndex, m_selectListIndex);
			}
			else
			{
				UnityEngine.Debug.LogError("TODO Apply valk & costume");
			}
			m_prismData.LMAAILCIFLF();
		}

		// // RVA: 0x169A398 Offset: 0x169A398 VA: 0x169A398
		private void OnUpdateScrollItem(IFlexibleListItem obj)
		{
			PopupMvSelectListItem item = obj.Layout.GetComponent<PopupMvSelectListItem>();
			PopupMvModeSelectListContent.ScrollListItem scrollItem = obj as PopupMvModeSelectListContent.ScrollListItem;
			if(obj == null || item == null)
				return;
			if(m_selectTarget == SelectTarget.Valkyrie)
			{
				UnityEngine.Debug.LogError("TODO OnUpdateScrollItem Valkyrie");
			}
			else if(m_selectTarget == SelectTarget.Costume)
			{
				UnityEngine.Debug.LogError("TODO OnUpdateScrollItem Costume");
			}
			else if(m_selectTarget == SelectTarget.Diva)
			{
				SetListItem(item, scrollItem as ScrollDivaListItem);
			}
			item.SetImageState(scrollItem.IsSet);
			item.SetButtonEvent(() => {
				//0x169BE20
				if(scrollItem.IsSet)
					return;
				SoundManager.Instance.sePlayerBoot.Play(3);
				for(int i = 0; i < m_scrollItem.Count; i++)
				{
					ScrollListItem sitem = m_scrollItem[i] as ScrollListItem;
					sitem.IsSet = sitem.ListIndex == item.ListIndex;
				}
				m_selectListIndex = item.ListIndex;
				m_scrollView.VisibleRangeUpdate();
			});
		}

		// // RVA: 0x169A834 Offset: 0x169A834 VA: 0x169A834
		private void SetListItem(PopupMvSelectListItem listLayout, PopupMvModeSelectListContent.ScrollDivaListItem listItem)
		{
			string txt;
			if(Database.Instance.gameSetup.musicInfo.onStageDivaNum < 2 && listItem.ListIndex == 0)
			{
				txt = MessageManager.Instance.GetMessage("menu", "mvmode_setting_popup_text_000_000");
			}
			else
			{
				txt = MessageManager.Instance.GetMessage("menu", "mvmode_setting_popup_text_000_001");
			}
			listLayout.SetName(string.Format(txt, listItem.DivaData.OPFGFINHFCE_DivaName));
			listLayout.SetListIndex(listItem.ListIndex);
			listLayout.HideTexture();
			GameManager.Instance.DivaIconCache.LoadDivaSmallBustupIcon(listItem.DivaData.AHHJLDLAPAN_DivaId, 1, (IiconTexture texture) => {
				//0x169C074
				if(listLayout.ListIndex != listItem.ListIndex)
					return;
				listLayout.SetTexture(texture);
			});
			listLayout.SetBackGround(true);
			listLayout.SetSubImage(null);
		}

		// // RVA: 0x169ABD8 Offset: 0x169ABD8 VA: 0x169ABD8
		// private void SetListItem(PopupMvSelectListItem listLayout, PopupMvModeSelectListContent.ScrollCostumeListItem listItem) { }

		// // RVA: 0x169B060 Offset: 0x169B060 VA: 0x169B060
		// private void SetListItem(PopupMvSelectListItem listLayout, PopupMvModeSelectListContent.ScrollValkyrieListItem listItem) { }

		// // RVA: 0x169B92C Offset: 0x169B92C VA: 0x169B92C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// // RVA: 0x169B934 Offset: 0x169B934 VA: 0x169B934 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_scrollView.LockScroll();
			m_control.ShowGradation();
		}

		// // RVA: 0x169B9B0 Offset: 0x169B9B0 VA: 0x169B9B0 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_scrollView.AllFree();
			m_scrollView.UpdateItemListener -= this.OnUpdateScrollItem;
		}

		// // RVA: 0x169BAB4 Offset: 0x169BAB4 VA: 0x169BAB4 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB;
		}

		// // RVA: 0x169BB54 Offset: 0x169BB54 VA: 0x169BB54 Slot: 22
		public void CallOpenEnd()
		{
			m_scrollView.UnLockScroll();
		}

		// // RVA: 0x169BB88 Offset: 0x169BB88 VA: 0x169BB88
		public void InitializeObject(LayoutUGUIRuntime obj, int count)
		{
			m_scrollView.AddLayoutCache(0, obj, count);
		}
	}
}

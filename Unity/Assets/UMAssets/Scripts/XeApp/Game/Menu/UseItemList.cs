using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;
using XeApp.Core;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class UseItemList : LayoutUGUIScriptBase
	{
		public enum LackReason
		{
			None = 0,
			LackUC = 1,
			LackItem = 2,
		}

		public enum Unlock
		{
			Default = 0,
			Status = 1,
			Episode = 2,
			All = 4,
		}
		
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x14
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x18
		[SerializeField]
		private Text[] m_texts; // 0x1C
		[SerializeField]
		private RawImageEx[] m_gradImages; // 0x20
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve; // 0x24
		private LayoutUGUIRuntime m_sourceObject; // 0x28
		private List<LayoutUGUIRuntime> m_scrollObjects = new List<LayoutUGUIRuntime>(); // 0x2C
		private List<GrowthNeedItemIcon> m_itemIconList = new List<GrowthNeedItemIcon>(); // 0x30
		private AbsoluteLayout m_rootLayout; // 0x34
		public const int lineItemCount = 6;
		private bool m_isLack; // 0x38
		private Color m_baseColor; // 0x3C
		private Color m_lackColor; // 0x4C
		private float m_time; // 0x5C

		public int ItemCount { get { return m_itemIconList.Count; } } //0x1653628

		// RVA: 0x16536A0 Offset: 0x16536A0 VA: 0x16536A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootLayout = layout.FindViewByExId("sw_pop_useitem_mask_all_swtbl_pop_item") as AbsoluteLayout;
			m_baseColor = SystemTextColor.GetLackColor();
			m_lackColor = SystemTextColor.GetImportantYellowColor();
			for(int i = 0; i < m_texts.Length; i++)
			{
				m_texts[i].text = "";
			}
			return true;
		}

		// RVA: 0x1653880 Offset: 0x1653880 VA: 0x1653880
		private void LateUpdate()
		{
			m_time += TimeWrapper.deltaTime;
			if(m_isLack)
			{
				if(m_animeCurve != null)
				{
					float f = m_animeCurve[0].Evaluate(m_time);
					m_texts[1].color = Color.Lerp(m_lackColor, m_baseColor, f);
				}
			}
			for(int i = 0; i< m_itemIconList.Count; i++)
			{
				m_itemIconList[i].UpdateFontColor(m_time);
			}
		}

		//// RVA: 0x1653AD4 Offset: 0x1653AD4 VA: 0x1653AD4
		public int GetScrollObjectCount()
		{
			return m_scrollObjects.Count;
		}

		//// RVA: 0x1653B4C Offset: 0x1653B4C VA: 0x1653B4C
		public void SetScrollTopPosition()
		{
			m_scrollRect.content.anchoredPosition = new Vector2(m_scrollRect.content.anchoredPosition.x, 0);
		}

		//// RVA: 0x1653BF4 Offset: 0x1653BF4 VA: 0x1653BF4
		public void SetItem(int index, int id, int needCount, int haveCount)
		{
			GrowthNeedItemIcon g = m_scrollObjects[index].GetComponent<GrowthNeedItemIcon>();
			g.gameObject.SetActive(true);
			g.SetIcon(id);
			g.SetNeedCount(needCount);
			g.SetHaveCount(haveCount, needCount);
			g.SetLack(haveCount < needCount);
		}

		//// RVA: 0x1653D9C Offset: 0x1653D9C VA: 0x1653D9C
		public void SetItemOff(int index)
		{
			m_scrollObjects[index].GetComponent<GrowthNeedItemIcon>().gameObject.SetActive(false);
		}

		//// RVA: 0x1653E8C Offset: 0x1653E8C VA: 0x1653E8C
		//private int GetOffsetX(int needCount) { }

		//// RVA: 0x1653E9C Offset: 0x1653E9C VA: 0x1653E9C
		//private int GetOffsetY() { }

		//// RVA: 0x1653EA4 Offset: 0x1653EA4 VA: 0x1653EA4
		//private int GetStrokeX() { }

		//// RVA: 0x1653EAC Offset: 0x1653EAC VA: 0x1653EAC
		//private int GetStrokeY() { }

		//// RVA: 0x1653EB4 Offset: 0x1653EB4 VA: 0x1653EB4
		public void SetConsumeHeader(Unlock unlock)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(unlock == Unlock.Status)
			{
				m_texts[0].text = bk.GetMessageByLabel("growth_popup_text23");
				m_texts[3].text = bk.GetMessageByLabel("growth_popup_text22");
			}
			else if(unlock == Unlock.Episode)
			{
				m_texts[0].text = bk.GetMessageByLabel("growth_popup_text21");
				m_texts[3].text = bk.GetMessageByLabel("growth_popup_text22");
			}
			else if (unlock == Unlock.All)
			{
				m_texts[0].text = bk.GetMessageByLabel("growth_popup_text20");
				m_texts[3].text = bk.GetMessageByLabel("growth_popup_text22");
			}
			else
			{
				m_texts[0].text = bk.GetMessageByLabel("growth_popup_text02");
				m_texts[3].text = "";
			}
		}

		//// RVA: 0x1654334 Offset: 0x1654334 VA: 0x1654334
		public void SetDispType(int needCount)
		{
			m_scrollRect.GetComponent<Mask>().enabled = needCount > 6;
			m_scrollRect.GetComponent<Image>().enabled = needCount > 6;
			for(int i = 0; i < m_gradImages.Length; i++)
			{
				m_gradImages[i].enabled = needCount > 6;
			}
			m_rootLayout.StartChildrenAnimGoStop(needCount > 6 ? "01" : "02");
		}

		//// RVA: 0x1654504 Offset: 0x1654504 VA: 0x1654504
		public void SetInvalidHeader(LackReason reason, Unlock unlock)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(reason == LackReason.LackItem)
			{
				m_texts[0].text = bk.GetMessageByLabel("growth_popup_text05");
			}
			else if(reason == (LackReason)3)
			{
				m_texts[0].text = bk.GetMessageByLabel("growth_popup_text09");
			}
			else
			{
				m_texts[0].text = bk.GetMessageByLabel("growth_popup_text08");
			}
			if(unlock > Unlock.All || ((1 << (int)unlock) & 0x16) == 0)
			{
				m_texts[3].text = "";
			}
			else
			{
				m_texts[3].text = bk.GetMessageByLabel("growth_popup_text22");
			}
		}

		//// RVA: 0x16547F4 Offset: 0x16547F4 VA: 0x16547F4
		public void SetNeedCredit(int needCredit)
		{
			m_texts[2].text = needCredit.ToString();
		}

		//// RVA: 0x165492C Offset: 0x165492C VA: 0x165492C
		public void SetHaveCredit(int credit, int needuc)
		{
			m_texts[1].text = credit.ToString();
			m_time = 0;
			m_isLack = credit < needuc;
		}

		//// RVA: 0x1654A80 Offset: 0x1654A80 VA: 0x1654A80
		public void ResetScrollItem(int needCount)
		{
			SetDispType(needCount);
			m_itemIconList.Clear();
			int a = 6;
			if (needCount > 6)
				a = 7;
			for(int i = 0; i < needCount; i++)
			{
				m_scrollObjects[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
				m_itemIconList.Add(m_scrollObjects[i].GetComponent<GrowthNeedItemIcon>());
				m_scrollObjects[i].gameObject.SetActive(true);
			}
			for(int i = m_itemIconList.Count; i < m_scrollObjects.Count; i++)
			{
				m_scrollObjects[i].gameObject.SetActive(false);
			}
			m_scrollSupport.BeginAddView();
			int c = 56;
			if (needCount < 7)
				c = 6;
			for(int i = 0; i < m_itemIconList.Count; i++)
			{
				m_scrollSupport.AddView(m_itemIconList[i].gameObject, c + (i % a) * 120, (i / a) * 140 * 23);
			}
			m_scrollSupport.EndAddView(new Vector2(120 * a, ((needCount - 1) / a) * 140 + 163));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7336FC Offset: 0x7336FC VA: 0x7336FC
		//// RVA: 0x1654F94 Offset: 0x1654F94 VA: 0x1654F94
		public IEnumerator LoadObjectCoroutine(int needCount)
		{
			int loadCount; // 0x18
			AssetBundleLoadLayoutOperationBase lytOperation; // 0x1C

			//0x1655238
			loadCount = needCount - m_scrollObjects.Count;
			if (loadCount < 0)
				yield break;
			if(m_sourceObject == null)
			{
				lytOperation = AssetBundleManager.LoadLayoutAsync("ly/097.xab", "root_pop_useitem_layout_root");
				yield return lytOperation;
				yield return Co.R(lytOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x165511C
					m_sourceObject = instance.GetComponent<LayoutUGUIRuntime>();
					m_sourceObject.transform.SetParent(transform, false);
					m_sourceObject.gameObject.SetActive(false);
				}));
				AssetBundleManager.UnloadAssetBundle("ly/097.xab", false);
				lytOperation = null;
			}
			for(int i = 0; i < loadCount; i++)
			{
				LayoutUGUIRuntime r = Instantiate(m_sourceObject);
				r.gameObject.SetActive(true);
				r.IsLayoutAutoLoad = false;
				r.Layout = m_sourceObject.Layout.DeepClone();
				r.UvMan = m_sourceObject.UvMan;
				r.LoadLayout();
				m_scrollObjects.Add(r);
			}
			yield return null;
		}
	}
}

using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeSys.Gfx;
using mcrs;
using XeSys;
using System.Linq;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvItemPopup : SwapScrollListContent
	{
		private static List<ViewOfferCompensation> lastCompensationList; // 0x0
		[SerializeField]
		private Text m_cautionText; // 0x20
		[SerializeField]
		private Text m_itemOverText; // 0x24
		[SerializeField]
		private Text m_ucText; // 0x28
		[SerializeField]
		private NumberBase m_ucNumber; // 0x2C
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x30
		private List<ViewOfferGetItem> m_getItemList = new List<ViewOfferGetItem>(); // 0x34

		public static List<ViewOfferCompensation> LastCompensationList { get { return lastCompensationList; } } //0x1520920
		public SwapScrollList List { get { return m_scrollList; } } //0x15209E8

		// RVA: 0x1520984 Offset: 0x1520984 VA: 0x1520984
		public static void SetLastCompensationList(List<ViewOfferCompensation> compensationList)
		{
			lastCompensationList = compensationList;
		}

		//// RVA: 0x15209F0 Offset: 0x15209F0 VA: 0x15209F0
		public void Setup(bool isLimit)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_cautionText.text = bk.GetMessageByLabel("popup_vop_all_receive_vc_caution");
			if(isLimit)
			{
				m_itemOverText.text = bk.GetMessageByLabel("popup_vop_all_receive_item_over");
			}
			else
			{
				m_itemOverText.text = "";
			}
			m_scrollList.SetContentEscapeMode(true);
			m_scrollList.Apply();
			m_getItemList.Clear();
			for(int i = 0; i < lastCompensationList.Count; i++)
			{
				m_getItemList.AddRange(new List<ViewOfferGetItem>(lastCompensationList[i].ItemList));
			}
			List<ViewOfferGetItem> l = new List<ViewOfferGetItem>();
			List<ViewOfferGetItem> l2 = m_getItemList.FindAll((ViewOfferGetItem x) =>
			{
				//0x15224F4
				return x.itemType == ViewOfferGetItem.ItemType.NOMAL;
			});
			l2.Sort((ViewOfferGetItem a, ViewOfferGetItem b) =>
			{
				//0x1522524
				return a.itemId - b.itemId;
			});
			m_getItemList.RemoveAll((ViewOfferGetItem x) =>
			{
				//0x1522564
				return x.itemType == ViewOfferGetItem.ItemType.NOMAL;
			});
			List<ViewOfferGetItem> l3 = new List<ViewOfferGetItem>();
			List<ViewOfferGetItem> l4 = m_getItemList.FindAll((ViewOfferGetItem x) =>
			{
				//0x1522594
				return x.itemType == ViewOfferGetItem.ItemType.NUM;
			});
			l4.Sort((ViewOfferGetItem a, ViewOfferGetItem b) =>
			{
				//0x15225C4
				return a.itemId - b.itemId;
			});
			l.AddRange(l4);
			List<ViewOfferGetItem> l5 = m_getItemList.FindAll((ViewOfferGetItem x) =>
			{
				//0x1522604
				return x.itemType == ViewOfferGetItem.ItemType.GREATERARE;
			});
			l5.Sort((ViewOfferGetItem a, ViewOfferGetItem b) =>
			{
				//0x1522630
				return a.itemId - b.itemId;
			});
			l.AddRange(l5);
			List<ViewOfferGetItem> l6 = m_getItemList.FindAll((ViewOfferGetItem x) =>
			{
				//0x1522670
				return x.itemType == ViewOfferGetItem.ItemType.RARE;
			});
			l6.Sort((ViewOfferGetItem a, ViewOfferGetItem b) =>
			{
				//0x15226A0
				return a.itemId - b.itemId;
			});
			l.AddRange(l6);
			List<ViewOfferGetItem> l7 = m_getItemList.FindAll((ViewOfferGetItem x) =>
			{
				//0x15226E0
				return x.itemType == ViewOfferGetItem.ItemType.CONFIRM;
			});
			l7.Sort((ViewOfferGetItem a, ViewOfferGetItem b) =>
			{
				//0x1522710
				return a.itemId - b.itemId;
			});
			l.AddRange(l7);
			int id = 0;
			while(!l2.IsEmpty())
			{
				id = l2.First().itemId;
				ViewOfferGetItem offer = new ViewOfferGetItem();
				offer.itemNum = 0;
				offer.bonusNum = 0;
				List<ViewOfferGetItem> l8 = l2.FindAll((ViewOfferGetItem x) =>
				{
					//0x1522750
					return x.itemId == id;
				});
				for(int i = 0; i < l8.Count; i++)
				{
					offer.itemNum += l8[i].itemNum;
					offer.bonusNum += l8[i].bonusNum;
				}
				l2.RemoveAll((ViewOfferGetItem x) =>
				{
					//0x1522788
					return x.itemId == id;
				});
				offer.itemType = ViewOfferGetItem.ItemType.NOMAL;
				offer.itemId = id;
				l.Add(offer);
			}
			int uc = 0;
			for(int i = 0; i < lastCompensationList.Count; i++)
			{
				uc += lastCompensationList[i].UCNum;
			}
			m_ucNumber.SetNumber(uc, 0);
			m_getItemList = l;
			m_scrollList.SetItemCount(l.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x1522108 Offset: 0x1522108 VA: 0x1522108
		public void Show()
		{
			gameObject.SetActive(true);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			this.StartCoroutineWatched(Co_MainFlow());
		}

		//// RVA: 0x1522218 Offset: 0x1522218 VA: 0x1522218
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8374 Offset: 0x6F8374 VA: 0x6F8374
		//// RVA: 0x15221A4 Offset: 0x15221A4 VA: 0x15221A4
		private IEnumerator Co_MainFlow()
		{
			//0x15227C4
			yield break;
		}

		//// RVA: 0x1522270 Offset: 0x1522270 VA: 0x1522270
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			content.GetComponent<OfferAllRecvItemContent>().Setup(m_getItemList[index]);
		}

		// RVA: 0x1522340 Offset: 0x1522340 VA: 0x1522340 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_ucText.text = JpStringLiterals.StringLiteral_18787;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}

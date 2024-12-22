using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAddEpisodeScrollContent : UIBehaviour, IPopupContent
	{
		private class ItemParam
		{
			public int m_episodeId; // 0x8
			public LayoutPopupAddEpisode.Type m_type; // 0xC
			public string m_viewEpisodeName; // 0x10
			public int m_rewardItemId; // 0x14
		}

		private LayoutPopupAddEpisodeScrollItemList m_itemList; // 0xC
		private List<ItemParam> m_paramList = new List<ItemParam>(); // 0x10

		public Transform Parent { get; private set; } // 0x14

		// RVA: 0x132EE58 Offset: 0x132EE58 VA: 0x132EE58 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupAddEpisodeScrollSetting s = setting as PopupAddEpisodeScrollSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			s.m_setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			foreach(var id in s.EpisodeIds)
			{
				if(id > 0)
				{
					ItemParam data = new ItemParam();
					data.m_episodeId = id;
					data.m_type = s.Type;
					PIGBBNDPPJC ep = new PIGBBNDPPJC();
					ep.KHEKNNFCAOI(id);
					data.m_viewEpisodeName = ep.OPFGFINHFCE_Name;
					LGMEPLIJLNB rwd = LGMEPLIJLNB.BMFKMFNPGPC(id, true);
					if(rwd != null && rwd.GOOIIPFHOIG != null)
						data.m_rewardItemId = rwd.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId;
					m_paramList.Add(data);
				}
			}
			m_itemList = setting.Content.GetComponent<LayoutPopupAddEpisodeScrollItemList>();
			m_itemList.Setup(s.m_setting);
			m_itemList.ScrollList.OnUpdateItem.AddListener(ListUpdateFunc);
			m_itemList.ScrollList.SetItemCount(m_paramList.Count);
			m_itemList.ScrollList.VisibleRegionUpdate();
			gameObject.SetActive(true);
		}

		// RVA: 0x132F518 Offset: 0x132F518 VA: 0x132F518
		private void ListUpdateFunc(int index, SwapScrollListContent content)
		{
			LayoutPopupAddEpisodeScrollItem c = content as LayoutPopupAddEpisodeScrollItem;
			c.EpisodeId = m_paramList[index].m_episodeId;
			c.Type = m_paramList[index].m_type;
			c.SetEpisodeName(m_paramList[index].m_viewEpisodeName);
			c.SetImageIcon(m_paramList[index].m_rewardItemId);
		}

		// RVA: 0x132F754 Offset: 0x132F754 VA: 0x132F754 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x132F75C Offset: 0x132F75C VA: 0x132F75C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x132F794 Offset: 0x132F794 VA: 0x132F794 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x132F7CC Offset: 0x132F7CC VA: 0x132F7CC Slot: 21
		public bool IsReady()
		{
			return !GameManager.Instance.ItemTextureCache.IsLoading();
		}

		// RVA: 0x132F88C Offset: 0x132F88C VA: 0x132F88C Slot: 22
		public void CallOpenEnd()
		{
			m_itemList.Show();
		}
	}
}

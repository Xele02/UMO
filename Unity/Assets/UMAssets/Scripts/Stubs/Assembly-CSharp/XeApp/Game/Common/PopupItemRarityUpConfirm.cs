using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupItemRarityUpConfirm : LayoutUGUIScriptBase, IPopupContent
	{
		[SerializeField]
		private RawImageEx m_imageBefore; // 0x14
		[SerializeField]
		private RawImageEx m_imageAfter; // 0x18
		[SerializeField]
		private Text m_textName; // 0x1C
		[SerializeField]
		private Text m_textDesc; // 0x20

		public Transform Parent { get; private set; }

		// RVA: 0x1BAA8E0 Offset: 0x1BAA8E0 VA: 0x1BAA8E0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}

		// RVA: 0x1BAA8F8 Offset: 0x1BAA8F8 VA: 0x1BAA8F8 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupItemRarityUpConfirmSetting s = setting as PopupItemRarityUpConfirmSetting;
			int rarity = EKLNMHFCAOI_ItemManager.FABCKNDLPDH_GetItemRarity(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, s.SceneId);
			string name = EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, s.SceneId);
			Parent = setting.m_parent;
			MenuScene.Instance.SceneIconCache.Load(s.SceneId, 1, (IiconTexture texture) => {
				//0x1BAADEC
				texture.Set(m_imageBefore);
			});
			MenuScene.Instance.SceneIconCache.Load(s.SceneId, 2, (IiconTexture texture) => {
				//0x1BAAECC
				texture.Set(m_imageAfter);
			});
			m_textDesc.text = bk.GetMessageByLabel("rarityup_item_use_confirm_desc");
			m_textName.text = string.Format(bk.GetMessageByLabel("popup_event_reward_platetitle"), rarity, name);
		}

		// RVA: 0x1BAAD60 Offset: 0x1BAAD60 VA: 0x1BAAD60 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BAAD68 Offset: 0x1BAAD68 VA: 0x1BAAD68 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1BAADA0 Offset: 0x1BAADA0 VA: 0x1BAADA0 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BAADD8 Offset: 0x1BAADD8 VA: 0x1BAADD8 Slot: 10
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1BAADE0 Offset: 0x1BAADE0 VA: 0x1BAADE0 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}

using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutQuestRewardItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_imageIcon; // 0x20
		[SerializeField]
		private NumberBase m_numReward; // 0x24
		[SerializeField]
		private ActionButton m_buttonReward; // 0x28
		private MFDJIFIIPJD m_itemInfo; // 0x2C

		// RVA: 0x187BDD8 Offset: 0x187BDD8 VA: 0x187BDD8 Slot: 6
		public virtual void SetStatus(MFDJIFIIPJD info)
		{
			m_itemInfo = info;
			m_imageIcon.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(m_itemInfo.JJBGOIMEIPF_ItemId, (IiconTexture texture) =>
			{
				//0x187CE5C
				m_imageIcon.enabled = true;
				if(texture != null)
				{
					texture.Set(m_imageIcon);
				}
			});
			m_numReward.SetNumber(m_itemInfo.MBJIFDBEDAC_Cnt, 0);
		}

		//// RVA: 0x187CA28 Offset: 0x187CA28 VA: 0x187CA28
		private void ShowPopupItemDetails(MFDJIFIIPJD itemInfo)
		{
			if(itemInfo != null)
			{
				if(itemInfo.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
				{
					CKFGMNAIBNG data = new CKFGMNAIBNG();
					int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemInfo.JJBGOIMEIPF_ItemId);
					data.KHEKNNFCAOI(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[itemId - 1].AHHJLDLAPAN_PrismDivaId, itemId, 0, false);
					MenuScene.Instance.ShowCostumeDetailWindow(data, 0);
				}
				else if(itemInfo.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
					int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemInfo.JJBGOIMEIPF_ItemId);
					scene.KHEKNNFCAOI(itemId, null, null, 0, 0, 0, false, 0, 0);
					MenuScene.Instance.ShowSceneStatusPopupWindow(scene, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, true, true, 0, false);
				}
				else
				{
					MenuScene.Instance.ShowItemDetail(itemInfo.JJBGOIMEIPF_ItemId, itemInfo.MBJIFDBEDAC_Cnt, null);
				}
			}
		}

		// RVA: 0x187BF84 Offset: 0x187BF84 VA: 0x187BF84 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_buttonReward.AddOnClickCallback(() =>
			{
				//0x187CF5C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ShowPopupItemDetails(m_itemInfo);
			});
			Loaded();
			return true;
		}
	}
}

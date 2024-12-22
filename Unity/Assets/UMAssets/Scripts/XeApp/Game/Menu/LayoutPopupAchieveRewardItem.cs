using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAchieveRewardItem : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_itemDesc; // 0x14
		[SerializeField]
		private Text m_conditionsDesc; // 0x18
		[SerializeField]
		private RawImageEx m_icon; // 0x1C
		private GameObject m_base; // 0x20
		private RectTransform m_rtTransform; // 0x24

		//// RVA: 0x15E1D54 Offset: 0x15E1D54 VA: 0x15E1D54
		public void SetStatus(LayoutPopupAchieveRewardScrollList.ItemParam param)
		{
			FPGEMAIAMBF_RewardData.LOIJICNJMKA rewardData = null;
			if (param != null)
				rewardData = param.rewardData;
			if (param == null || rewardData == null)
				return;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			switch(param.type)
			{
				case LayoutPopupAchieveRewardScrollList.ItemParam.eType.Clear:
					SetConditions(string.Format(bk.GetMessageByLabel("popup_reward_detail_001"), rewardData.FCDKJAKLGMB_TargetValue));
					break;
				case LayoutPopupAchieveRewardScrollList.ItemParam.eType.Score:
					SetConditions(string.Format(bk.GetMessageByLabel("popup_reward_detail_002"), rewardData.FCDKJAKLGMB_TargetValue));
					break;
				case LayoutPopupAchieveRewardScrollList.ItemParam.eType.Combo:
					SetConditions(string.Format(bk.GetMessageByLabel("popup_reward_detail_003"), rewardData.FCDKJAKLGMB_TargetValue));
					break;
				case LayoutPopupAchieveRewardScrollList.ItemParam.eType.All:
					SetConditions(bk.GetMessageByLabel("reward_all_clear_text_00").Replace("\n", "").Replace("\r", ""));
					break;
				default:
					SetConditions("");
					break;
			}
			SetItemName((rewardData.HHACNFODNEF_Category == 3 ? rewardData.JDLJPNMLFID.ToString() : rewardData.JDMIKEEIJFP + JpStringLiterals.StringLiteral_12037 + rewardData.JDLJPNMLFID.ToString()) + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(rewardData.KIJAPOFAGPN_GlobalItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(rewardData.KIJAPOFAGPN_GlobalItemId), rewardData.JDLJPNMLFID));
			SetIcon(rewardData.KIJAPOFAGPN_GlobalItemId);
		}

		//// RVA: 0x15E228C Offset: 0x15E228C VA: 0x15E228C
		public void SetItemName(string text)
		{
			if (m_itemDesc != null)
				m_itemDesc.text = text;
		}

		//// RVA: 0x15E21CC Offset: 0x15E21CC VA: 0x15E21CC
		public void SetConditions(string text)
		{
			if(m_conditionsDesc != null)
				m_conditionsDesc.text = text;
		}

		//// RVA: 0x15E234C Offset: 0x15E234C VA: 0x15E234C
		public void SetIcon(int iconId)
		{
			if(m_icon != null)
			{
				GameManager.Instance.ItemTextureCache.Load(iconId, (IiconTexture texture) =>
				{
					//0x15E27FC
					texture.Set(m_icon);
				});
			}
		}

		//// RVA: 0x15E24A4 Offset: 0x15E24A4 VA: 0x15E24A4
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x15E24DC Offset: 0x15E24DC VA: 0x15E24DC
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x15E2514 Offset: 0x15E2514 VA: 0x15E2514
		public void Reset()
		{
			return;
		}

		//// RVA: 0x15E2518 Offset: 0x15E2518 VA: 0x15E2518
		//private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x15E2668 Offset: 0x15E2668 VA: 0x15E2668 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = gameObject;
			m_rtTransform = GetComponent<RectTransform>();
			Loaded();
			return true;
		}

		//// RVA: 0x15E26F0 Offset: 0x15E26F0 VA: 0x15E26F0
		public GameObject GetBase()
		{
			return m_base;
		}

		//// RVA: 0x15E26F8 Offset: 0x15E26F8 VA: 0x15E26F8
		public void SetPosition(int x, int y)
		{
			if (m_rtTransform != null)
				m_rtTransform.anchoredPosition = new Vector2(x, -y);
		}
	}
}

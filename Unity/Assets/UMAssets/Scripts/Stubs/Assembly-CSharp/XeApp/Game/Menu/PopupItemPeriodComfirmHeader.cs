using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupItemPeriodComfirmHeader : FlexibleListItemLayout
	{
		[SerializeField]
		private Text m_textPeriod; // 0x18
		[SerializeField]
		private Text m_textNum; // 0x1C

		//// RVA: 0x17ACD60 Offset: 0x17ACD60 VA: 0x17ACD60
		//public bool IsLoading() { }

		// RVA: 0x17ACDFC Offset: 0x17ACDFC VA: 0x17ACDFC
		public void Setup(int typeItemId)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textPeriod.text = bk.GetMessageByLabel("item_use_period_text_1");
			m_textNum.text = string.Format(bk.GetMessageByLabel("item_use_period_text_2"), EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(typeItemId)));
		}

		// RVA: 0x17ACFBC Offset: 0x17ACFBC VA: 0x17ACFBC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}

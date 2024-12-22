using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeSys;
using System;

namespace XeApp.Game.Menu
{
	public class PopupItemPeriodComfirmElem : FlexibleListItemLayout
	{
		[SerializeField]
		private Text m_textPeriod; // 0x18
		[SerializeField]
		private Text m_textNum; // 0x1C

		//// RVA: 0x17AC7CC Offset: 0x17AC7CC VA: 0x17AC7CC
		//public bool IsLoading() { }

		// RVA: 0x17AC868 Offset: 0x17AC868 VA: 0x17AC868
		public void Setup(int period, int typeItemId, int num)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			DateTime date = Utility.GetLocalDateTime(period);
			m_textPeriod.text = string.Format(bk.GetMessageByLabel("item_use_period_date"), new object[5]
			{
				date.Year, date.Month, date.Day, date.Hour, date.Minute
			});
			m_textNum.text = num + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(typeItemId));
		}

		// RVA: 0x17ACD40 Offset: 0x17ACD40 VA: 0x17ACD40 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}

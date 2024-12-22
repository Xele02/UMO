using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupRegistrationBirthday : LayoutUGUIScriptBase
	{
		private static readonly int DEFAULT_YEAR = 1980; // 0x0
		private static readonly int DEFAULT_MONTH = 1; // 0x4
		private Vector2 m_YearAreaSize = new Vector2(180, 250); // 0x14
		private Vector2 m_YearItemSize = new Vector2(180, 50); // 0x1C
		private Vector2 m_MonthAreaSize = new Vector2(140, 250); // 0x24
		private Vector2 m_MonthItemSize = new Vector2(140, 50); // 0x2C
		public int m_YearStart = 1900; // 0x34
		public int m_YearEnd = 2020; // 0x38
		private Action m_OnClickTermsOfService; // 0x3C
		private ActionButton m_TermsOfServiceButton; // 0x40

		public Action OnClickTermsOfService { set { m_OnClickTermsOfService = value; } } //0x1782468

		// RVA: 0x1782470 Offset: 0x1782470 VA: 0x1782470 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Text[] txts = GetComponentsInChildren<Text>(true);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			txts.Where((Text _) =>
			{
				//0x178361C
				return _.name == "registration (TextView)";
			}).First().text = bk.GetMessageByLabel("popup_denom_regist_birthday_text1");
			txts.Where((Text _) =>
			{
				//0x178369C
				return _.name == "year (TextView)";
			}).First().text = JpStringLiterals.StringLiteral_1374;
			txts.Where((Text _) =>
			{
				//0x178371C
				return _.name == "month (TextView)";
			}).First().text = JpStringLiterals.StringLiteral_1376;
			txts.Where((Text _) =>
			{
				//0x178379C
				return _.name == "explanation (TextView)";
			}).First().text = bk.GetMessageByLabel("popup_denom_regist_birthday_text2");
			GetComponentInChildren<ActionButton>(true).AddOnClickCallback(() =>
			{
				//0x178358C
				if(m_OnClickTermsOfService != null)
					m_OnClickTermsOfService();
			});
			Loaded();
			return true;
		}

		// RVA: 0x1782B04 Offset: 0x1782B04 VA: 0x1782B04
		public void Setup(GameObject year_obj, GameObject month_obj)
		{
			DateTime date = Utility.GetLocalDateTime(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			m_YearStart = date.Year - 100;
			m_YearEnd = date.Year - 1;
			Transform t = transform.Find("sw_birth (AbsoluteLayout)");
			Transform t2 = t.Find("atari1 (AbsoluteLayout)");
			t2.SetAsLastSibling();
			year_obj.transform.SetParent(t2, false);
			List<string> l = new List<string>();
			int select = 0;
			for(int i = m_YearStart; i <= m_YearEnd; i++)
			{
				if(i == DEFAULT_YEAR)
					select = l.Count;
				l.Add(i.ToString());
			}
			year_obj.GetComponent<SelectValueContentControl>().Setup(m_YearItemSize, m_YearAreaSize, l, select);
			t2 = t.Find("atari2 (AbsoluteLayout)");
			t2.SetAsLastSibling();
			month_obj.transform.SetParent(t2, false);
			select = 0;
			l = new List<string>();
			for(int i = 1; i < 13; i++)
			{
				if(i == DEFAULT_MONTH)
					select = l.Count;
				l.Add(i.ToString());
			}
			month_obj.GetComponent<SelectValueContentControl>().Setup(m_MonthItemSize, m_MonthAreaSize, l, select);

		}

		// RVA: 0x178312C Offset: 0x178312C VA: 0x178312C
		public void GetBirth(out int year, out int month)
		{
			SelectValueContentControl[] selects = GetComponentsInChildren<SelectValueContentControl>(true);
			year = int.Parse(selects.Where((SelectValueContentControl _) =>
			{
				//0x178381C
				return _.name == "SelectValueContent_Year";
			}).First().GetSelectItem());
			month = int.Parse(selects.Where((SelectValueContentControl _) =>
			{
				//0x178389C
				return _.name == "SelectValueContent_Month";
			}).First().GetSelectItem());
		}

		// RVA: 0x1783410 Offset: 0x1783410 VA: 0x1783410
		public void Update()
		{
			return;
		}
	}
}

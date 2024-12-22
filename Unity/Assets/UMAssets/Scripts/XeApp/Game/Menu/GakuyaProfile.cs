using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GakuyaProfile : MonoBehaviour
	{
		[SerializeField]
		private Text m_textAge; // 0xC
		[SerializeField]
		private Text m_textBirthday; // 0x10
		[SerializeField]
		private Text m_textBirthplace; // 0x14
		[SerializeField]
		private Text m_textFavorite; // 0x18
		[SerializeField]
		private Text m_textDescription; // 0x1C
		[SerializeField]
		private ScrollRect m_scroll; // 0x20

		// RVA: 0xB75460 Offset: 0xB75460 VA: 0xB75460
		private void Awake()
		{
			m_textAge.transform.parent.Find("Title").GetComponent<Text>().text = JpStringLiterals.UMO_Age;
			m_textBirthday.transform.parent.Find("Title").GetComponent<Text>().text = JpStringLiterals.StringLiteral_19017;
			m_textBirthplace.transform.parent.Find("Title").GetComponent<Text>().text = JpStringLiterals.UMO_Birthplace;
			m_textFavorite.transform.parent.Find("Title").GetComponent<Text>().text = JpStringLiterals.UMO_Favorite;
			m_textDescription.transform.parent.Find("Title").GetComponent<Text>().text = JpStringLiterals.UMO_DivaDesc;
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
			{
				m_textFavorite.resizeTextForBestFit = true;
				m_textFavorite.resizeTextMaxSize = m_textFavorite.fontSize;
				RectTransform rt = m_textAge.transform.parent.Find("TitleBack").GetComponent<RectTransform>();
				rt.sizeDelta = new Vector2(200, rt.sizeDelta.y);
				rt = m_textBirthday.transform.parent.Find("TitleBack").GetComponent<RectTransform>();
				rt.sizeDelta = new Vector2(200, rt.sizeDelta.y);
				rt = m_textBirthplace.transform.parent.Find("TitleBack").GetComponent<RectTransform>();
				rt.sizeDelta = new Vector2(200, rt.sizeDelta.y);
				rt = m_textFavorite.transform.parent.Find("TitleBack").GetComponent<RectTransform>();
				rt.sizeDelta = new Vector2(200, rt.sizeDelta.y);
				rt = m_textDescription.transform.parent.Find("TitleBack").GetComponent<RectTransform>();
				rt.sizeDelta = new Vector2(200, rt.sizeDelta.y);
			}
			return;
		}

		// RVA: 0xB75464 Offset: 0xB75464 VA: 0xB75464
		private void Update()
		{
			return;
		}

		// RVA: 0xB75468 Offset: 0xB75468 VA: 0xB75468
		private void OnDestroy()
		{
			return;
		}

		// RVA: 0xB7546C Offset: 0xB7546C VA: 0xB7546C
		public void Setup(int divaId)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			string prefix = string.Format("profile_diva{0:000}", divaId);
			m_textAge.text = bk.GetMessageByLabel(prefix + "_age");
			m_textBirthday.text = bk.GetMessageByLabel(prefix + "_birthday");
			m_textBirthplace.text = bk.GetMessageByLabel(prefix + "_birthplace");
			m_textFavorite.text = bk.GetMessageByLabel(prefix + "_favorite");
			m_textDescription.text = bk.GetMessageByLabel(prefix + "_description_gakuya");
		}

		// RVA: 0xB732A4 Offset: 0xB732A4 VA: 0xB732A4
		public void SetScrollTop()
		{
			if(m_scroll.vertical)
			{
				m_scroll.verticalNormalizedPosition = 1;
				m_scroll.velocity = Vector2.zero;
			}
		}
	}
}

using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class IntimacySystemMessage : MonoBehaviour
	{
		// [HeaderAttribute] // RVA: 0x68B1C8 Offset: 0x68B1C8 VA: 0x68B1C8
		[SerializeField]
		private UGUICommonInfoWindow m_systemWindow; // 0xC
		// [HeaderAttribute] // RVA: 0x68B224 Offset: 0x68B224 VA: 0x68B224
		[SerializeField]
		private Color[] m_colorTable = new Color[10]
		{
			GetRgbColor(0xfb5a74),
			GetRgbColor(0x973cff),
			GetRgbColor(0xe7b300),
			GetRgbColor(0xff6ec3),
			GetRgbColor(0xccd5a),
			GetRgbColor(0xccd5a),
			GetRgbColor(0x973cff),
			GetRgbColor(0xff6ec3),
			GetRgbColor(0xf43650),
			GetRgbColor(0xf6cf7)
		}; // 0x10

		// // RVA: 0x110220C Offset: 0x110220C VA: 0x110220C
		private static Color GetRgbColor(uint color)
		{
			if(color < 0x1000000)
			{
				return new Color(((color >> 16) & 0xff) / 255.0f
					, ((color >> 8) & 0xff) / 255.0f
					, ((color) & 0xff) / 255.0f
					, 1);
			}
			else
			{
				return new Color(((color >> 24) & 0xff) / 255.0f
					, ((color >> 16) & 0xff) / 255.0f
					, ((color >> 8) & 0xff) / 255.0f
					, ((color) & 0xff) / 255.0f);
			}
		}

		// // RVA: 0x11022C4 Offset: 0x11022C4 VA: 0x11022C4
		public void Init(bool isHome)
		{
			if(isHome)
			{
				m_systemWindow.SetDirection(UGUICommonInfoWindow.Direction.Left);
				(m_systemWindow.transform as RectTransform).anchoredPosition = new Vector2(100, -200);
				(m_systemWindow.transform as RectTransform).anchorMax = new Vector2(0, 1);
				(m_systemWindow.transform as RectTransform).anchorMin = new Vector2(0, 1);
			}
			else
			{
				m_systemWindow.SetDirection(UGUICommonInfoWindow.Direction.Right);
				(m_systemWindow.transform as RectTransform).anchoredPosition = new Vector2(-95, -20);
				(m_systemWindow.transform as RectTransform).anchorMax = new Vector2(0.5f, 0.5f);
				(m_systemWindow.transform as RectTransform).anchorMin = new Vector2(0, 0);
			}
		}

		// // RVA: 0x1102568 Offset: 0x1102568 VA: 0x1102568
		public void SetTextLevelUpBonus(int divaId, string name, JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK type, int param)
		{
			m_systemWindow.SetTelopColor(m_colorTable[divaId - 1]);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str = "";
			switch (type)
			{
				case JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK.POBNHLKGMPF_1:
					str = bk.GetMessageByLabel("diva_intimacy_lvup_text_001");
					break;
				case JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK.EHJDMAOKHHP_2:
					str = bk.GetMessageByLabel("diva_intimacy_lvup_text_002");
					break;
				case JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK.JFEKIMDCKIH_3:
					str = bk.GetMessageByLabel("diva_intimacy_lvup_text_003");
					break;
				case JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK.GBINCMPKLOF_4:
					str = bk.GetMessageByLabel("diva_intimacy_lvup_text_004");
					break;
				default:
					break;
			}
			m_systemWindow.Setup(string.Format(str, name, param), null);
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
			{
				m_systemWindow.SetTextWidth(200);
			}
		}

		// // RVA: 0x11027FC Offset: 0x11027FC VA: 0x11027FC
		public void SetTextSystem(int divaId, string text)
		{
			m_systemWindow.SetTelopColor(m_colorTable[divaId - 1]);
			m_systemWindow.Setup(text, null);
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
			{
				m_systemWindow.SetTextWidth(200);
			}
		}

		// // RVA: 0x11028C0 Offset: 0x11028C0 VA: 0x11028C0
		public void Enter(bool force = false)
		{
			m_systemWindow.Enter(force);
		}

		// // RVA: 0x11028F4 Offset: 0x11028F4 VA: 0x11028F4
		public void Enter(float animTime, bool force = false)
		{
			m_systemWindow.Enter(animTime, force);
		}

		// // RVA: 0x1102930 Offset: 0x1102930 VA: 0x1102930
		public void Leave(bool force = false)
		{
			m_systemWindow.Leave(force);
		}

		// // RVA: 0x1102964 Offset: 0x1102964 VA: 0x1102964
		public void Leave(float animTime, bool force = false)
		{
			m_systemWindow.Leave(animTime, force);
		}

		// // RVA: 0x11029A0 Offset: 0x11029A0 VA: 0x11029A0
		public bool IsPlaying()
		{
			return m_systemWindow.IsPlaying();
		}
	}
}

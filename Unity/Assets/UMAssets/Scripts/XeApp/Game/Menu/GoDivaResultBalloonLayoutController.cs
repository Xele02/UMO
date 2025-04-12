using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GoDivaResultBalloonLayoutController : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layoutRoot; // 0x14
		[SerializeField]
		private Text m_textName; // 0x18
		[SerializeField]
		private Text m_text; // 0x1C
		private RawImageEx[] rawImages; // 0x20

		// RVA: 0xE204A4 Offset: 0xE204A4 VA: 0xE204A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.Root;
			rawImages = GetComponentsInChildren<RawImageEx>(true);
			for(int i = 0; i < rawImages.Length; i++)
			{
				rawImages[i].enabled = false;
			}
			m_textName.text = "";
			m_text.text = "";
			Loaded();
			return true;
		}

		// RVA: 0xE2063C Offset: 0xE2063C VA: 0xE2063C
		public void Setup()
		{
			m_layoutRoot.StartAllAnimGoStop("st_wait");
		}

		// // RVA: 0xE1AD6C Offset: 0xE1AD6C VA: 0xE1AD6C
		public void ShowBalloon(int divaId, int balloonType)
		{
			for(int i = 0; i < rawImages.Length; i++)
			{
				rawImages[i].enabled = true;
			}
			StringBuilder str = new StringBuilder();
			str.AppendFormat("diva{0:D3}", divaId);
			MessageBank bk = MessageManager.Instance.GetBank(str.ToString());
			m_textName.text = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[divaId - 1].OPFGFINHFCE_Name;
			str.Clear();
			str.AppendFormat("go_diva_result_{0:D2}", balloonType);
			m_text.text = bk.GetMessageByLabel(str.ToString());
			m_layoutRoot.StartAllAnimGoStop("go_in", "st_in");
		}
	}
}

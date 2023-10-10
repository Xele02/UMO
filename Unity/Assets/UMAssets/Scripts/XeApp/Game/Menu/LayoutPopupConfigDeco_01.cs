using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigDeco_01 : LayoutPopupDecoOptionBase
	{
		public enum eTextType
		{
			DisplayTitle = 0,
			PlateAnimeCaution = 1,
			Num = 2,
		}

		public enum eToggleButton
		{
			EffectDisplay = 0,
			PosterAnimation = 1,
			Num = 2,
		}

		private struct ConfigInfo
		{
			public bool isEnableBgEffect; // 0x0
			public bool isPosterAnime; // 0x1
		}

		private ConfigInfo m_configInfo; // 0x3C
		private TextSet[] m_textTbl = new TextSet[2]
		{
			new TextSet() { index = 0, label = "pop_deco_option_desc_display" },
			new TextSet() { index = 1, label = "pop_deco_option_caution_plateanimation_01" }
		}; // 0x40

		// RVA: 0x1EC172C Offset: 0x1EC172C VA: 0x1EC172C Slot: 6
		public override int GetContentsHeight()
		{
			return 210;
		}

		// RVA: 0x1EC1734 Offset: 0x1EC1734 VA: 0x1EC1734 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// RVA: 0x1EC173C Offset: 0x1EC173C VA: 0x1EC173C Slot: 9
		public override void SetDecoOption(MDDBFCFOKFC saveData)
		{
			saveData.KOGBMDOONFA.CINLIMIKCAL_EnableBgEffect = m_configInfo.isEnableBgEffect;
			saveData.KOGBMDOONFA.HEKJKLJDHNN_EnablePosterAnim = m_configInfo.isPosterAnime;
		}

		//// RVA: 0x1EC17C0 Offset: 0x1EC17C0 VA: 0x1EC17C0
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for (int i = 0; i < m_textTbl.Length; i++)
			{
				if (!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					SetText(m_textTbl[i].index, bk.GetMessageByLabel(m_textTbl[i].label));
				}
				else
				{
					SetText(i, "");
				}
			}
		}

		// RVA: 0x1EC19C8 Offset: 0x1EC19C8 VA: 0x1EC19C8 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetText();
			m_configInfo.isEnableBgEffect = SaveData.KOGBMDOONFA.CINLIMIKCAL_EnableBgEffect;
			m_configInfo.isPosterAnime = SaveData.KOGBMDOONFA.HEKJKLJDHNN_EnablePosterAnim;
			SetSelectToggleButton(0, m_configInfo.isEnableBgEffect ? 1 : 0);
			SetSelectToggleButton(1, m_configInfo.isPosterAnime ? 1 : 0);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D135C Offset: 0x6D135C VA: 0x6D135C
		//// RVA: 0x1EC1A70 Offset: 0x1EC1A70 VA: 0x1EC1A70
		private IEnumerator Setup()
		{
			//0x1EC1D8C
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1EC1D38
				ConfigUtility.PlaySeToggleButton();
				m_configInfo.isEnableBgEffect = value == 1;
			});
			SetCallbackToggleButton(1, (int value) =>
			{
				//0x1EC1D60
				ConfigUtility.PlaySeToggleButton();
				m_configInfo.isPosterAnime = value == 1;
			});
			yield break;
		}

		// RVA: 0x1EC1B1C Offset: 0x1EC1B1C VA: 0x1EC1B1C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}

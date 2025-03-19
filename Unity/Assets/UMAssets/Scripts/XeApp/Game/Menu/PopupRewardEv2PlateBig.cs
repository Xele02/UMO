using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using mcrs;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class PopupRewardEv2PlateBig : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textPlateName; // 0x14
		[SerializeField]
		private Text[] m_textPointList; // 0x18
		[SerializeField]
		private Text m_textPointTitle; // 0x1C
		[SerializeField]
		private Text m_textPointPage; // 0x20
		[SerializeField]
		private Text[] m_textRankingList; // 0x24
		[SerializeField]
		private Text m_textRankingTitle; // 0x28
		[SerializeField]
		private Text m_textRankingPage; // 0x2C
		[SerializeField]
		private RawImageEx m_imagePlate; // 0x30
		[SerializeField]
		private StayButton m_buttonPlate; // 0x34
		[SerializeField]
		private ActionButton[] m_buttonPoint; // 0x38
		[SerializeField]
		private ActionButton[] m_buttonRanking; // 0x3C
		private PopupRewardEv2ItemLayout.ViewPlateData m_view; // 0x40
		private int m_indexPoint; // 0x44
		private int m_indexPointMax; // 0x48
		private int m_indexRanking; // 0x4C
		private int m_indexRankingMax; // 0x50

		// RVA: 0x1A63298 Offset: 0x1A63298 VA: 0x1A63298 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_buttonPoint[0].AddOnClickCallback(() =>
			{
				//0x1A64074
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdatePointPage(-1);
			});
			m_buttonPoint[1].AddOnClickCallback(() =>
			{
				//0x1A640DC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdatePointPage(1);
			});
			m_buttonRanking[0].AddOnClickCallback(() =>
			{
				//0x1A64144
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdateRankingPage(-1);
			});
			m_buttonRanking[1].AddOnClickCallback(() =>
			{
				//0x1A641AC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				UpdateRankingPage(1);
			});
			Loaded();
			return true;
		}

		// RVA: 0x1A63524 Offset: 0x1A63524 VA: 0x1A63524
		public void Setup(PopupRewardEv2ItemLayout.ViewPlateData view)
		{
			m_view = view;
			GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
			scene.KHEKNNFCAOI(view.plateNo, null, null, 0, 0, 0, false, 0, 0);
			MenuScene.Instance.SceneIconCache.Load(view.plateNo, view.data.JOKJBMJBLBB_Single ? 2 : 1, (IiconTexture texture) =>
			{
				//0x1A64214
				texture.Set(m_imagePlate);
			});
			m_textPlateName.text = scene.OPFGFINHFCE_SceneName;
			m_textPointTitle.text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_check_pt");
			m_textRankingTitle.text = string.Format(JpStringLiterals.StringLiteral_19432, m_view.rankingTitle);
			m_indexPointMax = ((m_view.point.Count - 1) / m_textPointList.Length) + 1;
			m_buttonPoint[0].Hidden = m_indexPointMax < 2;
			m_buttonPoint[1].Hidden = m_indexPointMax < 2;
			m_textPointPage.enabled = m_indexPointMax > 1;
			UpdatePointPage(0);
			m_indexRankingMax = ((m_view.ranking.Count - 1) / m_textRankingList.Length) + 1;
			m_buttonRanking[0].Hidden = m_indexRankingMax < 2;
			m_buttonRanking[1].Hidden = m_indexRankingMax < 2;
			m_textRankingPage.enabled = m_indexRankingMax > 1;
			UpdateRankingPage(0);
		}

		// // RVA: 0x1A63AF8 Offset: 0x1A63AF8 VA: 0x1A63AF8
		private void UpdatePointPage(int add)
		{
			m_indexPoint = Mathf.Clamp(m_indexPoint + add, 0, m_indexPointMax - 1);
			UpdatePage(m_indexPoint, m_indexPointMax, m_buttonPoint, m_textPointPage, m_view.point, m_textPointList);
		}

		// // RVA: 0x1A63BE0 Offset: 0x1A63BE0 VA: 0x1A63BE0
		private void UpdateRankingPage(int add)
		{
			m_indexRanking = Mathf.Clamp(m_indexRanking + add, 0, m_indexRankingMax - 1);
			UpdatePage(m_indexRanking, m_indexRankingMax, m_buttonRanking, m_textRankingPage, m_view.ranking, m_textRankingList);
		}

		// // RVA: 0x1A63CC8 Offset: 0x1A63CC8 VA: 0x1A63CC8
		private void UpdatePage(int num, int max, ActionButton[] button, Text page, List<string> viewList, Text[] textList)
		{
			if(!button[0].Hidden)
			{
				button[0].Disable = num < 1;
			}
			if(!button[1].Hidden)
			{
				button[1].Disable = max - 1 <= num;
			}
			page.text = string.Format("{0}/{1}", num + 1, max);
			for(int i = 0; i < textList.Length; i++)
			{
				if(viewList.Count > (textList.Length * num + i))
				{
					textList[i].text = viewList[textList.Length * num + i];
				}
				else
				{
					textList[i].text = i == 0 ? JpStringLiterals.StringLiteral_8686 : "";
				}
			}
		}

		// RVA: 0x1A64064 Offset: 0x1A64064 VA: 0x1A64064
		public StayButton GetBtn()
		{
			return m_buttonPlate;
		}
	}
}

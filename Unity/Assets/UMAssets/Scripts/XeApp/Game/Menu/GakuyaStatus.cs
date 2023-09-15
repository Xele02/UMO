using UnityEngine;
using TMPro;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;
using System.Text;
using XeSys;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class GakuyaStatus : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI m_textDivaLevel; // 0xC
		[SerializeField]
		private TextMeshProUGUI m_textIntimacyLevel; // 0x10
		[SerializeField]
		private TextMeshProUGUI m_textCostumeCount; // 0x14
		[SerializeField]
		private TextMeshProUGUI m_textDivaRanking; // 0x18
		[SerializeField]
		private TextMeshProUGUI m_textTotal; // 0x1C
		[SerializeField]
		private TextMeshProUGUI m_textDivaStatus; // 0x20
		[SerializeField]
		private TextMeshProUGUI m_textSoulTotalStatus; // 0x24
		[SerializeField]
		private TextMeshProUGUI m_textVoiceTotalStatus; // 0x28
		[SerializeField]
		private TextMeshProUGUI m_textCharmTotalStatus; // 0x2C
		[SerializeField]
		private TextMeshProUGUI m_textCostumeStatus; // 0x30
		[SerializeField]
		private UGUIButton m_buttonDivaRanking; // 0x34
		[SerializeField]
		private ScrollRect m_scroll; // 0x38
		public Action OnClickDivaRankingButtonCallback; // 0x3C
		private JJOELIOGMKK_DivaIntimacyInfo m_intimacyData = new JJOELIOGMKK_DivaIntimacyInfo(); // 0x40
		private StringBuilder m_stringBuilder = new StringBuilder(); // 0x44

		// RVA: 0xB83468 Offset: 0xB83468 VA: 0xB83468
		private void Awake()
		{
			m_buttonDivaRanking.AddOnClickCallback(() =>
			{
				//0xB83E74
				if (OnClickDivaRankingButtonCallback != null)
					OnClickDivaRankingButtonCallback();
			});
		}

		// RVA: 0xB7D0CC Offset: 0xB7D0CC VA: 0xB7D0CC
		public void Setup(FFHPBEPOMAK_DivaInfo divaData)
		{
			m_intimacyData.KHEKNNFCAOI(divaData.AHHJLDLAPAN_DivaId);
			m_textDivaLevel.text = divaData.CIEOBFIIPLD_Level.ToString();
			m_textIntimacyLevel.text = m_intimacyData.HEKJGCMNJAB_CurrentLevel.ToString();
			SetCostumeCount(divaData.AHHJLDLAPAN_DivaId);
			SetDivaRankingInvalid();
			m_textTotal.text = divaData.JLJGCBOHJID_Status.Total.ToString();
			m_textDivaStatus.text = GetDivaBaseTotalStatus(divaData).ToString();
			m_textSoulTotalStatus.text = divaData.IHANGGCHPAL.PNOKIEEILJN().ToString();
			m_textVoiceTotalStatus.text = divaData.IHANGGCHPAL.LCDIGPJJJGI().ToString();
			m_textCharmTotalStatus.text = divaData.IHANGGCHPAL.KDKCMCBLEMG().ToString();
			m_textCostumeStatus.text = divaData.FDFPMGHGBNN().Total.ToString();
		}

		//// RVA: 0xB7311C Offset: 0xB7311C VA: 0xB7311C
		//public void SetScrollTop() { }

		// RVA: 0xB7D3EC Offset: 0xB7D3EC VA: 0xB7D3EC
		public void UpdateDivaRanking(FFHPBEPOMAK_DivaInfo divaData, Action<LAMCONGFONF.OJFOLGKMBIG> success, Action error)
		{
			SetDivaRankingInvalid();
			LAMCONGFONF rankingManager = LAMCONGFONF.HHCJCDFCLOB;
			rankingManager.HDAMBNOFGAN(divaData.AHHJLDLAPAN_DivaId - 1, false);
			rankingManager.HEOKADCEAGL(divaData.AHHJLDLAPAN_DivaId - 1, false, () =>
			{
				//0xB83FA0
				LAMCONGFONF.OJFOLGKMBIG obj = rankingManager.CEPOFDBHIAC(divaData.AHHJLDLAPAN_DivaId - 1, false);
				SetDivaRanking(obj.FJOLNJLLJEJ);
				if (success != null)
					success(obj);
			}, () =>
			{
				//0xB84088
				SetDivaRankingInvalid();
				if (error != null)
					error();
			}, () =>
			{
				//0xB83F04
				MenuScene.Instance.GotoTitle();
			});
		}

		//// RVA: 0xB77CB0 Offset: 0xB77CB0 VA: 0xB77CB0
		//public void UpdateIntimacy() { }

		//// RVA: 0xB83A74 Offset: 0xB83A74 VA: 0xB83A74
		private int GetDivaBaseTotalStatus(FFHPBEPOMAK_DivaInfo divaData)
		{
			BJPLLEBHAGO_DivaInfo d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[divaData.AHHJLDLAPAN_DivaId - 1];
			EPPOHFLMDBC_DivaStats s = d.CMCKNKKCNDK_StatsByLevel[divaData.CIEOBFIIPLD_Level];
			return s.PFJCOCPKABN_Soul + s.JFJDLEMNKFE_Vocal + s.GDOLPGBLMEA_Charm;
		}

		//// RVA: 0xB839D4 Offset: 0xB839D4 VA: 0xB839D4
		private void SetDivaRankingInvalid()
		{
			SetRankingText(m_stringBuilder, TextConstant.InvalidText);
		}

		//// RVA: 0xB83D80 Offset: 0xB83D80 VA: 0xB83D80
		private void SetDivaRanking(int rank)
		{
			if (rank > 0)
				SetRankingText(m_stringBuilder, rank.ToString());
			else
				SetDivaRankingInvalid();
		}

		//// RVA: 0xB83C58 Offset: 0xB83C58 VA: 0xB83C58
		private void SetRankingText(StringBuilder sb, string rank)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			sb.SetFormat(bk.GetMessageByLabel("gakuya_status_diva_ranking_value"), rank);
			m_textDivaRanking.text = sb.ToString();
		}

		//// RVA: 0xB83510 Offset: 0xB83510 VA: 0xB83510
		private void SetCostumeCount(int divaId)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			List<FFHPBEPOMAK_DivaInfo> l = FFHPBEPOMAK_DivaInfo.DNAIGDHCILM_GetCostumeList(divaId, true);
			int cnt = 0;
			int total = 0;
			foreach(var k in l)
			{
				total++;
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cinfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(k.AHHJLDLAPAN_DivaId, k.FFKMJNHFFFL_Costume.JPIDIENBGKH_CostumeId);
				if (k.JLKPGDEKPEO_IsHave)
					cnt++;
				short[] tcols = cinfo.CHDBGFLFPNC_GetAllAvaiableColors();
				short[] cols = cinfo.KKLPLPGBOFD_GetAvaiableColor(k.FFKMJNHFFFL_Costume.GKIKAABHAAD_Level);
				for(int i = 0; i < tcols.Length; i++)
				{
					total++;
					for(int j = 0; j < cols.Length; j++)
					{
						if (tcols[i] == cols[j])
							cnt++;
					}
				}
			}
			m_textCostumeCount.text = cnt.ToString() + bk.GetMessageByLabel("home_diva_view_status_havecostume_now_text") + total.ToString();
		}
	}
}

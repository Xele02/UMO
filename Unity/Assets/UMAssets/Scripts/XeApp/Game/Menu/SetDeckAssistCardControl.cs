using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SetDeckAssistCardControl : MonoBehaviour
	{
		public delegate void OnClickFriendButton(EAJCBFGKKFA_FriendInfo viewFriendData);

		//[TooltipAttribute] // RVA: 0x680198 Offset: 0x680198 VA: 0x680198
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x680198 Offset: 0x680198 VA: 0x680198
		private SetDeckDivaCardControl m_divaCard; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680210 Offset: 0x680210 VA: 0x680210
		private SetDeckSceneControl m_scene; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680258 Offset: 0x680258 VA: 0x680258
		private GameObject m_assistIconObject; // 0x14
		//[TooltipAttribute] // RVA: 0x6802B4 Offset: 0x6802B4 VA: 0x6802B4
		[SerializeField]
		private GameObject m_rivalIconObject; // 0x18
		//[TooltipAttribute] // RVA: 0x680310 Offset: 0x680310 VA: 0x680310
		[SerializeField]
		private Image m_rivalRankImage; // 0x1C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68036C Offset: 0x68036C VA: 0x68036C
		private GameObject m_scoreObject; // 0x20
		//[TooltipAttribute] // RVA: 0x6803D0 Offset: 0x6803D0 VA: 0x6803D0
		[SerializeField]
		private Text m_scoreText; // 0x24
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68042C Offset: 0x68042C VA: 0x68042C
		private GameObject m_tapGuardObject; // 0x28
		//[HeaderAttribute] // RVA: 0x680474 Offset: 0x680474 VA: 0x680474
		//[TooltipAttribute] // RVA: 0x680474 Offset: 0x680474 VA: 0x680474
		[SerializeField] // RVA: 0x680474 Offset: 0x680474 VA: 0x680474
		private List<Sprite> m_rivalRankSprite; // 0x2C
		public OnClickFriendButton OnClickFriend; // 0x30
		private EAJCBFGKKFA_FriendInfo m_viewFriendData; // 0x34

		public bool IsLoading { get { return m_divaCard.IsLoading || m_scene.IsLoading; } } //0xA68204

		// RVA: 0xA682A0 Offset: 0xA682A0 VA: 0xA682A0
		private void Awake()
		{
			if(m_divaCard != null)
			{
				m_divaCard.OnClickDivaButton = () =>
				{
					//0xA6932C
					if(m_viewFriendData != null && OnClickFriend != null)
					{
						OnClickFriend(m_viewFriendData);
					}
				};
			}
		}

		//// RVA: 0xA68384 Offset: 0xA68384 VA: 0xA68384
		public void UpdateContent(EAJCBFGKKFA_FriendInfo friendData, EEDKAACNBBG_MusicData musicData)
		{
			m_viewFriendData = friendData;
			SetDiva(friendData.JIGONEMPPNP_Diva);
			SetScene(friendData.JIGONEMPPNP_Diva, friendData.KHGKPKDBMOH_GetAssistScene(), musicData);
			m_assistIconObject.SetActive(true);
			m_rivalIconObject.SetActive(false);
			m_rivalRankImage.gameObject.SetActive(false);
			m_scoreObject.gameObject.SetActive(false);
			m_tapGuardObject.SetActive(false);
		}

		//// RVA: 0xA6861C Offset: 0xA6861C VA: 0xA6861C
		public void UpdateContent(BKKMNPEEILG ghostData)
		{
			m_viewFriendData = null;
			SetDiva(ghostData.FDBOPFEOENF_RivalData);
			SetScene(ghostData.FDBOPFEOENF_RivalData, ghostData.AFBMEMCHJCL_Scene, null);
			m_assistIconObject.SetActive(false);
			m_rivalIconObject.SetActive(true);
			m_rivalRankImage.gameObject.SetActive(true);
			int idx = ghostData.BHCIFFILAKJ_Str > 2 ? 3 : ghostData.BHCIFFILAKJ_Str;
			m_rivalRankImage.sprite = m_rivalRankSprite[idx];
			m_scoreObject.gameObject.SetActive(true);
			Text t = m_scoreObject.transform.Find("Image_TitleBack/Text_Title").GetComponent<Text>();
			t.text = MessageManager.Instance.GetMessage("menu", JpStringLiterals.StringLiteral_17240);
			if(RuntimeSettings.CurrentSettings.Language != "jp")
			{
				t.alignment = TextAnchor.UpperCenter;
				t.horizontalOverflow = HorizontalWrapMode.Overflow;
			}
			HAEDCCLHEMN_EventBattle ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as HAEDCCLHEMN_EventBattle;
			m_scoreText.text = ev.HOJNMALLCME_GetClassMaxScore(idx, 0).ToString();
			m_tapGuardObject.SetActive(true);
		}

		//// RVA: 0xA68978 Offset: 0xA68978 VA: 0xA68978
		//public void SetImp(SetDeckDivaCardControl.ImpType type) { }

		//// RVA: 0xA68C74 Offset: 0xA68C74 VA: 0xA68C74
		public void SetSkillStatusDisplayType(DisplayType type)
		{
			if(m_viewFriendData!= null)
			{
				m_scene.SetStatusDisplayType(type);
			}
			else
			{
				m_scene.SetStatusDisplayForRival();
			}
		}

		//// RVA: 0xA684F4 Offset: 0xA684F4 VA: 0xA684F4
		private void SetDiva(FFHPBEPOMAK_DivaInfo divaData)
		{
			if(m_divaCard != null)
			{
				m_divaCard.SetForAssist(divaData);
			}
		}

		//// RVA: 0xA685AC Offset: 0xA685AC VA: 0xA685AC
		private void SetScene(FFHPBEPOMAK_DivaInfo divaData, GCIJNCFDNON_SceneInfo sceneData, EEDKAACNBBG_MusicData musicData)
		{
			m_scene.Set(divaData != null ? divaData.AHHJLDLAPAN_DivaId : 0, SetDeckSceneControl.SkillType.Live, sceneData, musicData != null ? musicData.DLAEJOBELBH_MusicId : 0);
		}
	}
}

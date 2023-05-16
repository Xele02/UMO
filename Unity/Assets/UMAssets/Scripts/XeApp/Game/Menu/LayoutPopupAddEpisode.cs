using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAddEpisode : LayoutUGUIScriptBase
	{
		public enum Type
		{
			AddEpisode = 0,
			AvailableEpisode = 1,
			ViewEpisode = 2,
			AddEpisodeListContent = 3,
		}
		
		[SerializeField]
		private Text m_title; // 0x14
		[SerializeField]
		private Text[] m_episodeDesc; // 0x18
		[SerializeField]
		private Text m_divaName; // 0x1C
		[SerializeField]
		private Text m_homeBgName; // 0x20
		[SerializeField]
		private Text[] m_rewardName; // 0x24
		[SerializeField]
		private Text[] m_desc; // 0x28
		[SerializeField]
		private RawImageEx[] m_image; // 0x2C
		[SerializeField]
		private RawImageEx m_episodeImage; // 0x30
		[SerializeField]
		private RawImageEx m_episodeBgImage; // 0x34
		private AbsoluteLayout m_typeTbl; // 0x38
		private AbsoluteLayout m_descTbl; // 0x3C
		private AbsoluteLayout[] m_stringAnim; // 0x40
		private int m_stringIndex; // 0x44
		private Type m_type; // 0x48
		private bool m_isLoadingIcon; // 0x4C
		private bool m_isLoadingEpisodeImage; // 0x4D
		private bool m_isLoadingEpisodeBgImage; // 0x4E
		private List<IEnumerator> m_animList = new List<IEnumerator>(4); // 0x50

		public bool IsOpen { get; private set; } // 0x4F

		//// RVA: 0x15E414C Offset: 0x15E414C VA: 0x15E414C
		public void SetStatus(int episodeId, Type type)
		{
			TodoLogger.Log(0, "SetStatus");
		}

		//// RVA: 0x15E5144 Offset: 0x15E5144 VA: 0x15E5144
		//private int GetDivaIdForCostume(int costumeId) { }

		//// RVA: 0x15E55C0 Offset: 0x15E55C0 VA: 0x15E55C0
		//private int GetPilotIdForValkyrie(int vfId) { }

		//// RVA: 0x15E5274 Offset: 0x15E5274 VA: 0x15E5274
		//private string GetDivaShortName(int divaId) { }

		//// RVA: 0x15E56F0 Offset: 0x15E56F0 VA: 0x15E56F0
		//private string GetPilotName(int pilotId) { }

		//// RVA: 0x15E4CF0 Offset: 0x15E4CF0 VA: 0x15E4CF0
		//private int GetHomeBgId(int bgid) { }

		//// RVA: 0x15E4B0C Offset: 0x15E4B0C VA: 0x15E4B0C
		//private string GetHomeBgName(int bgid) { }

		//// RVA: 0x15E5FEC Offset: 0x15E5FEC VA: 0x15E5FEC
		public bool IsLoading()
		{
			TodoLogger.Log(0, "IsLoading");
			return false;
		}

		//// RVA: 0x15E4914 Offset: 0x15E4914 VA: 0x15E4914
		//private void SetType(LayoutPopupAddEpisode.Type type, EKLNMHFCAOI.FKGCBLHOOCL itemType) { }

		//// RVA: 0x15E5DDC Offset: 0x15E5DDC VA: 0x15E5DDC
		public void SetEpisodeName(string text)
		{
			if(m_title != null)
			{
				m_title.text = text;
			}
		}

		//// RVA: 0x15E5E9C Offset: 0x15E5E9C VA: 0x15E5E9C
		public void SetEpisodeDesc(string text)
		{
			for(int i = 0; i < m_episodeDesc.Length; i++)
			{
				if(m_episodeDesc[i] != null)
				{
					m_episodeDesc[i].text = text;
				}
			}
		}

		//// RVA: 0x15E534C Offset: 0x15E534C VA: 0x15E534C
		//public void SetDivaName(string text) { }

		//// RVA: 0x15E57C8 Offset: 0x15E57C8 VA: 0x15E57C8
		//public void SetPilotName(string text) { }

		//// RVA: 0x15E4C30 Offset: 0x15E4C30 VA: 0x15E4C30
		//public void SetHomeBgName(string text) { }

		//// RVA: 0x15E4A6C Offset: 0x15E4A6C VA: 0x15E4A6C
		public void SetRewardName(string text)
		{
			for(int i = 0; i < m_rewardName.Length; i++)
			{
				m_rewardName[i].text = text;
			}
		}

		//// RVA: 0x15E59B0 Offset: 0x15E59B0 VA: 0x15E59B0
		//private void SetDesc(EKLNMHFCAOI.FKGCBLHOOCL itemType) { }

		//// RVA: 0x15E60B4 Offset: 0x15E60B4 VA: 0x15E60B4
		//private void SwitchDesc(EKLNMHFCAOI.FKGCBLHOOCL itemType) { }

		//// RVA: 0x15E6170 Offset: 0x15E6170 VA: 0x15E6170
		private void SetDesc(string text)
		{
			for(int i = 0; i < m_desc.Length; i++)
			{
				m_desc[i].text = text;
			}
		}

		//// RVA: 0x15E502C Offset: 0x15E502C VA: 0x15E502C
		//public void SetImageIcon(int id) { }

		//// RVA: 0x15E5498 Offset: 0x15E5498 VA: 0x15E5498
		//public void SetImageCostume(int cos_id) { }

		//// RVA: 0x15E5888 Offset: 0x15E5888 VA: 0x15E5888
		//public void SetImageValkyrie(int id) { }

		//// RVA: 0x15E4E14 Offset: 0x15E4E14 VA: 0x15E4E14
		//public void SetImageHomeBg(int id) { }

		//// RVA: 0x15E5B8C Offset: 0x15E5B8C VA: 0x15E5B8C
		//public void SetImageEpisode(int id) { }

		// RVA: 0x15E6210 Offset: 0x15E6210 VA: 0x15E6210
		public void Update()
		{
			for (int i = 0; i < m_animList.Count; i++)
			{
				if (m_animList[i] != null)
				{
					if (!m_animList[i].MoveNext())
					{
						m_animList[i] = null;
					}
				}
			}
		}

		//// RVA: 0x15E63AC Offset: 0x15E63AC VA: 0x15E63AC
		public void ResetData()
		{
			TodoLogger.Log(0, "ResetData");
		}

		//// RVA: 0x15E648C Offset: 0x15E648C VA: 0x15E648C
		public void Show()
		{
			TodoLogger.Log(0, "Show");
		}

		//// RVA: 0x15E6560 Offset: 0x15E6560 VA: 0x15E6560
		public void Hide()
		{
			TodoLogger.Log(0, "Hide");
		}

		//// RVA: 0x15E6630 Offset: 0x15E6630 VA: 0x15E6630
		public void StringIn()
		{
			TodoLogger.Log(0, "StringIn");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70B6D4 Offset: 0x70B6D4 VA: 0x70B6D4
		//// RVA: 0x15E67DC Offset: 0x15E67DC VA: 0x15E67DC
		//private IEnumerator AnimInWait() { }

		// RVA: 0x15E6888 Offset: 0x15E6888 VA: 0x15E6888 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_typeTbl = layout.FindViewByExId("root_pop_ep_sw_pop_ep_all") as AbsoluteLayout;
			m_descTbl = layout.FindViewByExId("sw_pop_ep_all_swtbl_caution_txt") as AbsoluteLayout;
			m_stringAnim = new AbsoluteLayout[4];
			m_stringAnim[0] = layout.FindViewByExId("sw_pop_ep_all_sw_pop_ep_fnt_03_anim") as AbsoluteLayout;
			m_stringAnim[1] = layout.FindViewByExId("sw_pop_ep_all_sw_pop_ep_fnt_04_anim") as AbsoluteLayout;
			m_stringAnim[2] = layout.FindViewByExId("sw_pop_ep_all_sw_pop_ep_fnt_05_anim") as AbsoluteLayout;
			m_stringAnim[3] = layout.FindViewByExId("sw_pop_ep_all_sw_pop_ep_fnt_06_anim") as AbsoluteLayout;
			SetEpisodeName("");
			SetEpisodeDesc("");
			SetRewardName("");
			SetDesc("");
			if(m_episodeImage != null)
			{
				m_episodeImage.uvRect = EpisodeTextuteCache.ImageUv;
			}
			Loaded();
			return true;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x70B74C Offset: 0x70B74C VA: 0x70B74C
		//// RVA: 0x15E6FA8 Offset: 0x15E6FA8 VA: 0x15E6FA8
		//private void <SetImageIcon>b__41_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70B75C Offset: 0x70B75C VA: 0x70B75C
		//// RVA: 0x15E70B8 Offset: 0x15E70B8 VA: 0x15E70B8
		//private void <SetImageCostume>b__42_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70B76C Offset: 0x70B76C VA: 0x70B76C
		//// RVA: 0x15E71C8 Offset: 0x15E71C8 VA: 0x15E71C8
		//private void <SetImageValkyrie>b__43_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70B77C Offset: 0x70B77C VA: 0x70B77C
		//// RVA: 0x15E72D8 Offset: 0x15E72D8 VA: 0x15E72D8
		//private void <SetImageHomeBg>b__44_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70B78C Offset: 0x70B78C VA: 0x70B78C
		//// RVA: 0x15E7498 Offset: 0x15E7498 VA: 0x15E7498
		//private void <SetImageEpisode>b__45_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x70B79C Offset: 0x70B79C VA: 0x70B79C
		//// RVA: 0x15E7578 Offset: 0x15E7578 VA: 0x15E7578
		//private void <SetImageEpisode>b__45_1(IiconTexture texture) { }
	}
}

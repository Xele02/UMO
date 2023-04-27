using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAchieveReward : LayoutUGUIScriptBase
	{
		
		private enum eLayoutArrayIndex
		{
			Clear = 0,
			Score = 4,
			Combo = 8,
			Max = 12,
		}

		private enum eStampStatus
		{
			None = 0,
			Play = 1,
			Press = 2,
			Skip = 3,
		}

		private enum eLayoutType
		{
			None = 0,
			Clear = 1,
			Score = 2,
			Combo = 3,
		}

		public enum eMode
		{
			None = 0,
			MusicSelect = 1,
			Result = 2,
		}

		
		private const int REWARD_ITEM_COUNT = 4;
		private const int REWARD_ITEM_NUM = 12;
		[SerializeField]
		private RawImageEx[] m_icons; // 0x14
		[SerializeField]
		private NumberBase[] m_nums; // 0x18
		[SerializeField]
		private Text[] m_texts; // 0x1C
		[SerializeField]
		private string[] m_layerNames; // 0x20
		[SerializeField]
		private Text m_musicName; // 0x24
		[SerializeField]
		private Text m_clearNum; // 0x28
		[SerializeField]
		private Text m_scoreNum; // 0x2C
		[SerializeField]
		private Text m_comboNum; // 0x30
		[SerializeField]
		private RawImageEx[] m_diffImages = new RawImageEx[5]; // 0x34
		private AbsoluteLayout m_diffLayout; // 0x38
		private AbsoluteLayout[] m_rectLayout = new AbsoluteLayout[12]; // 0x3C
		private AbsoluteLayout[] m_rankLayout = new AbsoluteLayout[12]; // 0x40
		private AbsoluteLayout[] m_stampLayout = new AbsoluteLayout[12]; // 0x44
		private AbsoluteLayout[] m_stampPlayingLayout = new AbsoluteLayout[12]; // 0x48
		private AbsoluteLayout[] m_stampPlayingFirstLayout = new AbsoluteLayout[12]; // 0x4C
		private AbsoluteLayout[] m_stampPressLayout = new AbsoluteLayout[12]; // 0x50
		private AbsoluteLayout[] m_comboRankIconLayout = new AbsoluteLayout[12]; // 0x54
		private AbsoluteLayout m_stampFirstShadow; // 0x58
		private List<int> m_stampPlayList = new List<int>(12); // 0x5C
		private List<IEnumerator> m_animationEnumerator = new List<IEnumerator>(12); // 0x60
		private bool m_isSkip; // 0x64
		private TexUVListManager m_uvMan; // 0x68
		private static readonly string[] DiffObjTable = new string[5] {
			"cmn_music_diff_01 (ImageView)",
			"swtexc_cmn_music_diff_02 (ImageView)",
			"cmn_music_diff_03 (ImageView)",
			"swtexc_cmn_music_diff_04 (ImageView)",
			"cmn_music_diff_05 (ImageView)"
		}; // 0x0
		private static readonly string[] DiffTexTable = new string[5] {
			"cmn_music_diff_01",
			"cmn_music_diff_02",
			"cmn_music_diff_03",
			"cmn_music_diff_04",
			"cmn_music_diff_05"
		}; // 0x4
		private static readonly string[] DiffTexTable_6Line = new string[3] {
			"cmn_music_diff_06",
			"cmn_music_diff_07",
			"cmn_music_diff_08"
		}; // 0x8
		private eMode m_sceneType = eMode.MusicSelect; // 0x6C
		private int m_firstStampIndex = -1; // 0x70

		//// RVA: 0x15DDAD0 Offset: 0x15DDAD0 VA: 0x15DDAD0
		private void SwitchStampAnim(int arrayIndex, eStampStatus status)
		{
			if (m_stampLayout.Length <= arrayIndex)
				return;
			if (m_stampLayout[arrayIndex] == null)
				return;
			if (m_stampPressLayout[arrayIndex] != null)
			{
				m_stampPressLayout[arrayIndex].StartChildrenAnimGoStop("01");
			}
			switch(status)
			{
				case eStampStatus.None:
					m_stampLayout[arrayIndex].StartAllAnimGoStop("st_wait");
					break;
				case eStampStatus.Play:
					m_stampLayout[arrayIndex].StartAllAnimGoStop("go_in", "st_in");
					break;
				case eStampStatus.Press:
					if (m_stampPressLayout[arrayIndex] == null)
						return;
					m_stampPressLayout[arrayIndex].StartChildrenAnimGoStop("02");
					break;
				case eStampStatus.Skip:
					m_stampLayout[arrayIndex].StartAllAnimGoStop("st_in", "st_in");
					break;
			}
		}

		//// RVA: 0x15DDE48 Offset: 0x15DDE48 VA: 0x15DDE48
		//private void SwitchStampFirst(int arrayIndex) { }

		//// RVA: 0x15DDFD4 Offset: 0x15DDFD4 VA: 0x15DDFD4
		//private bool IsPlayingStampAnim(int arrayIndex) { }

		//// RVA: 0x15DE0B0 Offset: 0x15DE0B0 VA: 0x15DE0B0
		public void PlayStampAnim()
		{
			if (m_stampPlayList.Count == 0)
				return;
			m_animationEnumerator.Add(PlayStampAnimInner());
		}

		//// RVA: 0x15DE1F8 Offset: 0x15DE1F8 VA: 0x15DE1F8
		//private void PlaySeStamp() { }

		//[IteratorStateMachineAttribute] // RVA: 0x703E5C Offset: 0x703E5C VA: 0x703E5C
		//// RVA: 0x15DE16C Offset: 0x15DE16C VA: 0x15DE16C
		private IEnumerator PlayStampAnimInner()
		{
			int index; // 0x14
			float waitCounter; // 0x18
			float wait; // 0x1C

			//0x15E1820
			TodoLogger.Log(0, "PlayStampAnimInner");
			yield return null;
		}

		//// RVA: 0x15DE270 Offset: 0x15DE270 VA: 0x15DE270
		//private bool IsEndAllPlayStampAnimInner() { }

		//// RVA: 0x15DE348 Offset: 0x15DE348 VA: 0x15DE348
		public bool IsEndAllPlayStampAnim()
		{
			return m_animationEnumerator.Count < 1;
		}

		//// RVA: 0x15DE3D0 Offset: 0x15DE3D0 VA: 0x15DE3D0
		public void PlayStampSkip()
		{
			if (m_animationEnumerator.Count > 0)
				m_isSkip = true;
		}

		//// RVA: 0x15DE454 Offset: 0x15DE454 VA: 0x15DE454
		public void SetupReward(string music_name, int difficulty, FPGEMAIAMBF_RewardData viewData, IBJAKJJICBC viewMusic, bool isLine6Mode)
		{
			SetMusicName(music_name, viewMusic.FKDCCLPGKDK_JacketAttr);
			SwitchDifficulty((Difficulty.Type)difficulty, isLine6Mode);
			int cnt = Mathf.Min(difficulty, viewMusic.MGJKEJHEBPO_DiffInfos.Count - 1);
			SetClearNumber(viewMusic.MGJKEJHEBPO_DiffInfos[cnt].JNLKJCDFFMM_Clear);
			SetScoreNumber(viewMusic.MGJKEJHEBPO_DiffInfos[cnt].KNIFCANOHOC_Score);
			SetComboNumber(viewMusic.MGJKEJHEBPO_DiffInfos[cnt].NLKEBAOBJCM_Combo);
			m_stampPlayList.Clear();
			for(int i = 0; i < viewData.PDONJHCHBAE_ScoreReward.Count; i++)
			{
				SetRewardStatus(i + 4, viewData.PDONJHCHBAE_ScoreReward[i], false);
				SwitchRank(i + 4, (ResultScoreRank.Type) viewData.PDONJHCHBAE_ScoreReward[i].FCDKJAKLGMB_TargetValue);
			}
			for (int i = 0; i < viewData.HFPMKBAANFO_ComboReward.Count; i++)
			{
				SetRewardStatus(i + 8, viewData.HFPMKBAANFO_ComboReward[i], false);
				SwitchComboRank(i + 8, (ResultScoreRank.Type)viewData.HFPMKBAANFO_ComboReward[i].FCDKJAKLGMB_TargetValue);
			}
			for (int i = 0; i < viewData.IOCLNNCJFKA_ClearReward.Count; i++)
			{
				SetRewardStatus(i, viewData.IOCLNNCJFKA_ClearReward[i], false);
			}
		}

		//// RVA: 0x15DEB48 Offset: 0x15DEB48 VA: 0x15DEB48
		public void SwitchDifficulty(Difficulty.Type diff, bool isLine6Mode)
		{
			if (m_diffLayout == null)
				return;
			switch(diff)
			{
				case Difficulty.Type.Easy:
					m_diffLayout.StartAllAnimGoStop("01");
					break;
				case Difficulty.Type.Normal:
					m_diffLayout.StartAllAnimGoStop("02");
					break;
				case Difficulty.Type.Hard:
					m_diffLayout.StartAllAnimGoStop("03");
					break;
				case Difficulty.Type.VeryHard:
					m_diffLayout.StartAllAnimGoStop("04");
					break;
				case Difficulty.Type.Extreme:
					m_diffLayout.StartAllAnimGoStop("05");
					break;
				default:
					break;
			}
			LayoutCommonTextureManager.CommonTexture tex;
			string key;
			if (!isLine6Mode)
			{
				key = DiffTexTable[(int)diff];
				tex = GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack");
			}
			else
			{
				key = DiffTexTable_6Line[(int)diff - 2];
				tex = GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_02_pack");
			}
			tex.Set(m_diffImages[(int)diff]);
			m_diffImages[(int)diff].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(key));
		}

		//// RVA: 0x15DE9E8 Offset: 0x15DE9E8 VA: 0x15DE9E8
		public void SetMusicName(string name, int musicAttr)
		{
			if(m_musicName != null)
			{
				m_musicName.text = string.Format("<color={0}>{1}</color>", GameAttributeTextColor.Colors[musicAttr - 1], name);
			}
		}

		//// RVA: 0x15DEF58 Offset: 0x15DEF58 VA: 0x15DEF58
		public void SetClearNumber(int num)
		{
			if(m_clearNum != null)
			{
				m_clearNum.text = string.Format("{0}", num);
			}
		}

		//// RVA: 0x15DF05C Offset: 0x15DF05C VA: 0x15DF05C
		public void SetScoreNumber(int num)
		{
			if (m_scoreNum != null)
			{
				m_scoreNum.text = string.Format("{0}", num);
			}
		}

		//// RVA: 0x15DF160 Offset: 0x15DF160 VA: 0x15DF160
		public void SetComboNumber(int num)
		{
			if (m_comboNum != null)
			{
				m_comboNum.text = string.Format("{0}", num);
			}
		}

		//// RVA: 0x15DF8F4 Offset: 0x15DF8F4 VA: 0x15DF8F4
		public void SetIcon(int rewardIndex, int iconId)
		{
			if (m_icons.Length <= rewardIndex)
				return;
			if (m_icons[rewardIndex] == null)
				return;
			RawImageEx image = m_icons[rewardIndex];
			GameManager.Instance.ItemTextureCache.Load(iconId, (IiconTexture texture) =>
			{
				//0x15E1740
				if (texture == null)
					return;
				texture.Set(image);
			});
		}

		//// RVA: 0x15DFB00 Offset: 0x15DFB00 VA: 0x15DFB00
		private void SetItemNumber(int arrayIndex, int num)
		{
			if (m_nums.Length <= arrayIndex)
				return;
			if (m_nums[arrayIndex] == null)
				return;
			m_nums[arrayIndex].SetNumber(num);
		}

		//// RVA: 0x15DFC20 Offset: 0x15DFC20 VA: 0x15DFC20
		private void SetThresholdNumber(int arrayIndex, string text)
		{
			if (m_texts.Length <= arrayIndex)
				return;
			if (m_texts[arrayIndex] == null)
				return;
			m_texts[arrayIndex].text = text;
		}

		//// RVA: 0x15DF264 Offset: 0x15DF264 VA: 0x15DF264
		private void SetRewardStatus(int arrayIndex, FPGEMAIAMBF_RewardData.LOIJICNJMKA reward, bool isAllClear = false)
		{
			if (reward == null)
				return;
			string txt;
			if(isAllClear)
			{
				txt = MessageManager.Instance.GetBank("menu").GetMessageByLabel("reward_all_clear_text_00");
			}
			else
			{
				txt = string.Format("{0}", reward.FCDKJAKLGMB_TargetValue);
			}
			SetThresholdNumber(arrayIndex, txt);
			SetItemNumber(arrayIndex, reward.JDLJPNMLFID);
			SetIcon(arrayIndex, reward.KIJAPOFAGPN_GlobalItemId);
			if(reward.CMCKNKKCNDK_Achieved != FPGEMAIAMBF_RewardData.LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA/*0*/)
			{
				if(reward.CMCKNKKCNDK_Achieved == FPGEMAIAMBF_RewardData.LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL/*1*/)
				{
					SwitchStampAnim(arrayIndex, eStampStatus.Press);
					return;
				}
				if (reward.CMCKNKKCNDK_Achieved != FPGEMAIAMBF_RewardData.LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved/*2*/)
					return;
				m_stampPlayList.Add(arrayIndex);
			}
			SwitchStampAnim(arrayIndex, eStampStatus.None);
		}

		//// RVA: 0x15DFD3C Offset: 0x15DFD3C VA: 0x15DFD3C
		//private void DeleteImage(ref RawImageEx image) { }

		//// RVA: 0x15DFDDC Offset: 0x15DFDDC VA: 0x15DFDDC
		private void SwitchLayoutType(int arrayIndex, eLayoutType layoutType)
		{
			if (m_rectLayout.Length <= arrayIndex)
				return;
			if(layoutType == eLayoutType.Combo)
			{
				m_rectLayout[arrayIndex].StartChildrenAnimGoStop("03");
			}
			else if (layoutType == eLayoutType.Score)
			{
				m_rectLayout[arrayIndex].StartChildrenAnimGoStop("02");
			}
			else if (layoutType == eLayoutType.Clear)
			{
				m_rectLayout[arrayIndex].StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x15DF424 Offset: 0x15DF424 VA: 0x15DF424
		private void SwitchRank(int arrayIndex, ResultScoreRank.Type rank)
		{
			if (m_rankLayout.Length <= arrayIndex)
				return;
			switch(rank)
			{
				case ResultScoreRank.Type.C:
					m_rankLayout[arrayIndex].StartChildrenAnimGoStop("01");
					break;
				case ResultScoreRank.Type.B:
					m_rankLayout[arrayIndex].StartChildrenAnimGoStop("02");
					break;
				case ResultScoreRank.Type.A:
					m_rankLayout[arrayIndex].StartChildrenAnimGoStop("03");
					break;
				case ResultScoreRank.Type.S:
					m_rankLayout[arrayIndex].StartChildrenAnimGoStop("04");
					break;
				case ResultScoreRank.Type.SS:
					m_rankLayout[arrayIndex].StartChildrenAnimGoStop("05");
					break;
				default:
					break;
			}
		}

		//// RVA: 0x15DF68C Offset: 0x15DF68C VA: 0x15DF68C
		private void SwitchComboRank(int arrayIndex, ResultScoreRank.Type rank)
		{
			if (m_comboRankIconLayout.Length <= arrayIndex)
				return;
			switch(rank)
			{
				case ResultScoreRank.Type.C:
					m_comboRankIconLayout[arrayIndex].StartChildrenAnimGoStop("01");
					break;
				case ResultScoreRank.Type.B:
					m_comboRankIconLayout[arrayIndex].StartChildrenAnimGoStop("02");
					break;
				case ResultScoreRank.Type.A:
					m_comboRankIconLayout[arrayIndex].StartChildrenAnimGoStop("03");
					break;
				case ResultScoreRank.Type.S:
					m_comboRankIconLayout[arrayIndex].StartChildrenAnimGoStop("04");
					break;
				case ResultScoreRank.Type.SS:
					m_comboRankIconLayout[arrayIndex].StartChildrenAnimGoStop("05");
					break;
				default:
					return;
			}
		}

		// RVA: 0x15DFF80 Offset: 0x15DFF80 VA: 0x15DFF80
		public void Reset()
		{
			return;
		}

		//// RVA: 0x15DFF84 Offset: 0x15DFF84 VA: 0x15DFF84
		public void Show()
		{
			return;
		}

		//// RVA: 0x15DFF88 Offset: 0x15DFF88 VA: 0x15DFF88
		//public void Hide() { }

		// RVA: 0x15DFF8C Offset: 0x15DFF8C VA: 0x15DFF8C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			m_diffLayout = layout.FindViewByExId("sw_pop_reward_swtbl_pop_reward_diffi") as AbsoluteLayout;
			m_stampFirstShadow = layout.FindViewByExId("sw_pop_reward_sw_pop_reward_base_info_clear_first_sdw_anim") as AbsoluteLayout;
			for(int i = 0; i < m_layerNames.Length; i++)
			{
				string s = m_layerNames[i].Insert(m_layerNames[i].Length - 2, "eff_");
				m_stampLayout[i] = layout.FindViewByExId("sw_pop_reward_" + s) as AbsoluteLayout;
				if(m_stampLayout[i] != null)
				{
					m_stampPlayingFirstLayout[i] = m_stampLayout[i].FindViewByExId("swtbl_pop_reward_base_info_clear_eff_sw_pop_reward_base_info_clear_first_anim") as AbsoluteLayout;
					m_stampPlayingLayout[i] = m_stampLayout[i].FindViewByExId("swtbl_pop_reward_base_info_clear_eff_sw_pop_reward_base_info_clear_anim") as AbsoluteLayout;
				}
				AbsoluteLayout v = layout.FindViewByExId("sw_pop_reward_" + m_layerNames[i]) as AbsoluteLayout;
				if(v != null)
				{
					m_stampPressLayout[i] = v.FindViewByExId("sw_pop_reward_" + m_layerNames[i]) as AbsoluteLayout;
					m_rectLayout[i] = v.FindViewByExId("swtbl_pop_reward_base_info_clear_onof_swtbl_pop_reward_base_info") as AbsoluteLayout;
				}
				if(m_rectLayout[i] != null)
				{
					m_rankLayout[i] = m_rectLayout[i].FindViewByExId("swtbl_pop_reward_base_info_swtbl_cmn_rank_icon") as AbsoluteLayout;
					m_comboRankIconLayout[i] = m_rectLayout[i].FindViewByExId("swtbl_pop_reward_base_info_swtbl_pop_reward_rank_cmb") as AbsoluteLayout;
				}
			}
			for(int i = 0; i < 4; i++)
			{
				SwitchLayoutType(i, eLayoutType.Clear);
			}
			for (int i = 4; i < 8; i++)
			{
				SwitchLayoutType(i, eLayoutType.Score);
			}
			for (int i = 8; i < 12; i++)
			{
				SwitchLayoutType(i, eLayoutType.Combo);
			}
			for(int i = 0; i < m_texts.Length; i++)
			{
				m_texts[i].text = "";
			}
			SetMusicName("", 1);
			SetClearNumber(0);
			SetScoreNumber(0);
			SetComboNumber(0);
			Loaded();
			return true;
		}

		// RVA: 0x15E0DC8 Offset: 0x15E0DC8 VA: 0x15E0DC8
		public void Update()
		{
			if(m_animationEnumerator.Count > 0)
			{
				if (!m_animationEnumerator[0].MoveNext())
					m_animationEnumerator.RemoveAt(0);
			}
		}
	}
}

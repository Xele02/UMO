using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutGachaSkillUpPopup : LayoutUGUIScriptBase
	{
		private const string LevelFormat = "Lv{0}";
		[SerializeField]
		private RawImageEx PrePlateImage; // 0x14
		[SerializeField]
		private RawImageEx NextPlateImage; // 0x18
		[SerializeField]
		private RawImageEx PrePlateRank; // 0x1C
		[SerializeField]
		private RawImageEx NextPlateRank; // 0x20
		[SerializeField]
		private Text PrePlateName; // 0x24
		[SerializeField]
		private Text NextPlateName; // 0x28
		[SerializeField]
		private Text PrePlateLevel; // 0x2C
		[SerializeField]
		private Text NextPlateLevel; // 0x30
		[SerializeField]
		private Text PrePlateText; // 0x34
		[SerializeField]
		private Text NextPlateText; // 0x38
		private AbsoluteLayout popupTitle; // 0x3C
		private AbsoluteLayout preSkillType; // 0x40
		private AbsoluteLayout nextSkillType; // 0x44
		private bool IsPreImage; // 0x48
		private bool IsNextImage; // 0x49

		// RVA: 0x1D4DAB8 Offset: 0x1D4DAB8 VA: 0x1D4DAB8
		public void Setup(int _sceneId, GCIJNCFDNON_SceneInfo.DLAMEBMGKDO type)
		{
			GCIJNCFDNON_SceneInfo s1 = new GCIJNCFDNON_SceneInfo();
			GCIJNCFDNON_SceneInfo s2 = new GCIJNCFDNON_SceneInfo();
			s1.KHEKNNFCAOI(_sceneId, null, null, 0, 0, 0, false, 0, 0);
			s2.KHEKNNFCAOI(_sceneId, null, null, 1, 0, 0, false, 0, 0);
			GameManager.Instance.SceneIconCache.Load(_sceneId, 1, (IiconTexture image) =>
			{
				//0x1D4ED20
				if(PrePlateImage != null)
				{
					image.Set(PrePlateImage);
					IsPreImage = true;
				}
			});
			GameManager.Instance.SceneIconCache.Load(_sceneId, 2, (IiconTexture image) =>
			{
				//0x1D4EE50
				if(NextPlateImage != null)
				{
					image.Set(NextPlateImage);
					IsNextImage = true;
				}
			});
			PrePlateName.text = GameMessageManager.GetSceneCardName(s1);
			NextPlateName.text = GameMessageManager.GetSceneCardName(s2);
			PrePlateText.horizontalOverflow = HorizontalWrapMode.Wrap;
			PrePlateText.verticalOverflow = VerticalWrapMode.Overflow;
			NextPlateText.horizontalOverflow = HorizontalWrapMode.Wrap;
			NextPlateText.verticalOverflow = VerticalWrapMode.Overflow;
			if(type == GCIJNCFDNON_SceneInfo.DLAMEBMGKDO.OONCLCEAICE)
				SetLiveSkill(s1, s2);
			else if(type == GCIJNCFDNON_SceneInfo.DLAMEBMGKDO.DFAPCDGNNPN)
				SetCenterSkill(s1, s2);
			else if(type == GCIJNCFDNON_SceneInfo.DLAMEBMGKDO.DJECFFENCND)
				SetActiveSkill(s1, s2);
		}

		// // RVA: 0x1D4DED8 Offset: 0x1D4DED8 VA: 0x1D4DED8
		public void SetActiveSkill(GCIJNCFDNON_SceneInfo view1, GCIJNCFDNON_SceneInfo view2)
		{
			PrePlateLevel.text = string.Format("Lv{0}", view1.PNHJPCPFNFI_ActiveSkillLevel);
			NextPlateLevel.text = string.Format("Lv{0}", view2.PNHJPCPFNFI_ActiveSkillLevel);
			PrePlateText.text = view1.PCMEMHPDABG_GetActiveSkillDesc();
			NextPlateText.text = view2.PCMEMHPDABG_GetActiveSkillDesc();
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(PrePlateRank, (SkillRank.Type) view1.BEKGEAMJGEN_ActiveSkillRank);
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(NextPlateRank, (SkillRank.Type) view2.BEKGEAMJGEN_ActiveSkillRank);
			preSkillType.StartChildrenAnimGoStop("01");
			nextSkillType.StartChildrenAnimGoStop("01");
		}

		// // RVA: 0x1D4E1E0 Offset: 0x1D4E1E0 VA: 0x1D4E1E0
		public void SetCenterSkill(GCIJNCFDNON_SceneInfo view1, GCIJNCFDNON_SceneInfo view2)
		{
			PrePlateLevel.text = string.Format("Lv{0}", view1.DDEDANKHHPN_SkillLevel);
			NextPlateLevel.text = string.Format("Lv{0}", view2.DDEDANKHHPN_SkillLevel);
			PrePlateText.text = view1.IHLINMFMCDN_GetCenterSkillDesc(false);
			NextPlateText.text = view2.IHLINMFMCDN_GetCenterSkillDesc(false);
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(PrePlateRank, (SkillRank.Type) view1.DHEFMEGKKDN_CenterSkillRank);
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(NextPlateRank, (SkillRank.Type) view2.DHEFMEGKKDN_CenterSkillRank);
			preSkillType.StartChildrenAnimGoStop("02");
			nextSkillType.StartChildrenAnimGoStop("02");
		}

		// // RVA: 0x1D4E4F0 Offset: 0x1D4E4F0 VA: 0x1D4E4F0
		public void SetLiveSkill(GCIJNCFDNON_SceneInfo view1, GCIJNCFDNON_SceneInfo view2)
		{
			PrePlateLevel.text = string.Format("Lv{0}", view1.AADFFCIDJCB_LiveSkillLevel);
			NextPlateLevel.text = string.Format("Lv{0}", view2.AADFFCIDJCB_LiveSkillLevel);
			PrePlateText.text = view1.KDGACEJPGFG_GetLiveSkillDesc(false);
			NextPlateText.text = view2.KDGACEJPGFG_GetLiveSkillDesc(false);
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(PrePlateRank, (SkillRank.Type) view1.OAHMFMJIENM_LiveSkillRank);
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(NextPlateRank, (SkillRank.Type) view2.OAHMFMJIENM_LiveSkillRank);
			preSkillType.StartChildrenAnimGoStop("03");
			nextSkillType.StartChildrenAnimGoStop("03");
		}

		// RVA: 0x1D4E800 Offset: 0x1D4E800 VA: 0x1D4E800
		public void Enter()
		{
			popupTitle.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_EnterAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x703934 Offset: 0x703934 VA: 0x703934
		// // RVA: 0x1D4E8A4 Offset: 0x1D4E8A4 VA: 0x1D4E8A4
		private IEnumerator Co_EnterAnim()
		{
			//0x1D4EF84
			yield return null;
			while(popupTitle.IsPlaying())
			{
				;
			}
			Loop();
		}

		// // RVA: 0x1D4E950 Offset: 0x1D4E950 VA: 0x1D4E950
		private void Loop()
		{
			popupTitle.StartChildrenAnimLoop("logo_up");
		}

		// // RVA: 0x1D4E9CC Offset: 0x1D4E9CC VA: 0x1D4E9CC
		// public void Hide() { }

		// RVA: 0x1D4EA48 Offset: 0x1D4EA48 VA: 0x1D4EA48
		public bool IsSettingEnd()
		{
			return IsPreImage && IsNextImage;
		}

		// RVA: 0x1D4EA68 Offset: 0x1D4EA68 VA: 0x1D4EA68 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			popupTitle = layout.FindViewByExId("sw_window_swpop_skill_ul_title_anim") as AbsoluteLayout;
			preSkillType = (layout.FindViewByExId("sw_window_content_00") as AbsoluteLayout).FindViewByExId("content_skill_a") as AbsoluteLayout;
			nextSkillType = (layout.FindViewByExId("sw_window_content_01") as AbsoluteLayout).FindViewByExId("content_skill_a") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}

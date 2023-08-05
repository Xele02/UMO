using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.RhythmGame;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlaylogDetailSkill : LayoutUGUIScriptBase
	{
		private TexUVListManager m_UvMan; // 0x14
		private Mask m_Mask; // 0x18
		private Text m_NameText; // 0x1C
		private Text m_LevelText; // 0x20
		private Text m_ExplainText; // 0x24
		private RawImageEx m_SceneTex; // 0x28
		private RawImageEx m_RankTex; // 0x2C

		// RVA: 0x1D04DF0 Offset: 0x1D04DF0 VA: 0x1D04DF0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_UvMan = uvMan;
			m_Mask = GetComponentInParent<Mask>();
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_NameText = txts.Where((Text _) =>
			{
				//0x1D05978
				return _.name == "skillname (TextView)";
			}).First();
			m_LevelText = txts.Where((Text _) =>
			{
				//0x1D059F8
				return _.name == "skill_lv_01 (TextView)";

			}).First();
			m_ExplainText = txts.Where((Text _) =>
			{
				//0x1D05A78
				return _.name == "skilltxt (TextView)";
			}).First();
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_SceneTex = imgs.Where((RawImageEx _) =>
			{
				//0x1D05AF8
				return _.name == "swtex_cmn_scene_icon (ImageView)";
			}).First();
			m_RankTex = imgs.Where((RawImageEx _) =>
			{
				//0x1D05B78
				return _.name == "swtexf_cmn_skill_rank_icon_02 (ImageView)";
			}).First();
			Hide();
			Loaded();
			return true;
		}

		//// RVA: 0x1D03ED8 Offset: 0x1D03ED8 VA: 0x1D03ED8
		public void Enter(RectTransform rt, RhythmGamePlayLog.SkillData data)
		{
			this.StopAllCoroutinesWatched();
			this.StartCoroutineWatched(Co_Enter(rt, data));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71CF14 Offset: 0x71CF14 VA: 0x71CF14
		//// RVA: 0x1D05438 Offset: 0x1D05438 VA: 0x1D05438
		private IEnumerator Co_Enter(RectTransform rt, RhythmGamePlayLog.SkillData data)
		{
			//0x1D05BFC
			GetComponent<RectTransform>().position = rt.position;
			GetComponent<RectTransform>().anchoredPosition += new Vector2(rt.sizeDelta.x, -rt.sizeDelta.y) * 0.5f;
			MessageBank bk = MessageManager.Instance.GetBank("master");
			if(!data.isActive)
			{
				m_NameText.text = bk.GetMessageByLabel("l_nm_" + data.skillId.ToString("D4"));
				m_RankTex.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_UvMan.GetUVData(string.Format("cmn_skill_rank_icon_{0:00}", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[data.skillId - 1].JGNHOGKKPDM)));
				m_ExplainText.text = GetLiveSkillComment(bk.GetMessageByLabel("l_dsc_" + data.skillId.ToString("D4")), data.skillId, data.skillLevel);
			}
			else
			{
				m_NameText.text = bk.GetMessageByLabel("a_nm_" + data.skillId.ToString("D4"));
				m_RankTex.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_UvMan.GetUVData(string.Format("cmn_skill_rank_icon_{0:00}", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[data.skillId - 1].JGNHOGKKPDM)));
				m_ExplainText.text = GetActiveSkillComment(bk.GetMessageByLabel("a_dsc_" + data.skillId.ToString("D4")), data.skillId, data.skillLevel);
			}
			m_LevelText.text = string.Format("Lv{0}", data.skillLevel);
			m_ExplainText.horizontalOverflow = HorizontalWrapMode.Wrap;
			int rank = 1;
			if(data.sceneId > 0)
			{
				rank = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[data.sceneId - 1].CGIELKDLHGE_GetEvolveId();
			}
			GameManager.Instance.SceneIconCache.Load(data.sceneId, rank, (IiconTexture texture) =>
			{
				//0x1D0581C
				texture.Set(m_SceneTex);
			});
			yield return null;
			Show();
		}

		//// RVA: 0x1D02624 Offset: 0x1D02624 VA: 0x1D02624
		public void Leave()
		{
			this.StopAllCoroutinesWatched();
			Hide();
		}

		//// RVA: 0x1D05544 Offset: 0x1D05544 VA: 0x1D05544
		private string GetActiveSkillComment(string comment, int id, int level)
		{
			if (id < 1)
				return comment;
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[id - 1].KMFMGLENCJH_FormatDesc(comment, level);
		}

		//// RVA: 0x1D05694 Offset: 0x1D05694 VA: 0x1D05694
		private string GetLiveSkillComment(string comment, int id, int level)
		{
			if (id < 1)
				return comment;
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[id - 1].KMFMGLENCJH_FormatDesc(comment, level);
		}

		//// RVA: 0x1D057E4 Offset: 0x1D057E4 VA: 0x1D057E4
		private void Show()
		{
			m_Mask.enabled = false;
		}

		//// RVA: 0x1D05408 Offset: 0x1D05408 VA: 0x1D05408
		private void Hide()
		{
			m_Mask.enabled = true;
		}
	}
}

using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneIconDecorationBehaviour : MonoBehaviour, ILayoutUGUIPaste
	{
		[SerializeField]
		private Text[] m_texts; // 0xC
		[SerializeField]
		private RawImageEx[] m_skillImages; // 0x10
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve; // 0x14
		[SerializeField]
		private EpisodeNameParts m_episodeNamePrefab; // 0x18
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x1C
		private TexUVListManager m_uvManager; // 0x20
		private EpisodeNameParts m_episodeNameParts; // 0x24
		private Image m_episodeNameImage; // 0x28
		private Text m_episodeNameText; // 0x2C
		private RectTransform m_episodeNameRectTransform; // 0x30
		private const string m_uvName = "cmn_s_s_icon_skill_{0:D2}";
		private bool isMax; // 0x34
		private bool isShowLeaf; // 0x35
		private bool isMultiSkill; // 0x36
		private bool isChangedSkillIcon; // 0x37
		private const float BaseImageWidth = 218;
		private const float BaseImageHeight = 36;
		private const float MinImageHeight = 28;
		private const float BaseFontSize = 18;
		private const int lackyLeafFontSize = 16;
		private const int lackyLeafSmallFontSize = 10;
		private const int lackyLeafStringAreaBaseSize = 109;

		// RVA: 0x136D47C Offset: 0x136D47C VA: 0x136D47C Slot: 4
		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime ui = GetComponentInParent<LayoutUGUIRuntime>();
			for (int i = 0; i < m_texts.Length; i++)
			{
				m_texts[i].font = ui.Font;
				m_texts[i].material = ui.Font.material;
			}
			m_episodeNameParts = Instantiate(m_episodeNamePrefab);
			m_episodeNameImage = m_episodeNameParts.GetComponent<Image>();
			m_episodeNameText = m_episodeNameParts.GetComponentInChildren<Text>();
			m_episodeNameRectTransform = m_episodeNameParts.GetComponent<RectTransform>();
			m_episodeNameText.font = GameManager.Instance.GetSystemFont();
			m_episodeNameParts.transform.SetParent(transform);
			m_uvManager = uvMan;
			return true;
		}

		//// RVA: 0x136A620 Offset: 0x136A620 VA: 0x136A620
		public void AdjustEpisodeName(RectTransform sceneImage, Vector2 scale)
		{
			m_episodeNameRectTransform.sizeDelta = new Vector2(sceneImage.sizeDelta.x, Mathf.Clamp(sceneImage.sizeDelta.x / 218.0f * 36.0f, 28.0f, 36.0f));
			m_episodeNameRectTransform.localScale = new Vector3(1.0f / scale.x, 1.0f / scale.x, 1);
			m_episodeNameRectTransform.anchoredPosition = sceneImage.sizeDelta * 0.5f * (1.0f / scale.x);
			m_episodeNameText.fontSize = Mathf.CeilToInt(sceneImage.sizeDelta.x / 218.0f * 18.0f);
		}

		//// RVA: 0x136C6C8 Offset: 0x136C6C8 VA: 0x136C6C8
		//public void SetValue(int value, bool isShowLevel, bool isMax, bool isFeed) { }

		//// RVA: 0x136C384 Offset: 0x136C384 VA: 0x136C384
		//public void SetFraction(int num, int den) { }

		//// RVA: 0x136CA18 Offset: 0x136CA18 VA: 0x136CA18
		//public void SetLuck(int value, int leafCount, bool isVisible) { }

		//// RVA: 0x136B190 Offset: 0x136B190 VA: 0x136B190
		//public void SetEpisode(int episodeId, int level, bool isMax, bool isFeed) { }

		//// RVA: 0x136B59C Offset: 0x136B59C VA: 0x136B59C
		//public void SetLuckyLeafCount(int leafCount, int releaseAbleLeafCount) { }

		//// RVA: 0x136BDB8 Offset: 0x136BDB8 VA: 0x136BDB8
		//public void SetSkillIcon(int iconId, int iconId2, bool isActive) { }

		//// RVA: 0x136D804 Offset: 0x136D804 VA: 0x136D804
		//private void SetLevel(int level, bool isMax, bool isFeed) { }

		//// RVA: 0x136BA9C Offset: 0x136BA9C VA: 0x136BA9C
		//public void SetSpecialNoteAttribute(SpecialNoteAttribute.Type type, int value) { }

		//// RVA: 0x136CF44 Offset: 0x136CF44 VA: 0x136CF44
		public void UpdateMaxAnime(float time)
		{
			if(m_animeCurve != null)
			{
				for(int i = 0; i < m_animeCurve.Count; i++)
				{
					bool b = isMax;
					bool c = !b;
					if (c)
						b = isShowLeaf;
					if((!c || b) || isMultiSkill)
					{
						float val = m_animeCurve[i].Evaluate(time);
						if(isMax)
						{
							m_texts[i].color = new Color(1, 1, 1, val);
						}
						if(isShowLeaf)
						{
							m_texts[1 + i * 3].color = new Color(1, 1, 1, val);
						}
						if(isMultiSkill)
						{
							m_skillImages[i].color = new Color(1, 1, 1, val);
						}
					}
				}
			}
		}
	}
}

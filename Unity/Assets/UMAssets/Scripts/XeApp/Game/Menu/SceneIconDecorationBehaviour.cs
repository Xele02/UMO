using System;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
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
			BundleShaderInfo.Instance.FixMaterialShader(m_episodeNameParts.gameObject);
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
		public void SetValue(int value, bool isShowLevel, bool isMax, bool isFeed)
		{
			if(isShowLevel)
			{
				SetLevel(value, isMax, isFeed);
			}
			else
			{
				m_strBuilder.SetFormat("{0}", value);
				m_texts[0].text = m_strBuilder.ToString();
				m_texts[0].enabled = true;
				m_texts[2].text = "";
				m_texts[3].text = "";
			}
			this.isMax = isMax;
			for(int i = 0; i < m_skillImages.Length; i++)
			{
				m_skillImages[i].enabled = false;
			}
			m_episodeNameRectTransform.gameObject.SetActive(false);
		}

		//// RVA: 0x136C384 Offset: 0x136C384 VA: 0x136C384
		public void SetFraction(int num, int den)
		{
			m_strBuilder.SetFormat("{0}/{1}", num, den);
			m_texts[0].text = m_strBuilder.ToString();
			m_texts[0].enabled = true;

			m_texts[2].text = "";
			m_texts[3].text = "";

			for(int i = 0; i < m_skillImages.Length; i++)
			{
				m_skillImages[i].enabled = false;
			}

			m_episodeNameRectTransform.gameObject.SetActive(false);
		}

		//// RVA: 0x136CA18 Offset: 0x136CA18 VA: 0x136CA18
		public void SetLuck(int value, int leafCount, bool isVisible)
		{
			m_strBuilder.SetFormat("+{0}", value);
			m_texts[1].text = m_strBuilder.ToString();
			m_texts[1].enabled = value > 0 && isVisible;
			m_texts[1].color = new Color(1, 1, 1, 1);

			m_strBuilder.SetFormat(JpStringLiterals.StringLiteral_20290, leafCount);
			m_texts[4].text = m_strBuilder.ToString();
			m_texts[4].enabled = leafCount > 0 && isVisible;
			if(m_texts[4].enabled)
			{
				isShowLeaf = m_texts[1].enabled;
			}
		}

		//// RVA: 0x136B190 Offset: 0x136B190 VA: 0x136B190
		public void SetEpisode(int episodeId, int level, bool isMax, bool isFeed)
		{
			int a = 0;
			string str = TextConstant.InvalidText;
			if (episodeId > 0)
			{
				a = (Database.Instance.bonusData.EffectiveEpisodeBonus.FindIndex((IKDICBBFBMI_EventBase.GNPOABJANKO x) =>
				{
					//0x136DEC8
					return x.KELFCMEOPPM_EpisodeId == episodeId;
				}) >> 0x1f) ^ 1;
				str = PIGBBNDPPJC.EJOJNFDHDHN_GetEpName(episodeId);
			}
			for(int i = 0; i < m_texts.Length; i++)
			{
				m_texts[i].text = "";
			}
			for (int i = 0; i < m_skillImages.Length; i++)
			{
				m_skillImages[i].enabled = false;
			}
			m_episodeNameText.text = str;
			m_episodeNameImage.sprite = m_episodeNameParts[a];
			m_episodeNameRectTransform.gameObject.SetActive(true);
			SetLevel(level, isMax, isFeed);
			this.isMax = isMax;
		}

		//// RVA: 0x136B59C Offset: 0x136B59C VA: 0x136B59C
		public void SetLuckyLeafCount(int leafCount, int releaseAbleLeafCount)
		{
			if(releaseAbleLeafCount > 0)
			{
				m_strBuilder.SetFormat(MessageManager.Instance.GetMessage("menu", "lucky_leaf_sort_message"), releaseAbleLeafCount, Mathf.Clamp(m_episodeNameRectTransform.rect.width / 109.0f * 16, 10, 16));
				m_episodeNameText.text = m_strBuilder.ToString();
				m_episodeNameImage.sprite = m_episodeNameParts[0];
			}
			m_episodeNameRectTransform.gameObject.SetActive(releaseAbleLeafCount > 0);
			for(int i = 0; i < m_texts.Length; i++)
			{
				m_texts[i].enabled = false;
			}
			for(int i = 0; i < m_skillImages.Length; i++)
			{
				m_skillImages[i].enabled = false;
			}
			m_strBuilder.SetFormat(JpStringLiterals.StringLiteral_20290, leafCount);
			m_texts[0].text = m_strBuilder.ToString();
			m_texts[0].enabled = leafCount > 0;
			isShowLeaf = false;
		}

		//// RVA: 0x136BDB8 Offset: 0x136BDB8 VA: 0x136BDB8
		public void SetSkillIcon(int iconId, int iconId2, bool isActive)
		{
			isMultiSkill = false;
			isChangedSkillIcon = false;
			m_strBuilder.SetFormat("cmn_s_s_icon_skill_{0:D2}", iconId);
			m_skillImages[0].enabled = true;
			m_skillImages[0].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_strBuilder.ToString()));
			if(iconId2 < 1)
			{
				m_skillImages[1].enabled = false;
			}
			else
			{
				m_strBuilder.SetFormat("cmn_s_s_icon_skill_{0:D2}", iconId2);
				m_skillImages[1].enabled = true;
				m_skillImages[1].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_strBuilder.ToString()));
				isMultiSkill = true;
			}
			m_skillImages[2].enabled = isActive;
			m_texts[0].text = "";
			m_texts[2].text = "";
			m_texts[3].text = "";
			m_episodeNameRectTransform.gameObject.SetActive(false);
		}

		//// RVA: 0x136D804 Offset: 0x136D804 VA: 0x136D804
		private void SetLevel(int level, bool isMax, bool isFeed)
		{
			if(isFeed)
			{
				m_texts[0].enabled = false;
				m_texts[2].enabled = false;
				m_texts[3].enabled = false;
				return;
			}
			if (isMax)
			{
				m_strBuilder.Set(Regex.Replace(level.ToString(), "[0-9]", (Match p) =>
				{
					//0x136DE50
					return Convert.ToChar(p.Value[0] + 0xfee0).ToString();
				}));
			}
			else
			{
				m_strBuilder.Set(level.ToString());
			}
			m_texts[0].text = "Lv";
			m_texts[0].enabled = true;
			m_texts[2].text = "   " + m_strBuilder.ToString();
			m_texts[2].enabled = true;
			m_texts[3].text = isMax ? "   m" : "";
			m_texts[3].enabled = true;
		}

		//// RVA: 0x136BA9C Offset: 0x136BA9C VA: 0x136BA9C
		public void SetSpecialNoteAttribute(SpecialNoteAttribute.Type type, int value)
		{
			string str = (int)type - 1 < 5 && (int)type - 1 >= 0 ? new string[] { "H", "S", "I", "F", "A" }[(int)type - 1] : "";
			for(int i = 0; i < m_texts.Length; i++)
			{
				m_texts[i].enabled = false;
			}
			for(int i = 0; i < m_skillImages.Length; i++)
			{
				m_skillImages[i].enabled = false;
			}
			m_strBuilder.SetFormat("{0}{1}", str, value);
			m_texts[0].text = m_strBuilder.ToString();
			m_texts[0].enabled = str != "";
			m_episodeNameRectTransform.gameObject.SetActive(false);
		}

		//// RVA: 0x136CF44 Offset: 0x136CF44 VA: 0x136CF44
		public void UpdateMaxAnime(float time)
		{
			if(m_animeCurve != null)
			{
				for(int i = 0; i < m_animeCurve.Count; i++)
				{
					if(isMax || isShowLeaf || isMultiSkill)
					{
						float val = m_animeCurve[i].Evaluate(time);
						if(isMax)
						{
							m_texts[i + 2].color = new Color(1, 1, 1, val);
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

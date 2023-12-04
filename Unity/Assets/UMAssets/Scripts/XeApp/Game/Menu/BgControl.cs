using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Text;
using UnityEngine.Events;
using XeSys;
using XeApp.Core;
using XeSys.uGUI;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public enum BgPriority
	{
		Bottom = 0,
		TopMost = 1,
	}
	public enum BgTextureType
	{
		Normal = 0,
		Scene = 1,
		Music = 2,
		MusicEvent = 3,
		Valkyrie = 4,
		Result = 5,
		LoginBonus = 6,
		CostumeSelect = 7,
		NewYearEvent = 8,
		GachaBox = 9,
		GachaNormal = 10,
		Offer = 11,
		Raid = 12,
		LobbyMain = 13,
		_Num = 14,
	}
	public class BgControl
	{ 
		public enum BgTextureFlag
		{
			None = 0,
			Permanently = 1,
		}

		public class BgTexture
		{
			public Texture2D texture; // 0x8
			public Material material; // 0xC
			private BgTextureFlag flags; // 0x10

			// RVA: 0x143F530 Offset: 0x143F530 VA: 0x143F530
			public void SetFlags(BgTextureFlag flags)
			{
				this.flags = flags;
			}

			// RVA: 0x143E340 Offset: 0x143E340 VA: 0x143E340
			public bool CanDestory()
			{
				return (flags & BgTextureFlag.Permanently) == 0;
			}
		}

		public class LimitedHomeBg
		{
			public static int INVALID_MUSIC_ID = -1; // 0x0
			public static int INVALID_BG_ID = -1; // 0x4
			public int m_bg_id = INVALID_BG_ID; // 0x8
			public int m_music_id = INVALID_MUSIC_ID; // 0xC
			public int m_time_zone = -1; // 0x10
			public GameObject m_prefab; // 0x14
			public GameObject m_camera; // 0x18
			public GameObject m_fade; // 0x1C
			public Image m_darkImage; // 0x20
			public bool m_enable; // 0x24
			public CGFNKMNBNBN m_master; // 0x28
		}

		private GameObject m_bgRoot; // 0x8
		private GameObject m_bgInstance; // 0xC
		private BgBehaviour m_bgBehaviour; // 0x10
		private BgType m_type = BgType.Undefined; // 0x14
		private BgTextureType m_textureType; // 0x18
		private int m_id; // 0x1C
		private GameAttribute.Type m_attr; // 0x20
		private BgPriority m_priority; // 0x24
		private BgControl.BgTexture m_bgTexture; // 0x28
		private StringBuilder m_strBuilder = new StringBuilder(128); // 0x2C
		private static IndexableDictionary<string, BgControl.BgTexture> m_cachedTextures = new IndexableDictionary<string, BgTexture>(8); // 0x0
		private bool m_fadeReserved; // 0x30
		private float m_fadeTime = -1.0f; // 0x34
		private Color m_fadeColor = Color.black; // 0x38
		private const string BgPrefabBundlePath = "ly/003.xab";
		private const string BgPrefabResourcePath = "Menu/Prefab/MenuBg";
		private const string HomeBgTextureBundlePath = "ct/bg/hm/";
		private const string SceneBgTextureBundlePath = "ct/sc/me/02/";
		private const string SceneBg2TextureBundlePath = "ct/sc/me/02_2/";
		private const string MusicBgTextureBundlePath = "ct/bg/mc/nm/";
		private const string GachaBgTextureBundlePath = "ct/bg/gc/";
		private const string MusicEventBgTextureBundlePath = "ct/ev/bg/";
		private const string ValkyrieBgTextureBundlePath = "ct/bg/vl/";
		private const string CostumeBgTextureBundlePath = "ct/bg/cs/";
		private const string ResultBgTextureBundlePath = "ct/bg/re/";
		private const string LoginBonusBgTextureBundlePath = "ct/bg/lo/";
		private const string NewYearEventBgTextureBundlePath = "ct/ev/bg/";
		private const string GachaBoxBgTextureBundlePath = "ct/ev/bg/";
		private const string HomeLimitedBgBundlePath = "mn/hm/bg/";
		private const string OfferBgTextureBundlePath = "ct/bg/of/";
		private const string RaidBgTextureBundlePath = "ct/bg/rd/";
		private const string LobbyMainBgTextureBundlePath = "ct/bg/lb/";
		private LimitedHomeBg m_limitedHomeBg = new LimitedHomeBg(); // 0x48
		private StoryBgParam storyBgParam; // 0x4C
		private bool storyBgLoading; // 0x58

		public LimitedHomeBg limitedHomeBg { get { return m_limitedHomeBg; } private set { return; } } //0x143CA14 0x143CA1C
		public ScrollRect storyBgScrollRect { get { return m_bgBehaviour.storyBgScrollRect; } private set { return; } } //0x143EA44 0x143EA68

		// RVA: 0x143CA20 Offset: 0x143CA20 VA: 0x143CA20
		public BgControl(GameObject bgRoot)
		{
			m_bgRoot = bgRoot;
		}

		// // RVA: 0x1429568 Offset: 0x1429568 VA: 0x1429568
		public static void ForceDestoryTexture()
		{
			for(int i = 0; i < m_cachedTextures.Count; i++)
			{
				if(m_cachedTextures[i].texture != null)
				{
					Resources.UnloadAsset(m_cachedTextures[i].texture);
					m_cachedTextures[i].texture = null;
				}
				if (m_cachedTextures[i].material != null)
				{
					Resources.UnloadAsset(m_cachedTextures[i].material);
					m_cachedTextures[i].material = null;
				}
			}
			m_cachedTextures.Clear();
		}

		// // RVA: 0x143CBB8 Offset: 0x143CBB8 VA: 0x143CBB8
		// public GameObject GetCurrent() { }

		// // RVA: 0x143CBC0 Offset: 0x143CBC0 VA: 0x143CBC0
		public BgType GetCurrentType()
		{
			return m_type;
		}

		// // RVA: 0x143CBC8 Offset: 0x143CBC8 VA: 0x143CBC8
		public BgTextureType GetCurrentTextureType()
		{
			return m_textureType;
		}

		// // RVA: 0x143CBD0 Offset: 0x143CBD0 VA: 0x143CBD0
		public int GetCurrentId()
		{
			return m_id;
		}

		// // RVA: 0x143CBD8 Offset: 0x143CBD8 VA: 0x143CBD8
		public GameAttribute.Type GetCurrentAttr()
		{
			return m_attr;
		}

		// // RVA: 0x143CBE0 Offset: 0x143CBE0 VA: 0x143CBE0
		// public bool GetBgIsFade() { }

		// // RVA: 0x143CC20 Offset: 0x143CC20 VA: 0x143CC20
		public bool IsSceneBg(BgType a_bg_type)
		{
			if(a_bg_type == BgType.Home)
			{
				if(JKHEOEEPBMJ.HDOOGKNLOGI_IsHomeSceneEvolve())
				{
					int a = 0, b = 0;
					return JKHEOEEPBMJ.KIIBKADPJAF_FillSceneEvoleInfo(out a, out b);
				}
			}
			return false;
		}

		// // RVA: 0x143CD18 Offset: 0x143CD18 VA: 0x143CD18
		public bool Comparer(int bgId, BgType type)
		{
			if (m_id != bgId)
				return false;
			return m_type == type;
		}

		// // RVA: 0x143CD40 Offset: 0x143CD40 VA: 0x143CD40
		// public void Destroy() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5968 Offset: 0x6C5968 VA: 0x6C5968
		// // RVA: 0x143D2A4 Offset: 0x143D2A4 VA: 0x143D2A4
		public IEnumerator Load(UnityAction action)
		{
			//0x144265C
			GameObject prefab = null;
			ResourcesManager.Instance.Load(Path.Combine("Menu/Prefab/MenuBg","BgRoot"), (FileResultObject fo) => {
				//0x143EF38
				prefab = fo.unityObject as GameObject;
				return true;
			});
			while(prefab == null)
				yield return null;
			m_bgInstance = UnityEngine.Object.Instantiate<GameObject>(prefab);
			m_bgBehaviour = m_bgInstance.GetComponent<BgBehaviour>();
			m_bgInstance.transform.SetParent(m_bgRoot.transform, false);
			m_bgBehaviour.ResetBgImageRectSize(false);
			prefab = null;
			m_bgBehaviour.SetHome(CGFNKMNBNBN.MHJBBLBFHIB_IsHomeBgDark());
			m_bgBehaviour.ChangeAttribute(m_attr);
			if(action != null)
				action();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C59E0 Offset: 0x6C59E0 VA: 0x6C59E0
		// // RVA: 0x143D36C Offset: 0x143D36C VA: 0x143D36C
		public IEnumerator ChangeBgCoroutine(BgType bgType, int id = -1, SceneGroupCategory category = SceneGroupCategory.UNDEFINED, TransitionList.Type transitionType = TransitionList.Type.UNDEFINED, int attribute = -1)
		{
			BgTextureType textureType = 0;
			bool doFade;
			float fadeTime;
			UGUIFader fader;
			//0x143F5D4
			if (bgType <= BgType.Undefined)
				yield break;
			if (id < 1)
				id = 1;
			ConvertBgType(bgType, ref textureType, ref id);
			bool wasEnabled = m_limitedHomeBg.m_enable;
			m_limitedHomeBg.m_enable = false;
			if(bgType == BgType.Home)
			{
				if(!CGFNKMNBNBN.CEJADGLBCPA())
				{
					int defaultBgId = GetDefaultHomeBg();
					JKHEOEEPBMJ.NDFFOBHACPE_SetHomeSceneId(defaultBgId, 0);
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					CGFNKMNBNBN.DPMCLJMIBDK(defaultBgId, time);
					CGFNKMNBNBN.HHGLKFFKFAB(-1);
				}
				if(bgType == BgType.Home)
				{
					if(JKHEOEEPBMJ.HDLMKFFMGEP_GetHomeSceneEvolveId() == 0)
					{
						List<int> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.NIJNOFHBKEB_GetAvaiableBgs();
						int homeSceneId = JKHEOEEPBMJ.AGHGOOBIGDI_GetHomeSceneId();
						if (!CGFNKMNBNBN.JBNMNPMCIBM_HaveBg(homeSceneId))
						{
							if(!l.Contains(homeSceneId))
							{
								JKHEOEEPBMJ.NDFFOBHACPE_SetHomeSceneId(GetDefaultHomeBg(), 0);
								//LAB_01440528
								ConvertBgType(bgType, ref textureType, ref id);
							}
						}
					}
					else
					{
						DFKGGBMFFGB_PlayerInfo pData = GameManager.Instance.ViewPlayerData;
						int sceneId = 0;
						int evolveId = 0;
						if (JKHEOEEPBMJ.KIIBKADPJAF_FillSceneEvoleInfo(out sceneId, out evolveId))
						{
							BgTextureType texType = 0;
							ConvertBgType(bgType, ref texType, ref id);
							int id_cat = id / 1000000;
							int id_id = id % 1000000;
							for (int i = 0; i < pData.OPIBAPEGCLA_Scenes.Count; i++)
							{
								if (pData.OPIBAPEGCLA_Scenes[i].BCCHOBPJJKE_SceneId == id_id)
								{
									if (!pData.OPIBAPEGCLA_Scenes[i].CGKAEMGLHNK_IsUnlocked() || pData.OPIBAPEGCLA_Scenes[i].MCCIFLKCNKO_Feed || pData.OPIBAPEGCLA_Scenes[i].CGIELKDLHGE_GetEvolveId() < id_cat)
									{
										JKHEOEEPBMJ.NDFFOBHACPE_SetHomeSceneId(GetDefaultHomeBg(), 0);
										//LAB_01440528
										ConvertBgType(bgType, ref textureType, ref id);
									}
								}
							}
						}
						else
						{
							JKHEOEEPBMJ.NDFFOBHACPE_SetHomeSceneId(GetDefaultHomeBg(), 0);
						}
					}
					//LAB_01440530
					if(bgType == BgType.Home)
					{
						if(JKHEOEEPBMJ.HDLMKFFMGEP_GetHomeSceneEvolveId() == 0)
						{
							int homeSceneId = JKHEOEEPBMJ.AGHGOOBIGDI_GetHomeSceneId();
							m_limitedHomeBg.m_master = CGFNKMNBNBN.ELKDCEEPLKB(homeSceneId);
							if (m_limitedHomeBg.m_master == null)
							{
								homeSceneId = GetDefaultHomeBg();
								m_limitedHomeBg.m_master = CGFNKMNBNBN.ELKDCEEPLKB(homeSceneId);
								JKHEOEEPBMJ.NDFFOBHACPE_SetHomeSceneId(homeSceneId, 0);
							}
							m_limitedHomeBg.m_enable = true;
							m_textureType = textureType;
							id = m_id;
						}
					}
				}
			}
			bool isSame = false;
			if (m_textureType == textureType && m_id == id)
				isSame = true;
			bool needUpdate = (wasEnabled != m_limitedHomeBg.m_enable);
			if (wasEnabled && m_limitedHomeBg.m_enable)
			{
				// L 426
				if(m_limitedHomeBg.m_enable)
				{
					needUpdate = false;
					if (m_limitedHomeBg.m_master.KEFGPJBKAOD_BgId != m_limitedHomeBg.m_bg_id)
						needUpdate = true;
				}
			}
			doFade = m_fadeReserved && (needUpdate || !isSame);
			m_fadeReserved = false;
			fadeTime = m_fadeTime;
			fader = m_bgBehaviour.Fader;
			if(doFade)
			{
				fader.Fade(fadeTime, m_fadeColor);
				while (fader.isFading)
					yield return null;
			}
			m_limitedHomeBg.m_music_id = LimitedHomeBg.INVALID_MUSIC_ID;
			if(bgType < BgType.CostumeSelect)
			{
				if(bgType == BgType.Home || bgType == BgType.HomeNormal || bgType == BgType.LoginBonus)
				{
					// L528
					long time = MenuScene.Instance.EnterToHomeTime;
					if(time == 0)
					{
						time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					}
					CGFNKMNBNBN c;
					if(CGFNKMNBNBN.DELFEMBCFCO_GetFirstAvaiableMusicBg(time, out c))
					{
						m_limitedHomeBg.m_music_id = c.KLMAMIOBDHP_MusicId;
					}
				}
			}
			if (m_limitedHomeBg.m_enable)
			{
				// 588
				long time = MenuScene.Instance.EnterToHomeTime;
				int homeId = GetHomeBgId(time);
				if (m_limitedHomeBg.m_bg_id != m_limitedHomeBg.m_master.KEFGPJBKAOD_BgId || m_limitedHomeBg.m_time_zone != homeId || m_limitedHomeBg.m_prefab == null)
				{
					m_limitedHomeBg.m_bg_id = m_limitedHomeBg.m_master.KEFGPJBKAOD_BgId;
					m_limitedHomeBg.m_time_zone = homeId;
					yield return Co.R(Co_CreateLimitedBG(m_limitedHomeBg.m_bg_id, m_limitedHomeBg.m_time_zone));
					//2
				}
				//LAB_0143f6e4
				m_limitedHomeBg.m_darkImage.enabled = CGFNKMNBNBN.MHJBBLBFHIB_IsHomeBgDark();
				if (m_limitedHomeBg.m_master.GJFPFFBAKGK_CloseAt != 0)
				{
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().GBCEALJIKFN_Home.HBGKPLDGGLF(m_limitedHomeBg.m_master.GJFPFFBAKGK_CloseAt);
				}
				UnloadBgTexture();
				m_bgBehaviour.SetBgTexture(null, false, false);
				m_bgBehaviour.SetLimitedHomeScene();
				StoryBgHide();
				yield return null;
				//3
			}
			if (!m_limitedHomeBg.m_enable)
			{
				DeleteLimitedBG();
				yield return Co.R(LoadBgTexture(textureType, id, bgType == BgType.GachaPickup));
				switch(bgType)
				{
					case BgType.Home:
						if(!IsSceneBg(BgType.Home))
						{
							m_bgBehaviour.SetHome(CGFNKMNBNBN.MHJBBLBFHIB_IsHomeBgDark());
							if(id == 3)
							{
								m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.HomeNight);
							}
							else if(id != 2)
							{
								if (id == 1)
								{
									m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Home);
								}
							}
							else
							{
								m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.HomeEvening);
							}
						}
						else
						{
							m_bgBehaviour.SetHomeScene(CGFNKMNBNBN.MHJBBLBFHIB_IsHomeBgDark());
						}
						StoryBgHide();
						break;
					case BgType.HomeNormal:
						m_bgBehaviour.SetMenu();
						m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Home);
						StoryBgHide();
						break;
					case BgType.Music:
						m_bgBehaviour.SetMusic(Database.Instance.gameSetup.musicInfo.IsMvMode);
						StoryBgHide();
						break;
					case BgType.MusicEvent:
						m_bgBehaviour.SetMusic(false);
						StoryBgHide();
						break;
					case BgType.Valkyrie:
						m_bgBehaviour.SetValkyrieSelect();
						StoryBgHide();
						break;
					case BgType.Result:
						m_bgBehaviour.SetResult();
						break;
					case BgType.LoginBonus:
						m_bgBehaviour.SetLoginBonus();
						StoryBgHide();
						break;
					case BgType.CostumeSelect:
						m_bgBehaviour.SetCostumeSelect();
						m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.CostumeSelect);
						StoryBgHide();
						break;
					case BgType.UnlockValkyrie:
						m_bgBehaviour.SetUnlockValkyrie();
						StoryBgHide();
						break;
					case BgType.Story:
						UnloadBgTexture();
						m_bgBehaviour.SetBgTexture(null, false, false);
						StoryBgShow();
						break;
					default:
						UnloadBgTexture();
						m_bgBehaviour.SetBgTexture(null, false, false);
						m_bgBehaviour.SetMenu();
						StoryBgHide();
						ChangeColor(category, transitionType);
						break;
					case BgType.NewYearEvent:
						m_bgBehaviour.SetNewYearEvent();
						StoryBgHide();
						break;
					case BgType.GachaBox:
						m_bgBehaviour.SetGachaBox();
						StoryBgHide();
						break;
					case BgType.Campaign:
						m_bgBehaviour.SetCampaign();
						StoryBgHide();
						break;
					case BgType.GachaPickup:
					case BgType.GachaNormal:
						m_bgBehaviour.GachaPickup();
						StoryBgHide();
						break;
					case BgType.Offer:
						m_bgBehaviour.SetOffer();
						StoryBgHide();
						break;
					case BgType.CostumeUpgrade:
						UnloadBgTexture();
						m_bgBehaviour.SetBgTexture(null, false, false);
						m_bgBehaviour.SetMenu();
						m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Setting);
						StoryBgHide();
						break;
					case BgType.Raid:
						m_bgBehaviour.SetRaid();
						StoryBgHide();
						break;
					case BgType.Decoration:
						m_bgBehaviour.SetDecoration();
						StoryBgHide();
						break;
					case BgType.LobbyMain:
						m_bgBehaviour.SetLobbyMain();
						StoryBgHide();
						break;
					case BgType.VerticalMusic:
						m_bgBehaviour.SetVerticalMusic();
						StoryBgHide();
						break;
				}
			}
			// LAB_01440c6c
			if (attribute < 0)
			{
				if (m_type != bgType)
				{
					ChangeAttribute(0);
				}
			}
			else
			{
				ChangeAttribute((GameAttribute.Type)attribute);
			}
			m_type = bgType;
			if (doFade)
			{
				fader.Fade(fadeTime, 0);
				while (fader.isFading)
					yield return null;
			}
		}

		// // RVA: 0x143D498 Offset: 0x143D498 VA: 0x143D498
		public void ShowBgDark()
		{
			if(m_limitedHomeBg.m_enable)
			{
				m_limitedHomeBg.m_darkImage.enabled = true;
			}
			m_bgBehaviour.ShowOverlay(BgBehaviour.HomeSceneOverlayAlpha);
		}

		// // RVA: 0x143D5A8 Offset: 0x143D5A8 VA: 0x143D5A8
		public void HideBgDark()
		{
			if(m_limitedHomeBg.m_enable)
			{
				m_limitedHomeBg.m_darkImage.enabled = false;
			}
			m_bgBehaviour.HideOverlay();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C5A58 Offset: 0x6C5A58 VA: 0x6C5A58
		// // RVA: 0x143D62C Offset: 0x143D62C VA: 0x143D62C
		public IEnumerator ChangeHomeBgCoroutine(BgType bgType, int id = -1, int evolveId = -1, bool isBgDark = false, SceneGroupCategory category = SceneGroupCategory.UNDEFINED, TransitionList.Type transitionType = TransitionList.Type.UNDEFINED, int attribute = -1)
		{
			BgTextureType textureType; // 0x30
			float fadeTime; // 0x34
			UGUIFader fader; // 0x38

			//0x1440EAC
			if (bgType < 0)
				yield break;
			if (id < 1)
				id = 1;
			int baseId = id;
			textureType = BgTextureType.Normal;
			ConvertBgType(bgType, ref textureType, ref id, ref evolveId);
			m_limitedHomeBg.m_enable = false;
			if(bgType == BgType.Home && evolveId == 0)
			{
				m_limitedHomeBg.m_master = CGFNKMNBNBN.ELKDCEEPLKB(baseId);
				if(m_limitedHomeBg.m_master == null)
				{
					m_limitedHomeBg.m_master = CGFNKMNBNBN.ELKDCEEPLKB(GetDefaultHomeBg());
				}
				m_limitedHomeBg.m_enable = true;
				m_textureType = textureType;
				id = m_id;
			}
			m_fadeReserved = false;
			fadeTime = m_fadeTime;
			fader = m_bgBehaviour.Fader;
			fader.Fade(m_fadeTime, new Color(m_fadeColor.r, m_fadeColor.g, m_fadeColor.b, 0), m_fadeColor);
			while (fader.isFading)
				yield return null;
			m_limitedHomeBg.m_music_id = LimitedHomeBg.INVALID_MUSIC_ID;
			if (bgType >= BgType.Home && bgType < BgType.Music)
			{
				CGFNKMNBNBN bgInfo;
				if (CGFNKMNBNBN.DELFEMBCFCO_GetFirstAvaiableMusicBg(MenuScene.Instance.EnterToHomeTime, out bgInfo))
				{
					m_limitedHomeBg.m_music_id = bgInfo.KLMAMIOBDHP_MusicId;
				}
			}
			if (m_limitedHomeBg.m_enable)
			{
				int a = GetHomeBgId(MenuScene.Instance.EnterToHomeTime);
				if (m_limitedHomeBg.m_bg_id != m_limitedHomeBg.m_master.KEFGPJBKAOD_BgId ||
					m_limitedHomeBg.m_time_zone != a ||
					m_limitedHomeBg.m_prefab == null)
				{
					m_limitedHomeBg.m_bg_id = m_limitedHomeBg.m_master.KEFGPJBKAOD_BgId;
					m_limitedHomeBg.m_time_zone = a;
					yield return Co.R(Co_CreateLimitedBG(m_limitedHomeBg.m_bg_id, m_limitedHomeBg.m_time_zone));
				}
				//LAB_01440fb4
				m_limitedHomeBg.m_darkImage.enabled = isBgDark;
				if (m_limitedHomeBg.m_master.GJFPFFBAKGK_CloseAt != 0)
				{
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().GBCEALJIKFN_Home.HBGKPLDGGLF(m_limitedHomeBg.m_master.GJFPFFBAKGK_CloseAt);
				}
				UnloadBgTexture();
				m_bgBehaviour.SetBgTexture(null, false, false);
				m_bgBehaviour.SetLimitedHomeScene();
				StoryBgHide();
				yield return null;
			}
			//LAB_014416cc
			if (!m_limitedHomeBg.m_enable)
			{
				DeleteLimitedBG();
				yield return Co.R(LoadBgTexture(textureType, id, bgType == BgType.GachaPickup));
				if(bgType == BgType.Home)
				{
					if(evolveId == 0)
					{
						m_bgBehaviour.SetHome(isBgDark);
						if(id == 3)
						{
							m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.HomeNight);
						}
						else if(id == 2)
						{
							m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.HomeEvening);
						}
						else if(id == 1)
						{
							m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Home);
						}
					}
					else
					{
						m_bgBehaviour.SetHomeScene(isBgDark);
					}
					StoryBgHide();
				}
				else
				{
					UnloadBgTexture();
					m_bgBehaviour.SetBgTexture(null, false, false);
					m_bgBehaviour.SetMenu();
					StoryBgHide();
					ChangeColor(category, transitionType);
				}
			}
			//LAB_01441864
			if (attribute < 0)
			{
				if (m_type != bgType)
					ChangeAttribute(GameAttribute.Type.None);
			}
			else
			{
				ChangeAttribute((GameAttribute.Type)attribute);
			}
			m_type = bgType;
			fader.Fade(fadeTime, 0);
			while (fader.isFading)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C5AD0 Offset: 0x6C5AD0 VA: 0x6C5AD0
		// // RVA: 0x143D794 Offset: 0x143D794 VA: 0x143D794
		public IEnumerator Co_CreateLimitedBG(int a_bundle_id, int a_time_zone)
		{
			int loadCount = 0; // 0x1C
			string nameBundle; // 0x20
			AssetBundleLoadAssetOperation t_operation; // 0x24

			//0x14419FC
			DeleteLimitedBG();
			yield return null;
			m_strBuilder.SetFormat("{0}bg{1:D4}.xab", HomeLimitedBgBundlePath, a_bundle_id);
			nameBundle = m_strBuilder.ToString();
			m_strBuilder.SetFormat("bg{0:D4}_{1:D2}_prefab", a_bundle_id, a_time_zone - 1);
			t_operation = AssetBundleManager.LoadAssetAsync(nameBundle, m_strBuilder.ToString(), typeof(GameObject));
			yield return t_operation;
			loadCount++;
			m_limitedHomeBg.m_prefab = UnityEngine.Object.Instantiate(t_operation.GetAsset<GameObject>());
			t_operation = null;

			m_strBuilder.SetFormat("bg{0:D4}_00_camera", a_bundle_id);
			t_operation = AssetBundleManager.LoadAssetAsync(nameBundle, m_strBuilder.ToString(), typeof(GameObject));
			yield return t_operation;
			loadCount++;
			m_limitedHomeBg.m_camera = UnityEngine.Object.Instantiate(t_operation.GetAsset<GameObject>());

			GameObject g = new GameObject("dark_panel");
			Image i = g.AddComponent<Image>();
			i.color = new Color(0, 0, 0, BgBehaviour.HomeSceneOverlayAlpha);
			g.transform.SetParent(m_limitedHomeBg.m_camera.transform.Find("fade_prefab"), false);
			m_limitedHomeBg.m_darkImage = i;
			RectTransform rt = g.GetComponent<RectTransform>();
			rt.anchorMin = Vector2.zero;
			rt.anchorMax = Vector2.one;
			rt.offsetMin = Vector2.zero;
			rt.offsetMax = Vector2.zero;
			rt.pivot = new Vector2(0.5f, 0.5f);
			LinkUGUIFader l = m_limitedHomeBg.m_camera.GetComponentInChildren<LinkUGUIFader>();
			if(l != null)
			{
				l.SetTargetFader(m_bgBehaviour.Fader);
			}
			if(SystemManager.isLongScreenDevice)
			{
				yield return null;
				FlexibleLayoutCamera f = m_limitedHomeBg.m_camera.GetComponentInChildren<FlexibleLayoutCamera>(true);
				f.IsEnableFov = false;
				f.FlexibleFovCameraList[0].fieldOfView = Mathf.CeilToInt(f.GetDefaultFov(0) * MenuScene.GetLongScreenScale());
			}
			for(int j = 0; j < loadCount; j++)
			{
				AssetBundleManager.UnloadAssetBundle(nameBundle, false);
			}
		}

		// // RVA: 0x143D0C8 Offset: 0x143D0C8 VA: 0x143D0C8
		public void DeleteLimitedBG()
		{
			if(m_limitedHomeBg.m_prefab != null)
			{
				UnityEngine.Object.Destroy(m_limitedHomeBg.m_prefab);
				m_limitedHomeBg.m_prefab = null;
			}
			if(m_limitedHomeBg.m_camera != null)
			{
				UnityEngine.Object.Destroy(m_limitedHomeBg.m_camera);
				m_limitedHomeBg.m_camera = null;
			}
		}

		// // RVA: 0x143D874 Offset: 0x143D874 VA: 0x143D874
		public void ReserveFade(float time, Color color)
		{
			m_fadeReserved = true;
			m_fadeTime = time;
			m_fadeColor = color;
		}

		// // RVA: 0x143D89C Offset: 0x143D89C VA: 0x143D89C
		private int GetDefaultHomeBg()
		{
			FFHPBEPOMAK_DivaInfo d = GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(false).BCJEAJPLGMB_MainDivas[0];
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId > 0)
			{
				d = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId - 1];
			}
			int idx = 9;
			if(d != null)
			{
				idx = d.AHHJLDLAPAN_DivaId - 1;
			}
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[idx].CMBCBNEODPD_HomeBgId;
		}

		// // RVA: 0x143DBCC Offset: 0x143DBCC VA: 0x143DBCC
		private void ChangeColor(SceneGroupCategory category, TransitionList.Type transitionType)
		{
			if(transitionType == TransitionList.Type.COSTUME_VIEW_MODE || transitionType == TransitionList.Type.COSTUME_SELECT)
			{
				m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.CostumeSelect);
				return;
			}
			if((int)category - 3 < 7)
			{
				switch(category)
				{
					case SceneGroupCategory.FORMATION: //0
						m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Setting);
						return;
					default:
						return;
					case SceneGroupCategory.GACHA: // 3
						m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Gacha);
						return;
					case SceneGroupCategory.OPTION: //4
						m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Option);
						return;
					case SceneGroupCategory.QUEST://7
						m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Quest);
						return;
				}
			}
			if (category != SceneGroupCategory.MUSIC_RATE)
				return;
			m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.Setting);
		}

		// // RVA: 0x143DCDC Offset: 0x143DCDC VA: 0x143DCDC
		// public void ChangeTilingFade(float time, float alpha) { }

		// // RVA: 0x143DD24 Offset: 0x143DD24 VA: 0x143DD24
		public void ChangeDownLoadBg()
		{
			UnloadBgTexture();
			m_bgBehaviour.SetMenu();
			m_bgBehaviour.ChangeColor(BgBehaviour.ColorType.DownLoad);
		}

		// // RVA: 0x143DE8C Offset: 0x143DE8C VA: 0x143DE8C
		// public void ChangeNameEntryBg() { }

		// // RVA: 0x143DEDC Offset: 0x143DEDC VA: 0x143DEDC
		// public void ChangeHomeSceneView() { }

		// // RVA: 0x143DF04 Offset: 0x143DF04 VA: 0x143DF04
		// public void ChangeTeamSelect() { }

		// // RVA: 0x143DF08 Offset: 0x143DF08 VA: 0x143DF08
		public void ChangeAttribute(GameAttribute.Type attr)
		{
			if (m_attr == attr)
				return;
			m_bgBehaviour.ChangeAttribute(attr);
			m_attr = attr;
		}

		// // RVA: 0x143DF4C Offset: 0x143DF4C VA: 0x143DF4C
		public void ChangeTilingType(BgBehaviour.TilingType type)
		{
			m_bgBehaviour.ChangeTilingType(type, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C5B48 Offset: 0x6C5B48 VA: 0x6C5B48
		// // RVA: 0x143DF80 Offset: 0x143DF80 VA: 0x143DF80
		public IEnumerator LoadBgTexture(BgTextureType textureType, int id, bool isBlur = false)
		{
			Type types;
			AssetBundleLoadAssetOperation operation;
			//0x1442B38
			if (m_bgTexture != null && m_textureType == textureType && m_id == id)
				yield break;
			m_textureType = textureType;
			m_id = id;
			m_strBuilder.Clear();
			bool canBeMat = false;
			string assetId = m_id.ToString("D2");
			switch (textureType)
			{
				case BgTextureType.Scene:
					int itemId = m_id / 1000000;
					m_strBuilder.SetFormat("{0:D6}_{1:D2}", m_id % 1000000, itemId);
					assetId = m_strBuilder.ToString();
					List<MLIBEPGADJH_Scene.KKLDOOJBJMN> scenesList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList;
					if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.LENJLNLNPEO_IsPlateAnimationHome == 0 
						&& itemId > 0 
						&& scenesList.Count >= itemId
						&& scenesList[itemId - 1].EKLIPGELKCL_Rarity >= 6)
					{
						m_strBuilder.SetFormat("{0}{1}.xab", SceneBg2TextureBundlePath, assetId);
						canBeMat = true;
					}
					else
					{
						m_strBuilder.SetFormat("{0}{1}.xab", SceneBgTextureBundlePath, assetId);
					}
					break;
				case BgTextureType.Music:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", MusicBgTextureBundlePath, m_id);
					break;
				case BgTextureType.MusicEvent:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", MusicEventBgTextureBundlePath, m_id);
					break;
				case BgTextureType.Valkyrie:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", ValkyrieBgTextureBundlePath, m_id);
					break;
				case BgTextureType.Result:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", ResultBgTextureBundlePath, m_id);
					break;
				case BgTextureType.LoginBonus:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", LoginBonusBgTextureBundlePath, m_id);
					break;
				case BgTextureType.CostumeSelect:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", CostumeBgTextureBundlePath, m_id);
					break;
				case BgTextureType.NewYearEvent:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", NewYearEventBgTextureBundlePath, m_id);
					break;
				case BgTextureType.GachaBox:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", GachaBoxBgTextureBundlePath, m_id);
					break;
				case BgTextureType.GachaNormal:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", GachaBgTextureBundlePath, m_id);
					break;
				case BgTextureType.Offer:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", OfferBgTextureBundlePath, m_id);
					break;
				case BgTextureType.Raid:
					m_strBuilder.AppendFormat("{0}{1:D3}_{2:D2}.xab", RaidBgTextureBundlePath, m_id, 1);
					assetId = string.Format("{0:D3}_{1:D2}", id, 1);
					break;
				case BgTextureType.LobbyMain:
					m_strBuilder.AppendFormat("{0}{1:D3}.xab", LobbyMainBgTextureBundlePath, m_id);
					assetId = m_id.ToString("D3");
					break;
				//case BgTextureType.Normal:
				default:
					m_strBuilder.AppendFormat("{0}{1:D2}.xab", HomeBgTextureBundlePath, m_id);
					break;
			}
			BgTexture tex;
			if (!m_cachedTextures.TryGetValue(m_strBuilder.ToString(), out tex))
			{
				types = typeof(Texture2D);
				if(m_textureType == BgTextureType.Scene)
				{
					if(canBeMat)
						types = typeof(Material);
				}
				operation = AssetBundleManager.LoadAssetAsync(m_strBuilder.ToString(), assetId, types);
				yield return Co.R(operation);
				tex = new BgTexture();
				if(types == typeof(Texture2D))
				{
					tex.texture = operation.GetAsset<Texture2D>();
				}
				else
				{
					tex.material = operation.GetAsset<Material>();
				}
				AssetBundleManager.UnloadAssetBundle(m_strBuilder.ToString());
			}
			m_bgBehaviour.SetHomeBgTexture(tex, m_textureType == BgTextureType.Scene, isBlur);
			m_bgTexture = tex;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C5BC0 Offset: 0x6C5BC0 VA: 0x6C5BC0
		// // RVA: 0x143E078 Offset: 0x143E078 VA: 0x143E078
		// public IEnumerator LoadBgTexture(GameObject obj, int id) { }

		// // RVA: 0x143DD74 Offset: 0x143DD74 VA: 0x143DD74
		private void UnloadBgTexture()
		{
			if (m_bgTexture == null)
				return;
			if(!m_cachedTextures.ContainsValue(m_bgTexture))
			{
				Resources.UnloadAsset(m_bgTexture.texture);
				m_bgTexture.texture = null;
			}
			m_bgTexture = null;
		}

		// // RVA: 0x143E158 Offset: 0x143E158 VA: 0x143E158
		// private void UnloadBgTexture(BgControl.BgTexture bgTexture) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5C38 Offset: 0x6C5C38 VA: 0x6C5C38
		// // RVA: 0x143E260 Offset: 0x143E260 VA: 0x143E260
		public IEnumerator CacheBg(BgType bgType, int id)
		{
			AssetBundleLoadAssetOperation operation;
			//0x143EFDC
			BgTextureType texType = 0;
			ConvertBgType(bgType, ref texType, ref id);
			if(texType == BgTextureType.Raid)
			{
				m_strBuilder.SetFormat("{0}{1:D3}_{2:D2}.xab", RaidBgTextureBundlePath, id, 1);
			}
			else if(texType == BgTextureType.Music)
			{
				m_strBuilder.SetFormat("{0}{1:D2}.xab", MusicBgTextureBundlePath, id);
			}
			if(!m_cachedTextures.ContainsKey(m_strBuilder.ToString()))
			{
				operation = AssetBundleManager.LoadAssetAsync(m_strBuilder.ToString(), id.ToString("D2"), typeof(Texture2D));
				yield return Co.R(operation);
				BgTexture tex = new BgTexture();
				tex.SetFlags(BgTextureFlag.Permanently);
				tex.texture = operation.GetAsset<Texture2D>();
				AssetBundleManager.UnloadAssetBundle(m_strBuilder.ToString(), false);
				m_cachedTextures.Add(m_strBuilder.ToString(), tex);
			}
		}

		// // RVA: 0x143CDE8 Offset: 0x143CDE8 VA: 0x143CDE8
		public void DestroyCacheBg()
		{
			for(int i = 0; i < m_cachedTextures.Count; i++)
			{
				if(m_bgTexture == null || (m_bgTexture != m_cachedTextures[i] && m_cachedTextures[i].CanDestory()))
				{
					if(m_cachedTextures[i].texture != null)
					{
						Resources.UnloadAsset(m_cachedTextures[i].texture);
						m_cachedTextures[i].texture = null;
					}
					if (m_cachedTextures[i].material != null)
					{
						Resources.UnloadAsset(m_cachedTextures[i].material);
						m_cachedTextures[i].material = null;
					}
					m_cachedTextures.Remove(i);
					i--;
				}
			}
		}

		// // RVA: 0x143E354 Offset: 0x143E354 VA: 0x143E354
		public void SetPriority(BgPriority priority)
		{
			m_priority = priority;
			ApplyPriority();
		}

		// // RVA: 0x143E35C Offset: 0x143E35C VA: 0x143E35C
		private void ApplyPriority()
		{
			if(m_priority == BgPriority.TopMost)
			{
				m_bgBehaviour.transform.SetAsLastSibling();
			}
			else if(m_priority == BgPriority.Bottom)
			{
				m_bgBehaviour.transform.SetAsFirstSibling();
			}
		}

		// // RVA: 0x143E400 Offset: 0x143E400 VA: 0x143E400
		// private bool CheckEqualBg(BgTextureType textureType, int id) { }

		// // RVA: 0x143E424 Offset: 0x143E424 VA: 0x143E424
		private void ConvertBgType(BgType bgType, ref BgTextureType textureType, ref int id, ref int evolveId)
		{
			if (bgType < BgType.Home || bgType > BgType.HomeNormal)
				return;
			if(evolveId == 0)
			{
				id = GetHomeBgId(MenuScene.Instance.EnterToHomeTime);
				textureType = BgTextureType.Normal;
			}
			else
			{
				id += evolveId * 1000000;
				textureType = BgTextureType.Scene;
			}
		}

		// // RVA: 0x143E650 Offset: 0x143E650 VA: 0x143E650
		private void ConvertBgType(BgType bgType, ref BgTextureType textureType, ref int id)
		{
			int category_id = 0;
			int asset_id = 0;
			if(bgType < BgType.Music)
			{
				if(bgType == BgType.Home)
				{
					category_id = -1;
					asset_id = -1;
					if(JKHEOEEPBMJ.HDOOGKNLOGI_IsHomeSceneEvolve())
					{
						if(JKHEOEEPBMJ.KIIBKADPJAF_FillSceneEvoleInfo(out asset_id, out category_id))
						{
							id = asset_id + category_id * 1000000;
							textureType = BgTextureType.Scene;
							return;
						}
					}
				}
				else
				{
					category_id = -1;
					asset_id = -1;
				}
				id = GetHomeBgId(MenuScene.Instance.EnterToHomeTime);
				textureType = BgTextureType.Normal;
			}
			else
			{
				switch(bgType)
				{
					case BgType.Music:
					case BgType.VerticalMusic:
						textureType = BgTextureType.Music;
						break;
					case BgType.MusicEvent:
					case BgType.Valkyrie:
					case BgType.Result:
					case BgType.CostumeSelect:
						textureType = (BgTextureType)bgType;
						break;
					case BgType.LoginBonus:
						id = GetHomeBgId(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						textureType = BgTextureType.Normal;
						break;
					case BgType.UnlockValkyrie:
						textureType = BgTextureType.Valkyrie;
						break;
					case BgType.NewYearEvent:
						textureType = BgTextureType.NewYearEvent;
						break;
					case BgType.GachaBox:
						textureType = BgTextureType.GachaBox;
						break;
					case BgType.Campaign:
						textureType = BgTextureType.MusicEvent;
						break;
					case BgType.GachaPickup:
						id = 2000000 + id;
						textureType = BgTextureType.Scene;
						break;
					case BgType.GachaNormal:
						textureType = BgTextureType.GachaNormal;
						break;
					case BgType.Offer:
						textureType = BgTextureType.Offer;
						break;
					case BgType.Raid:
						textureType = BgTextureType.Raid;
						break;
					case BgType.LobbyMain:
						textureType = BgTextureType.LobbyMain;
						break;
					default:
						break;
				}
			}
		}

		// // RVA: 0x143E574 Offset: 0x143E574 VA: 0x143E574
		// public static int CompoundSceneBgId(int sceneId, int rank) { }

		// // RVA: 0x143E9F8 Offset: 0x143E9F8 VA: 0x143E9F8
		// public static bool ExtractSceneBgId(int sceneBgId, out int sceneId, out int rank) { }

		// // RVA: 0x143E584 Offset: 0x143E584 VA: 0x143E584
		public static int GetHomeBgId(long unixTime)
		{
			bool b = false;
			DivaTimezoneTalk.Type dayType = DivaTimezoneTalk.GetByUnixTime(unixTime, out b);
			switch(dayType)
			{
				case DivaTimezoneTalk.Type.Morning:
				case DivaTimezoneTalk.Type.Noon:
				default:
					return 1;
				case DivaTimezoneTalk.Type.Evening:
					return 2;
				case DivaTimezoneTalk.Type.Night:
				case DivaTimezoneTalk.Type.Midnight:
					return 3;
			}
			/*int c = 0;
			if(a < 5)
			{
				c = 0x7fad >> ((a * 3) & 0xff);
			}
			int res = 1;
			if ((c & 7) == 6)
				res = 2;
			if ((c & 7) == 7)
				res = 3;
			return res;*/
		}

		// // RVA: 0x143EA6C Offset: 0x143EA6C VA: 0x143EA6C
		// public void SetStoryParam(StoryBgParam param) { }

		// // RVA: 0x143EA78 Offset: 0x143EA78 VA: 0x143EA78
		public StoryBgParam OutputStoryBgParam(bool isStory)
		{
			storyBgParam.isCategoryStory = isStory;
			storyBgParam.x = m_bgBehaviour.storyBgScrollRect.content.anchoredPosition.x;
			return storyBgParam;
		}

		// // RVA: 0x143EB70 Offset: 0x143EB70 VA: 0x143EB70
		public void StorytBgReturn()
		{
			if(storyBgParam.isCategoryStory)
			{
				TodoLogger.LogError(0, "StorytBgReturn");
			}
			storyBgLoading = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C5CB0 Offset: 0x6C5CB0 VA: 0x6C5CB0
		// // RVA: 0x143ED60 Offset: 0x143ED60 VA: 0x143ED60
		public IEnumerator SetStoryBgTexture(int map, Action callback)
		{
			//0x14444E8
			storyBgLoading = true;
			storyBgParam.map = map;
			yield return Co.R(m_bgBehaviour.SetupStoryBg(map, null));
			storyBgLoading = false;
			if (callback != null)
				callback();
		}

		// // RVA: 0x143EE40 Offset: 0x143EE40 VA: 0x143EE40
		public bool IsLoadingStoryBg()
		{
			return storyBgLoading;
		}

		// // RVA: 0x143EE48 Offset: 0x143EE48 VA: 0x143EE48
		public void StoryBgShow()
		{
			m_bgBehaviour.StoryBgShow();
		}

		// // RVA: 0x143EE70 Offset: 0x143EE70 VA: 0x143EE70
		public void StoryBgHide()
		{
			m_bgBehaviour.StoryBgHide();
		}

		// // RVA: 0x143EC5C Offset: 0x143EC5C VA: 0x143EC5C
		// public void SetStoryBgSetPositionX(float x) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C5D28 Offset: 0x6C5D28 VA: 0x6C5D28
		// // RVA: 0x143EF2C Offset: 0x143EF2C VA: 0x143EF2C
		// private void <StorytBgReturn>b__88_0() { }
	}
}

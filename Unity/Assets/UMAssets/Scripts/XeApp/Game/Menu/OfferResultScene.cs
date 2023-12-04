using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferResultScene : TransitionRoot
	{
		private int m_pilotId; // 0x48
		private int m_valId; // 0x4C
		private const int VcItemId = 10001;
		private const float PopWaitTime = 0.5f;
		private UnlockValkyrieScene.CameraInfo m_DefaultCameraInfo; // 0x50
		private UnlockValkyrieScene.CameraInfo m_FinishCameraInfo; // 0x54
		private List<UnlockValkyrieScene.CameraInfo> m_FinishCameraInfoList = new List<UnlockValkyrieScene.CameraInfo>(); // 0x58
		private float m_CameraFieldOfView; // 0x5C
		private float m_CameraFarClip; // 0x60
		private float m_CameraNearClip; // 0x64
		private float m_CameraLerpTime; // 0x68
		[SerializeField]
		private ScriptableObject m_CameraParam; // 0x6C
		[SerializeField]
		private Button m_SkipButton; // 0x70
		private UnlockValkyrieObject m_Object; // 0x74
		private OfferResultEffect m_Effect; // 0x78
		private OfferGetItemLayout m_layout; // 0x7C
		private OfferReturnLayout m_EntryLayout; // 0x80
		private OfferSortiePilotLayout m_pilotCutIn; // 0x84
		private bool m_model_loaded; // 0x88
		private bool m_IsRady; // 0x89
		private bool IsLayoutAssetLoad; // 0x8A
		private bool IsGreatSuccessState = true; // 0x8B
		private ViewOfferCompensation m_viewCompItem; // 0x8C
		private OfferResultOkayLayout m_OkayButtonLayout; // 0x90
		private OfferResultTitleLayout m_titleLayout; // 0x94
		private HEFCLPGPMLK.ANKPCIEKPAH ValkyrieData; // 0x98
		private HEFCLPGPMLK.AAOPGOGGMID m_viewOfferInfo; // 0x9C
		private int m_valkyrieId; // 0xA0
		private bool IsProductionEnd; // 0xA4
		private bool IsEndRelease; // 0xA5
		private bool IsEntryAssetLoaded; // 0xA6

		//// RVA: 0x1856274 Offset: 0x1856274 VA: 0x1856274
		private void InitializeFinishCameraData()
		{
			ValkyrieCameraParameter p = m_CameraParam as ValkyrieCameraParameter;
			m_DefaultCameraInfo = new UnlockValkyrieScene.CameraInfo(p.m_DefaultCameraPosition, p.m_DefaultTargetPosition);
			m_FinishCameraInfo = new UnlockValkyrieScene.CameraInfo(p.m_FinishCameraInfo, p.m_FinishTargetInfo);
			m_CameraFieldOfView = p.m_CameraFieldOfView;
			m_CameraFarClip = p.m_CameraFarClip;
			m_CameraNearClip = p.m_CameraNearClip;
			m_CameraLerpTime = p.m_CameraLerpTime;
			m_FinishCameraInfoList.Clear();
			for(int i = 0; i < p.m_FinishCameraPositionList.Count; i++)
			{
				m_FinishCameraInfoList.Add(new UnlockValkyrieScene.CameraInfo(p.m_FinishCameraPositionList[i], p.m_FinishTargetPositionList[i]));
			}
		}

		// RVA: 0x1856628 Offset: 0x1856628 VA: 0x1856628
		private void Start()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.BKLNHBHDDEJ(JpStringLiterals.StringLiteral_18843);
		}

		// RVA: 0x18566D4 Offset: 0x18566D4 VA: 0x18566D4
		private void Update()
		{
			return;
		}

		// RVA: 0x18566D8 Offset: 0x18566D8 VA: 0x18566D8 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			InitializeFinishCameraData();
			IsReady = true;
		}

		// RVA: 0x1856708 Offset: 0x1856708 VA: 0x1856708 Slot: 16
		protected override void OnPreSetCanvas()
		{
			IsProductionEnd = false;
			base.OnPreSetCanvas();
			OfferResultArgs arg = Args as OfferResultArgs;
			if (arg != null)
				m_viewOfferInfo = arg.offerInfo;
			this.StartCoroutineWatched(Co_EntryLoadAsset());
		}

		// RVA: 0x185685C Offset: 0x185685C VA: 0x185685C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsEntryAssetLoaded;
		}

		// RVA: 0x1856864 Offset: 0x1856864 VA: 0x1856864 Slot: 18
		protected override void OnPostSetCanvas()
		{
			this.StartCoroutineWatched(Co_MainFlow());
			base.OnPostSetCanvas();
		}

		// RVA: 0x1856920 Offset: 0x1856920 VA: 0x1856920 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return IsLayoutAssetLoad;
		}

		// RVA: 0x1856928 Offset: 0x1856928 VA: 0x1856928
		private void Reset()
		{
			ApplyCameraParameter();
			m_Object.Reset();
			m_Effect.Reset();
		}

		// RVA: 0x1856AA8 Offset: 0x1856AA8 VA: 0x1856AA8 Slot: 14
		protected override void OnDestoryScene()
		{
			GameManager.Instance.SetFPS(30);
			MenuScene.Instance.BgControl.SetPriority(BgPriority.Bottom);
		}

		// RVA: 0x1856BC0 Offset: 0x1856BC0 VA: 0x1856BC0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			IsEndRelease = false;
			Reset();
			this.StartCoroutineWatched(Co_AllAssetRelease(() =>
			{
				//0x1858AC4
				IsEndRelease = true;
			}));
		}

		// RVA: 0x1856D24 Offset: 0x1856D24 VA: 0x1856D24 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return IsEndRelease;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F999C Offset: 0x6F999C VA: 0x6F999C
		//// RVA: 0x1856C7C Offset: 0x1856C7C VA: 0x1856C7C
		private IEnumerator Co_AllAssetRelease(Action endcallBack)
		{
			//0x1859A10
			yield return Co.R(Co_ValkyrieRelease());
			if (IsProductionEnd)
				m_layout.ResetScrollList();
			m_layout.ReleaseBonusIconList();
			Co_LayoutRelease();
			yield return Resources.UnloadUnusedAssets();
			yield return null;
			GC.Collect();
			if (endcallBack != null)
				endcallBack();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9A14 Offset: 0x6F9A14 VA: 0x6F9A14
		//// RVA: 0x1856D4C Offset: 0x1856D4C VA: 0x1856D4C
		private IEnumerator Co_ValkyrieRelease()
		{
			//0x185CA48
			if(m_Object != null)
				m_Object.Release();
			if (m_Effect != null)
				m_Effect.Release();
			yield return null;
			m_Object = null;
			m_Effect = null;
		}

		//// RVA: 0x1856DF8 Offset: 0x1856DF8 VA: 0x1856DF8
		private void Co_LayoutRelease()
		{
			if(m_layout != null)
			{
				DestroyImmediate(m_layout.gameObject);
				m_layout = null;
			}
			if(m_pilotCutIn != null)
			{
				DestroyImmediate(m_pilotCutIn.gameObject);
				m_pilotCutIn = null;
			}
			if(m_OkayButtonLayout != null)
			{
				DestroyImmediate(m_OkayButtonLayout.gameObject);
				m_OkayButtonLayout = null;
			}
			if(m_titleLayout != null)
			{
				DestroyImmediate(m_titleLayout.gameObject);
				m_titleLayout = null;
			}
			if(m_EntryLayout != null)
			{
				DestroyImmediate(m_EntryLayout.gameObject);
				m_EntryLayout = null;
			}
		}

		//// RVA: 0x18571A0 Offset: 0x18571A0 VA: 0x18571A0
		private void SetSkipButton()
		{
			m_SkipButton.onClick.RemoveAllListeners();
			m_SkipButton.onClick.AddListener(() =>
			{
				//0x1858AD0
				m_layout.IsSkip = true;
			});
			m_layout.IsSkip = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9A8C Offset: 0x6F9A8C VA: 0x6F9A8C
		//// RVA: 0x1856894 Offset: 0x1856894 VA: 0x1856894
		private IEnumerator Co_MainFlow()
		{
			//0x185BBF0
			EntryAnimStart();
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			KDHGBOOECKC.HHCJCDFCLOB.MOOJLBNGNOB(m_viewOfferInfo.FGHGMHPNEMG_Category, m_viewOfferInfo.PPFNGGCBJKC, BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete);
			KDHGBOOECKC.HHCJCDFCLOB.PGGLEDMJEHB(m_viewOfferInfo.FGHGMHPNEMG_Category, m_viewOfferInfo.PPFNGGCBJKC, 1);
			KDHGBOOECKC.HHCJCDFCLOB.EBJOGGIHHBA(m_viewOfferInfo.FGHGMHPNEMG_Category, m_viewOfferInfo.PPFNGGCBJKC, false);
			JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.PMMOLBAAHEM_31);
			m_viewCompItem = ViewOfferCompensation.CreateList(m_viewOfferInfo.FGHGMHPNEMG_Category, m_viewOfferInfo.PPFNGGCBJKC);
			IsGreatSuccessState = m_viewCompItem.IsGreatSuccess;
			ILCCJNDFFOB.HHCJCDFCLOB.ONPIDKLOPIP(m_viewOfferInfo.FGHGMHPNEMG_Category, m_viewOfferInfo.PPFNGGCBJKC, IsGreatSuccessState ? 2 : 1);
			yield return null;
			this.StartCoroutineWatched(AllAssetLoad());
			yield return new WaitUntil(() =>
			{
				//0x1859188
				return IsLayoutAssetLoad;
			});
			SetSkipButton();
			layoutInitialize();
			OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.FOFLMHELILC.Find((OCMJNBIFJNM_Offer.JPOHOLBBFGP _) =>
			{
				//0x18591AC
				if (_.GBJFNGCDKPM_Type != (int)m_viewOfferInfo.FGHGMHPNEMG_Category)
					return false;
				return _.MLDPDLPHJPM_OfferId == m_viewOfferInfo.PPFNGGCBJKC;
			});
			m_layout.SettingValkyrieFormIcon(of.MNCEBKHBBEF_VFform, (int)m_viewOfferInfo.FGHGMHPNEMG_Category, m_viewOfferInfo.PPFNGGCBJKC);
			while (!m_layout.ItemIconLoded())
				yield return null;
			yield return null;
			yield return Co.R(Co_Setup());
			yield return new WaitUntil(() =>
			{
				//0x1859270
				return m_model_loaded;
			});
			while (m_pilotCutIn.IsImageLoading())
				yield return null;
			bool isSuccess = false;
			MenuScene.SaveWithAchievement(0x1000000000, () =>
			{
				//0x1859294
				isSuccess = true;
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			}, () =>
			{
				//0x18590E0
				SoundManager.Instance.sePlayerMenu.Stop();
				JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			});
			while (!isSuccess)
				yield return null;
			bool done = false;
			bool err = false;
			PBJPACKDIIB.NPIJAIOCACL(() =>
			{
				//0x18592D4
				done = true;
			}, () =>
			{
				//0x18592E0
				done = true;
				err = true;
			});
			while (!done)
				yield return null;
			while (!m_EntryLayout.IsEntryEnd)
				yield return null;
			EntryAnimLeave();
			yield return Co.R(DirectionCoroutine());
			m_IsRady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9B04 Offset: 0x6F9B04 VA: 0x6F9B04
		//// RVA: 0x18572EC Offset: 0x18572EC VA: 0x18572EC
		private IEnumerator Co_Setup()
		{
			//0x185C7C8
			HEFCLPGPMLK d = new HEFCLPGPMLK();
			ValkyrieData = d.FFGHIOAOABE(d.LLMEKDNIOEF(m_viewOfferInfo.FGHGMHPNEMG_Category, m_viewOfferInfo.PPFNGGCBJKC));
			if(ValkyrieData == null)
			{
				m_pilotId = 1;
				m_valId = 1;
			}
			else
			{
				m_pilotId = ValkyrieData.PFGJJLGLPAC_PilotId;
				m_valId = ValkyrieData.LLOBHDMHJIG_Id;
			}
			Initialize();
			yield return new WaitWhile(() =>
			{
				//0x1858B00
				return !m_model_loaded;
			});
		}

		//// RVA: 0x1857398 Offset: 0x1857398 VA: 0x1857398
		private void Initialize()
		{
			GameManager.Instance.SetFPS(60);
			InitializeValkyrie(m_valId);
			m_pilotCutIn.SetUp(m_pilotId, false);
			InputEnable();
		}

		//// RVA: 0x1857558 Offset: 0x1857558 VA: 0x1857558
		private bool valkyrieEnterSkip()
		{
			if(m_layout.IsSkip)
			{
				m_Object.ValkyrieAnimSkip(100.0f);
				return true;
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9B7C Offset: 0x6F9B7C VA: 0x6F9B7C
		//// RVA: 0x18575C4 Offset: 0x18575C4 VA: 0x18575C4
		private IEnumerator DirectionCoroutine()
		{
			bool retry; // 0x18
			bool IsEffectPlaying; // 0x19
			List<KDHGBOOECKC.IBAOKNMIBCL> NotReceiveItemList; // 0x1C
			int i; // 0x20

			//0x185CC84
			retry = false;
			do
			{ 
				//LAB_0185da6c
				retry = false;
				m_SkipButton.transform.SetAsLastSibling();
				GameManager.Instance.SetFPS(60);
				m_Object.Enter();
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_002);
				m_Effect.PlayBackFlash();
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x1858B14
					if(m_Object.GetCurrentForm() == FKGMGBHBNOC.HPJOCKGKNCC_Form.AEFCOHJBLPO_Num || m_Object.GetCurrentForm() == FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter)
					{
						return !valkyrieEnterSkip();
					}
					SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VALKYRIE_000);
					return false;
				});
				yield return new WaitWhile(() =>
				{
					//0x1858BB4
					if (valkyrieEnterSkip())
						return false;
					return !m_Object.IsEntered();
				});
				if(!m_layout.IsSkip)
				{
					m_pilotCutIn.Enter();
					m_Effect.Play(0);
					if(!IsGreatSuccessState)
					{
						m_Effect.Play(OfferResultEffect.OfferEfectType.SuccessA);
						SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Offer_Success, 0);
						SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VFOPS_005);
					}
					else
					{
						m_Effect.Play(OfferResultEffect.OfferEfectType.SuccessB);
						SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Offer_Great, 0);
						SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VFOPS_006);
					}
				}
				else
				{
					m_Effect.AnimSkip(!IsGreatSuccessState ? OfferResultEffect.OfferEfectType.SuccessA : OfferResultEffect.OfferEfectType.SuccessB);
				}
				IsEffectPlaying = false;
				//LAB_0185d9f8
				do
				{
					IsEffectPlaying = m_Effect.IsPlaying(0);
					IsEffectPlaying |= m_Effect.IsPlaying(IsGreatSuccessState ? OfferResultEffect.OfferEfectType.SuccessB : OfferResultEffect.OfferEfectType.SuccessA);
					yield return null;
				} while (IsEffectPlaying);
				m_pilotCutIn.ResultLeave();
				yield return null;
				while (m_pilotCutIn.IsPlayingChildren() && !m_layout.IsSkip)
					yield return null;
				m_pilotCutIn.Hide();
				GameManager.Instance.ResetViewPlayerData();
				m_layout.ResetUC();
				m_layout.ScrollContentAllHide();
				yield return null;
				m_layout.Enter();
				m_titleLayout.Enter();
				yield return null;
				while (m_layout.IsPlaying())
					yield return null;
				m_layout.BonusIconLoopAnimStart();
				m_layout.EnterChild();
				yield return null;
				while (m_layout.IsPlayingInWindow())
				{
					if(m_layout.IsSkip)
					{
						m_layout.ShowChild();
					}
					yield return null;
				}
				yield return null;
				yield return Co.R(m_layout.ScrollAnimPlay());
				if(!m_layout.IsSkip)
				{
					yield return Co.R(m_layout.Co_AutoScrolling(0, 0.1f, null));
				}
				else
				{
					yield return KDHGBOOECKC.HHCJCDFCLOB.FMGMIKPJNKG_Co_wait(0.1f, false, null);
				}
				m_layout.ResetScrollBar();
				m_layout.CampaignAnimStart();
				yield return null;
				while (m_layout.IsPlayingInWindow() && !m_layout.IsSkip)
					yield return null;
				m_layout.DropItemBounsNumAnumStart();
				yield return null;
				while (m_layout.IsPlayingDropItem() && !m_layout.IsSkip)
					yield return null;
				if(!m_layout.IsSkip)
				{
					yield return Co.R(m_layout.SceneCardCheck());
					m_layout.UCEnter();
					yield return null;
					while (m_layout.IsPlayingInWindow() && !m_layout.IsSkip)
						yield return null;
					yield return null;
					yield return Co.R(m_layout.Co_PlayingUCAnim());
					m_layout.UC_AnimSkip();
				}
				//LAB_0185d514
				if(m_layout.IsSkip)
				{
					m_layout.ShowDropItem();
					yield return Co.R(m_layout.SceneCardCheck());
					m_layout.CampaignAnimShow();
					m_layout.DropItemBounsNumAnumShow();
					m_layout.UCShow();
					m_layout.UC_AnimSkip();
				}
				bool IsOpnePopup = true;
				ShowItemGetPopup(() =>
				{
					//0x18592F4
					IsOpnePopup = false;
				});
				while (IsOpnePopup)
					yield return null;
				IsOpnePopup = true;
				NotReceiveItemList = KDHGBOOECKC.HHCJCDFCLOB.NGHMGNMNNEP.AJPLGEHPPGN;
				for(i = 0; i < NotReceiveItemList.Count; i++)
				{
					IsOpnePopup = true;
					ShowNotReceivedPopup(NotReceiveItemList[i].PPFNGGCBJKC_Id, NotReceiveItemList[i].BFINGCJHOHI_Cnt, () =>
					{
						//0x1859300
						IsOpnePopup = false;
					});
					while (IsOpnePopup)
						yield return null;
				}
				m_OkayButtonLayout.Enter();
				m_SkipButton.transform.SetAsFirstSibling();
				IsProductionEnd = true;
				GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
				NotReceiveItemList = null;
			} while (retry);
		}

		//// RVA: 0x1857670 Offset: 0x1857670 VA: 0x1857670
		private void ShowItemGetPopup(Action PopupClose)
		{
			if(m_viewOfferInfo.OHOGIHMFEIJ)
			{
				if(m_viewOfferInfo.CADENLBDAEB)
				{
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					PopupItemGetSetting s = new PopupItemGetSetting();
					s.TitleText = bk.GetMessageByLabel("offer_result_first_achievement_title");
					s.ItemId = 10001;
					s.Count = m_viewOfferInfo.KPFHAMNOIAG;
					s.IsPresentBox = true;
					s.IsCaption = true;
					s.WindowSize = SizeType.Small;
					s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
					PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x185930C
						PopupClose();
					}, null, null, null);
				}
			}
		}

		//// RVA: 0x1857AE4 Offset: 0x1857AE4 VA: 0x1857AE4
		private void ShowNotReceivedPopup(int _itemId, int _itemCount, Action closePopup)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupNotReceiveItemSetting s = new PopupNotReceiveItemSetting();
			s.DescText = bk.GetMessageByLabel("offer_not_received_item_text");
			s.ItemId = _itemId;
			s.ItemCount = _itemCount;
			s.TitleText = bk.GetMessageByLabel("offer_not_received_item_title");
			s.WindowSize = SizeType.Small;
			s.IsCaption = true;
			s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
			PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1859338
				closePopup();
			}, null, null, null);
		}

		//// RVA: 0x185748C Offset: 0x185748C VA: 0x185748C
		public void InitializeValkyrie(float camDepth = 0)
		{
			PNGOLKLFFLH p = new PNGOLKLFFLH();
			p.KHEKNNFCAOI_Init(m_valId, 0, 0);
			this.StartCoroutineWatched(Load3dResourceCoroutine(m_valId, camDepth));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9BF4 Offset: 0x6F9BF4 VA: 0x6F9BF4
		//// RVA: 0x1857E78 Offset: 0x1857E78 VA: 0x1857E78
		private IEnumerator Load3dResourceCoroutine(int valkyrieId, float camDepth = 0)
		{
			//0x185E03C
			m_model_loaded = false;
			m_Object = GetComponentInChildren<UnlockValkyrieObject>(true);
			ApplyCameraParameter();
			m_Object.LoadResource(valkyrieId);
			bool IsCueChenged = false;
			SoundManager.Instance.voPilot.RequestChangeCueSheet_offer(m_pilotId, () =>
			{
				//0x185936C
				IsCueChenged = true;
			});
			while(!IsCueChenged)
				yield return null;
			m_valkyrieId = valkyrieId;
			yield return new WaitWhile(() =>
			{
				//0x1859378
				return !m_Object.IsLoaded();
			});
			m_Effect = GetComponentInChildren<OfferResultEffect>(true);
			m_Effect.LoadResource();
			yield return new WaitWhile(() =>
			{
				//0x18593BC
				return !m_Object.IsLoaded() || !m_Effect.IsLoaded();
			});
			m_Object.Camera.depth = camDepth;
			m_model_loaded = true;
		}

		//// RVA: 0x1856978 Offset: 0x1856978 VA: 0x1856978
		private void ApplyCameraParameter()
		{
			m_Object.DefaultCameraInfo = m_DefaultCameraInfo;
			m_Object.FinishCameraInfo = m_FinishCameraInfo;
			m_Object.FinishCameraInfoList = m_FinishCameraInfoList;
			m_Object.CameraFieldOfView = m_CameraFieldOfView;
			m_Object.CameraFarClip = m_CameraFarClip;
			m_Object.CameraNearClip = m_CameraNearClip;
			m_Object.CameraLerpTime = m_CameraLerpTime;
		}

		//// RVA: 0x1857F64 Offset: 0x1857F64 VA: 0x1857F64
		private void layoutInitialize()
		{
			m_layout.SetView(m_viewCompItem);
			m_layout.Initialize();
			m_layout.Hide();
		}

		//// RVA: 0x1857FDC Offset: 0x1857FDC VA: 0x1857FDC
		//public void AssetLoadStart() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6F9C6C Offset: 0x6F9C6C VA: 0x6F9C6C
		//// RVA: 0x1858000 Offset: 0x1858000 VA: 0x1858000
		private IEnumerator AllAssetLoad()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18

			//0x18595AC
			IsLayoutAssetLoad = false;
			bundleName = "ly/145.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsGetItemList(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutListItem(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsOKButton(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsTitle(bundleName, systemFont));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (!m_layout.IsLoaded())
				yield return null;
			while (!m_OkayButtonLayout.IsLoaded())
				yield return null;
			while (!m_titleLayout.IsLoaded())
				yield return null;
			yield return null;
			IsLayoutAssetLoad = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9CE4 Offset: 0x6F9CE4 VA: 0x6F9CE4
		//// RVA: 0x18580AC Offset: 0x18580AC VA: 0x18580AC
		private IEnumerator Co_LoadAssetsOKButton(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x185B2F4
			if(m_OkayButtonLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_btn_ok_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1858BFC
					instance.transform.SetParent(transform, false);
					m_OkayButtonLayout = instance.GetComponent<OfferResultOkayLayout>();
					m_OkayButtonLayout.SetOKButtonAction(OnClickOkBtn);
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			else
			{
				m_OkayButtonLayout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9D5C Offset: 0x6F9D5C VA: 0x6F9D5C
		//// RVA: 0x185818C Offset: 0x185818C VA: 0x185818C
		private IEnumerator Co_LoadAssetsTitle(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x185B8DC
			if(m_titleLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_midasi_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1858D24
					instance.transform.SetParent(transform, false);
					m_titleLayout = instance.GetComponent<OfferResultTitleLayout>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_titleLayout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9DD4 Offset: 0x6F9DD4 VA: 0x6F9DD4
		//// RVA: 0x185826C Offset: 0x185826C VA: 0x185826C
		private IEnumerator Co_LoadAssetsGetItemList(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x185A828
			if(m_layout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_drop_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1858DF4
					instance.transform.SetParent(transform, false);
					m_layout = instance.GetComponent<OfferGetItemLayout>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_layout.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9E4C Offset: 0x6F9E4C VA: 0x6F9E4C
		//// RVA: 0x185834C Offset: 0x185834C VA: 0x185834C
		private IEnumerator Co_LoadAssetsLayoutListItem(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation; // 0x20
			int poolSize; // 0x24
			int i; // 0x28

			//0x185AB3C
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_getitem_set_layout_root");
			yield return operation;
			List<OfferGetItemContent> contentList = new List<OfferGetItemContent>();
			LayoutUGUIRuntime baseRuntime = null;
			poolSize = m_viewCompItem.ItemList.Count;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x185944C
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
				contentList.Add(baseRuntime.GetComponent<OfferGetItemContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			List<OfferGetItemContent> l = new List<OfferGetItemContent>();
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = baseRuntime.name.Replace("00", i.ToString("D2"));
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				contentList.Add(r.GetComponent<OfferGetItemContent>());
			}
			for(i = 0; i < contentList.Count; i++)
			{
				while (!contentList[i].IsLoaded())
					yield return null;
			}
			m_layout.AddScrollContent(contentList);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9EC4 Offset: 0x6F9EC4 VA: 0x6F9EC4
		//// RVA: 0x18567D0 Offset: 0x18567D0 VA: 0x18567D0
		private IEnumerator Co_EntryLoadAsset()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0x1859C5C
			IsEntryAssetLoaded = false;
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VFOPS_004);
			if(m_EntryLayout == null)
			{
				bundleName = "ly/147.xab";
				systemFont = GameManager.Instance.GetSystemFont();
				yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
				if(m_EntryLayout != null)
				{
					m_layout.transform.SetParent(transform, false);
				}
				else
				{ 
					operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sortie_vfo_return_layout_root");
					yield return operation;
					yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
					{
						//0x1858EC4
						instance.transform.SetParent(transform, false);
						m_EntryLayout = instance.GetComponent<OfferReturnLayout>();
					}));
					AssetBundleManager.UnloadAssetBundle(bundleName, false);
					operation = null;
				}
				//LAB_0185a12c
				yield return Co.R(Co_LoadAssetsPilotCutinLayout(bundleName, systemFont));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				while(!m_EntryLayout.IsLoaded())
					yield return null;
				while (!m_pilotCutIn.IsLoaded())
					yield return null;
			}
			//LAB_0185a0ac
			IsEntryAssetLoaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9F3C Offset: 0x6F9F3C VA: 0x6F9F3C
		//// RVA: 0x185844C Offset: 0x185844C VA: 0x185844C
		private IEnumerator Co_LoadAssetsPilotCutinLayout(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x185B608
			if(m_pilotCutIn == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sortie_vfo_pilot_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1858F94
					instance.transform.SetParent(transform, false);
					m_pilotCutIn = instance.GetComponent<OfferSortiePilotLayout>();
				}));
				operation = null;
			}
			else
			{
				m_pilotCutIn.transform.SetParent(transform, false);
			}
		}

		//// RVA: 0x185852C Offset: 0x185852C VA: 0x185852C
		private void EntryAnimStart()
		{
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VFOPS_003);
			m_EntryLayout.AnimStart();
		}

		//// RVA: 0x185868C Offset: 0x185868C VA: 0x185868C
		private void EntryAnimLeave()
		{
			SoundManager.Instance.sePlayerMenu.Stop();
			m_EntryLayout.AnimLeave();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9FB4 Offset: 0x6F9FB4 VA: 0x6F9FB4
		//// RVA: 0x1858794 Offset: 0x1858794 VA: 0x1858794
		//private IEnumerator Co_IsPlayingEntryAnim() { }

		//// RVA: 0x1858840 Offset: 0x1858840 VA: 0x1858840
		public void OnClickOkBtn()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			this.StartCoroutineWatched(Co_LayoutLeave());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FA02C Offset: 0x6FA02C VA: 0x6FA02C
		//// RVA: 0x1858980 Offset: 0x1858980 VA: 0x1858980
		private IEnumerator Co_LayoutLeave()
		{
			bool _IsPlaying;

			//0x185A3B8
			MenuScene.Instance.RaycastDisable();
			_IsPlaying = true;
			m_layout.Leave();
			m_titleLayout.Leave();
			m_OkayButtonLayout.Leave();
			GameManager.Instance.fullscreenFader.Fade(0.1f, Color.black);
			if (_IsPlaying)
			{
				_IsPlaying = m_layout.IsPlaying() || m_titleLayout.IsPlaying() || m_OkayButtonLayout.IsPlaying();
				yield return null;
			}
			MenuScene.Instance.RaycastEnable();
			MenuScene.Instance.Return(true);
		}

		//// RVA: 0x1858A2C Offset: 0x1858A2C VA: 0x1858A2C
		private void OnBackButton()
		{
			OnClickOkBtn();
		}
	}
}

using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class OfferFormationScene : TransitionRoot
	{
		public enum OfferFormationArrow
		{
			NONE = 0,
			LEFT = 1,
			RIGHIT = 2,
		}

		public static int FORMATION_MAX_NUM = 5; // 0x0
		public static int FORMATION_VAL_NUM = 3; // 0x4
		[SerializeField]
		private OfferFormationController m_offerFormationController; // 0x48
		private List<HEFCLPGPMLK.ANKPCIEKPAH> m_ValkyrieList = new List<HEFCLPGPMLK.ANKPCIEKPAH>(); // 0x4C
		private List<HEFCLPGPMLK.ANKPCIEKPAH>[] m_SeriesValkyrieList = new List<HEFCLPGPMLK.ANKPCIEKPAH>[5]; // 0x50
		private List<HEFCLPGPMLK.ANKPCIEKPAH>[] FormationList = new List<HEFCLPGPMLK.ANKPCIEKPAH>[FORMATION_MAX_NUM]; // 0x54
		private bool ReturnScene = true; // 0x58
		private bool IsChengeLayout = true; // 0x59
		private bool IsInitialize; // 0x5A
		private DFKGGBMFFGB_PlayerInfo m_PlayerData; // 0x5C
		private JLKEOGLJNOD_TeamInfo m_UnitData; // 0x60
		private Action m_Updater; // 0x64
		public int SelectSeries; // 0x68
		public int Select; // 0x6C
		private int SelectBanner; // 0x70
		private OfferInfoLayout m_InfoLayout; // 0x74
		private HEFCLPGPMLK.AAOPGOGGMID m_offerViewInfoData; // 0x78
		private HEFCLPGPMLK m_view; // 0x7C
		private OfferHaveItemCheck itemCheckButton; // 0x80
		private OfferSelectDivaController m_divaController; // 0x84
		private SwaipTouch m_SwaipTouch; // 0x88
		private bool IsSwipOff; // 0x8C
		private bool IsLeaveing; // 0x8D

		// RVA: 0x1526358 Offset: 0x1526358 VA: 0x1526358
		private void Awake()
		{
			//m_Updater = OfferFormationController.formationSelectUpdate;
			for(int i = 0; i < m_SeriesValkyrieList.Length; i++)
			{
				m_SeriesValkyrieList[i] = new List<HEFCLPGPMLK.ANKPCIEKPAH>();
			}
			m_Updater = UpdateInit;
			IsReady = true;
		}

		// RVA: 0x15264F0 Offset: 0x15264F0 VA: 0x15264F0
		private void Start()
		{
			ILCCJNDFFOB.HHCJCDFCLOB.BKLNHBHDDEJ(JpStringLiterals.StringLiteral_18797);
		}

		//// RVA: 0x152659C Offset: 0x152659C VA: 0x152659C
		private void UpdateInit()
		{
			if(m_offerFormationController != null)
			{
				if (!m_offerFormationController.IsAssetLoad)
					return;
				m_Updater = UpdateIdel;
			}
		}

		//// RVA: 0x152668C Offset: 0x152668C VA: 0x152668C
		private void UpdateIdel()
		{
			if(!IsSwipOff)
			{
				if(m_SwaipTouch != null)
				{
					if(!m_SwaipTouch.IsStop())
					{
						if(m_SwaipTouch.IsFlick(SwaipTouch.Direction.RIGHT))
						{
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
							OnClickArrow(OfferFormationArrow.LEFT);
							SwaipReset();
						}
						if(m_SwaipTouch.IsFlick(SwaipTouch.Direction.LEFT))
						{
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
							OnClickArrow(OfferFormationArrow.RIGHIT);
							SwaipReset();
						}
					}
				}
			}
		}

		//// RVA: 0x1526A94 Offset: 0x1526A94 VA: 0x1526A94
		private void SwaipReset()
		{
			m_SwaipTouch.ResetValue();
			m_SwaipTouch.ResetInputState();
		}

		// RVA: 0x1526AE4 Offset: 0x1526AE4 VA: 0x1526AE4
		private void Update()
		{
			if (m_Updater != null)
				m_Updater();
		}

		//// RVA: 0x1526AF8 Offset: 0x1526AF8 VA: 0x1526AF8
		//private bool IsAllAssetLoad() { }

		// RVA: 0x1526B00 Offset: 0x1526B00 VA: 0x1526B00 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_offerFormationController.StartAssetLoad();
			this.StartCoroutineWatched(Co_IsInitialize());
			m_view = new HEFCLPGPMLK();
			m_view.CFMHAGBNNKA();
			IsSwipOff = true;
			ReturnScene = true;
			OfferFormationArgs args = Args as OfferFormationArgs;
			if(args != null)
			{
				m_offerViewInfoData = args.viewOfferData;
				m_offerFormationController.selectFormation = 0;
				itemCheckButton = args.itemCheckButton;
				m_divaController = args.DivaController;
			}
		}

		// RVA: 0x1526D0C Offset: 0x1526D0C VA: 0x1526D0C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return IsInitialize;
		}

		// RVA: 0x1526D14 Offset: 0x1526D14 VA: 0x1526D14 Slot: 18
		protected override void OnPostSetCanvas()
		{
			m_InfoLayout.transform.SetParent(transform.parent, false);
			this.StartCoroutineWatched(Co_Start());
			base.OnPostSetCanvas();
		}

		// RVA: 0x1526E4C Offset: 0x1526E4C VA: 0x1526E4C Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0x1526E54 Offset: 0x1526E54 VA: 0x1526E54 Slot: 21
		protected override void OnOpenScene()
		{
			base.OnOpenScene();
		}

		// RVA: 0x1526E5C Offset: 0x1526E5C VA: 0x1526E5C Slot: 22
		protected override bool IsEndOpenScene()
		{
			return base.IsEndOpenScene();
		}

		// RVA: 0x1526E64 Offset: 0x1526E64 VA: 0x1526E64 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return base.IsEndActivateScene();
		}

		// RVA: 0x1526E6C Offset: 0x1526E6C VA: 0x1526E6C Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
			this.StartCoroutineWatched(Co_LayoutLeave());
		}

		// RVA: 0x1526F28 Offset: 0x1526F28 VA: 0x1526F28 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !IsLeaveing;
		}

		// RVA: 0x1526F3C Offset: 0x1526F3C VA: 0x1526F3C Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			if(ReturnScene)
			{
				m_InfoLayout.Leave();
			}
			m_offerFormationController.LayoutDestroy();
		}

		// RVA: 0x1526F9C Offset: 0x1526F9C VA: 0x1526F9C Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_InfoLayout != null)
			{
				m_InfoLayout.transform.SetParent(transform, false);
			}
		}

		//// RVA: 0x1527088 Offset: 0x1527088 VA: 0x1527088
		private void ResetValkyrieData()
		{
			m_ValkyrieList = m_view.AANFIKBAJPI_GetValkyrieList();
			for(int i = 0; i < m_SeriesValkyrieList.Length; i++)
			{
				m_SeriesValkyrieList[i].Clear();
			}
			for(int i = 0; i < m_ValkyrieList.Count; i++)
			{
				m_SeriesValkyrieList[(int)m_ValkyrieList[i].CPKMLLNADLJ_Attr - 1].Add(m_ValkyrieList[i]);
			}
			for(int i = 0; i < 5; i++)
			{
				FormationList[i] = m_view.PMFIOHGEPPD(i + 1, true);
			}
			if (FormationList[m_offerFormationController.selectFormation].Count >= 0)
				VfIdSearchSeriesAndSelect(m_view.FFGHIOAOABE(m_offerFormationController.selectFormation + 1).LLOBHDMHJIG_Id);
			else
				VfIdSearchSeriesAndSelect(1);
		}

		//// RVA: 0x152744C Offset: 0x152744C VA: 0x152744C
		private void VfIdSearchSeriesAndSelect(int vfId)
		{
			if (vfId < 2)
				vfId = 1;
			//LLOBHDMHJIG = id
			HEFCLPGPMLK.ANKPCIEKPAH d = m_ValkyrieList.Find((HEFCLPGPMLK.ANKPCIEKPAH _) =>
			{
				//0x1529244
				return _.LLOBHDMHJIG_Id == vfId;
			});
			SelectSeries = (int)d.CPKMLLNADLJ_Attr - 1;
			Select = m_SeriesValkyrieList[SelectSeries].FindIndex((HEFCLPGPMLK.ANKPCIEKPAH _) =>
			{
				//0x152927C
				return _.LLOBHDMHJIG_Id == vfId;
			});
		}

		//// RVA: 0x1527620 Offset: 0x1527620 VA: 0x1527620
		private void SettingSelectSeriesAndSelectIndex(int vfId)
		{
			if(vfId < 1)
			{
				vfId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.AHMOGDDPIFL_LastVfId;
				List<int> l = m_view.LOEDABGEMFJ(GameManager.Instance.localSave.EPJOACOONAC_GetSave().DKFCBKNPPOO_Offer.CPKMLLNADLJ_Series);
				if (l.Count > 0)
					vfId = l[0];
			}
			HEFCLPGPMLK.ANKPCIEKPAH d = m_ValkyrieList.Find((HEFCLPGPMLK.ANKPCIEKPAH _) =>
			{
				//0x15292B4
				return _.LLOBHDMHJIG_Id == vfId;
			});
			SelectSeries = (int)d.CPKMLLNADLJ_Attr - 1;
			Select = m_SeriesValkyrieList[SelectSeries].FindIndex((HEFCLPGPMLK.ANKPCIEKPAH _) =>
			{
				//0x15292EC
				return _.LLOBHDMHJIG_Id == vfId;
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8A04 Offset: 0x6F8A04 VA: 0x6F8A04
		//// RVA: 0x1527990 Offset: 0x1527990 VA: 0x1527990
		private IEnumerator Co_LoadAssetsOrderListLayout()
		{
			string bundleName; // 0x14
			XeSys.FontInfo font; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0x1529FC0
			if(m_InfoLayout == null)
			{
				bundleName = "ly/144.xab";
				font = GameManager.Instance.GetSystemFont();
				yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_s_v_info_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1528D20
					m_InfoLayout = instance.GetComponent<OfferInfoLayout>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName);
				bundleName = null;
				font = null;
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8A7C Offset: 0x6F8A7C VA: 0x6F8A7C
		//// RVA: 0x1526E9C Offset: 0x1526E9C VA: 0x1526E9C
		private IEnumerator Co_LayoutLeave()
		{
			//0x1529D5C
			IsLeaveing = true;
			m_offerFormationController.Leave();
			itemCheckButton.Leave();
			yield return null;
			while(m_offerFormationController.IsPlaying())
				yield return null;
			MenuScene.Instance.HelpButton.HideOfferHelpButton();
			IsLeaveing = false;
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8AF4 Offset: 0x6F8AF4 VA: 0x6F8AF4
		//// RVA: 0x1526C80 Offset: 0x1526C80 VA: 0x1526C80
		private IEnumerator Co_IsInitialize()
		{
			//0x1529788
			IsInitialize = false;
			while (!m_offerFormationController.IsAssetLoad)
				yield return null;
			yield return Co.R(Co_LoadAssetsOrderListLayout());
			if (PrevTransition == TransitionList.Type.OFFER_SELECT)
			{
				m_InfoLayout.SetOfferInfomation(m_offerViewInfoData);
				for (int i = 0; i < 5; i++)
				{
					if (m_view.NAIBONEPAOJ(i + 1))
					{
						m_offerFormationController.selectFormation = i;
						break;
					}
				}
			}
			m_SwaipTouch = GetComponentInChildren<SwaipTouch>(true);
			m_SwaipTouch.ResetValue();
			m_SwaipTouch.ResetInputState();
			m_SwaipTouch.SetMute(true);
			ResetValkyrieData();
			m_offerFormationController.SetView(m_view);
			m_offerFormationController.Initialize();
			formationChenge(m_offerFormationController.selectFormation);
			m_offerFormationController.SetLayoutButton(() =>
			{
				//0x1528D9C
				OnClickDone();
			}, () =>
			{
				//0x1528DA0
				DissolutionPopUp();
			}, () =>
			{
				//0x1528DA4
				OnClickArrow(OfferFormationArrow.RIGHIT);
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
			}, () =>
			{
				//0x1528E04
				OnClickArrow(OfferFormationArrow.LEFT);
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
			}, (int index) =>
			{
				//0x1528E64
				OnClickFormationChenge(index);
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
			}, (int i) =>
			{
				//0x1528EC0
				OnClickValkyrieBanner(i);
			});
			yield return null;
			while (m_offerFormationController.IsImageLoding())
				yield return null;
			IsInitialize = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8B6C Offset: 0x6F8B6C VA: 0x6F8B6C
		//// RVA: 0x1526DC0 Offset: 0x1526DC0 VA: 0x1526DC0
		private IEnumerator Co_Start()
		{
			//0x152A34C
			MenuScene.Instance.RaycastDisable();
			m_offerFormationController.Enter();
			if(PrevTransition == TransitionList.Type.OFFER_SELECT)
			{
				m_InfoLayout.Enter();
			}
			itemCheckButton.Enter();
			yield return null;
			while (m_InfoLayout.IsPlaying())
				yield return null;
			while (m_offerFormationController.IsPlaying())
				yield return null;
			HEFCLPGPMLK.ANKPCIEKPAH d = m_view.FFGHIOAOABE(m_offerFormationController.selectFormation + 1);
			if(d.LLOBHDMHJIG_Id < 1)
			{
				m_offerFormationController.ValkyrieIconHide();
			}
			else
			{
				m_offerFormationController.ValkyrieIconChenge(d.LLOBHDMHJIG_Id, 0, null);
			}
			MenuScene.Instance.RaycastEnable();
			itemCheckButton.ButtonDisable();
			yield return Co.R(m_offerFormationController.Co_Tuto(() =>
			{
				//0x1529234
				return;
			}));
			itemCheckButton.ButtonEnable();
			IsSwipOff = false;
		}

		//// RVA: 0x1527A9C Offset: 0x1527A9C VA: 0x1527A9C
		private void OnClickValkyrieBanner(int index = 0)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_GotoValkyrieSelect(index));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8BE4 Offset: 0x6F8BE4 VA: 0x6F8BE4
		//// RVA: 0x1527B18 Offset: 0x1527B18 VA: 0x1527B18
		private IEnumerator Co_GotoValkyrieSelect(int index)
		{
			//0x1529328
			IsChengeLayout = false;
			ReturnScene = false;
			MenuScene.Instance.InputDisable();
			int id = 1;
			for(int i = 0; i < 3; i++)
			{
				if(FormationList[m_offerFormationController.selectFormation][i].JMHKMDFNAIN == index)
				{
					id = FormationList[m_offerFormationController.selectFormation][i].LLOBHDMHJIG_Id;
					break;
				}
			}
			SettingSelectSeriesAndSelectIndex(id);
			MenuScene.Instance.Call(TransitionList.Type.OFFER_VALKYRIESELECT, new OfferValkyrieSelectArgs(m_SeriesValkyrieList, FormationList[m_offerFormationController.selectFormation], m_offerViewInfoData, SelectSeries, Select, index, m_offerFormationController.selectFormation), true);
			MenuScene.Instance.InputEnable();
			yield break;
		}

		//// RVA: 0x1527BE0 Offset: 0x1527BE0 VA: 0x1527BE0
		private void formationChenge(int _SelectFormation)
		{
			m_offerFormationController.selectFormation = _SelectFormation;
			m_InfoLayout.StartChengeEnemyPower(m_offerFormationController.selectFormation + 1, false, 0, false);
			m_offerFormationController.platoonSetting(FormationList[m_offerFormationController.selectFormation], textColorChenge(m_offerViewInfoData.KINFGHHNFCF, KDHGBOOECKC.HHCJCDFCLOB.LBDENPEGONA(_SelectFormation + 1, BOPFPIHGJMD.HBJMIJIOCAM.FMHLGHDKJBC_0)), textColorChenge(m_offerViewInfoData.NONBCCLGBAO, KDHGBOOECKC.HHCJCDFCLOB.LBDENPEGONA(_SelectFormation + 1, BOPFPIHGJMD.HBJMIJIOCAM.JIOPJDJBLFK_1)), m_offerViewInfoData.DFMOGBOPLEF_Series, m_InfoLayout.IsLackPower);
		}

		//// RVA: 0x1527EEC Offset: 0x1527EEC VA: 0x1527EEC
		private void OnClickFormationChenge(int index)
		{
			formationChenge(index);
			int vfId = m_view.FFGHIOAOABE(m_offerFormationController.selectFormation + 1).LLOBHDMHJIG_Id;
			if (vfId < 1)
				m_offerFormationController.ValkyrieIconHide();
			else
				m_offerFormationController.ValkyrieIconChenge(vfId, 0, null);
			VfIdSearchSeriesAndSelect(vfId);
		}

		//// RVA: 0x1527FB4 Offset: 0x1527FB4 VA: 0x1527FB4
		private void OnClickDone()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			int id = m_view.FFGHIOAOABE(m_offerFormationController.selectFormation + 1).LLOBHDMHJIG_Id;
			if (id < 1)
				NotLeaderPopup();
			else
			{
				VfIdSearchSeriesAndSelect(id);
				ReturnScene = false;
				m_divaController.DivaPlayVoice(OfferVoiceDataTable.VoiceType.Sortie);
				MenuScene.Instance.Call(TransitionList.Type.OFFER_TRANSFORMATION, new OfferTransformationArgs(m_SeriesValkyrieList[SelectSeries][Select], m_InfoLayout, itemCheckButton, m_offerFormationController.selectFormation + 1), true);
			}
		}

		//// RVA: 0x1526870 Offset: 0x1526870 VA: 0x1526870
		private void OnClickArrow(OfferFormationArrow arrow)
		{
			if(arrow == OfferFormationArrow.LEFT)
			{
				if(m_offerFormationController.selectFormation < 1)
				{
					m_offerFormationController.selectFormation = FORMATION_MAX_NUM - 1;
				}
				else
				{
					m_offerFormationController.selectFormation--;
				}
			}
			else if(arrow == OfferFormationArrow.RIGHIT)
			{
				if(m_offerFormationController.selectFormation < FORMATION_MAX_NUM - 1)
				{
					m_offerFormationController.selectFormation++;
				}
				else
				{
					m_offerFormationController.selectFormation = 0;
				}
			}
			OnClickFormationChenge(m_offerFormationController.selectFormation);
			m_offerFormationController.chengePaltoonButton(m_offerFormationController.selectFormation);
		}

		//// RVA: 0x1528208 Offset: 0x1528208 VA: 0x1528208
		private void NotLeaderPopup()
		{
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, MessageManager.Instance.GetBank("menu").GetMessageByLabel("offer_no_leader_popup_text"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, false), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1529238
				return;
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x152923C
				return;
			}, null, null);
		}

		//// RVA: 0x15285D8 Offset: 0x15285D8 VA: 0x15285D8
		private void DissolutionPopUp()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			TextPopupSetting s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("offer_chenge_popup_title"), SizeType.Small, bk.GetMessageByLabel("offer_Dissolution_popup_text"), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true);
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1528EC4
				if(type == PopupButton.ButtonType.Positive)
				{
					for(int i = 0; i < FormationList[m_offerFormationController.selectFormation].Count; i++)
					{
						m_view.JBHBEKJHLFE(m_offerFormationController.selectFormation + 1, i, 0);
					}
					TapGuardON();
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0x15290D4
						TapGuardOFF();
						ResetValkyrieData();
						OnClickFormationChenge(m_offerFormationController.selectFormation);
					}, () =>
					{
						//0x1529110
						TapGuardOFF();
						MenuScene.Instance.GotoTitle();
					}, null);
				}
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x1529240
				return;
			}, null, null);
		}

		//// RVA: 0x1528A0C Offset: 0x1528A0C VA: 0x1528A0C
		private void TapGuardON()
		{
			IsSwipOff = true;
			MenuScene.Instance.InputDisable();
			itemCheckButton.ButtonDisable();
		}

		//// RVA: 0x1528AD4 Offset: 0x1528AD4 VA: 0x1528AD4
		private void TapGuardOFF()
		{
			IsSwipOff = false;
			MenuScene.Instance.InputEnable();
			itemCheckButton.ButtonEnable();
		}

		//// RVA: 0x1527E28 Offset: 0x1527E28 VA: 0x1527E28
		public static string textColorChenge(int offerData, int platoonData)
		{
			if (offerData < platoonData)
				return "<color=#008200>" + platoonData + "</color>";
			else if (offerData <= platoonData)
				return platoonData.ToString();
			return "<color=#8E0529>" + platoonData + "</color>";
		}
	}
}

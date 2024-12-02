using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class OfferFormationController : MonoBehaviour
	{
		private LayoutOfferFormation m_layout; // 0xC
		public bool IsAssetLoad; // 0x10
		private TextPopupSetting m_notChangedCommentPopupSetting = new TextPopupSetting(); // 0x14
		private LayoutOfferFormationLock m_LayoutPopupLock; // 0x18
		private HEFCLPGPMLK m_view; // 0x1C
		public int selectFormation; // 0x20

		// RVA: 0x1522D3C Offset: 0x1522D3C VA: 0x1522D3C
		private void Start()
		{
			return;
		}

		// RVA: 0x1522D40 Offset: 0x1522D40 VA: 0x1522D40
		private void Update()
		{
			return;
		}

		//// RVA: 0x1522D44 Offset: 0x1522D44 VA: 0x1522D44
		//public void formationSelectUpdate() { }

		// RVA: 0x1522D48 Offset: 0x1522D48 VA: 0x1522D48
		public void Initialize()
		{
			PopUpSetting();
			if(m_layout != null)
			{
				m_layout.initialize(selectFormation);
			}
			if(m_LayoutPopupLock != null)
			{
				m_LayoutPopupLock.Hide();
			}
			m_layout.ValkyrieIconHide();
		}

		// RVA: 0x1523080 Offset: 0x1523080 VA: 0x1523080
		public void SetLayoutButton(Action DoneCallback, Action DissolutionCallback, Action RArrowCallback, Action LArrowCallback, Action<int> PlantoonCallback, Action<int> BannerCallback)
		{
			m_layout.AllButtonListenersReset();
			m_layout.SetDoneButton(DoneCallback);
			m_layout.SetDissolutionButton(DissolutionCallback);
			m_layout.SetNameChengeButton(() =>
			{
				//0x1524728
				OnChangeComment(m_layout.GetPlatoonName());
			});
			m_layout.SetArrowButton(LArrowCallback, RArrowCallback);
			m_layout.SetPlatoonSelectButton(PlantoonCallback);
			m_layout.SetValkyrieBannerBtns(BannerCallback);
		}

		//// RVA: 0x1523228 Offset: 0x1523228 VA: 0x1523228
		//public void initializeTexture() { }

		// RVA: 0x152322C Offset: 0x152322C VA: 0x152322C
		public void platoonSetting(List<HEFCLPGPMLK.ANKPCIEKPAH> list, string attack, string hit, BOPFPIHGJMD.LGEIPIHHNPH OfferSeries, bool IsLackPower)
		{
			m_layout.SetPlatoonName(m_view.NPMKEEANPBE(selectFormation + 1));
			bool b1 = true;
			bool b2 = false;
			for(int i = 0; i < 3; i++)
			{
				m_layout.SettingAbilityAnim(list[i].LLOBHDMHJIG_Id, list[i].JMHKMDFNAIN);
				m_layout.DisplayLockIcon(m_view.JGFHJPGJJHP() <= selectFormation, i);
				if(selectFormation < m_view.JGFHJPGJJHP())
				{
					m_LayoutPopupLock.Leave();
				}
				else
				{
					m_LayoutPopupLock.SetText(KDHGBOOECKC.HHCJCDFCLOB.OMPLNLDPOFN_GetReleaseCondText(selectFormation + 1));
					m_LayoutPopupLock.Enter();
				}
				m_layout.SetValkyrieBanner(list[i].JMHKMDFNAIN, list[i].LLOBHDMHJIG_Id);
				if(list[i].JMHKMDFNAIN > 0)
				{
					m_layout.SetSubValkyrieIcon(list[i].JMHKMDFNAIN - 1, list[i].LLOBHDMHJIG_Id);
				}
				b1 &= list[i].LLOBHDMHJIG_Id < 1;
				b2 |= KDHGBOOECKC.HHCJCDFCLOB.CKBDHFNLLJE(OfferSeries, list[i].CPKMLLNADLJ_Attr);
			}
			for(int i = 0; i < 5; i++)
			{
				m_layout.SetSotiePlatoonButton(i, m_view.NAIBONEPAOJ(i + 1));
			}
			bool IsSortie = m_view.NAIBONEPAOJ(selectFormation + 1);
			m_layout.ButtonDisable(IsSortie || m_view.JGFHJPGJJHP() <= selectFormation);
			m_layout.BounsIconDisable(b2);
			m_layout.PlatoonEnpty(IsSortie || b1);
			m_layout.DisplaySortieIcon(IsSortie);
			m_layout.LackPowerIconDisable(IsLackPower);
			m_layout.SetAttackText(attack.ToString());
			m_layout.SetAcccuracyText(hit.ToString());
		}

		// RVA: 0x1523830 Offset: 0x1523830 VA: 0x1523830
		public bool IsPlaying()
		{
			return m_layout.IsPlaying();
		}

		// RVA: 0x152385C Offset: 0x152385C VA: 0x152385C
		public void Enter()
		{
			m_layout.Enter();
		}

		// RVA: 0x1523888 Offset: 0x1523888 VA: 0x1523888
		public void Leave()
		{
			m_layout.Leave();
			m_LayoutPopupLock.Leave();
		}

		// RVA: 0x15238D8 Offset: 0x15238D8 VA: 0x15238D8
		public void LayoutDestroy()
		{
			DestroyImmediate(m_layout.gameObject);
			m_layout = null;
			DestroyImmediate(m_LayoutPopupLock.gameObject);
			IsAssetLoad = false;
			m_LayoutPopupLock = null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8524 Offset: 0x6F8524 VA: 0x6F8524
		// RVA: 0x15239BC Offset: 0x15239BC VA: 0x15239BC
		public IEnumerator Co_Tuto(Action act)
		{
			//0x15255E8
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.HFKNIAGOFKC_1))
			{
				ButtonBase[] btns = m_layout.GetComponentsInChildren<ButtonBase>();
				ButtonBase btn = null;
				for (int i = 0; i < btns.Length; i++)
				{
					if(btns[i].name == "sw_cmn_btn_p_anim (AbsoluteLayout)")
					{
						btn = btns[i];
					}
				}
				if(btn != null)
				{
					yield return Co.R(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.Delegate, btn, () =>
					{
						//0x1524AC4
						act();
					}, BasicTutorialMessageId.Id_OfferPlatoon, true, null, null));
				}
			}
		}

		// RVA: 0x1523A84 Offset: 0x1523A84 VA: 0x1523A84
		public void chengePaltoonButton(int selectPaltoon)
		{
			m_layout.platoonNumAnim(selectPaltoon);
		}

		// RVA: 0x1523AB8 Offset: 0x1523AB8 VA: 0x1523AB8
		public bool IsImageLoding()
		{
			return m_layout.BannerImageIsLoding() || m_layout.SubValkyrieIconImageIsLoding();
		}

		//// RVA: 0x1522E94 Offset: 0x1522E94 VA: 0x1522E94
		private void PopUpSetting()
		{
			m_notChangedCommentPopupSetting = PopupWindowManager.CrateTextContent(MessageManager.Instance.GetMessage("common", "popup_ngword_error_title"), SizeType.Small, MessageManager.Instance.GetMessage("menu", "offer_formation_name_notchangedcomment_popup"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true);
		}

		//// RVA: 0x1523B10 Offset: 0x1523B10 VA: 0x1523B10
		private bool IsChangeComment(string changedComment)
		{
			return m_layout.GetPlatoonName() != changedComment;
		}

		//// RVA: 0x1523B4C Offset: 0x1523B4C VA: 0x1523B4C
		private void ShowNotChangedCommentPopup()
		{
			PopupWindowManager.Show(m_notChangedCommentPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1524980
				MenuScene.Instance.RaycastEnable();
			}, null, null, null);
		}

		//// RVA: 0x1523CEC Offset: 0x1523CEC VA: 0x1523CEC
		private void OnChangeComment(string comment)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(OnChangeCommentCoroutine(comment));
			MenuScene.Instance.RaycastDisable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F859C Offset: 0x6F859C VA: 0x6F859C
		//// RVA: 0x1523DF8 Offset: 0x1523DF8 VA: 0x1523DF8
		private IEnumerator OnChangeCommentCoroutine(string comment)
		{
			//0x1525CA0
			bool isWait = true;
			bool isDecide = false;
			string inputComment = "";
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			InputPopupSetting s = new InputPopupSetting();
			s.TitleText = bk.GetMessageByLabel("offer_formation_name_chenge_popup_title");
			s.InputText = comment;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.InputLineCount = 1;
			s.CharacterLimit = 15;
			s.WindowSize = SizeType.Middle;
			s.Description = bk.GetMessageByLabel("offer_formation_name_chenge_popup_text_01");
			s.Notes = bk.GetMessageByLabel("offer_formation_name_chenge_popup_text_02");
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1524AF8
				if(type == PopupButton.ButtonType.Negative)
				{
					MenuScene.Instance.RaycastEnable();
				}
				else if(type == PopupButton.ButtonType.Positive)
				{
					InputContent c = control.Content as InputContent;
					isDecide = true;
					inputComment = c.Text;
				}
				isWait = false;
			}, null, null, null);
			while (isWait)
				yield return null;
			if(isDecide)
			{
				if(IsChangeComment(inputComment))
				{
					this.StartCoroutineWatched(OnChangeCommentCoroutine2(inputComment));
				}
				else
				{
					ShowNotChangedCommentPopup();
				}
			}
	}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8614 Offset: 0x6F8614 VA: 0x6F8614
		//// RVA: 0x1523EC0 Offset: 0x1523EC0 VA: 0x1523EC0
		private IEnumerator OnChangeCommentCoroutine2(string inputComment)
		{
			//0x152598C
			m_layout.SetPlatoonName(inputComment);
			m_view.PFEMFIICBCE(selectFormation + 1, inputComment);
			bool isError = false;
			MenuScene.Save(null, () =>
			{
				//0x1524CA8
				isError = true;
			});
			while (CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI_IsSaving)
				yield return null;
			while (isError)
				yield return null;
			ChangeComment();
		}

		//// RVA: 0x1523F88 Offset: 0x1523F88 VA: 0x1523F88
		private void ChangeComment()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("offer_formation_name_chenge_popup_title"), SizeType.Small, bk.GetMessageByLabel("offer_formation_name_chenge_popup_text_03"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1524A1C
				MenuScene.Instance.RaycastEnable();
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x1524AB8
				return;
			}, null, null);
		}

		//// RVA: 0x1524398 Offset: 0x1524398 VA: 0x1524398
		public void StartAssetLoad()
		{
			this.StartCoroutineWatched(AllAssetLoad());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F868C Offset: 0x6F868C VA: 0x6F868C
		// RVA: 0x15243BC Offset: 0x15243BC VA: 0x15243BC
		private IEnumerator AllAssetLoad()
		{
			string bundleName; // 0x14
			XeSys.FontInfo systemFont; // 0x18

			//0x1524CB8
			if (IsAssetLoad)
				yield break;
			bundleName = "ly/140.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsLayoutOfferFormation(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutPopupLock(bundleName, systemFont));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (m_layout == null)
				yield return null;
			while (m_LayoutPopupLock == null)
				yield return null;
			IsAssetLoad = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8704 Offset: 0x6F8704 VA: 0x6F8704
		//// RVA: 0x1524468 Offset: 0x1524468 VA: 0x1524468
		private IEnumerator Co_LoadAssetsLayoutOfferFormation(string bundleName, XeSys.FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1525080
			if(m_layout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_deck_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1524764
					instance.transform.SetParent(transform, false);
					m_layout = instance.GetComponent<LayoutOfferFormation>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F877C Offset: 0x6F877C VA: 0x6F877C
		//// RVA: 0x1524548 Offset: 0x1524548 VA: 0x1524548
		private IEnumerator Co_LoadAssetsLayoutPopupLock(string bundleName, XeSys.FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1525334
			if(m_LayoutPopupLock == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_terms_pop_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1524834
					instance.transform.SetParent(transform, false);
					m_LayoutPopupLock = instance.GetComponent<LayoutOfferFormationLock>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
		}

		// RVA: 0x1524628 Offset: 0x1524628 VA: 0x1524628
		public void ValkyrieIconChenge(int vfId, int from, Action act)
		{
			m_layout.SetValkyrieIcon(vfId, from, act);
		}

		// RVA: 0x1524678 Offset: 0x1524678 VA: 0x1524678
		public void ValkyrieIconHide()
		{
			m_layout.ValkyrieIconHide();
		}

		//// RVA: 0x15246A4 Offset: 0x15246A4 VA: 0x15246A4
		public void SetView(HEFCLPGPMLK view)
		{
			m_view = view;
		}
	}
}

using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using System;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutQuestVerticalItem : SwapScrollListContent
	{
		public enum eButtonType
		{
			None = 0,
			Challenge = 1,
			Receive = 2,
			Clear = 3,
			Hide = 4,
		}

		[SerializeField]
		private NumberBase m_mol; // 0x20
		[SerializeField]
		private NumberBase m_den; // 0x24
		[SerializeField]
		private ActionButton m_buttonChallenge; // 0x28
		[SerializeField]
		private ActionButton m_buttonReceive; // 0x2C
		[SerializeField]
		private StayButton m_itemDetailsButton; // 0x30
		[SerializeField]
		private RawImageEx m_icon; // 0x34
		[SerializeField]
		private Text m_desc1; // 0x38
		[SerializeField]
		private Text m_desc2; // 0x3C
		[SerializeField]
		private Text m_time; // 0x40
		[SerializeField]
		private NumberBase m_rewardNum; // 0x44
		private GameObject m_base; // 0x48
		private RectTransform m_rtTransform; // 0x4C
		private AbsoluteLayout m_layoutButtonTbl; // 0x50
		private AbsoluteLayout m_layoutRoot; // 0x54
		private AbsoluteLayout m_layoutGauge; // 0x58
		private AbsoluteLayout m_layoutDaily; // 0x5C
		private AbsoluteLayout m_layoutDailyAnim; // 0x60
		private int m_dailyAnimFrame; // 0x64
		private FKMOKDCJFEN m_viewData; // 0x68
		private GCIJNCFDNON_SceneInfo sceneData; // 0x70
		private CKFGMNAIBNG costumeData = new CKFGMNAIBNG(); // 0x74
		private int m_itemId; // 0x78
		private LimitTimeWatcher m_timeWatcher = new LimitTimeWatcher(); // 0x7C
		private Matrix23 m_identity; // 0x80

		public Action OnReceiveCallback { get; set; } // 0x6C
		public ActionButton ChallengeButton { get { return m_buttonChallenge; } } //0x187EEF0

		// RVA: 0x1881308 Offset: 0x1881308 VA: 0x1881308
		private void Update()
		{
			m_timeWatcher.Update();
		}

		//// RVA: 0x187EEDC Offset: 0x187EEDC VA: 0x187EEDC
		public bool Compare(FKMOKDCJFEN viewData)
		{
			return m_viewData == viewData;
		}

		//// RVA: 0x1881334 Offset: 0x1881334 VA: 0x1881334
		//public GameObject GetBase() { }

		//// RVA: 0x188133C Offset: 0x188133C VA: 0x188133C
		//public void SetPosition(int x, int y) { }

		// RVA: 0x1879F00 Offset: 0x1879F00 VA: 0x1879F00
		public void SetStatus(FKMOKDCJFEN viewData)
		{
			m_viewData = viewData;
			SetDaily(viewData.EFJDHILLIEK_IsDaily);
			FKMOKDCJFEN.ADCPCCNCOMD_Status status = viewData.CMCKNKKCNDK_Status;
			if (viewData.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1)
			{
				status = !viewData.PNFDMBHDPAJ_IsRewardOnly && viewData.NNHHNFFLCFO != 0 ? FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1 : FKMOKDCJFEN.ADCPCCNCOMD_Status.HJNNKCMLGFL_0;
			}
			SetButton(status, viewData.PNFDMBHDPAJ_IsRewardOnly);
			switch(status)
			{
				case FKMOKDCJFEN.ADCPCCNCOMD_Status.HJNNKCMLGFL_0:
				case FKMOKDCJFEN.ADCPCCNCOMD_Status.CADDNFIKDLG_Received:
					SetTimeEnable(false);
					break;
				case FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1:
					SetTimeEnable(viewData.JONPKLHMOBL == FKMOKDCJFEN.MEDJADCKPKH.CCDOBDNDPIL_Event && viewData.PNFDMBHDPAJ_IsRewardOnly);
					SetTime(viewData.BLHJBMPONHC);
					break;
				case FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved:
					SetTimeEnable(viewData.JONPKLHMOBL == FKMOKDCJFEN.MEDJADCKPKH.CCDOBDNDPIL_Event);
					SetTime(viewData.PNHMDOHCBGK);
					break;
				default:
					break;
			}
			SetDesc(viewData.KLMPFGOCBHC_Description);
			SetGauge((int)(viewData.ABLHIAEDJAI_CurrentValue * 100.0f / viewData.HLDGMMDFNHB_TargetValue));
			if (viewData.GOOIIPFHOIG != null)
				SetIcon(viewData.GOOIIPFHOIG.JJBGOIMEIPF_ItemId);
			SetNumber(viewData.ABLHIAEDJAI_CurrentValue, viewData.HLDGMMDFNHB_TargetValue);
			SetRewardNum(viewData.GOOIIPFHOIG == null ? 0 : viewData.GOOIIPFHOIG.MBJIFDBEDAC_Cnt);
			m_layoutRoot.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_layoutRoot.Update(m_identity, Color.white);
		}

		//// RVA: 0x1881BC0 Offset: 0x1881BC0 VA: 0x1881BC0
		public void SetNumber(int mol, int den)
		{
			if(m_den != null)
			{
				for(int i = 1; m_den.DigitMax > i - 1; i++)
				{
					m_den.SetDigitNuber(i, 0);
				}
				m_den.SetNumber(den, 0);
			}
			if (m_mol != null)
				m_mol.SetNumber(mol, 0);
		}

		//// RVA: 0x1881D6C Offset: 0x1881D6C VA: 0x1881D6C
		public void SetRewardNum(int num)
		{
			if (m_rewardNum != null)
				m_rewardNum.SetNumber(num, 0);
		}

		//// RVA: 0x18814C4 Offset: 0x18814C4 VA: 0x18814C4
		public void SetButton(FKMOKDCJFEN.ADCPCCNCOMD_Status status, bool isRewardOnly)
		{
			switch(status)
			{
				case FKMOKDCJFEN.ADCPCCNCOMD_Status.HJNNKCMLGFL_0:
					SwitchButton(eButtonType.Hide);
					break;
				case FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1:
					if(!isRewardOnly)
						SwitchButton(eButtonType.Challenge);
					else
						SwitchButton(eButtonType.Hide);
					break;
				case FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved:
					SwitchButton(eButtonType.Receive);
					break;
				case FKMOKDCJFEN.ADCPCCNCOMD_Status.CADDNFIKDLG_Received:
					SwitchButton(eButtonType.Clear);
					break;
				default:
					break;
			}
		}

		//// RVA: 0x18819B4 Offset: 0x18819B4 VA: 0x18819B4
		public void SetGauge(int val)
		{
			m_layoutGauge.StartAllAnimGoStop(val, val);
		}

		//// RVA: 0x1881438 Offset: 0x1881438 VA: 0x1881438
		public void SetDaily(bool isDaily)
		{
			m_layoutDaily.StartChildrenAnimGoStop(isDaily ? "01" : "02");
		}

		//// RVA: 0x1879BB8 Offset: 0x1879BB8 VA: 0x1879BB8
		public void SetDailyAnimFrame(int frame)
		{
			m_layoutDailyAnim.StartChildrenAnimGoStop(frame % m_dailyAnimFrame, frame % m_dailyAnimFrame);
		}

		//// RVA: 0x18816A8 Offset: 0x18816A8 VA: 0x18816A8
		public void SetDesc(string text)
		{
			string[] strs = text.Split(new char[] { '\n' });
			m_desc1.text = strs[0];
			m_desc1.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_desc1.verticalOverflow = VerticalWrapMode.Truncate;
			m_desc1.resizeTextForBestFit = true;
			m_desc1.resizeTextMaxSize = m_desc1.fontSize;
			m_desc2.text = "";
			if (strs.Length < 2)
				return;
			m_desc2.text = strs[1];
			m_desc2.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_desc2.verticalOverflow = VerticalWrapMode.Truncate;
			m_desc2.resizeTextForBestFit = true;
			m_desc2.resizeTextMaxSize = m_desc2.fontSize;
		}

		//// RVA: 0x1881548 Offset: 0x1881548 VA: 0x1881548
		public void SetTime(long remainTime)
		{
			if(m_time != null && remainTime != 0)
			{
				m_timeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
				{
					//0x188306C
					ApplyRemainTime(remain);
				};
				m_timeWatcher.onEndCallback = null;
				m_timeWatcher.WatchStart(remainTime, true);
			}
		}

		//// RVA: 0x188204C Offset: 0x188204C VA: 0x188204C
		private void ApplyRemainTime(long remainSec)
		{
			int days, hours, min, sec;
			MusicSelectSceneBase.ExtractRemainTime((int)remainSec, out days, out hours, out min, out sec);
			m_time.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("music_event_remain_prefix") + MusicSelectSceneBase.MakeRemainTime(days, hours, min, sec);
		}

		//// RVA: 0x1881514 Offset: 0x1881514 VA: 0x1881514
		public void SetTimeEnable(bool enable)
		{
			m_time.enabled = enable;
		}

		//// RVA: 0x18819EC Offset: 0x18819EC VA: 0x18819EC
		public void SetIcon(int iconId)
		{
			if (m_icon == null)
				return;
			m_itemId = iconId;
			m_icon.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(iconId, (IiconTexture texture) =>
			{
				//0x18830B4
				if(m_icon != null && m_itemId == iconId)
				{
					m_icon.enabled = true;
					if(texture != null)
						texture.Set(m_icon);
				}
			});
		}

		//// RVA: 0x1881E34 Offset: 0x1881E34 VA: 0x1881E34
		public void SwitchButton(eButtonType type)
		{
			switch(type)
			{
				case eButtonType.Challenge:
					m_layoutButtonTbl.StartAllAnimGoStop("01");
					break;
				case eButtonType.Receive:
					m_layoutButtonTbl.StartAllAnimGoStop("02");
					SetDaily(false);
					break;
				case eButtonType.Clear:
					m_layoutButtonTbl.StartAllAnimGoStop("03");
					SetDaily(false);
					break;
				case eButtonType.Hide:
					m_layoutButtonTbl.StartAllAnimGoStop("04");
					SetDaily(false);
					break;
				default:
					break;
			}
			m_layoutButtonTbl.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_layoutButtonTbl.UpdateAll(m_identity, Color.white);
		}

		//// RVA: 0x18821A8 Offset: 0x18821A8 VA: 0x18821A8
		private void OnClickChallenge()
		{
			if(m_viewData.NNHHNFFLCFO == BKANGIKIEML.NODKLJHEAJB.KKFFEJEKFEG)
			{
				QuestUtility.OpenURL(m_viewData, () =>
				{
					//0x188308C
					if (OnReceiveCallback != null)
						OnReceiveCallback();
				});
			}
			else
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				QuestUtility.Challenge(m_viewData);
			}
		}

		//// RVA: 0x1882318 Offset: 0x1882318 VA: 0x1882318
		private void OnClickReceive()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			QuestUtility.Receive(m_viewData, this, () =>
			{
				//0x18830A0
				if (OnReceiveCallback != null)
					OnReceiveCallback();
			});
		}

		//// RVA: 0x188242C Offset: 0x188242C VA: 0x188242C
		private void OnShowItemDetails()
		{
			if(m_viewData != null && m_viewData.GOOIIPFHOIG != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_viewData.GOOIIPFHOIG.JJBGOIMEIPF_ItemId);
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
				{
					InitCostumeData(costumeData, m_viewData.GOOIIPFHOIG.JJBGOIMEIPF_ItemId);
					MenuScene.Instance.ShowCostumeDetailWindow(costumeData, 0);
				}
				else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					if (sceneData == null)
						sceneData = new GCIJNCFDNON_SceneInfo();
					sceneData.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_viewData.GOOIIPFHOIG.JJBGOIMEIPF_ItemId), null, null, 0, 0, 0, false, 0, 0);
					MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, true, true, SceneStatusParam.PageSave.None, false);
				}
				else
				{
					MenuScene.Instance.ShowItemDetail(m_viewData.GOOIIPFHOIG.JJBGOIMEIPF_ItemId, m_viewData.GOOIIPFHOIG.MBJIFDBEDAC_Cnt, null);
				}
			}
		}

		//// RVA: 0x1882870 Offset: 0x1882870 VA: 0x1882870
		private void InitCostumeData(CKFGMNAIBNG costumeData, int appItemId)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[EKLNMHFCAOI.DEACAHNLMNI_getItemId(appItemId) - 1];
			costumeData.KHEKNNFCAOI(cos.AHHJLDLAPAN_PrismDivaId, EKLNMHFCAOI.DEACAHNLMNI_getItemId(appItemId), 0, false);
		}

		// RVA: 0x1882A1C Offset: 0x1882A1C VA: 0x1882A1C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = gameObject;
			layout.Root[0].StartAnimGoStop("st_wait");
			m_layoutRoot = layout.Root;
			m_layoutGauge = layout.FindViewById("sw_sel_que_progress_anim") as AbsoluteLayout;
			m_layoutDaily = layout.FindViewById("swtbl_sel_que_badge_anim") as AbsoluteLayout;
			m_layoutDailyAnim = layout.FindViewById("sw_sel_que_badge_anim") as AbsoluteLayout;
			m_layoutButtonTbl = layout.FindViewById("swtbl_sel_que_btn") as AbsoluteLayout;
			m_rtTransform = GetComponent<RectTransform>();
			SwitchButton(eButtonType.Challenge);
			if(m_buttonChallenge != null)
			{
				m_buttonChallenge.AddOnClickCallback(OnClickChallenge);
			}
			if(m_buttonReceive != null)
			{
				m_buttonReceive.AddOnClickCallback(OnClickReceive);
			}
			m_itemDetailsButton.AddOnClickCallback(OnShowItemDetails);
			m_itemDetailsButton.AddOnStayCallback(OnShowItemDetails);
			SetDaily(false);
			m_layoutDailyAnim.StartChildrenAnimGoStop(0, 0);
			m_dailyAnimFrame = m_layoutDailyAnim.GetView(0).FrameAnimation.FrameNum;
			Loaded();
			return true;
		}
	}
}

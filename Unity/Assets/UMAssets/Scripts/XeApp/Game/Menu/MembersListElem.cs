using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MembersListElem : MembersListElemBase
	{
		public enum ButtonType
		{
			Guest = 0,
			Fan = 1,
			Select = 2,
			Me = 3,
		}

		public const int InvokeId_FunEnetry = 0;
		public const int InvokeId_FunVisit = 1;
		public const int InvokeId_Cancel = 2;
		public const int InvokeId_Profile = 3;
		public const int InvokeId_Select = 4;
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x18
		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x1C
		[SerializeField]
		private RawImageEx m_musicRatioIconImage; // 0x20
		[SerializeField]
		private Text m_nameText; // 0x24
		[SerializeField]
		private Text m_loginDateText; // 0x28
		[SerializeField]
		private Text m_totalText; // 0x2C
		[SerializeField]
		private Text m_soulText; // 0x30
		[SerializeField]
		private Text m_voiceText; // 0x34
		[SerializeField]
		private Text m_charmText; // 0x38
		[SerializeField]
		private Text m_lifeText; // 0x3C
		[SerializeField]
		private Text m_supportText; // 0x40
		[SerializeField]
		private Text m_foldText; // 0x44
		[SerializeField]
		private Text m_luckText; // 0x48
		[SerializeField]
		private Text m_commentText; // 0x4C
		[SerializeField]
		private Text m_macPow; // 0x50
		[SerializeField]
		private NumberBase m_funCount; // 0x54
		[SerializeField]
		private ScrollListButton m_01; // 0x58
		[SerializeField]
		private ScrollListButton m_02; // 0x5C
		[SerializeField]
		private ScrollListButton m_03; // 0x60
		[SerializeField]
		private ScrollListButton m_04; // 0x64
		[SerializeField]
		private ButtonBase m_profileButton; // 0x68
		private string m_loginDateString; // 0x6C
		private string m_requestDateString; // 0x70
		private bool m_useRequestDate; // 0x74
		private LayoutSymbolData m_symbolParamTable; // 0x78
		private AbsoluteLayout m_buttonAnima; // 0x7C
		private DivaIconDecoration m_divaDeco; // 0x80
		private bool m_isKira; // 0x84

		private Func<IiconTexture> divaIconDelegate { get; set; } // 0x88
		private Func<IiconTexture> sceneIconDelegate { get; set; } // 0x8C

		// RVA: 0xEC241C Offset: 0xEC241C VA: 0xEC241C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_buttonAnima = layout.FindViewById("swtbl_lb_btn_fan_01") as AbsoluteLayout;
			m_01.ClearOnClickCallback();
			m_01.AddOnClickCallback(OnClickFunEntryCallback);
			m_02.ClearOnClickCallback();
			m_02.AddOnClickCallback(OnClickFunFunVisitCallback);
			m_03.ClearOnClickCallback();
			m_03.AddOnClickCallback(OnClickFunCancelCallback);
			m_04.ClearOnClickCallback();
			m_04.AddOnClickCallback(OnClickSelectCallBack);
			m_profileButton.ClearOnClickCallback();
			m_profileButton.AddOnClickCallback(OnClickProfileCallback);
			m_symbolParamTable = CreateSymbol("param_tbl", layout);
			Loaded();
			return true;
		}

		// // RVA: 0xEC2784 Offset: 0xEC2784 VA: 0xEC2784
		private void OnClickFunEntryCallback()
		{
			InvokeSelectItem(1);
		}

		// // RVA: 0xEC283C Offset: 0xEC283C VA: 0xEC283C
		private void OnClickFunFunVisitCallback()
		{
			InvokeSelectItem(2);
		}

		// // RVA: 0xEC2844 Offset: 0xEC2844 VA: 0xEC2844
		private void OnClickFunCancelCallback()
		{
			InvokeSelectItem(0);
		}

		// // RVA: 0xEC284C Offset: 0xEC284C VA: 0xEC284C
		private void OnClickProfileCallback()
		{
			InvokeSelectItem(3);
		}

		// // RVA: 0xEC2854 Offset: 0xEC2854 VA: 0xEC2854
		private void OnClickSelectCallBack()
		{
			InvokeSelectItem(4);
		}

		// RVA: 0xEC285C Offset: 0xEC285C VA: 0xEC285C
		private void Update()
		{
			if(divaIconDelegate != null)
			{
				IiconTexture t = divaIconDelegate();
				if(t != null)
				{
					SetDivaIcon(t);
					divaIconDelegate = null;
				}
			}
			if(sceneIconDelegate != null)
			{
				IiconTexture t = sceneIconDelegate();
				if(t != null)
				{
					SetSceneIcon(t, m_isKira);
					sceneIconDelegate = null;
				}
			}
		}

		// // RVA: 0xEC2B48 Offset: 0xEC2B48 VA: 0xEC2B48
		public void SetMcannonPower(string powNum)
		{
			m_macPow.text = powNum;
		}

		// // RVA: 0xEC2B84 Offset: 0xEC2B84 VA: 0xEC2B84
		public void SetMusicRank(HighScoreRatingRank.Type rank)
		{
			GameManager.Instance.MusicRatioTextureCache.Load(rank, (IiconTexture texture) =>
			{
				//0xEC3438
				if(texture is MusicRatioTextureCache.MusicRatioTexture)
				{
					(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_musicRatioIconImage, rank);
				}
			});
		}

		// // RVA: 0xEC2CEC Offset: 0xEC2CEC VA: 0xEC2CEC
		public void UpdateLayoutAnimation()
		{
			m_buttonAnima.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_buttonAnima.UpdateAll(new Matrix23(), Color.white);
		}

		// // RVA: 0xEC2D98 Offset: 0xEC2D98 VA: 0xEC2D98
		public void SetFunCount(int funNum)
		{
			if(m_funCount != null)
				m_funCount.SetNumber(funNum, 0);
		}

		// // RVA: 0xEC2E60 Offset: 0xEC2E60 VA: 0xEC2E60
		public void SetButtonAnimaiton(ButtonType _type, bool isDeco/* = True*/)
		{
			switch(_type)
			{
				case ButtonType.Guest:
					m_buttonAnima.StartAllAnimGoStop(isDeco ? "05" : "01");
					break;
				case ButtonType.Fan:
					m_buttonAnima.StartAllAnimGoStop(isDeco ? "02" : "04");
					break;
				case ButtonType.Select:
					m_buttonAnima.StartAllAnimGoStop("03");
					break;
				case ButtonType.Me:
					m_buttonAnima.StartAllAnimGoStop("06");
					break;
			}
		}

		// // RVA: 0xEC2FB4 Offset: 0xEC2FB4 VA: 0xEC2FB4
		public void SetDivaIconDelegate(Func<IiconTexture> iconDelegate)
		{
			divaIconDelegate = iconDelegate;
		}

		// // RVA: 0xEC2FBC Offset: 0xEC2FBC VA: 0xEC2FBC
		public void SetSceneIconDelegate(Func<IiconTexture> iconDelegate)
		{
			sceneIconDelegate = iconDelegate;
		}

		// // RVA: 0xEC2924 Offset: 0xEC2924 VA: 0xEC2924
		public void SetDivaIcon(IiconTexture iconTex)
		{
			iconTex.Set(m_divaIconImage);
		}

		// // RVA: 0xEC2A04 Offset: 0xEC2A04 VA: 0xEC2A04
		public void SetSceneIcon(IiconTexture iconTex, bool isKira)
		{
			iconTex.Set(m_sceneIconImage);
			SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, iconTex as IconTexture, isKira);
		}

		// // RVA: 0xEC2FC4 Offset: 0xEC2FC4 VA: 0xEC2FC4
		public GameObject GetDivaIconObject()
		{
			return m_divaIconImage.gameObject;
		}

		// // RVA: 0xEC2FF0 Offset: 0xEC2FF0 VA: 0xEC2FF0
		public GameObject GetSceneIconObject()
		{
			return m_sceneIconImage.gameObject;
		}

		// // RVA: 0xEC301C Offset: 0xEC301C VA: 0xEC301C
		public void SetParamTable(SortItem sortBy)
		{
			switch(sortBy)
			{
				case SortItem.Total:
					m_symbolParamTable.GoToFrame("tbl", 2);
					break;
				case SortItem.Soul:
					m_symbolParamTable.GoToFrame("tbl", 3);
					break;
				case SortItem.Voice:
					m_symbolParamTable.GoToFrame("tbl", 4);
					break;
				case SortItem.Charm:
					m_symbolParamTable.GoToFrame("tbl", 5);
					break;
				case SortItem.Rarity:
					m_symbolParamTable.GoToFrame("tbl", 1);
					break;
				case SortItem.Life:
					m_symbolParamTable.GoToFrame("tbl", 6);
					break;
				case SortItem.Luck:
					m_symbolParamTable.GoToFrame("tbl", 9);
					break;
				case SortItem.Support:
					m_symbolParamTable.GoToFrame("tbl", 7);
					break;
				case SortItem.Fold:
					m_symbolParamTable.GoToFrame("tbl", 8);
					break;
				case SortItem.LastPlayDate:
					m_useRequestDate = false;
					ApplyDateString();
					break;
				case SortItem.Request:
					m_useRequestDate = true;
					ApplyDateString();
					break;
				default:
					m_symbolParamTable.GoToFrame("tbl", 0);
					break;
			}
		}

		// // RVA: 0xEC31B8 Offset: 0xEC31B8 VA: 0xEC31B8
		// public void SetRequestDate(string date) { }

		// // RVA: 0xEC3170 Offset: 0xEC3170 VA: 0xEC3170
		private void ApplyDateString()
		{
			if(!m_useRequestDate)
				m_loginDateText.text = m_loginDateString;
			else
				m_loginDateText.text = m_requestDateString;
		}

		// // RVA: 0xEC31C0 Offset: 0xEC31C0 VA: 0xEC31C0
		public void SetName(string name)
		{
			m_nameText.text = name;
		}

		// // RVA: 0xEC31FC Offset: 0xEC31FC VA: 0xEC31FC
		public void SetLoginDate(string date)
		{
			m_loginDateString = date;
			ApplyDateString();
		}

		// // RVA: 0xEC3204 Offset: 0xEC3204 VA: 0xEC3204
		public void SetTotal(string total)
		{
			m_totalText.text = total;
		}

		// // RVA: 0xEC3240 Offset: 0xEC3240 VA: 0xEC3240
		public void SetSoul(string soul)
		{
			m_soulText.text = soul;
		}

		// // RVA: 0xEC327C Offset: 0xEC327C VA: 0xEC327C
		public void SetVoice(string voice)
		{
			m_voiceText.text = voice;
		}

		// // RVA: 0xEC32B8 Offset: 0xEC32B8 VA: 0xEC32B8
		public void SetCharm(string charm)
		{
			m_charmText.text = charm;
		}

		// // RVA: 0xEC32F4 Offset: 0xEC32F4 VA: 0xEC32F4
		public void SetLife(string life)
		{
			m_lifeText.text = life;
		}

		// // RVA: 0xEC3330 Offset: 0xEC3330 VA: 0xEC3330
		public void SetSupport(string support)
		{
			m_supportText.text = support;
		}

		// // RVA: 0xEC336C Offset: 0xEC336C VA: 0xEC336C
		public void SetFold(string fold)
		{
			m_foldText.text = fold;
		}

		// // RVA: 0xEC33A8 Offset: 0xEC33A8 VA: 0xEC33A8
		public void SetLuck(string luck)
		{
			m_luckText.text = luck;
		}

		// // RVA: 0xEC33E4 Offset: 0xEC33E4 VA: 0xEC33E4
		public void SetComment(string comment)
		{
			m_commentText.text = comment;
		}

		// // RVA: 0xEC3420 Offset: 0xEC3420 VA: 0xEC3420
		public void SetKira(bool isKira)
		{
			m_isKira = isKira;
		}
	}
}

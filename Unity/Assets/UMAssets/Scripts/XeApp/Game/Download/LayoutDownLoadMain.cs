using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys.Gfx;

namespace XeApp.Game.DownLoad
{
	public class LayoutDownLoadMain : LayoutUGUIScriptBase
	{
		
		private class DivaLayoutData
		{
			public AbsoluteLayout win_anim; // 0x8
			public RawImageEx image; // 0xC
			public Text age; // 0x10
			public Text birthday; // 0x14
			public Text birthplace; // 0x18
			public Text favorite; // 0x1C
			public Text description; // 0x20
		}

		private const string UV_STATUS_FINISH_NAME = "sel_chara_down_font_02";
		private Action m_OnClickOk; // 0x14
		private Action m_OnClickVoice; // 0x18
		private Action<int> m_OnClickIcon; // 0x1C
		private RectTransform m_SwaipRect; // 0x20
		private TexUVListManager m_UvListManager; // 0x24
		private AbsoluteLayout m_ChangeAnim; // 0x28
		private AbsoluteLayout m_VoiceButtonAnim; // 0x2C
		private AbsoluteLayout m_ChangeDivaAnim; // 0x30
		private RawImageEx[] m_DivaImages; // 0x34
		private AbsoluteLayout m_DownLoadAnim; // 0x38
		private AbsoluteLayout m_DownLoadProgressBar; // 0x3C
		private AbsoluteLayout m_DownLoadProgressBarEffect; // 0x40
		private AbsoluteLayout m_DownLoadFinishAnim; // 0x44
		private NumberBase m_DownLoadPerNum; // 0x48
		private RawImageEx m_DownLoadStatusImage; // 0x4C
		private AbsoluteLayout m_DivaSelectAnim; // 0x50
		private ActionButton m_DivaSelectOkBtn; // 0x54
		private ActionButton m_DivaSelectVoiceBtn; // 0x58
		private List<ActionButton> m_DivaIconBtnList = new List<ActionButton>(); // 0x5C
		private RawImageEx[] m_DivaIcons; // 0x60
		private AbsoluteLayout[] m_SelectIconAnim; // 0x64
		private LayoutDownLoadDefine.ViewDivaProfileData m_DispDivaProfile; // 0x68
		private bool m_IsEnterVoiceButton; // 0x6C
		private bool m_IsChangeDiva; // 0x6D
		private int m_LoadingDivaIconCount; // 0x70
		private DivaLayoutData[] m_DivaLayouts = new DivaLayoutData[2]; // 0x74

		public Action OnClickOk { set { m_OnClickOk = value; } } //0x11C2C1C
		public Action OnClickVoice { set { m_OnClickVoice = value; } } //0x11C298C
		public Action<int> OnClickIcon { set { m_OnClickIcon = value; } } //0x11C2C14
		public RectTransform SwaipRect { get { return m_SwaipRect; } } //0x11C2374

		// RVA: 0x11C57E8 Offset: 0x11C57E8 VA: 0x11C57E8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_UvListManager = uvMan;
			m_ChangeAnim = layout.FindViewByExId("sw_load02_uta_rool_amim_swtbl_display_switch_anim") as AbsoluteLayout;
			m_VoiceButtonAnim = layout.FindViewByExId("swtbl_ display_switch_anim_sw_voice_btn_in_anim") as AbsoluteLayout;
			m_ChangeDivaAnim = layout.FindViewByExId("root_cmn_load02_uta_sw_load02_uta_rool_amim") as AbsoluteLayout;
			m_DownLoadProgressBar = layout.FindViewByExId("sw_cmn_load02_down_anim_swfrm_bar_01_anim") as AbsoluteLayout;
			m_DownLoadProgressBarEffect = layout.FindViewByExId("swfrm_bar_01_anim_sw_load02_down_bar") as AbsoluteLayout;
			m_DownLoadFinishAnim = layout.FindViewByExId("sw_cmn_load02_down_anim_sw_load2_wind_amim") as AbsoluteLayout;
			m_DownLoadAnim = layout.FindViewByExId("swtbl_ display_switch_anim_sw_cmn_load02_down") as AbsoluteLayout;
			m_DivaSelectAnim = layout.FindViewByExId("swtbl_ display_switch_anim_sw_sel_chara_sel_diva_anim") as AbsoluteLayout;
			m_DownLoadPerNum = GetComponentsInChildren<NumberBase>(true).Where((NumberBase _) => {
				//0x97D488
				return _.name == "swnum_load_down_num (AbsoluteLayout)";
			}).First();
			RawImageEx[] rs = GetComponentsInChildren<RawImageEx>(true);
			m_DownLoadStatusImage = rs.Where((RawImageEx _) => {
				//0x97D508
				return _.name == "swtexf_cmn_load02_down_font_01 (ImageView)";
			}).First();
			m_DivaIcons = rs.Where((RawImageEx _) => {
				//0x97D588
				return _.name == "swtexc_cmn_diva_m01 (ImageView)";
			}).Reverse().ToArray();
			m_SelectIconAnim = new AbsoluteLayout[m_DivaIcons.Length];
			for(int i = 0; i < m_DivaIcons.Length; i++)
			{
				m_SelectIconAnim[i] = (layout.FindViewByExId(string.Format("sw_sel_chara_sel_diva_anim_sw_cmn_sel_diva_02_{0:00}", i + 1)) as AbsoluteLayout).FindViewByExId("sw_cmn_sel_diva_sw_cursor_anim") as AbsoluteLayout;
			}
			ActionButton[] bts = GetComponentsInChildren<ActionButton>(true);
			m_DivaSelectOkBtn = bts.Where((ActionButton _) => {
				//0x97D608
				return _.name == "sw_chara_btn_ok_anim (AbsoluteLayout)";
			}).First();
			m_DivaSelectOkBtn.AddOnClickCallback(() => {
				//0x11C7810
				if(m_OnClickOk != null)
					m_OnClickOk();
			});
			m_DivaSelectVoiceBtn = bts.Where((ActionButton _) => {
				//0x97D688
				return _.name == "sw_voice_btn_anim (AbsoluteLayout)";
			}).First();
			m_DivaSelectVoiceBtn.AddOnClickCallback(() => {
				//0x11C7824
				if(m_OnClickVoice != null)
					m_OnClickVoice();
			});
			m_DivaIconBtnList.Clear();
			m_DivaIconBtnList.AddRange(bts.Where((ActionButton _) => {
				//0x97D708
				return Regex.IsMatch(_.name, "sw_cmn_sel_diva_0[0-9]");
			}).Reverse().ToArray());
			for(int i = 0; i < m_DivaIconBtnList.Count; i++)
			{
				int index = i;
				m_DivaIconBtnList[i].AddOnClickCallback(() => {
					//0x97DAC4
					if(m_IsChangeDiva)
					{
						m_DivaIconBtnList[index].SetOn();
						return;
					}
					if(m_OnClickIcon == null)
						return;
					m_OnClickIcon(index);
				});
			}
			Transform t = transform.Find("sw_load02_uta_rool_amim (AbsoluteLayout)/hit_check (AbsoluteLayout)");
			t.GetComponent<Button>().enabled = false;
			t.GetComponent<LayoutUGUIHitOnly>().enabled = false;
			m_SwaipRect = t.GetComponent<RectTransform>();
			for(int i = 0; i < m_DivaLayouts.Length; i++)
			{
				Transform t2 = transform.Find("sw_load02_uta_rool_amim (AbsoluteLayout)");
				string str = "";
				if(i == 0)
				{
					str = "l";
				}
				else if(i == 1)
				{
					str = "r";
				}
				else
				{
					str = "";
				}
				Transform t3 = t2.Find(string.Format("sw_load02_uta_amim_{0} (AbsoluteLayout)", str));
				DivaLayoutData data = new DivaLayoutData();
				data.win_anim = layout.FindViewByExId(string.Format("sw_load02_uta_rool_amim_sw_load02_uta_amim_{0}", str)) as AbsoluteLayout;
				data.image = t3.GetComponentsInChildren<RawImageEx>(true).Where((RawImageEx _) => {
					//0x97D7BC
					return _.name == "swtexc_cmn_download_01 (ImageView)";
				}).First();
				Text[] ts = t3.GetComponentsInChildren<Text>(true);
				data.age = ts.Where((Text _) => {
					//0x97D83C
					return _.name == "age_01 (TextView)";
				}).First();
				data.age.horizontalOverflow = HorizontalWrapMode.Overflow;
				data.birthday = ts.Where((Text _) => {
					//0x97D8BC
					return _.name == "birthday_01 (TextView)";
				}).First();
				data.birthday.horizontalOverflow = HorizontalWrapMode.Overflow;
				data.birthplace = ts.Where((Text _) => {
					//0x97D93C
					return _.name == "birthplace_01 (TextView)";
				}).First();
				data.favorite = ts.Where((Text _) => {
					//0x97D9BC
					return _.name == "favorite_01 (TextView)";
				}).First();
				data.description = ts.Where((Text _) => {
					//0x97DA3C
					return _.name == "detail_01 (TextView)";
				}).First();
				m_DivaLayouts[i] = data;
			}
			Loaded();
			return true;
		}

		// // RVA: 0x11C2C24 Offset: 0x11C2C24 VA: 0x11C2C24
		public bool IsReady()
		{
			if(IsLoaded())
			{
				if(GetComponent<LayoutUGUIRuntime>().IsReady)
				{
					return m_LoadingDivaIconCount < 1;
				}
			}
			return false;
		}

		// // RVA: 0x11C4608 Offset: 0x11C4608 VA: 0x11C4608
		public bool IsPlaying()
		{
			if(!m_ChangeAnim.IsPlayingChildren())
			{
				if(!m_ChangeDivaAnim.IsPlayingChildren())
				{
					return m_DivaSelectAnim.IsPlayingChildren();
				}
			}
			return true;
		}

		// // RVA: 0x11C2D7C Offset: 0x11C2D7C VA: 0x11C2D7C
		public bool IsFinishDownLoadAnim()
		{
			return !m_DownLoadFinishAnim.IsPlayingChildren();
		}

		// // RVA: 0x11C237C Offset: 0x11C237C VA: 0x11C237C
		// public void SetupDownLoad(List<int> diva_list) { }

		// // RVA: 0x11C2994 Offset: 0x11C2994 VA: 0x11C2994
		public void SetupDivaSelect(List<int> diva_list, int select_diva)
		{
			for(int i = 0; i < m_DivaIcons.Length; i++)
			{
				int index = i;
				if (diva_list.Count <= i)
					break;
				m_LoadingDivaIconCount++;
				GameManager.Instance.DivaIconCache.Load(diva_list[index], 1, 0, (IiconTexture texture) =>
				{
					//0x97DC14
					texture.Set(m_DivaIcons[index]);
					m_LoadingDivaIconCount--;
				});
			}
			SelectIcon(select_diva);
		}

		// // RVA: 0x11C2EA4 Offset: 0x11C2EA4 VA: 0x11C2EA4
		public void EnterDownLoad()
		{
			m_ChangeAnim.StartChildrenAnimGoStop("01");
			m_DownLoadAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_DownLoadProgressBarEffect.StartChildrenAnimLoop("logo_");
		}

		// // RVA: 0x11C2FB8 Offset: 0x11C2FB8 VA: 0x11C2FB8
		// public void LeaveDownLoad() { }

		// // RVA: 0x11C2DAC Offset: 0x11C2DAC VA: 0x11C2DAC
		public void Visible()
		{
			m_ChangeDivaAnim.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x11C3094 Offset: 0x11C3094 VA: 0x11C3094
		public void InVisible()
		{
			m_ChangeDivaAnim.StartChildrenAnimGoStop("st_non");
		}

		// // RVA: 0x11C31B4 Offset: 0x11C31B4 VA: 0x11C31B4
		// public void HideDownLoad() { }

		// // RVA: 0x11C3230 Offset: 0x11C3230 VA: 0x11C3230
		public void EnterDivaSelect()
		{
			m_ChangeAnim.StartChildrenAnimGoStop("02");
			m_DivaSelectAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x11C3314 Offset: 0x11C3314 VA: 0x11C3314
		// public void LeaveDivaSelect() { }

		// // RVA: 0x11C33D0 Offset: 0x11C33D0 VA: 0x11C33D0
		public void EnterVoiceButton()
		{
			if(m_IsEnterVoiceButton)
				return;
			m_VoiceButtonAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_IsEnterVoiceButton = true;
		}

		// // RVA: 0x11C3498 Offset: 0x11C3498 VA: 0x11C3498
		public void LeaveVoiceButton()
		{
			if(!m_IsEnterVoiceButton)
				return;
			m_VoiceButtonAnim.StartChildrenAnimGoStop("go_out", "st_out");
			m_IsEnterVoiceButton = false;
		}

		// // RVA: 0x11C37FC Offset: 0x11C37FC VA: 0x11C37FC
		public void SetProgressPer(float per)
		{
			m_DownLoadPerNum.SetNumber(Mathf.FloorToInt(per * 100), 0);
			int v = Mathf.FloorToInt(per);
			m_DownLoadProgressBar.StartChildrenAnimGoStop(v, v);
		}

		// // RVA: 0x11C3908 Offset: 0x11C3908 VA: 0x11C3908
		public void FinishDownLoad()
		{
			m_DownLoadPerNum.SetNumber(10000, 0);
			m_DownLoadProgressBar.StartChildrenAnimGoStop(100, 100);
			m_DownLoadStatusImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_UvListManager.GetUVData("sel_chara_down_font_02"));
			m_DownLoadFinishAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x11C35E4 Offset: 0x11C35E4 VA: 0x11C35E4
		public void SetEnabledOperation(bool is_enable, bool is_change)
		{
			m_DivaSelectOkBtn.enabled = is_enable;
			m_DivaSelectVoiceBtn.enabled = is_enable;
			for(int i = 0; i < m_DivaIconBtnList.Count; i++)
			{
				m_IsChangeDiva = !is_enable;
				if(!is_change)
				{
					m_DivaIconBtnList[i].enabled = is_enable;
					m_IsChangeDiva = false;
				}
			}
			if(!is_change && is_enable)
			{
				SelectIcon(0);
			}
		}

		// // RVA: 0x11C4B98 Offset: 0x11C4B98 VA: 0x11C4B98
		public void SelectIcon(int index)
		{
			for(int i = 0; i < m_SelectIconAnim.Length; i++)
			{
				if(index == i)
				{
					m_SelectIconAnim[i].StartChildrenAnimLoop("logo_act_01", "loen_act_01");
				}
				else
				{
					m_SelectIconAnim[i].StartChildrenAnimGoStop("st_wait");
				}
			}
			for(int i = 0; i < m_DivaIconBtnList.Count; i++)
			{
				if(index == i)
				{
					m_DivaIconBtnList[i].enabled = false;
					m_DivaIconBtnList[i].SetOn();
				}
				else
				{
					m_DivaIconBtnList[i].enabled = true;
					m_DivaIconBtnList[i].SetOff();
				}
			}
		}

		// // RVA: 0x11C23F8 Offset: 0x11C23F8 VA: 0x11C23F8
		public void ChangeDiva(LayoutDownLoadDefine.DirectionType dir, LayoutDownLoadDefine.ViewDivaProfileData data, Action on_finish)
		{
			if(DownLoadDivaTextureCache.Instance == null)
				return;
			if(dir == LayoutDownLoadDefine.DirectionType.Right)
			{
				m_ChangeDivaAnim.StartChildrenAnimGoStop("go_in", "st_in");
				this.StartCoroutineWatched(Co_VoiceButtonAnim());
			}
			else if(dir == LayoutDownLoadDefine.DirectionType.Left)
			{
				m_ChangeDivaAnim.StartChildrenAnimGoStop("go_out", "st_out");
				this.StartCoroutineWatched(Co_VoiceButtonAnim());
			}
			else
			{
				m_ChangeDivaAnim.StartChildrenAnimGoStop("st_wait");
			}
			bool b = false;
			for(int i = 0; i < m_DivaLayouts.Length; i++)
			{
				LayoutDownLoadDefine.ViewDivaProfileData p = data;
				if((dir != LayoutDownLoadDefine.DirectionType.None && (int)dir != i))
					p = m_DispDivaProfile;
				if(p != null)
				{
                    DivaLayoutData layout = m_DivaLayouts[i];
					if(dir == LayoutDownLoadDefine.DirectionType.None)
					{
						layout.win_anim.StartChildrenAnimGoStop("st_in");
					}
					else if((int)dir == i)
					{
						this.StartCoroutineWatched(Co_EnterWinAnim(layout, on_finish));
						b = true;
					}
					this.StartCoroutineWatched(DownLoadDivaTextureCache.Instance.LoadDivaGraphicCoroutine(p.id, (DownLoadDivaTexture texture) => {
						//0x97DD7C
						texture.Set(layout.image);
					}));
					layout.age.text = p.age;
					layout.birthday.text = p.birthday;
					layout.birthplace.text = p.birthplace;
					layout.favorite.text = p.favorite;
					layout.description.text = p.description;
					layout.birthplace.resizeTextMaxSize = layout.birthplace.fontSize;
					layout.birthplace.verticalOverflow = VerticalWrapMode.Overflow;
					layout.birthplace.resizeTextForBestFit = IsHorizontalOverflow(layout.birthplace);
					layout.birthplace.verticalOverflow = VerticalWrapMode.Truncate;
					layout.favorite.resizeTextMaxSize = layout.favorite.fontSize;
					layout.favorite.verticalOverflow = VerticalWrapMode.Overflow;
					layout.favorite.resizeTextForBestFit = IsHorizontalOverflow(layout.favorite);
					layout.favorite.verticalOverflow = VerticalWrapMode.Truncate;
                }
			}
			m_DispDivaProfile = data;
			if(on_finish != null)
				on_finish();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B58C8 Offset: 0x6B58C8 VA: 0x6B58C8
		// // RVA: 0x11C73C4 Offset: 0x11C73C4 VA: 0x11C73C4
		private IEnumerator Co_VoiceButtonAnim()
		{
			//0x97E0B4
			LeaveVoiceButton();
			yield return new WaitWhile(() => {
				//0x11C7838
				return m_ChangeDivaAnim.IsPlayingChildren();
			});
			EnterVoiceButton();
		}

		// // RVA: 0x11C7508 Offset: 0x11C7508 VA: 0x11C7508
		private bool IsHorizontalOverflow(Text text)
		{
			text.resizeTextForBestFit = false;
			TextGenerator g = new TextGenerator();
            TextGenerationSettings settings = text.GetGenerationSettings(text.GetComponent<RectTransform>().sizeDelta);
			g.Populate(text.text, settings);
			return g.lineCount > 1;
        }

		// [IteratorStateMachineAttribute] // RVA: 0x6B5940 Offset: 0x6B5940 VA: 0x6B5940
		// // RVA: 0x11C744C Offset: 0x11C744C VA: 0x11C744C
		private IEnumerator Co_EnterWinAnim(LayoutDownLoadMain.DivaLayoutData layout, Action on_finish)
		{
			//0x97DDE8
			layout.win_anim.StartChildrenAnimGoStop("st_wait");
			yield return null;
			yield return new WaitWhile(() => {
				//0x11C7864
				return m_ChangeDivaAnim.IsPlayingChildren();
			});
			layout.win_anim.StartChildrenAnimGoStop("go_in", "st_in");
			if(on_finish != null)
				on_finish();
		}

		// // RVA: 0x11C413C Offset: 0x11C413C VA: 0x11C413C
		public void SetButtonEnable()
		{
			m_DivaSelectOkBtn.IsInputOff = false;
			m_DivaSelectVoiceBtn.IsInputOff = false;
			for(int i = 0; i < m_DivaIconBtnList.Count; i++)
			{
				m_DivaIconBtnList[i].IsInputOff = false;
			}
		}

		// // RVA: 0x11C42F8 Offset: 0x11C42F8 VA: 0x11C42F8
		public void SetButtonDisable()
		{
			m_DivaSelectOkBtn.IsInputOff = true;
			m_DivaSelectVoiceBtn.IsInputOff = true;
			for(int i = 0; i < m_DivaIconBtnList.Count; i++)
			{
				m_DivaIconBtnList[i].IsInputOff = false;
			}
		}
	}
}

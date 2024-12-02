using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using mcrs;
using System.Collections;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Menu
{
	public class DegreeSelectLayout : LayoutUGUIScriptBase
	{
		public class DegreeInfo
		{
			public RawImageEx image; // 0x8
			public Text name; // 0xC
			public ActionButton btn; // 0x10
		}

		[SerializeField]
		private Text m_current_window_title; // 0x14
		[SerializeField]
		private Text m_select_window_title; // 0x18
		private AbsoluteLayout m_abs; // 0x1C
		private Transform m_content; // 0x20
		private DegreeInfo m_set_degree = new DegreeInfo(); // 0x24
		private DegreeInfo m_select_degree = new DegreeInfo(); // 0x28
		private ActionButton m_set_btn; // 0x2C
		private NumberBase m_degree_mol; // 0x30
		private DegreeSetPopupSetting m_degree_setting = new DegreeSetPopupSetting(); // 0x34
		private List<IAPDFOPPGND> m_degree_list = new List<IAPDFOPPGND>(); // 0x38
		private List<DegreeSelectDegreeButton> m_button_list = new List<DegreeSelectDegreeButton>(); // 0x3C
		private DegreeSelectNoneBtn m_none_btn; // 0x40
		private const int BUTTON_W = 325;
		private const int BUTTON_H = 90;
		private const int LEFT_SPACE = 10;
		private const int SCROLL_SPACE = 20;
		private int m_set_btn_index; // 0x44
		private int m_select_btn_index; // 0x48
		private int m_start_view_icon_index; // 0x4C
		private float m_old_scroll_pos; // 0x50
		private const int PAGE_LINE = 4;
		private const int PAGE_COLUMN = 2;
		private const int PAGE_MAX_ICON = 8;
		private const int NAME_LIMIT_ROWS = 2;
		private Action m_updater; // 0x54

		// RVA: 0x11E39A0 Offset: 0x11E39A0 VA: 0x11E39A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_sel_degree") as AbsoluteLayout;
			m_content = transform.Find("sw_sel_degree (AbsoluteLayout)/sw_sel_degree_window (AbsoluteLayout)/sc_space (ScrollView)/Content");
			DegreeInfo[] dlist = new DegreeInfo[2]
			{
				m_set_degree, m_select_degree
			};
			string[] slist = new string[2]
			{
				"sw_sel_degree_set (AbsoluteLayout)",
				"sw_sel_degree_select (AbsoluteLayout)"
			};
			for(int i = 0; i < dlist.Length; i++)
			{
				Transform t = transform.Find("sw_sel_degree (AbsoluteLayout)/sw_sel_deg_l (AbsoluteLayout)").Find(slist[i]);
				dlist[i].image = t.Find("cmn_degree_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
				dlist[i].name = t.Find("name_00 (TextView)").GetComponent<Text>();
				dlist[i].btn = t.Find("cmn_btn_b_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			}
			m_degree_mol = transform.Find("sw_sel_degree (AbsoluteLayout)/sw_sel_degree_window (AbsoluteLayout)/swnum_cmn_num_l (AbsoluteLayout)").GetComponent<NumberBase>();
			m_set_btn = transform.Find("sw_sel_degree (AbsoluteLayout)/sw_sel_deg_l (AbsoluteLayout)/sw_sel_degree_select (AbsoluteLayout)/cmn_btn_p_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			this.StartCoroutineWatched(LoadDegreeInfoWindow());
			m_set_degree.btn.AddOnClickCallback(() =>
			{
				//0x11E69AC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OnClickInfoBtn(m_set_btn_index);
			});
			m_select_degree.btn.AddOnClickCallback(() =>
			{
				//0x11E6A14
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OnClickInfoBtn(m_select_btn_index);
			});
			m_set_btn.AddOnClickCallback(() =>
			{
				//0x11E6A7C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				OnClickSetBtn();
			});
			for(int i = 0; i < 24; i++)
			{
				this.StartCoroutineWatched(LoadDegreeButton());
			}
			this.StartCoroutineWatched(LoadDegreeNoneButton());
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0x11E4354 Offset: 0x11E4354 VA: 0x11E4354
		private void Start()
		{
			return;
		}

		// RVA: 0x11E4358 Offset: 0x11E4358 VA: 0x11E4358
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x11E436C Offset: 0x11E436C VA: 0x11E436C
		private void UpdateLoad()
		{
			if(m_degree_mol.IsLoaded())
			{
				if(m_degree_setting.Content != null)
				{
					if(m_button_list.Count == 24)
					{
						if(m_none_btn != null)
						{
							m_none_btn.GetBtn().AddOnClickCallback(() =>
							{
								//0x11E6AE0
								SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
								WaitAllBtnAnim();
								m_none_btn.ActiveSelectAnim(true);
								m_select_btn_index = 0;
								InitSelectDegree(0);
							});
							Loaded();
							m_updater = UpdateIdle;
						}
					}
				}
			}
		}

		//// RVA: 0x11E4590 Offset: 0x11E4590 VA: 0x11E4590
		private void UpdateIdle()
		{
			Vector2 p = m_content.GetComponent<RectTransform>().anchoredPosition;
			if((int)(p.y / 360) != (int)(m_old_scroll_pos / 360))
			{
				UpdateDegreeBtn();
			}
			m_old_scroll_pos = p.y;
		}

		//// RVA: 0x11E4F28 Offset: 0x11E4F28 VA: 0x11E4F28
		public void Enter()
		{
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x11E4FB4 Offset: 0x11E4FB4 VA: 0x11E4FB4
		public void Leave()
		{
			m_abs.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x11E5040 Offset: 0x11E5040 VA: 0x11E5040
		public void Init(bool allDebug = false)
		{
			m_degree_list = IAPDFOPPGND.FKDIMODKKJD(allDebug);
			m_degree_mol.SetNumber(m_degree_list.Count - 1, 0);
			m_set_btn_index = GetDegreeListIndex(GameManager.Instance.ViewPlayerData.NDOLELKAJNL_Degree.MDPKLNFFDBO_EmblemId);
			InitSetDegree(m_set_btn_index);
			InitSelectDegree(m_set_btn_index);
			UpdateDegreeBtn();
			Vector2 v = new Vector2(0, (m_degree_list.Count - 1) / 2 * 90 + 110);
			m_content.GetComponent<RectTransform>().sizeDelta = v;
			ScrollRect sr = GetComponentInChildren<ScrollRect>();
			sr.vertical = sr.GetComponent<RectTransform>().sizeDelta.y < v.y;
			for(int i = 0; i < m_degree_list.Count; i++)
			{
				if(m_degree_list[i].MDPKLNFFDBO_EmblemId != 1)
				{
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeEmblemIconTexturePath(m_degree_list[i].MDPKLNFFDBO_EmblemId));
				}
			}
		}

		//// RVA: 0x11E5AAC Offset: 0x11E5AAC VA: 0x11E5AAC
		//private bool IsNothingEmblem(int emblemId) { }

		//// RVA: 0x11E5ABC Offset: 0x11E5ABC VA: 0x11E5ABC
		public void SetCurrentWindowTitle(string title)
		{
			m_current_window_title.text = title;
		}

		//// RVA: 0x11E5AF8 Offset: 0x11E5AF8 VA: 0x11E5AF8
		public void SetSelectWindowTitle(string title)
		{
			m_select_window_title.text = title;
		}

		//// RVA: 0x11E5470 Offset: 0x11E5470 VA: 0x11E5470
		private int GetDegreeListIndex(int id)
		{
			for(int i = 0; i < m_degree_list.Count; i++)
			{
				if (m_degree_list[i].MDPKLNFFDBO_EmblemId == id)
					return i;
			}
			return 0;
		}

		//// RVA: 0x11E4674 Offset: 0x11E4674 VA: 0x11E4674
		public void UpdateDegreeBtn()
		{
			Vector2 v = m_content.GetComponent<RectTransform>().anchoredPosition;
			int f = (int)(v.y / 360);
			m_start_view_icon_index = f * 8;
			for (int i = 0; i < m_button_list.Count; i++)
			{
				Vector3 v3 = new Vector3((i % 2) * 325 - 10, i / 2 * -90 - (int)(f) * 360 + 360, 0);
				m_button_list[i].transform.GetComponent<RectTransform>().localPosition = v3;
				int btn_index = i;
				int index = m_start_view_icon_index + i - 8;
				if(index == 0)
				{
					m_none_btn.transform.localPosition = v3;
				}
				if(index >= 0 && index < m_degree_list.Count)
				{
					if(index == 0)
					{
						m_none_btn.transform.gameObject.SetActive(true);
						m_button_list[btn_index].gameObject.SetActive(false);
					}
					else
					{
						m_button_list[btn_index].gameObject.SetActive(true);
					}
					m_button_list[btn_index].GetBtn().ClearOnClickCallback();
					m_button_list[btn_index].GetBtn().AddOnClickCallback(() =>
					{
						//0x17CDA20
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						WaitAllBtnAnim();
						m_button_list[btn_index].ActiveSelectAnim(true);
						OnClickDegreeBtn(index);
					});
					if(index == m_select_btn_index)
					{
						m_button_list[btn_index].ActiveSelectAnim(true);
						if(index == 0)
						{
							m_none_btn.ActiveSelectAnim(true);
						}
					}
					else
					{
						m_button_list[btn_index].ActiveSelectAnim(false);
						if(index == 0)
						{
							m_none_btn.ActiveSelectAnim(false);
						}
					}
					m_button_list[btn_index].ActiveSetIcon(index == m_set_btn_index);
					m_button_list[btn_index].Init(m_degree_list[index]);
				}
				else
				{
					m_button_list[btn_index].gameObject.SetActive(false);
					if(index == 0)
					{
						m_none_btn.transform.gameObject.SetActive(false);
					}
				}
			}
		}

		//// RVA: 0x11E5B34 Offset: 0x11E5B34 VA: 0x11E5B34
		//private void SetActiveBtn(int index, bool active) { }

		//// RVA: 0x11E5C0C Offset: 0x11E5C0C VA: 0x11E5C0C
		//private void SetSelectAnimBtn(int index, bool active) { }

		//// RVA: 0x11E5CE0 Offset: 0x11E5CE0 VA: 0x11E5CE0
		//private void SetIconBtn(int index, bool enable) { }

		//// RVA: 0x11E5558 Offset: 0x11E5558 VA: 0x11E5558
		private void InitSetDegree(int index)
		{
			if(m_set_degree.name.horizontalOverflow != HorizontalWrapMode.Wrap)
			{
				m_set_degree.name.horizontalOverflow = HorizontalWrapMode.Wrap;
			}
			TextGeneratorUtility.SetTextRectangleMessage(m_set_degree.name, m_degree_list[index].ADCMNODJBGJ_EmblemName, 2, JpStringLiterals.StringLiteral_12038);
			m_set_btn_index = index;
			SetDegreeImage(m_degree_list[index].MDPKLNFFDBO_EmblemId);
			m_set_degree.btn.Hidden = index == 0;
			m_set_btn.Disable = m_select_btn_index == m_set_btn_index;
		}

		//// RVA: 0x11E57A0 Offset: 0x11E57A0 VA: 0x11E57A0
		private void InitSelectDegree(int index)
		{
			if(m_select_degree.name.horizontalOverflow != HorizontalWrapMode.Wrap)
			{
				m_select_degree.name.horizontalOverflow = HorizontalWrapMode.Wrap;
			}
			TextGeneratorUtility.SetTextRectangleMessage(m_select_degree.name, m_degree_list[index].ADCMNODJBGJ_EmblemName, 2, JpStringLiterals.StringLiteral_12038);
			m_select_btn_index = index;
			SetSelectDegreeImage(m_degree_list[index].MDPKLNFFDBO_EmblemId);
			if(index == 0)
			{
				m_select_degree.btn.Hidden = true;
				m_select_degree.btn.Disable = false;
			}
			else
			{
				m_select_degree.btn.Hidden = false;
				m_select_degree.btn.Disable = m_select_btn_index == m_set_btn_index;
			}
			m_set_btn.Disable = m_select_btn_index == m_set_btn_index;
		}

		//// RVA: 0x11E604C Offset: 0x11E604C VA: 0x11E604C
		public bool IsPlaying()
		{
			return m_abs.IsPlayingChildren();
		}

		//// RVA: 0x11E5D8C Offset: 0x11E5D8C VA: 0x11E5D8C
		public void SetDegreeImage(int degree_no)
		{
			if(degree_no == 1)
			{
				m_set_degree.image.enabled = false;
			}
			else
			{
				m_set_degree.image.enabled = true;
				GameManager.Instance.ItemTextureCache.LoadEmblem(degree_no, (IiconTexture icon) =>
				{
					//0x11E6B7C
					icon.Set(m_set_degree.image);
				});
			}
		}

		//// RVA: 0x11E5EEC Offset: 0x11E5EEC VA: 0x11E5EEC
		public void SetSelectDegreeImage(int degree_no)
		{
			if(degree_no == 1)
			{
				m_select_degree.image.enabled = false;
			}
			else
			{
				m_select_degree.image.enabled = true;
				GameManager.Instance.ItemTextureCache.LoadEmblem(degree_no, (IiconTexture icon) =>
				{
					//0x11E6C70
					icon.Set(m_select_degree.image);
				});
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD384 Offset: 0x6FD384 VA: 0x6FD384
		//// RVA: 0x11E41BC Offset: 0x11E41BC VA: 0x11E41BC
		private IEnumerator LoadDegreeInfoWindow()
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x17CDE5C
			operation = AssetBundleManager.LoadLayoutAsync(m_degree_setting.BundleName, m_degree_setting.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.GetFont(), (GameObject instance) =>
			{
				//0x11E6D64
				m_degree_setting.SetContent(instance);
			}));
			m_degree_setting.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_degree_setting.BundleName);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD3FC Offset: 0x6FD3FC VA: 0x6FD3FC
		//// RVA: 0x11E4244 Offset: 0x11E4244 VA: 0x11E4244
		private IEnumerator LoadDegreeButton()
		{
			AssetBundleLoadLayoutOperationBase operation;
			//0x17CDB90
			operation = AssetBundleManager.LoadLayoutAsync("ly/076.xab", "UI_DegreeButton");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.GetFont(), (GameObject instance) =>
			{
				//0x11E6D98
				m_button_list.Add(instance.GetComponent<DegreeSelectDegreeButton>());
				instance.transform.SetParent(m_content, false);
			}));
			AssetBundleManager.UnloadAssetBundle("ly/076.xab", false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD474 Offset: 0x6FD474 VA: 0x6FD474
		//// RVA: 0x11E42CC Offset: 0x11E42CC VA: 0x11E42CC
		private IEnumerator LoadDegreeNoneButton()
		{
			AssetBundleLoadLayoutOperationBase operation;
			//0x17CE208
			operation = AssetBundleManager.LoadLayoutAsync("ly/076.xab", "UI_DegreeButton_None");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(MenuScene.Instance.GetFont(), (GameObject instance) =>
			{
				//0x11E6E8C
				m_none_btn = instance.GetComponent<DegreeSelectNoneBtn>();
				m_none_btn.transform.SetParent(m_content, false);
			}));
			AssetBundleManager.UnloadAssetBundle("ly/076.xab", false);
		}

		//// RVA: 0x11E6078 Offset: 0x11E6078 VA: 0x11E6078
		private void OnClickInfoBtn(int index)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_degree_setting.TitleText = bk.GetMessageByLabel("popup_title_degree_01");
			m_degree_setting.SetParent(transform);
			m_degree_setting.data = m_degree_list[index];
			m_degree_setting.WindowSize = SizeType.Small;
			m_degree_setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_degree_setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x17CD91C
				return;
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x17CD920
				(content as PopupTabContents).ChangeContents((int)label);
			}, null, null);
		}

		//// RVA: 0x11E64EC Offset: 0x11E64EC VA: 0x11E64EC
		private void OnClickDegreeBtn(int index)
		{
			m_select_btn_index = index;
			InitSelectDegree(index);
		}

		//// RVA: 0x11E64F4 Offset: 0x11E64F4 VA: 0x11E64F4
		private void OnClickSetBtn()
		{
			InitSetDegree(m_select_btn_index);
			InitSelectDegree(m_select_btn_index);
			UpdateDegreeBtn();
			JDDGPJDKHNE.HHCJCDFCLOB.BGDOBGFECOB();
			int oldEmblem = GameManager.Instance.ViewPlayerData.NDOLELKAJNL_Degree.MDPKLNFFDBO_EmblemId;
			GameManager.Instance.ViewPlayerData.HPLIKGGILHF(m_degree_list[m_select_btn_index].MDPKLNFFDBO_EmblemId);
			ILCCJNDFFOB.HHCJCDFCLOB.PGHFPIMIOKE(oldEmblem, GameManager.Instance.ViewPlayerData.NDOLELKAJNL_Degree.MDPKLNFFDBO_EmblemId);
			MenuScene.Save(null, null);
		}

		//// RVA: 0x11E678C Offset: 0x11E678C VA: 0x11E678C
		private void WaitAllBtnAnim()
		{
			m_none_btn.ActiveSelectAnim(false);
			for(int i = 0; i < m_button_list.Count; i++)
			{
				m_button_list[i].ActiveSelectAnim(false);
			}
		}
	}
}

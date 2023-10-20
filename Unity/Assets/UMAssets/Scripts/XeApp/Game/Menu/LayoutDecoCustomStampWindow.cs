using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using XeApp.Core;
using System.Runtime.CompilerServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using mcrs;

namespace XeApp.Game.Menu
{
	public static class StampDataCopy
	{
		// RVA: -1 Offset: -1
		public static T DeepCopy<T>(this T src) where T : class
		{
			using (MemoryStream memStream = new MemoryStream())
			{
				BinaryFormatter input = new BinaryFormatter();
				input.Serialize(memStream, src);
				memStream.Seek(0, SeekOrigin.Begin);
				object obj = input.Deserialize(memStream);
				return obj as T;
			}
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x20921B8 Offset: 0x20921B8 VA: 0x20921B8
		|-StampDataCopy.DeepCopy<List<LayoutDecoCustomStampWindow.StampData>>
		|-StampDataCopy.DeepCopy<object>
		|-StampDataCopy.DeepCopy<LayoutDecoCustomStampWindow.StampData>
		*/
	}

	public class LayoutDecoCustomStampWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		public class StampData
		{
			public LayoutDecoCustomStampItem.Type type; // 0x8
			public int stampId; // 0xC
			public int serifId; // 0x10
			public int number; // 0x14

			// RVA: 0x19E0A64 Offset: 0x19E0A64 VA: 0x19E0A64
			public StampData()
			{
				return;
			}

			// RVA: 0x19E1B00 Offset: 0x19E1B00 VA: 0x19E1B00
			public StampData(StampData value)
			{
				type = value.type;
				stampId = value.stampId;
				serifId = value.serifId;
				number = value.number;
			}
		}

		public enum Mode
		{
			CreateStamp = 0,
			Sort = 1,
			Init = 2,
		}

		private AbsoluteLayout m_rootLayout; // 0x14
		private AbsoluteLayout m_stampMakerSwitchLayout; // 0x18
		[SerializeField]
		private ActionButton m_decideButton; // 0x1C
		[SerializeField]
		private ActionButton m_cancelButton; // 0x20
		[SerializeField]
		private RawImageEx m_cancelBtnImage; // 0x24
		private int targetNumber; // 0x2C
		private int exchangeNumber; // 0x30
		private LayoutDecoCustomStampItem targetItem; // 0x34
		private GameObject m_source; // 0x38
		private Mode mode = Mode.Init; // 0x3C
		public Action OnStampEdit; // 0x44
		public Action<Action> OnDeleteStamp; // 0x48
		[SerializeField]
		private Text m_titleText; // 0x4C
		[SerializeField]
		private Text m_registerNumberText; // 0x50
		[SerializeField]
		private Text m_windowDescText; // 0x54
		[SerializeField]
		private Text m_wintext; // 0x58
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x5C
		private List<StampData> m_stampList = new List<StampData>(); // 0x60
		private List<StampData> m_tempStampList = new List<StampData>(); // 0x64
		[SerializeField]
		private Vector2 m_windowSize; // 0x68
		private bool isExchange; // 0x70
		private TexUVListManager m_uvMan; // 0x74

		public bool IsSaveSucces { get; private set; } // 0x28
		public bool IsLoadItem { get; private set; } // 0x40

		//// RVA: 0x19DF290 Offset: 0x19DF290 VA: 0x19DF290
		public void SetDecideButtonAction(Action action)
		{
			m_decideButton.ClearOnClickCallback();
			m_decideButton.AddOnClickCallback(() =>
			{
				//0x19E2274
				action();
			});
		}

		// RVA: 0x19DF398 Offset: 0x19DF398 VA: 0x19DF398
		public void SetCancleButtonAction(Action action)
		{
			m_cancelButton.ClearOnClickCallback();
			m_cancelButton.AddOnClickCallback(() =>
			{
				//0x19E22A0
				action();
			});
		}

		//// RVA: 0x19DF4B0 Offset: 0x19DF4B0 VA: 0x19DF4B0
		public int GetStampCount()
		{
			return m_stampList.Count;
		}

		// RVA: 0x19DF528 Offset: 0x19DF528 VA: 0x19DF528
		public void Enter()
		{
			m_tempStampList = m_stampList.DeepCopy();
			m_rootLayout.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x19DF5D0 Offset: 0x19DF5D0 VA: 0x19DF5D0
		public void Leave()
		{
			m_rootLayout.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x19DF65C Offset: 0x19DF65C VA: 0x19DF65C
		public void Hide()
		{
			m_rootLayout.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x19DF6D8 Offset: 0x19DF6D8 VA: 0x19DF6D8
		public void SwitchLayout(Mode value)
		{
			targetNumber = 0;
			m_scrollList.VisibleRegionUpdate();
			if(mode != value)
			{
				mode = value;
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				if(mode == Mode.Sort)
				{
					isExchange = false;
					m_stampMakerSwitchLayout.StartChildrenAnimGoStop("02", "02");
					m_titleText.text = bk.GetMessageByLabel("customstamp_sort_title");
					m_windowDescText.text = bk.GetMessageByLabel("customstamp_sort_desc");
					m_cancelBtnImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData("deco_fnt_04"));
					DeleteCreateItem();
					ResetStayButton(false);
				}
				else if(mode == Mode.CreateStamp)
				{
					m_stampMakerSwitchLayout.StartChildrenAnimGoStop("01", "01");
					m_titleText.text = bk.GetMessageByLabel("customstamp_createt_itle");
					m_windowDescText.text = bk.GetMessageByLabel("customstamp_longtap_desc");
					m_cancelBtnImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData("deco_fnt_03"));
					AddCreateItem();
					CheckStampCount();
					ResetStayButton(true);
				}
			}
		}

		// RVA: 0x19E0104 Offset: 0x19E0104 VA: 0x19E0104
		public bool IsPlaying()
		{
			return m_rootLayout.IsPlayingChildren();
		}

		// RVA: 0x19E0130 Offset: 0x19E0130 VA: 0x19E0130 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			m_rootLayout = layout.FindViewByExId("root_cstm_deco_win_02_sw_cstm_deco_window_02_01_anim") as AbsoluteLayout;
			m_stampMakerSwitchLayout = layout.FindViewByExId("sw_cstm_deco_window_02_anim_swtbl_cstm_deco_window_02") as AbsoluteLayout;
			m_uvMan = uvMan;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_windowDescText.text = bk.GetMessageByLabel("customstamp_longtap_desc");
			IsLoadItem = false;
			return true;
		}

		// RVA: 0x19E0334 Offset: 0x19E0334 VA: 0x19E0334
		public void Prepare()
		{
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.ResetScrollVelocity();
			m_scrollList.VisibleRegionUpdate();
			CheckStampCount();
		}

		//// RVA: 0x19DFD4C Offset: 0x19DFD4C VA: 0x19DFD4C
		private void CheckStampCount()
		{
			if (mode != Mode.CreateStamp)
				return;
			m_cancelButton.Disable = m_stampList.Count < 3;
		}

		//// RVA: 0x19E03C8 Offset: 0x19E03C8 VA: 0x19E03C8
		private void RegisterStampNum()
		{
			StringBuilder str = new StringBuilder(16);
			str.Append(m_stampList.Count - (mode == Mode.CreateStamp ? 1 : 0));
			str.Append("/");
			str.Append(30);
			m_registerNumberText.text = str.ToString();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D79A4 Offset: 0x6D79A4 VA: 0x6D79A4
		//// RVA: 0x19E0564 Offset: 0x19E0564 VA: 0x19E0564
		private IEnumerator Co_LoadLayoutItemSource()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x19E2568
			op = AssetBundleManager.LoadLayoutAsync("ly/206.xab", "root_cstm_deco_item_03_layout_root");
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x19E203C
				m_source = instance;
			}));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D7A1C Offset: 0x6D7A1C VA: 0x6D7A1C
		// RVA: 0x19E0610 Offset: 0x19E0610 VA: 0x19E0610
		public IEnumerator Co_LoadListItem()
		{
			//0x19E27C8
			m_stampList = CreateStampList();
			yield return this.StartCoroutineWatched(Co_LoadLayoutItemSource());
			RegisterStampNum();
			while(m_source == null)
				yield return null;
			LayoutUGUIRuntime runtime = m_source.GetComponent<LayoutUGUIRuntime>();
			for(int i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				GameObject g = Instantiate(m_source);
				LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				m_scrollList.AddScrollObject(g.GetComponent<LayoutDecoCustomStampItem>());
			}
			yield return null;
			m_scrollList.Apply();
			AssetBundleManager.UnloadAssetBundle("ly/206.xab", false);
			Destroy(m_source);
			SetupList(m_stampList.Count, true);
			IsLoadItem = true;
		}

		//// RVA: 0x19E06BC Offset: 0x19E06BC VA: 0x19E06BC
		private void SetupList(int count, bool isPosUpdate = true)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(Co_UpdateList);
			m_scrollList.ResetScrollVelocity();
			if (isPosUpdate)
			{
				m_scrollList.SetPosition(0, 0, 0, false);
			}
			m_scrollList.VisibleRegionUpdate();
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(SelectStampItem);
			}
		}

		//// RVA: 0x19DFE00 Offset: 0x19DFE00 VA: 0x19DFE00
		public void ResetStayButton(bool _isStay)
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				(m_scrollList.ScrollObjects[i] as LayoutDecoCustomStampItem).ResetStayButton(_isStay);
			}
		}

		//// RVA: 0x19DFB14 Offset: 0x19DFB14 VA: 0x19DFB14
		private void AddCreateItem()
		{
			m_stampList.Insert(0, new StampData() { type = LayoutDecoCustomStampItem.Type.Create });
			SetupList(m_stampList.Count, true);
			for (int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				(m_scrollList.ScrollObjects[i] as LayoutDecoCustomStampItem).SelectEffectOff();
			}
		}

		//// RVA: 0x19DFF54 Offset: 0x19DFF54 VA: 0x19DFF54
		private void DeleteCreateItem()
		{
			m_stampList.RemoveAt(0);
			SetupList(m_stampList.Count, true);
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				(m_scrollList.ScrollObjects[i] as LayoutDecoCustomStampItem).SelectEffectOff();
			}
		}

		//// RVA: 0x19E0A6C Offset: 0x19E0A6C VA: 0x19E0A6C
		private List<StampData> CreateStampList()
		{
			List<StampData> res = new List<StampData>();
			IHGHHPPDPEO d = new IHGHHPPDPEO();
			for(int i = 0; i < d.GMCKCMFKPOB().Count; i++)
			{
				if(d.GMCKCMFKPOB()[i].IEDNAKOJNDE_IsValid)
				{
					StampData data = new StampData();
					data.type = LayoutDecoCustomStampItem.Type.Stamp;
					data.stampId = d.GMCKCMFKPOB()[i].CNOHJPEHHCH_StampId;
					data.serifId = d.GMCKCMFKPOB()[i].JBOCHIJAMFD_SerifId;
					data.number = i + 1;
					res.Add(data);
				}
			}
			return res;
		}

		//// RVA: 0x19E0D50 Offset: 0x19E0D50 VA: 0x19E0D50
		private void SelectStampItem(int index, SwapScrollListContent content)
		{
			LayoutDecoCustomStampItem l = content as LayoutDecoCustomStampItem;
			if (l != null)
			{
				targetNumber = l.Number;
				if (mode == Mode.Sort)
					SelectItemSort(l);
				else if (mode == Mode.CreateStamp)
					SelectItemCreateStamp(l);
			}
		}

		//// RVA: 0x19E0E78 Offset: 0x19E0E78 VA: 0x19E0E78
		private void SelectItemCreateStamp(LayoutDecoCustomStampItem stamp)
		{
			if(stamp.IsLongTap)
			{
				OnDeleteStamp(() =>
				{
					//0x19E22CC
					stamp.IsLongTapProcess = false;
					stamp.IsLongTap = false;
				});
				return;
			}
			if (OnStampEdit != null)
				OnStampEdit();
		}

		//// RVA: 0x19E130C Offset: 0x19E130C VA: 0x19E130C
		public void UpdateStamp(StampData stamp, int index)
		{
			targetNumber = 0;
			m_stampList[index] = stamp;
			this.StartCoroutineWatched(Co_SaveStampList(() =>
			{
				//0x19E2044
				SetupList(m_stampList.Count, false);
			}));
		}

		//// RVA: 0x19E1498 Offset: 0x19E1498 VA: 0x19E1498
		public void AddStamp(int charaId, int serifId)
		{
			m_stampList.Add(new StampData() { stampId = charaId, serifId = serifId, type = LayoutDecoCustomStampItem.Type.Stamp, number = m_stampList.Count });
			RegisterStampNum();
			this.StartCoroutineWatched(Co_SaveStampList(() =>
			{
				//0x19E20CC
				SetupList(m_stampList.Count, false);
				CheckStampCount();
			}));
		}

		//// RVA: 0x19E160C Offset: 0x19E160C VA: 0x19E160C
		public void DeleteStamp(int index, Action callback)
		{
			m_stampList.RemoveAt(index);
			RegisterStampNum();
			for(int i = 0; i < m_stampList.Count; i++)
			{
				if(i != 0)
				{
					m_stampList[i].number = i;
				}
			}
			targetNumber = 0;
			this.StartCoroutineWatched(Co_SaveStampList(() =>
			{
				//0x19E2310
				SetupList(m_stampList.Count, false);
				CheckStampCount();
				if (callback != null)
					callback();
			}));
		}

		//// RVA: 0x19E0FB0 Offset: 0x19E0FB0 VA: 0x19E0FB0
		private void SelectItemSort(LayoutDecoCustomStampItem stamp)
		{
			if(targetItem != null)
			{
				targetItem.SelectEffectOff();
			}
			if(!isExchange)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				isExchange = true;
				targetItem = stamp;
				stamp.SelectEffectOn();
				exchangeNumber = stamp.Number;
			}
			else
			{
				if(targetItem.Number == stamp.Number)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
				}
				else
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					Exchange(targetNumber);
					stamp.SelectEffectOff();
				}
				isExchange = false;
			}
		}

		//// RVA: 0x19E17D8 Offset: 0x19E17D8 VA: 0x19E17D8
		private void Exchange(int stampNumber)
		{
			StampData s1 = m_stampList.Find((StampData item) =>
			{
				//0x19E23DC
				return item.number == exchangeNumber;
			});
			s1 = new StampData(s1);
			StampData s2 = m_stampList.Find((StampData item) =>
			{
				//0x19E2428
				return item.number == exchangeNumber;
			});
			StampData s3 = m_stampList.Find((StampData item) =>
			{
				//0x19E2474
				return item.number == stampNumber;
			});
			s2.stampId = s3.stampId;
			s2.serifId = s3.serifId;
			s2.type = s3.type;
			s3.stampId = s1.stampId;
			s3.serifId = s1.stampId;
			s3.type = s1.type;
			SetupList(m_stampList.Count, false);
		}

		//// RVA: 0x19E1B8C Offset: 0x19E1B8C VA: 0x19E1B8C
		public void ExchangeSave()
		{
			if (m_tempStampList == null)
				return;
			this.StartCoroutineWatched(Co_SaveStampList(null));
		}

		//// RVA: 0x19E1C44 Offset: 0x19E1C44 VA: 0x19E1C44
		public void ExchangeCancell()
		{
			if (m_tempStampList == null)
				return;
			m_stampList = m_tempStampList;
			SetupList(m_stampList.Count, true);
			m_tempStampList = null;
		}

		//// RVA: 0x19E1D10 Offset: 0x19E1D10 VA: 0x19E1D10
		public StampData GetTargetStampInfo()
		{
			return m_stampList[targetNumber].DeepCopy();
		}

		//// RVA: 0x19E1DA4 Offset: 0x19E1DA4 VA: 0x19E1DA4
		private void Co_UpdateList(int index, SwapScrollListContent content)
		{
			LayoutDecoCustomStampItem l = content as LayoutDecoCustomStampItem;
			if (l != null)
				l.Copy(m_stampList[index], targetNumber);
		}

		//// RVA: 0x19E1EDC Offset: 0x19E1EDC VA: 0x19E1EDC
		public bool IsStampMax()
		{
			return m_stampList.Count > 30;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D7A94 Offset: 0x6D7A94 VA: 0x6D7A94
		//// RVA: 0x19E13F0 Offset: 0x19E13F0 VA: 0x19E13F0
		private IEnumerator Co_SaveStampList(Action callback)
		{
			//0x19E2D44
			IsSaveSucces = false;
			bool isDone = false;
			IHGHHPPDPEO data = new IHGHHPPDPEO();
			data.JCHLONCMPAJ();
			int cnt = 0;
			for(int i = 0; i < m_stampList.Count; i++)
			{
				if(m_stampList[i].type != LayoutDecoCustomStampItem.Type.Create)
				{
					data.ANIJHEBLMGB(i, m_stampList[i].stampId, m_stampList[i].serifId);
					cnt++;
				}
			}
			data.HJMKBCFJOOH(() =>
			{
				//0x19E24B4
				isDone = true;
				IsSaveSucces = true;
			}, () =>
			{
				//0x19E21D8
				MenuScene.Instance.GotoTitle();
			});
			while (!isDone)
				yield return null;
			if (callback != null)
				callback();
		}

		//// RVA: 0x19E1F84 Offset: 0x19E1F84 VA: 0x19E1F84
		public void ResetTarget()
		{
			targetNumber = 0;
		}
	}
}

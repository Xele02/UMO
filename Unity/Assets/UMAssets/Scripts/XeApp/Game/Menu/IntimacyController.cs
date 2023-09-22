using CriWare;
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
	public class IntimacyController : MonoBehaviour
	{
		public interface CharTouchInterface
		{
			bool isTouch { get; } // Slot: 0
			Vector2 touchPosition { get; } // Slot: 1
		}

		private class DecoCharTouch : CharTouchInterface
		{
			private Func<bool> checkTouch; // 0x10

			public bool isTouch { get { return checkTouch(); } } //0x14BCC5C
			public Vector2 touchPosition { get; private set; } // 0x8

			// RVA: 0x14B2740 Offset: 0x14B2740 VA: 0x14B2740
			public DecoCharTouch(Func<bool> checkTouch, Vector2 touchPos)
			{
				touchPosition = touchPos;
				this.checkTouch = checkTouch;
			}
		}

		public enum SerifPlayType
		{
			NONE = 0,
			TIPS = 1,
			N_GRATEFUL = 2,
			B_GRATEFUL = 3,
			S_ONLY = 4,
		}

		public enum ListType
		{
			NOMAL = 0,
			LEVEL_LIMIT = 1,
			ITEM_NONE = 2,
			COUNT_NONE = 3,
		}

		private const float LongTapTime = 1.5f;
		private TransitionRoot m_root; // 0xC
		private LayoutIntimacyInfo m_layoutInfo; // 0x10
		private IntimacySystemMessage m_systemMessage; // 0x14
		private IntimacyCounter m_intimacyCounter; // 0x18
		private IntimacyTouchEffect m_effectObject; // 0x1C
		private CommonDivaBalloon m_divaBalloon; // 0x20
		private MenuDivaTalk m_divaTalk; // 0x24
		private CriAtomExPlayback m_loopSE; // 0x28
		private Coroutine m_coroutine; // 0x2C
		private bool m_isPause; // 0x30
		private bool m_prevEnableReaction; // 0x31
		private bool m_enableLongTouchTips; // 0x32
		private JJOELIOGMKK_DivaIntimacyInfo m_viewIntimacyData; // 0x34
		private bool m_isLoading; // 0x38
		private LayoutIntimacyCounter m_layoutCounterDeco; // 0x3C
		private LayoutDecoIntimacyInfo m_layoutInfoDeco; // 0x40
		private LayoutDecoIntimacyMessage m_layoutMessageDeco; // 0x44
		private SerifPlayType m_serifType; // 0x48
		private ListType m_lsitType; // 0x4C
		[SerializeField] // RVA: 0x670974 Offset: 0x670974 VA: 0x670974
		private float m_SerifPlayTime = 1.5f; // 0x50
		private List<OJEGDIBEBHP> m_viewList; // 0x54
		public HomeDivaControl m_divaControl; // 0x58
		public bool IsPupUpWindow; // 0x5C
		private int m_preReactionIndex; // 0x60
		private GakuyaDivaMessage m_gakuyaDivaMessage; // 0x64
		private GakuyaPresentListWindow m_gakuyaPresentListWindow; // 0x68
		private GakuyaPresentLimit m_gakuyaPresentLimit; // 0x6C

		public JJOELIOGMKK_DivaIntimacyInfo viewData { get { return m_viewIntimacyData; } } //0x14AFBE4
		public bool m_isDisableIntimacyDeco { get; set; } // 0x39

		//// RVA: 0x14AFBEC Offset: 0x14AFBEC VA: 0x14AFBEC
		public bool IsLoading()
		{
			return m_isLoading;
		}

		// RVA: 0x14AFBF4 Offset: 0x14AFBF4 VA: 0x14AFBF4
		private void Update()
		{
			if(!m_isLoading && m_root != null)
			{
				if(m_root is HomeScene)
					UpdateLayout();
				if (m_root is DecoScene)
					UpdateLayoutDeco();
			}
		}

		// RVA: 0x14B0204 Offset: 0x14B0204 VA: 0x14B0204
		private void OnApplicationPause(bool pauseStatus)
		{
			TodoLogger.LogError(0, "IntimacyController.OnApplicationPause");
		}

		//// RVA: 0x14B0210 Offset: 0x14B0210 VA: 0x14B0210
		public void OnDestoryScene()
		{
			if(m_effectObject != null)
			{
				Destroy(m_effectObject.gameObject);
				m_effectObject = null;
			}
			m_coroutine = null;
			m_root = null;
			m_divaBalloon = null;
			if(m_layoutInfo != null)
			{
				m_layoutInfo.Hide();
			}
			if(m_systemMessage != null)
			{
				m_systemMessage.Leave(0, false);
			}
			m_loopSE.Stop();
			if(m_layoutInfoDeco != null)
			{
				m_layoutInfoDeco.Hide();
			}
			if(m_layoutMessageDeco != null)
			{
				m_layoutMessageDeco.Hide();
			}
		}

		//// RVA: 0x14B04BC Offset: 0x14B04BC VA: 0x14B04BC
		public bool CheckUnlock()
		{
			return m_viewIntimacyData.HFFOJIBDNOG();
		}

		//// RVA: 0x14B04E8 Offset: 0x14B04E8 VA: 0x14B04E8
		public void InitHome(TransitionRoot root, CommonDivaBalloon divaBalloon, MenuDivaTalk divaTalk, Action callback)
		{
			this.StartCoroutineWatched(InitHomeCoroutine(root, divaBalloon, divaTalk, callback));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E64D4 Offset: 0x6E64D4 VA: 0x6E64D4
		//// RVA: 0x14B0520 Offset: 0x14B0520 VA: 0x14B0520
		public IEnumerator InitHomeCoroutine(TransitionRoot root, CommonDivaBalloon divaBalloon, MenuDivaTalk divaTalk, Action callback)
		{
			string bundleName; // 0x24
			Font systemFont; // 0x28

			//0x14BC668
			m_root = root;
			m_divaBalloon = divaBalloon;
			m_isLoading = true;
			m_divaTalk = divaTalk;
			m_enableLongTouchTips = true;
			InitViewData(0);
			bundleName = "ly/116.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsLayoutInfo(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutCounter(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsSystemMessage(bundleName, systemFont, m_intimacyCounter.rootMessage));
			yield return Co.R(Co_LoadAssetsEffect(bundleName));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while(!m_layoutInfo.IsLoaded())
				yield return null;
			m_systemMessage.Init(true);
			m_isLoading = false;
			if(callback != null)
				callback();
		}

		//// RVA: 0x14B0634 Offset: 0x14B0634 VA: 0x14B0634
		//public void SetSiblingIndexSystemMessage(int index) { }

		//// RVA: 0x14B0688 Offset: 0x14B0688 VA: 0x14B0688
		//public void SetSiblingIndexCounter(int index) { }

		//// RVA: 0x14B06DC Offset: 0x14B06DC VA: 0x14B06DC
		public void EnterCounter()
		{
			if(!CheckUnlock())
				return;
			m_intimacyCounter.Enter();
			m_intimacyCounter.SetEnable(false);
			m_prevEnableReaction = false;
		}

		//// RVA: 0x14B0744 Offset: 0x14B0744 VA: 0x14B0744
		public void EnterCounter(float animTime)
		{
			if (!CheckUnlock())
				return;
			m_intimacyCounter.Enter(animTime);
			m_intimacyCounter.SetEnable(false);
			m_prevEnableReaction = false;
		}

		//// RVA: 0x14B07B4 Offset: 0x14B07B4 VA: 0x14B07B4
		public void LeaveCounter()
		{
			if(!CheckUnlock())
				return;
			m_intimacyCounter.Leave();
		}

		//// RVA: 0x14B07F0 Offset: 0x14B07F0 VA: 0x14B07F0
		public void LeaveCounter(float animTime)
		{
			if (!CheckUnlock())
				return;
			m_intimacyCounter.Leave(animTime);
		}

		//// RVA: 0x14B0834 Offset: 0x14B0834 VA: 0x14B0834
		public void DisableLongTouchTips()
		{
			m_enableLongTouchTips = false;
		}

		//// RVA: 0x14B0840 Offset: 0x14B0840 VA: 0x14B0840
		public void EnableLongTouchTips()
		{
			m_enableLongTouchTips = true;
		}

		//// RVA: 0x14B084C Offset: 0x14B084C VA: 0x14B084C
		public void EnterLongTouchTips(bool force = false)
		{
			if(m_enableLongTouchTips && m_divaTalk != null)
			{
				if(!m_divaTalk.IsEnableReaction())
					return;
				bool enabled = m_viewIntimacyData.HFFOJIBDNOG();
				if(m_viewIntimacyData.HHLEJPBEHNE() < 1)
				{
					if(enabled && !m_viewIntimacyData.HBODCMLFDOB.PFIILLOIDIL)
					{
						bool b = GameMessageManager.CheckBasara(m_viewIntimacyData.AHHJLDLAPAN_DivaId);
						MessageBank bk = MessageManager.Instance.GetBank("menu");
						string str = bk.GetMessageByLabel(b ? "diva_intimacy_basara_tips" : "diva_intimacy_tips");
						m_systemMessage.SetTextSystem(m_viewIntimacyData.AHHJLDLAPAN_DivaId, str);
						m_systemMessage.Enter(force);
					}
				}
			}
		}

		//// RVA: 0x14B0A74 Offset: 0x14B0A74 VA: 0x14B0A74
		public void EnterLongTouchTips(float animTime, bool force = false)
		{
			if(m_enableLongTouchTips && m_divaTalk != null && m_divaTalk.IsEnableReaction())
			{
				bool enabled = m_viewIntimacyData.HFFOJIBDNOG();
				if(m_viewIntimacyData.HHLEJPBEHNE() < 1)
				{
					if(enabled &&!m_viewIntimacyData.HBODCMLFDOB.PFIILLOIDIL)
					{
						bool b = GameMessageManager.CheckBasara(m_viewIntimacyData.AHHJLDLAPAN_DivaId);
						MessageBank bk = MessageManager.Instance.GetBank("menu");
						string str = bk.GetMessageByLabel(b ? "diva_intimacy_basara_tips" : "diva_intimacy_tips");
						m_systemMessage.SetTextSystem(m_viewIntimacyData.AHHJLDLAPAN_DivaId, str);
						m_systemMessage.Enter(animTime, force);
					}
				}
			}
		}

		//// RVA: 0x14B0CB0 Offset: 0x14B0CB0 VA: 0x14B0CB0
		public void LeaveLongTouchTips(bool force = false)
		{
			bool enabled = m_viewIntimacyData.HFFOJIBDNOG();
			if(m_viewIntimacyData.HHLEJPBEHNE() < 1)
			{
				if(enabled && !m_viewIntimacyData.HBODCMLFDOB.PFIILLOIDIL)
				{
					m_systemMessage.Leave(force);
				}
			}
		}

		//// RVA: 0x14B0D74 Offset: 0x14B0D74 VA: 0x14B0D74
		public void LeaveLongTouchTips(float animTime, bool force = false)
		{
			bool enabled = m_viewIntimacyData.HFFOJIBDNOG();
			if(m_viewIntimacyData.HHLEJPBEHNE() < 1)
			{
				if (enabled && !m_viewIntimacyData.HBODCMLFDOB.PFIILLOIDIL)
				{
					m_systemMessage.Leave(animTime, force);
				}
			}
		}

		//// RVA: 0x14B0E40 Offset: 0x14B0E40 VA: 0x14B0E40
		//public void StartIntimacyUp(CharTouchButton button, Action<bool> reactionCallback, Action endCallback, Func<bool> restartFunc) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E654C Offset: 0x6E654C VA: 0x6E654C
		//// RVA: 0x14B0F2C Offset: 0x14B0F2C VA: 0x14B0F2C
		//public IEnumerator Co_IntimacyUp(CharTouchButton button, Action<bool> reactionCallback, Action endCallback, Func<bool> restartFunc) { }

		//// RVA: 0x14B1040 Offset: 0x14B1040 VA: 0x14B1040
		private void InitViewData(int divaId = 0)
		{
			m_viewIntimacyData = new JJOELIOGMKK_DivaIntimacyInfo();
			if(divaId == 0)
			{
				divaId = GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId;
			}
			m_viewIntimacyData.KHEKNNFCAOI(divaId);
			m_viewIntimacyData.HCDGELDHFHB(false);
		}

		//// RVA: 0x14AFCE8 Offset: 0x14AFCE8 VA: 0x14AFCE8
		private void UpdateLayout()
		{
			if(m_viewIntimacyData != null)
			{
				if(m_intimacyCounter != null)
				{
					int cnt = m_viewIntimacyData.GMIEFBELJJH();
					if (cnt <= 0)
						cnt = 0;
					long t = m_viewIntimacyData.BPBIHCAMNBJ();
					JKNNIKNKMNJ j = new JKNNIKNKMNJ();
					int countMax = j.GPBGFJONHPB();
					if (countMax <= cnt)
						t = -1;
					m_intimacyCounter.SetTime(t);
					m_intimacyCounter.SetCount(cnt);
					if(m_divaTalk != null)
					{
						bool canEnable = cnt > 0 && m_divaTalk.IsEnableReaction() && !MenuScene.Instance.IsTransition() && m_coroutine == null;
						if (canEnable != m_prevEnableReaction)
						{
							m_prevEnableReaction = canEnable;
							if(!canEnable)
							{
								LeaveLongTouchTips(false);
								m_intimacyCounter.SetEnable(false);
							}
							else
							{
								EnterLongTouchTips(false);
								m_intimacyCounter.SetEnable(true);
							}
						}
					}
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E65C4 Offset: 0x6E65C4 VA: 0x6E65C4
		//// RVA: 0x14B116C Offset: 0x14B116C VA: 0x14B116C
		//private IEnumerator Co_CheckIntimacyCount(CharTouchButton button, Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E663C Offset: 0x6E663C VA: 0x6E663C
		//// RVA: 0x14B124C Offset: 0x14B124C VA: 0x14B124C
		//private IEnumerator Co_Save() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E66B4 Offset: 0x6E66B4 VA: 0x6E66B4
		//// RVA: 0x14B12E0 Offset: 0x14B12E0 VA: 0x14B12E0
		private IEnumerator Co_LoadAssetsLayoutInfo(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x14B752C
			if(m_layoutInfo == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_pre_gauge_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
					//0x14B3B60
					instance.transform.SetParent(m_root.transform, false);
					m_layoutInfo = instance.GetComponent<LayoutIntimacyInfo>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_layoutInfo.transform.SetParent(m_root.transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E672C Offset: 0x6E672C VA: 0x6E672C
		//// RVA: 0x14B13C0 Offset: 0x14B13C0 VA: 0x14B13C0
		private IEnumerator Co_LoadAssetsSystemMessage(string bundleName, Font font, Transform parent)
		{
			AssetBundleLoadUGUIOperationBase operation;

			//0x14B7E80
			if(m_systemMessage == null)
			{
				operation = AssetBundleManager.LoadUGUIAsync(bundleName, "IntimacySystemMessage");
				yield return operation;
				yield return operation.InitializeUGUICoroutine(font, (GameObject instance) => {
					//0x14B4550
					if(parent != null)
						instance.transform.SetParent(parent, false);
					else
						instance.transform.SetParent(m_root.transform, false);
					m_systemMessage = instance.GetComponent<IntimacySystemMessage>();
				});
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_systemMessage.transform.SetParent(m_root.transform, false);
			}
			
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E67A4 Offset: 0x6E67A4 VA: 0x6E67A4
		//// RVA: 0x14B14B8 Offset: 0x14B14B8 VA: 0x14B14B8
		private IEnumerator Co_LoadAssetsLayoutCounter(string bundleName, Font font)
		{
			int bundleLoadCount; // 0x1C
			AssetBundleLoadUGUIOperationBase operation; // 0x20

			//0x14B6EA8
			if(m_intimacyCounter == null)
			{
				bundleLoadCount = 0;
				operation = AssetBundleManager.LoadUGUIAsync(bundleName, "IntimacyCounter");
				bundleLoadCount++;
				yield return operation;
				yield return Co.R(operation.InitializeUGUICoroutine(font, (GameObject instance) => {
					//0x14B3C44
					instance.transform.SetParent(m_root.transform, false);
					m_intimacyCounter = instance.GetComponent<IntimacyCounter>();
				}));
				for(int i = 0; i < bundleLoadCount; i++)
				{
					AssetBundleManager.UnloadAssetBundle(bundleName, false);
				}
				operation = null;
			}
			else
			{
				m_intimacyCounter.transform.SetParent(m_root.transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E681C Offset: 0x6E681C VA: 0x6E681C
		//// RVA: 0x14B1598 Offset: 0x14B1598 VA: 0x14B1598
		private IEnumerator Co_LoadAssetsEffect(string bundleName)
		{
			AssetBundleLoadAssetOperation operation;

			//0x14B6B6C
			if(m_effectObject == null)
			{
				operation = AssetBundleManager.LoadAssetAsync(bundleName, "IntimacyTouchEffect", typeof(GameObject));
				yield return operation;
				GameObject go = Instantiate(operation.GetAsset<GameObject>());
				m_effectObject = go.GetComponentInChildren<IntimacyTouchEffect>();
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6E6894 Offset: 0x6E6894 VA: 0x6E6894
		//// RVA: 0x14B1660 Offset: 0x14B1660 VA: 0x14B1660
		//public bool get_m_isDisableIntimacyDeco() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E68A4 Offset: 0x6E68A4 VA: 0x6E68A4
		//// RVA: 0x14B1668 Offset: 0x14B1668 VA: 0x14B1668
		//public void set_m_isDisableIntimacyDeco(bool value) { }

		//// RVA: 0x14B1670 Offset: 0x14B1670 VA: 0x14B1670
		//public void HideDeco() { }

		//// RVA: 0x14B17CC Offset: 0x14B17CC VA: 0x14B17CC
		//public void DetachDeco() { }

		//// RVA: 0x14B17D4 Offset: 0x14B17D4 VA: 0x14B17D4
		public void SetEnableDecoCounter(bool isEnabled, bool isDisableImmediately = false)
		{
			if (m_layoutCounterDeco == null)
				return;
			if (m_root == null)
				return;
			if(isEnabled && !isDisableImmediately && CheckUnlock())
			{
				m_layoutCounterDeco.transform.SetParent(m_root.transform, false);
			}
			else
			{
				m_layoutCounterDeco.transform.SetParent(null, false);
			}
			if (!isEnabled)
				m_layoutCounterDeco.Hide();
			else
				m_layoutCounterDeco.Show();
		}

		//// RVA: 0x14B1678 Offset: 0x14B1678 VA: 0x14B1678
		//public void SetEnableDecoInfo(bool isEnabled) { }

		//// RVA: 0x14B19A8 Offset: 0x14B19A8 VA: 0x14B19A8
		//public void SetEnableDecoMessage(bool isEnabled) { }

		//// RVA: 0x14B1AFC Offset: 0x14B1AFC VA: 0x14B1AFC
		public void InitDeco(TransitionRoot root, Action callback)
		{
			if (m_root != null)
				return;
			this.StartCoroutineWatched(InitDecoCoroutine(root, callback));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E68B4 Offset: 0x6E68B4 VA: 0x6E68B4
		//// RVA: 0x14B1BB8 Offset: 0x14B1BB8 VA: 0x14B1BB8
		public IEnumerator InitDecoCoroutine(TransitionRoot root, Action callback)
		{
			string bundleName; // 0x1C
			Font systemFont; // 0x20

			//0x14BBE08
			m_isLoading = true;
			m_root = root;
			InitViewData(0);
			bundleName = "ly/116.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return null;
			yield return Co.R(Co_LoadAssetsEffect(bundleName));
			bundleName = "ly/201.xab";
			yield return Co.R(Co_LoadAssetsLayoutInfoDeco(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutMessageDeco(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutCounterDeco(bundleName, systemFont));
			while (!m_layoutCounterDeco.IsLoaded())
				yield return null;
			while (!m_layoutInfoDeco.IsLoaded())
				yield return null;
			while (!m_layoutMessageDeco.IsLoaded())
				yield return null;
			m_isLoading = false;
			if (callback != null)
				callback();
			if (!CheckUnlock())
				yield break;
			m_layoutCounterDeco.Enter();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E692C Offset: 0x6E692C VA: 0x6E692C
		//// RVA: 0x14B1C98 Offset: 0x14B1C98 VA: 0x14B1C98
		private IEnumerator Co_LoadAssetsLayoutCounterDeco(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x14B7204
			if(m_layoutCounterDeco == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_fs_to_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x14B3D28
					instance.transform.SetParent(m_root.transform, false);
					m_layoutCounterDeco = instance.GetComponent<LayoutIntimacyCounter>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_layoutCounterDeco.transform.SetParent(m_root.transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E69A4 Offset: 0x6E69A4 VA: 0x6E69A4
		//// RVA: 0x14B1D78 Offset: 0x14B1D78 VA: 0x14B1D78
		private IEnumerator Co_LoadAssetsLayoutInfoDeco(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x14B7854
			if(m_layoutInfoDeco == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_deco_present_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x14B3E0C
					instance.transform.SetParent(null, false);
					m_layoutInfoDeco = GetComponent<LayoutDecoIntimacyInfo>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_layoutInfoDeco.transform.SetParent(null, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E6A1C Offset: 0x6E6A1C VA: 0x6E6A1C
		//// RVA: 0x14B1E58 Offset: 0x14B1E58 VA: 0x14B1E58
		private IEnumerator Co_LoadAssetsLayoutMessageDeco(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x14B7B58
			if(m_layoutMessageDeco == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_pre_win_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x14B3ECC
					instance.transform.SetParent(m_root.transform, false);
					m_layoutMessageDeco = instance.GetComponent<LayoutDecoIntimacyMessage>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_layoutMessageDeco.transform.SetParent(m_root.transform, false);
			}
		}

		//// RVA: 0x14B1F38 Offset: 0x14B1F38 VA: 0x14B1F38
		//public bool CheckIntimacyDeco(JJOELIOGMKK viewIntimacyData, DecorationChara chara) { }

		//// RVA: 0x14B22FC Offset: 0x14B22FC VA: 0x14B22FC
		//public bool CanIntimacyDeco(JJOELIOGMKK viewIntimacyData, DecorationChara chara) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E6A94 Offset: 0x6E6A94 VA: 0x6E6A94
		//// RVA: 0x14B2194 Offset: 0x14B2194 VA: 0x14B2194
		//private IEnumerator Co_TapLockedChara(JJOELIOGMKK v) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E6B0C Offset: 0x6E6B0C VA: 0x6E6B0C
		//// RVA: 0x14B223C Offset: 0x14B223C VA: 0x14B223C
		//private IEnumerator Co_TapShowInfo(JJOELIOGMKK v, DecorationChara chara) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E6B84 Offset: 0x6E6B84 VA: 0x6E6B84
		//// RVA: 0x14B24EC Offset: 0x14B24EC VA: 0x14B24EC
		//private IEnumerator Co_NotifyLevelMax(JJOELIOGMKK v) { }

		//// RVA: 0x14B25B4 Offset: 0x14B25B4 VA: 0x14B25B4
		//public void TouchDecoCharactor(JJOELIOGMKK viewIntimacyData, DecorationChara chara, Vector2 touchPos, Func<bool> checkTouchKeeping, Action<bool> reactionCallback, Action endCallback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E6BFC Offset: 0x6E6BFC VA: 0x6E6BFC
		//// RVA: 0x14B2770 Offset: 0x14B2770 VA: 0x14B2770
		//private IEnumerator Co_TouchDecoCharactor(IntimacyController.CharTouchInterface charTouch, DecorationChara chara, Action<bool> reactionCallback, Action endCallback) { }

		//// RVA: 0x14AFFAC Offset: 0x14AFFAC VA: 0x14AFFAC
		private void UpdateLayoutDeco()
		{
			TodoLogger.LogError(0, "UpdateLayoutDeco");
		}

		//// RVA: 0x14B2884 Offset: 0x14B2884 VA: 0x14B2884
		public void InitGakuya(TransitionRoot root, GakuyaDivaMessage gakuyaDivaMessage, GakuyaPresentListWindow gakuyaPresentListWindow, GakuyaPresentLimit gakuyaPresentLimit, MenuDivaTalk divaTalk, HomeDivaControl divaControl, Action callback)
		{
			m_gakuyaDivaMessage = gakuyaDivaMessage;
			m_gakuyaPresentListWindow = gakuyaPresentListWindow;
			m_gakuyaPresentLimit = gakuyaPresentLimit;
			m_divaTalk = divaTalk;
			m_divaControl = divaControl;
			m_viewList = new List<OJEGDIBEBHP>();
			m_viewList = OJEGDIBEBHP.FKDIMODKKJD();
			this.StartCoroutineWatched(InitGakuyaCoroutine(root, callback));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E6C74 Offset: 0x6E6C74 VA: 0x6E6C74
		//// RVA: 0x14B2968 Offset: 0x14B2968 VA: 0x14B2968
		public IEnumerator InitGakuyaCoroutine(TransitionRoot root, Action callback)
		{
			string bundleName; // 0x1C
			Font systemFont; // 0x20

			//0x14BC284
			m_isLoading = true;
			m_root = root;
			InitViewData(0);
			bundleName = "ly/116.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsLayoutInfo(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsSystemMessage(bundleName, systemFont, null));
			yield return Co.R(Co_LoadAssetsEffect(bundleName));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while(!m_layoutInfo.IsLoaded())
				yield return null;
			m_systemMessage.Init(false);
			InitialGakuyaSetting();
			m_isLoading = false;
			if (callback != null)
				callback();
		}

		//// RVA: 0x14B2A48 Offset: 0x14B2A48 VA: 0x14B2A48
		public void GakuyaDivaChange(int divaId, MenuDivaTalk divaTalk)
		{
			m_divaTalk = divaTalk;
			InitViewData(divaId);
			InitialGakuyaSetting();
		}

		//// RVA: 0x14B2A68 Offset: 0x14B2A68 VA: 0x14B2A68
		private void InitialGakuyaSetting()
		{
			m_serifType = SerifPlayType.NONE;
			m_lsitType = ListType.NOMAL;
			m_gakuyaPresentListWindow.SetItems(m_viewList);
			m_layoutInfo.Setup(m_viewIntimacyData, false);
			m_gakuyaDivaMessage.SetPos(0);
			m_viewIntimacyData.HCDGELDHFHB(false);
			SetGakuyaPresentListState();
			SetPresentLimitCntLayout();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E6CEC Offset: 0x6E6CEC VA: 0x6E6CEC
		//// RVA: 0x14B2F04 Offset: 0x14B2F04 VA: 0x14B2F04
		public IEnumerator co_UpdateGakuyaList(Action callBack)
		{
			//0x14BCAE4
			m_viewList = OJEGDIBEBHP.FKDIMODKKJD();
			SetGakuyaPresentListState();
			SetPresentLimitCntLayout();
			m_gakuyaPresentListWindow.SetItems(m_viewList);
			if (callBack != null)
				callBack();
			yield break;
		}

		//// RVA: 0x14B2FCC Offset: 0x14B2FCC VA: 0x14B2FCC
		//public void StartToPresentGakuya(int itemId, int useitemCount, Vector2 effectPos, Action endCallback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E6D64 Offset: 0x6E6D64 VA: 0x6E6D64
		//// RVA: 0x14B3008 Offset: 0x14B3008 VA: 0x14B3008
		//public IEnumerator Co_ToPresentGakuya(int itemId, int useitemCount, Vector2 effectPos, Action endCallback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E6DDC Offset: 0x6E6DDC VA: 0x6E6DDC
		//// RVA: 0x14B312C Offset: 0x14B312C VA: 0x14B312C
		public IEnumerator GakuyaCancelReaction()
		{
			//0x14BBBC0
			m_gakuyaDivaMessage.Hide();
			if (m_divaControl != null)
			{
				yield return Co.R(m_divaControl.Coroutine_IdleCrossFade());
			}
			SoundManager.Instance.voDiva.Stop();
			while (!m_divaTalk.IsEnableReaction())
				yield return null;
			while (m_gakuyaDivaMessage.IsPlaying())
				yield return null;
		}

		//// RVA: 0x14B31D8 Offset: 0x14B31D8 VA: 0x14B31D8
		public void SetGakuyaType()
		{
			if(!IsPupUpWindow && !m_viewIntimacyData.HBODCMLFDOB.PFIILLOIDIL)
			{
				m_serifType = m_viewIntimacyData.NCNAPMHEINJ() ? SerifPlayType.TIPS : SerifPlayType.NONE;
			}
			else
			{
				m_serifType = SerifPlayType.NONE;
			}
			m_lsitType = ListType.ITEM_NONE;
			if (!itemCountCheck())
			{
				m_lsitType = ListType.LEVEL_LIMIT;
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled() || m_viewIntimacyData.HBODCMLFDOB.PFIILLOIDIL)
				{
					m_lsitType = ListType.COUNT_NONE;
					if (m_viewIntimacyData.NCNAPMHEINJ())
						m_lsitType = ListType.NOMAL;
				}
			}
		}

		//// RVA: 0x14B2B30 Offset: 0x14B2B30 VA: 0x14B2B30
		public void SetGakuyaPresentListState()
		{
			SetGakuyaType();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			switch(m_lsitType)
			{
				case ListType.NOMAL:
					m_gakuyaPresentListWindow.SetItemDark(false);
					m_gakuyaPresentListWindow.SetDark(false, "");
					break;
				case ListType.LEVEL_LIMIT:
					m_gakuyaPresentListWindow.SetItemDark(true);
					m_gakuyaPresentListWindow.SetDark(false, "");
					break;
				case ListType.ITEM_NONE:
					m_gakuyaPresentListWindow.SetItemDark(false);
					m_gakuyaPresentListWindow.SetDark(true, bk.GetMessageByLabel("gakuya_intimacy_present_none"));
					break;
				case ListType.COUNT_NONE:
					m_gakuyaPresentListWindow.SetItemDark(true);
					m_gakuyaPresentListWindow.SetDark(false, "");
					break;
				default:
					return;
			}
		}

		//// RVA: 0x14B2D5C Offset: 0x14B2D5C VA: 0x14B2D5C
		private void SetPresentLimitCntLayout()
		{
			if (m_viewIntimacyData == null)
				return;
			if (m_viewIntimacyData.AHHJLDLAPAN_DivaId < 1)
				return;
			m_gakuyaPresentLimit.SetPresentLimit(CIOECGOMILE.HHCJCDFCLOB.PAAMLFNPJGJ_IntimacyDivaPresentLeft[m_viewIntimacyData.AHHJLDLAPAN_DivaId - 1]);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E6E54 Offset: 0x6E6E54 VA: 0x6E6E54
		//// RVA: 0x14B34D4 Offset: 0x14B34D4 VA: 0x14B34D4
		//private IEnumerator Co_Data_Save() { }

		//// RVA: 0x14B33BC Offset: 0x14B33BC VA: 0x14B33BC
		private bool itemCountCheck()
		{
			if (m_viewList.Count < 1)
				return true;
			int r = 0;
			for(int i = 0; i < m_viewList.Count; i++)
			{
				r += m_viewList[i].GLHBKPNFLOP_Count;
			}
			return r < 1;
		}

		//// RVA: 0x14B3568 Offset: 0x14B3568 VA: 0x14B3568
		public void charTouchPlaySe()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_HOME_000);
		}

		//// RVA: 0x14B35CC Offset: 0x14B35CC VA: 0x14B35CC
		public void GakuyaInfoEnter()
		{
			m_layoutInfo.TryEnter();
			if (!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled())
				return;
			m_gakuyaPresentLimit.gameObject.SetActive(true);
		}

		//// RVA: 0x14B3718 Offset: 0x14B3718 VA: 0x14B3718
		public void GakuyaInfoLeave()
		{
			m_layoutInfo.TryLeave();
			m_gakuyaPresentLimit.gameObject.SetActive(false);
		}

		//// RVA: 0x14B378C Offset: 0x14B378C VA: 0x14B378C
		public void GakuyaSerifChenge()
		{
			if (m_divaTalk == null)
				return;
			SetGakuyaType();
			if (m_serifType == SerifPlayType.TIPS)
				OnChangedGakuyaDivaTalk();
		}

		//// RVA: 0x14B37C8 Offset: 0x14B37C8 VA: 0x14B37C8
		private void OnChangedGakuyaDivaTalk()
		{
			switch(m_serifType)
			{
				case SerifPlayType.TIPS:
					{
						int index = -1;
						while (true)
						{
							if (index != -1 && m_preReactionIndex != index)
								break;
							if (m_viewIntimacyData.NHCCINMHEAB - 1 > 2)
								return;
							index = UnityEngine.Random.Range(new int[] { 7, 1, 4 }[m_viewIntimacyData.NHCCINMHEAB - 1], new int[] { 10, 4, 7 }[m_viewIntimacyData.NHCCINMHEAB - 1]);
							if (index == -1)
								return;
						}
						m_preReactionIndex = index;
						m_divaTalk.DoPresentReaction(index, (string Msg) =>
						{
							//0x14B409C
							m_gakuyaDivaMessage.SetMessage(Msg);
						});
					}
					break;
				case SerifPlayType.N_GRATEFUL:
					m_divaTalk.DoPresentReaction(0, (string Msg) =>
					{
						//0x14B4034
						m_gakuyaDivaMessage.SetMessage(Msg);
					});
					break;
				case SerifPlayType.B_GRATEFUL:
					m_divaTalk.DoPresentReaction(10, (string Msg) =>
					{
						//0x14B4068
						m_gakuyaDivaMessage.SetMessage(Msg);
					});
					break;
				case SerifPlayType.S_ONLY:
					m_gakuyaDivaMessage.SetMessage(MenuScene.Instance.divaManager.GetMessageByLabel("present_01"));
					break;
				default:
					break;
			}
			if (m_serifType == SerifPlayType.NONE)
				return;
			m_gakuyaDivaMessage.TryEnter();
		}

		//// RVA: 0x14B3AA8 Offset: 0x14B3AA8 VA: 0x14B3AA8
		//private int RandomTalkReaction(int DivaTension) { }

		//// RVA: 0x14B3AE0 Offset: 0x14B3AE0 VA: 0x14B3AE0
		//private void LeaveGakuyaMessage() { }

		//// RVA: 0x14B3B18 Offset: 0x14B3B18 VA: 0x14B3B18
		//private void HideGakuyaMessage() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6E6F1C Offset: 0x6E6F1C VA: 0x6E6F1C
		//// RVA: 0x14B3FB0 Offset: 0x14B3FB0 VA: 0x14B3FB0
		//private bool <Co_TapLockedChara>b__67_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E6F2C Offset: 0x6E6F2C VA: 0x6E6F2C
		//// RVA: 0x14B3FDC Offset: 0x14B3FDC VA: 0x14B3FDC
		//private bool <Co_TapShowInfo>b__68_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E6F3C Offset: 0x6E6F3C VA: 0x6E6F3C
		//// RVA: 0x14B4008 Offset: 0x14B4008 VA: 0x14B4008
		//private bool <Co_NotifyLevelMax>b__69_0() { }
	}
}

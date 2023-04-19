using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnlock : MonoBehaviour, IDisposable
	{
		public enum eUnlockType
		{
			None = 0,
			Music = 1,
			Stage = 2,
			Diva = 3,
			DivaNotify = 4,
			DifficultyUnlock = 5,
			MultiDivaMusic = 6,
			Line6Music = 7,
			LiveSkip = 8,
			Max = 9,
		}
 
		public enum eSceneType
		{
			None = 0,
			StorySelect = 1,
			Home = 2,
			DropResult = 3,
			MusicSelect = 4,
			FreeMusicSelect1 = 5,
			FreeMusicSelect2 = 6,
		}

		public class UnlockParam
		{
			public eSceneType sceneType; // 0x8
			public eUnlockType unlockType; // 0xC
			public int id; // 0x10
			public int difficultyBit; // 0x14
			public int difficulty6LineBit; // 0x18
			public bool isLine6; // 0x1C
		}

		public class UnlockInfo
		{
			public List<UnlockParam> paramList; // 0x8

			public UnlockParam param { get { return paramList[0]; } } //0x115D728
		}

		private List<UnlockParam> m_paramList = new List<UnlockParam>(); // 0x14
		private Dictionary<int, List<UnlockParam>> m_paramDic = new Dictionary<int, List<UnlockParam>>(); // 0x18
		private List<IEnumerator> m_updater = new List<IEnumerator>(); // 0x1C
		private UnlockInfo m_unlockInfo = new UnlockInfo(); // 0x20
		private LayoutPopupUnlockController m_controller = new LayoutPopupUnlockController(); // 0x24
		private eUnlockType[] ShowPriorityTbl = new eUnlockType[8] {
			eUnlockType.Music, 
			eUnlockType.MultiDivaMusic, 
			eUnlockType.Line6Music,
			eUnlockType.Stage,
			eUnlockType.Diva,
			eUnlockType.DivaNotify,
			eUnlockType.DifficultyUnlock,
			eUnlockType.LiveSkip
		}; // 0x28

		public int PressButtonLabel { get; private set; } // 0xC
		public bool IsClosed { get; private set; } // 0x10
		// public bool IsDisplay { get; } 0x1159BE8

		// // RVA: 0x11588F8 Offset: 0x11588F8 VA: 0x11588F8
		public static PopupUnlock Create(Transform parent)
		{
			GameObject g = new GameObject("PopupUnlock");
			g.transform.SetParent(parent);
			return g.AddComponent<PopupUnlock>();
		}

		// // RVA: 0x11589E0 Offset: 0x11589E0 VA: 0x11589E0
		public static IEnumerator Show(PopupUnlock.eSceneType type, Action<int> callbackClose, bool autoChangeTransition = false, Action<PopupUnlock> receivePopup = null)
		{
			return Coroutine_ShowUnlock(type,callbackClose,autoChangeTransition,receivePopup);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70AC64 Offset: 0x70AC64 VA: 0x70AC64
		// // RVA: 0x11589F8 Offset: 0x11589F8 VA: 0x11589F8
		private static IEnumerator Coroutine_ShowUnlock(PopupUnlock.eSceneType type, Action<int> callbackClose, bool autoChangeTransition, Action<PopupUnlock> receivePopup)
		{
			PopupUnlock unlockPopup;

			//0x115C684
			if(GameManager.Instance.IsTutorial)
			{
				if(callbackClose != null)
					callbackClose(0);
			}
			unlockPopup = Create(null);
			unlockPopup.Setup(type);
			unlockPopup.Show();
			if(receivePopup != null)
			{
				receivePopup(unlockPopup);
			}
			while(!unlockPopup.IsClosed)
				yield return null;
			int a = unlockPopup.PressButtonLabel;
			unlockPopup.Dispose();
			if(callbackClose != null)
				callbackClose(a);
			if(autoChangeTransition)
				ChangeTransition(a);
		}

		// // RVA: 0x1158AF0 Offset: 0x1158AF0 VA: 0x1158AF0
		private static void ChangeTransition(int label)
		{
			if(label != 9)
			{
				if(MenuScene.Instance != null)
				{
					if(label == 46)
					{
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, 0);
					}
					else
					{
						if(label != 45)
							return;
						MenuScene.Instance.Mount(TransitionUniqueId.STORYSELECT, null, true, 0);
					}
				}
			}
		}

		// // RVA: 0x1158E48 Offset: 0x1158E48 VA: 0x1158E48
		private void SetViewData(eSceneType sceneType, List<FAGCLBOACEE> viewData)
		{
			for(int i = 0; i < viewData.Count; i++)
			{
				UnlockParam param = new UnlockParam();
				switch(viewData[i].DEPGBBJMFED)
				{
					case FAGCLBOACEE.BEFPBAIONFK.KDGLIKDMGCN/*1*/:
						param.unlockType = eUnlockType.Stage;
						param.sceneType = sceneType;
						param.id = viewData[i].PPFNGGCBJKC;
						AddParam(param);
						break;
					case FAGCLBOACEE.BEFPBAIONFK.CELONIBHMBA/*2*/:
						param.unlockType = eUnlockType.Music;
						param.sceneType = sceneType;
						param.id = viewData[i].PPFNGGCBJKC;
						AddParam(param);
						break;
					case FAGCLBOACEE.BEFPBAIONFK.EOBDILOCCHO/*3*/:
						param.unlockType = eUnlockType.DivaNotify;
						param.sceneType = sceneType;
						param.id = viewData[i].PPFNGGCBJKC;
						AddParam(param);
						break;
					case FAGCLBOACEE.BEFPBAIONFK.FCHMGAHKMLG/*4*/:
						param.unlockType = eUnlockType.DifficultyUnlock;
						param.sceneType = sceneType;
						param.id = viewData[i].PPFNGGCBJKC;
						param.difficultyBit = 0;
						if (!viewData[i].GIKLNODJKFK_6Line)
						{
							param.difficultyBit = 1 << viewData[i].AKNELONELJK;
						}
						param.difficulty6LineBit = 0;
						if(viewData[i].GIKLNODJKFK_6Line)
						{
							param.difficulty6LineBit = 1 << viewData[i].AKNELONELJK;
						}
						//LAB_011596fc;
						param.isLine6 = viewData[i].GIKLNODJKFK_6Line;
						AddParam(param);
						break;
					case FAGCLBOACEE.BEFPBAIONFK.OPPDJDDHHFM/*5*/:
						param.unlockType = eUnlockType.MultiDivaMusic;
						param.sceneType = sceneType;
						param.id = viewData[i].PPFNGGCBJKC;
						AddParam(param);
						break;
					case FAGCLBOACEE.BEFPBAIONFK.AJPJOJNIHKH/*6*/:
						param.unlockType = eUnlockType.Line6Music;
						param.sceneType = sceneType;
						param.id = viewData[i].PPFNGGCBJKC;
						param.isLine6 = true;
						param.difficultyBit = 0;
						param.difficulty6LineBit = 0;
						if (viewData[i].GIKLNODJKFK_6Line)
						{
							param.difficulty6LineBit = 1 << viewData[i].AKNELONELJK;
						}
						//LAB_01159728;
						AddParam(param);
						break;
					case FAGCLBOACEE.BEFPBAIONFK.KHBEKPMMALI/*7*/:
						param.unlockType = eUnlockType.LiveSkip;
						param.sceneType = sceneType;
						param.id = viewData[i].PPFNGGCBJKC;
						param.difficultyBit = 0;
						if (!viewData[i].GIKLNODJKFK_6Line)
						{
							param.difficultyBit = 1 << viewData[i].AKNELONELJK;
						}
						param.difficulty6LineBit = 0;
						if (viewData[i].GIKLNODJKFK_6Line)
						{
							param.difficulty6LineBit = 1 << viewData[i].AKNELONELJK;
						}
						//LAB_011596fc
						param.isLine6 = viewData[i].GIKLNODJKFK_6Line;
						//LAB_01159728
						//LAB_01159738
						AddParam(param);
						break;
					default:
						break;
				}
			}
		}

		// // RVA: 0x1159878 Offset: 0x1159878 VA: 0x1159878
		public void ViewInitialize(eSceneType type)
		{
			switch(type)
			{
				case eSceneType.StorySelect:
					TodoLogger.Log(0, "ViewInitialize 1");
					return;
				case eSceneType.Home:
					SetViewData(eSceneType.Home, FAGCLBOACEE.OGGDOPACJOB());
					return;
				case eSceneType.DropResult:
					TodoLogger.Log(0, "ViewInitialize 3");
					return;
				case eSceneType.MusicSelect:
					TodoLogger.Log(0, "ViewInitialize 4");
					return;
				case eSceneType.FreeMusicSelect1:
					{
						int level = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MMPPEHPKGLI_AddRegularMusicMVer = DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion;
						SetViewData(eSceneType.FreeMusicSelect1, FAGCLBOACEE.ICBFAFNOHIB(level));
						SetViewData(eSceneType.FreeMusicSelect1, FAGCLBOACEE.MLHMCCLKALG());
						SetViewData(eSceneType.FreeMusicSelect1, FAGCLBOACEE.GGGOIINDGMI());
					}
					return;
				case eSceneType.FreeMusicSelect2:
					SetViewData(eSceneType.FreeMusicSelect2, FAGCLBOACEE.JODDIFOOIOJ());
					return;
				default:
					return;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70AD1C Offset: 0x70AD1C VA: 0x70AD1C
		// // RVA: 0x1159B20 Offset: 0x1159B20 VA: 0x1159B20
		// public IEnumerator LoadLayout(Action callback) { }

		// // RVA: 0x11597F8 Offset: 0x11597F8 VA: 0x11597F8
		public void AddParam(UnlockParam param)
		{
			m_paramList.Add(param);
		}

		// // RVA: 0x1159C70 Offset: 0x1159C70 VA: 0x1159C70
		// public bool IsClearStoryMusic(int musicId) { }

		// // RVA: 0x1159D80 Offset: 0x1159D80 VA: 0x1159D80
		public void Clear()
		{
			m_paramList.Clear();
			PressButtonLabel = 0;
		}

		// RVA: 0x1159E00 Offset: 0x1159E00 VA: 0x1159E00 Slot: 4
		public void Dispose()
		{
			Clear();
			m_controller.Dispose();
			Destroy(gameObject);
		}

		// // RVA: 0x1159EBC Offset: 0x1159EBC VA: 0x1159EBC
		public void Setup(eSceneType type)
		{
			ViewInitialize(type);
			m_controller.Parent = gameObject;
			m_controller.Setup();
		}

		// // RVA: 0x1159F24 Offset: 0x1159F24 VA: 0x1159F24
		public void Show()
		{
			if(m_paramList.Count < 1)
				IsClosed = true;
			else
			{
				for(int i = 0; i < m_paramList.Count; i++)
				{
					UnlockParam current = m_paramList[i];
					int a = (int)current.unlockType;
					List<UnlockParam> l;
					if(!m_paramDic.TryGetValue(a, out l))
					{
						l = new List<UnlockParam>();
						m_paramDic.Add(a, l);
					}
					if((a | 2) == 7)
					{
						UnlockParam p = l.Find((UnlockParam x) =>
						{
							//0x115C520
							return current.id == x.id;
						});
						if(p == null)
						{
							l.Add(current);
						}
						else
						{
							p.difficultyBit |= current.difficultyBit;
							p.difficulty6LineBit |= current.difficulty6LineBit;
						}
					}
					else
					{
						l.Add(m_paramList[i]);
					}
				}
				for(int i = 0; i < ShowPriorityTbl.Length; i++)
				{
					List<UnlockParam> l;
					if (m_paramDic.TryGetValue((int)ShowPriorityTbl[i], out l))
					{ 
						switch(ShowPriorityTbl[i])
						{
							case eUnlockType.Music:
								m_updater.Add(ShowPopupMusic(ShowPriorityTbl[i], l));
								break;
							case eUnlockType.Stage:
							case eUnlockType.DivaNotify:
							case eUnlockType.DifficultyUnlock:
							case eUnlockType.MultiDivaMusic:
							case eUnlockType.Line6Music:
							case eUnlockType.LiveSkip:
								m_updater.Add(ShowPopupDefault(ShowPriorityTbl[i], l));
								break;
							case eUnlockType.Diva:
								m_updater.Add(ShowPopupDiva(ShowPriorityTbl[i], l));
								break;
							default:
								break;
						}
					}
				}
			}
		}

		// // RVA: 0x115A7AC Offset: 0x115A7AC VA: 0x115A7AC
		public void Update()
		{
			bool noCheckButton = true;
			if(m_updater.Count > 0)
			{
				if(!m_updater[0].MoveNext())
				{
					m_updater.RemoveAt(0);
					noCheckButton = false;
				}
				if (m_updater.Count == 0)
					IsClosed = true;
			}
			if (m_controller != null)
				m_controller.Update();
			if (!noCheckButton)
				CheckButtonLabel();
		}

		// // RVA: 0x115A988 Offset: 0x115A988 VA: 0x115A988
		private void CheckButtonLabel()
		{
			if (PressButtonLabel == 0 || PressButtonLabel == 9)
				return;
			m_updater.Clear();
			IsClosed = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70AD94 Offset: 0x70AD94 VA: 0x70AD94
		// // RVA: 0x115A56C Offset: 0x115A56C VA: 0x115A56C
		private IEnumerator ShowPopupDefault(eUnlockType unlockType, List<UnlockParam> param)
		{
			//0x115CBA0
			bool popupWait = true;
			PopupShowCommon(unlockType, param, null, null, () =>
			{
				//0x115C574
				popupWait = false;
				return true;
			});
			while (popupWait)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70AE0C Offset: 0x70AE0C VA: 0x70AE0C
		// // RVA: 0x115A6EC Offset: 0x115A6EC VA: 0x115A6EC
		private IEnumerator ShowPopupDiva(eUnlockType unlockType, List<UnlockParam> param)
		{
			TodoLogger.Log(0, "ShowPopupDiva");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70AE84 Offset: 0x70AE84 VA: 0x70AE84
		// // RVA: 0x115A62C Offset: 0x115A62C VA: 0x115A62C
		private IEnumerator ShowPopupMusic(eUnlockType unlockType, List<UnlockParam> param)
		{
			//0x115D138
			List<UnlockParam> paramList = param;
			bool isSingle = paramList.Count == 1;
			if(isSingle)
			{
				bool isLoading = true;
				this.StartCoroutineWatched(m_controller.LoadLayoutMusic(() =>
				{
					//0x115C628
					isLoading = false;
				}));
				while (isLoading)
					yield return null;
				m_controller.SetStatus(m_unlockInfo);
				bool isDirectionInWait = true;
				m_controller.MusicDirection.CallbackOpenEnd = () =>
				{
					//0x115C634
					isDirectionInWait = false;
				};
				m_controller.Show();
				while(isDirectionInWait)
					yield return null;
			}
			bool popupWait = true;
			PopupShowCommon(unlockType, param, null, () =>
			{
				//0x115C5A4
				if (!isSingle)
					return;
				m_controller.MusicDirection.Out();
			}, () =>
			{
				//0x115C610
				popupWait = false;
				return true;
			});
			if(isSingle)
			{
				//LAB_0115d5c4
				while (!m_controller.IsClosed)
					yield return null;
			}
			//LAB_0115d600
			while (popupWait)
				yield return null;
		}

		// // RVA: 0x115AA7C Offset: 0x115AA7C VA: 0x115AA7C
		private PopupSetting CreatePopupSetting(eUnlockType unlockTYpe, List<UnlockParam> param)
		{
			m_unlockInfo.paramList = param;
			PopupSetting res = null;
			switch (unlockTYpe)
			{
				case eUnlockType.Music:
					if (param.Count < 2)
					{
						PopupUnlockMusicContentSetting psetting = new PopupUnlockMusicContentSetting();
						res = psetting;
						res.TitleText = "";
						res.WindowSize = 0;
						res.Buttons = new ButtonInfo[1]
						{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
						};
						psetting.UnlockInfo = m_unlockInfo;
						psetting.closeAction = () =>
						{
							//0x115C22C
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ENIPGFLGJHH_LastStory = 0;
						};
					}
					else
					{
						PopupAddMusicMultiSetting psetting = new PopupAddMusicMultiSetting();
						res = psetting;
						res.TitleText = "";
						res.WindowSize = SizeType.Large;
						res.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
						};
						psetting.UnlockInfo = m_unlockInfo;
					}
					break;
				case eUnlockType.MultiDivaMusic:
					if (param.Count > 1)
					{
						PopupAddUnitDanceMusicMultiSetting mdmsetting = new PopupAddUnitDanceMusicMultiSetting();
						res = mdmsetting;
						res.TitleText = "";
						res.WindowSize = SizeType.Large;
						//LAB_0115b7b4
						res.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
						};
						mdmsetting.UnlockInfo = m_unlockInfo;
					}
					else
					{
						PopupAddMultiDivaMusicSetting mdmsetting = new PopupAddMultiDivaMusicSetting();
						res = mdmsetting;
						res.TitleText = "";
						res.WindowSize = SizeType.Small;
						res.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
						};
						mdmsetting.UnlockInfo = m_unlockInfo;
					}
					break;
				default:
					TodoLogger.Log(0, "CreatePopupSetting " + unlockTYpe);
					break;
			}
			res.IsCaption = false;
			return res;
		}

		// // RVA: 0x115BE00 Offset: 0x115BE00 VA: 0x115BE00
		// private ButtonInfo[] GetButtons(PopupUnlock.eSceneType sceneType) { }

		// // RVA: 0x115BFDC Offset: 0x115BFDC VA: 0x115BFDC
		private void PopupShowCommon(eUnlockType unlockType, List<UnlockParam> param, Action callback, Action openStartCallback, Func<bool> closeWaitCallback)
		{
			PopupWindowManager.Show(CreatePopupSetting(unlockType, param), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x115C640
				PressButtonLabel = (int)label;
				if (callback != null)
					callback();
			}, null, openStartCallback, null, true, true, false, closeWaitCallback);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.DownLoad
{
	public class LayoutDownLoad : MonoBehaviour
	{
		private static readonly int VOICE_COUNT = 3; // 0x0
		private Action m_OnClickOk; // 0xC
		private LayoutDownLoadMain m_LayoutDownLoadMain; // 0x10
		private LayoutDownLoadArrow m_LayoutDownLoadArrow; // 0x14
		private SwaipTouch m_SwaipTouch; // 0x18
		private List<int> m_DivaIdList; // 0x1C
		private List<LayoutDownLoadDefine.ViewDivaProfileData> m_DivaProfileList = new List<LayoutDownLoadDefine.ViewDivaProfileData>(); // 0x20
		private int m_ShowDivaCount; // 0x24
		private int m_SelectDiva; // 0x28
		private int m_PlayVoiceId; // 0x2C
		private bool m_IsChangeDiva; // 0x30
		private List<int> m_VoicePlayCounters = new List<int>(10); // 0x34

		// public Action OnClickOk { set; } 0x11BC6C8
		public SwaipTouch SwaipTouch { get
			{
				if (m_SwaipTouch != null)
					m_SwaipTouch = GetComponentInChildren<SwaipTouch>(true);
				return m_SwaipTouch;
			}
		} //0x11B9EC8

		// [IteratorStateMachineAttribute] // RVA: 0x6B5598 Offset: 0x6B5598 VA: 0x6B5598
		// // RVA: 0x11C1870 Offset: 0x11C1870 VA: 0x11C1870
		public static IEnumerator Co_LoadLayout(Transform parent, Action<LayoutDownLoad> onFinishLoad)
		{
			//0x11C4EB0
			GameObject obj = null;
			ResourcesManager.Instance.Load("Layout/sel_chara/UI_DownLoad", (FileResultObject fo) => {
				//0x11C4698
				obj = Instantiate(fo.unityObject) as GameObject;
				return true;
			});
			while(obj == null)
				yield return null;
			obj.transform.SetParent(parent, false);
			yield return null;
			LayoutDownLoad layout = obj.GetComponent<LayoutDownLoad>();
			yield return new WaitWhile(() => {
				//0x11C4774
				return !layout.IsReady();
			});
			onFinishLoad(layout);
		}

		// RVA: 0x11C1EF0 Offset: 0x11C1EF0 VA: 0x11C1EF0
		public void Awake()
		{
			for(int i = 0; i < 10; i++)
			{
				m_VoicePlayCounters.Add(0);
			}
			DownLoadDivaTextureCache.Create();
			SoundManager.Instance.voGreeting.EntrySheet();
		}

		// RVA: 0x11C1FF0 Offset: 0x11C1FF0 VA: 0x11C1FF0
		public void OnDestroy()
		{
			for(int i = 0; i < m_VoicePlayCounters.Count; i++)
			{
				if(m_VoicePlayCounters[i] > 0)
				{
					ILCCJNDFFOB.HHCJCDFCLOB.CMBKHLDBIEC_SendVoicePlayed(i + 1, MessageManager.Instance.GetMessage("master", "diva_s_"+(i + 1).ToString("D2")), m_VoicePlayCounters[i]);
				}
			}
			DownLoadDivaTextureCache.Release();
			SoundManager.Instance.voGreeting.RequestRemoveCueSheet();
		}

		// RVA: 0x11C22A4 Offset: 0x11C22A4 VA: 0x11C22A4
		public void Start()
		{
			m_LayoutDownLoadMain = GetComponentInChildren<LayoutDownLoadMain>(true);
			m_LayoutDownLoadArrow = GetComponentInChildren<LayoutDownLoadArrow>(true);
			m_SwaipTouch = GetComponentInChildren<SwaipTouch>(true);
			m_SwaipTouch.enabled = false;
		}

		// // RVA: 0x11C1918 Offset: 0x11C1918 VA: 0x11C1918
		public void SetupDownLoad(List<int> diva_list)
		{
			m_SwaipTouch.SetHitCheck(m_LayoutDownLoadMain.SwaipRect);
			m_DivaIdList = diva_list;
			m_ShowDivaCount = diva_list.Count;
			MessageBank bank = MessageManager.Instance.GetBank("common");
			for(int i = 0; i < m_DivaIdList.Count; i++)
			{
				string p = string.Format("profile_diva{0:000}", m_DivaIdList[i]);
				LayoutDownLoadDefine.ViewDivaProfileData data = new LayoutDownLoadDefine.ViewDivaProfileData();
				data.id = m_DivaIdList[i];
				data.age = bank.GetMessageByLabel(p + "_age");
				data.birthday = bank.GetMessageByLabel(p + "_birthday");
				data.birthplace = bank.GetMessageByLabel(p + "_birthplace");
				data.favorite = bank.GetMessageByLabel(p + "_favorite");
				data.description = bank.GetMessageByLabel(p + "_description");
				m_DivaProfileList.Add(data);
			}
			m_LayoutDownLoadMain.ChangeDiva(LayoutDownLoadDefine.DirectionType.None, m_DivaProfileList[LayoutDownLoadDefine.DEFAULT_DIVA], null);
			m_LayoutDownLoadArrow.OnClickArrow = OnClickArrow;
			m_LayoutDownLoadMain.OnClickVoice = OnClickVoice;
		}

		// // RVA: 0x11BC5A4 Offset: 0x11BC5A4 VA: 0x11BC5A4
		// public void SetupDivaSelect() { }

		// // RVA: 0x11B9AEC Offset: 0x11B9AEC VA: 0x11B9AEC
		public bool IsReady()
		{
			if(m_LayoutDownLoadMain.IsReady())
			{
				return m_LayoutDownLoadArrow.IsReady();
			}
			return false;
		}

		// // RVA: 0x11BB28C Offset: 0x11BB28C VA: 0x11BB28C
		// public bool IsPlaying() { }

		// // RVA: 0x11BF018 Offset: 0x11BF018 VA: 0x11BF018
		public bool IsFinishDownLoadAnim()
		{
			return m_LayoutDownLoadMain.IsFinishDownLoadAnim();
		}

		// // RVA: 0x11BF698 Offset: 0x11BF698 VA: 0x11BF698
		public void Visible()
		{
			m_LayoutDownLoadMain.Visible();
			m_LayoutDownLoadArrow.Visible();
		}

		// // RVA: 0x11BF6E0 Offset: 0x11BF6E0 VA: 0x11BF6E0
		public void EnterDownLoad()
		{
			m_LayoutDownLoadMain.EnterDownLoad();
		}

		// // RVA: 0x11C2F90 Offset: 0x11C2F90 VA: 0x11C2F90
		// public void LeaveDownLoad() { }

		// // RVA: 0x11C0F48 Offset: 0x11C0F48 VA: 0x11C0F48
		public void InVisible()
		{
			m_LayoutDownLoadMain.InVisible();
			m_LayoutDownLoadArrow.InVisible();
		}

		// // RVA: 0x11C318C Offset: 0x11C318C VA: 0x11C318C
		// public void HideDownLoad() { }

		// // RVA: 0x11BD4E8 Offset: 0x11BD4E8 VA: 0x11BD4E8
		// public void EnterDivaSelect() { }

		// // RVA: 0x11C32EC Offset: 0x11C32EC VA: 0x11C32EC
		// public void LeaveDivaSelect() { }

		// // RVA: 0x11BD510 Offset: 0x11BD510 VA: 0x11BD510
		public void EnterVoiceButton()
		{
			m_LayoutDownLoadMain.EnterVoiceButton();
		}

		// // RVA: 0x11C3470 Offset: 0x11C3470 VA: 0x11C3470
		// public void LeaveVoiceButton() { }

		// // RVA: 0x11BD538 Offset: 0x11BD538 VA: 0x11BD538
		// public void PlayStartVoice() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B5610 Offset: 0x6B5610 VA: 0x6B5610
		// // RVA: 0x11C3538 Offset: 0x11C3538 VA: 0x11C3538
		// private IEnumerator Co_PlayStartVoice() { }

		// // RVA: 0x11BA3B8 Offset: 0x11BA3B8 VA: 0x11BA3B8
		public void SetEnabledOperation(bool is_enable, bool is_change = false)
		{
			m_LayoutDownLoadMain.SetEnabledOperation(is_enable, is_change);
			m_LayoutDownLoadArrow.SetEnabledOperation(is_enable);
			m_SwaipTouch.enabled = is_enable;
		}

		// // RVA: g Offset: 0x11BEEA0 VA: 0x11BEEA0
		public void SetProgressPer(float per)
		{
			m_LayoutDownLoadMain.SetProgressPer(per);
		}

		// // RVA: 0x11BEED0 Offset: 0x11BEED0 VA: 0x11BEED0
		public void FinishDownLoad()
		{
			m_LayoutDownLoadMain.FinishDownLoad();
		}

		// // RVA: 0x11B9C54 Offset: 0x11B9C54 VA: 0x11B9C54
		public int GetSelectDivaId()
		{
			if(m_DivaIdList != null)
			{
				if(m_SelectDiva < m_DivaIdList.Count)
				{
					return m_DivaIdList[m_SelectDiva];
				}
			}
			return -1;
		}

		// RVA: 0x11C3A94 Offset: 0x11C3A94 VA: 0x11C3A94
		public void Update()
		{
			if(m_SwaipTouch != null)
			{
				if(!m_SwaipTouch.enabled || m_IsChangeDiva)
				{
					return;
				}
				if(m_SwaipTouch.IsSwaip(SwaipTouch.Direction.LEFT))
					OnChangeDiva(LayoutDownLoadDefine.DirectionType.Right);
				else if(m_SwaipTouch.IsSwaip(SwaipTouch.Direction.RIGHT))
					OnChangeDiva(LayoutDownLoadDefine.DirectionType.Left);
				if(m_SwaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
					OnChangeDiva(LayoutDownLoadDefine.DirectionType.Right);
				if(m_SwaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
					OnChangeDiva(LayoutDownLoadDefine.DirectionType.Left);
			}
		}

		// // RVA: 0x11C3CA0 Offset: 0x11C3CA0 VA: 0x11C3CA0
		// private void OnClickIcon(int index) { }

		// // RVA: 0x11C3E10 Offset: 0x11C3E10 VA: 0x11C3E10
		private void OnClickArrow(LayoutDownLoadDefine.DirectionType dir)
		{
			if(m_IsChangeDiva)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		// // RVA: 0x11C3C40 Offset: 0x11C3C40 VA: 0x11C3C40
		private void OnChangeDiva(LayoutDownLoadDefine.DirectionType dir)
		{
			int idx = m_SelectDiva;
			if(dir == LayoutDownLoadDefine.DirectionType.Right)
			{
				idx++;
				if(idx >= m_ShowDivaCount)
					idx = 0;
			}
			else if(dir == LayoutDownLoadDefine.DirectionType.Left)
			{
				idx--;
				if(idx < 0)
					idx = m_ShowDivaCount - 1;
			}
			this.StartCoroutineWatched(Co_ChangeDiva(dir, idx));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B5688 Offset: 0x6B5688 VA: 0x6B5688
		// // RVA: 0x11C3D50 Offset: 0x11C3D50 VA: 0x11C3D50
		private IEnumerator Co_ChangeDiva(LayoutDownLoadDefine.DirectionType dir, int index)
		{
			//0x11C4814
			m_IsChangeDiva = true;
			SetEnabledOperation(false, true);
			bool is_finish_anim = false;
			m_LayoutDownLoadMain.ChangeDiva(dir, m_DivaProfileList[index], () => {
				//0x11C47A8
				is_finish_anim = true;
			});
			m_LayoutDownLoadMain.SelectIcon(index);
			m_SelectDiva = index;
			m_PlayVoiceId = 0;
			yield return null;
			yield return new WaitWhile(() => {
				//0x11C47B4
				if(!m_LayoutDownLoadMain.IsPlaying())
					return !is_finish_anim;
				return true;
			});
			OnClickVoice();
			SetEnabledOperation(true, true);
			m_SwaipTouch.ResetValue();
			m_SwaipTouch.ResetInputState();
			yield return null;
			m_IsChangeDiva = false;
		}

		// // RVA: 0x11C3EA8 Offset: 0x11C3EA8 VA: 0x11C3EA8
		// private void OnClickOkCallback() { }

		// // RVA: 0x11C3F30 Offset: 0x11C3F30 VA: 0x11C3F30
		private void OnClickVoice()
		{
			int divaId = GetSelectDivaId();
			if(divaId != -1)
			{
				SoundManager.Instance.voGreeting.Play(divaId, m_PlayVoiceId);
				if(divaId > 0 && divaId <= m_VoicePlayCounters.Count)
				{
					m_VoicePlayCounters[divaId - 1]++;
				}
			}
			m_PlayVoiceId++;
			if(m_PlayVoiceId < VOICE_COUNT)
				return;
			m_PlayVoiceId -= VOICE_COUNT;
		}

		// // RVA: 0x11B9F80 Offset: 0x11B9F80 VA: 0x11B9F80
		// public void SetButtonEnable() { }

		// // RVA: 0x11BBB78 Offset: 0x11BBB78 VA: 0x11BBB78
		// public void SetButtonDisable() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B5700 Offset: 0x6B5700 VA: 0x6B5700
		// // RVA: 0x11C45E0 Offset: 0x11C45E0 VA: 0x11C45E0
		// private bool <Co_PlayStartVoice>b__35_0() { }
	}
}

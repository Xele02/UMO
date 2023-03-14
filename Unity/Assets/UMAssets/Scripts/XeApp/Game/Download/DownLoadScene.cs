using XeApp.Core;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.DownLoad
{
	public class DownLoadScene : MainSceneBase
	{
		[SerializeField]
		private GameObject m_questionaryPrefab; // 0x28
		private LayoutDownLoad m_Layout; // 0x2C
		private LayoutQuestionary m_questionary; // 0x30
		private MBLFHJJEHLH_AnketoMgr m_anketoMrg = new MBLFHJJEHLH_AnketoMgr(); // 0x34
		private bool m_IsFinish; // 0x38
		private bool m_IsDispDownLoadUI; // 0x39
		private bool m_IsExecuteQuestionary; // 0x3A
		private string m_NextSceneName = string.Empty; // 0x3C

		// RVA: 0x11BE484 Offset: 0x11BE484 VA: 0x11BE484 Slot: 9
		protected override void DoAwake()
		{
			enableFade = false;
			base.DoAwake();
		}

		// RVA: 0x11BE4AC Offset: 0x11BE4AC VA: 0x11BE4AC Slot: 10
		protected override void DoStart()
		{
			base.DoStart();
		}

		// RVA: 0x11BE4B4 Offset: 0x11BE4B4 VA: 0x11BE4B4 Slot: 12
		protected override bool DoUpdateEnter()
		{
			this.StartCoroutineWatched(Co_MainProc());
			return base.DoUpdateEnter();
		}

		// RVA: 0x11BE570 Offset: 0x11BE570 VA: 0x11BE570
		private void LoadResource()
		{
			List<int> l = new List<int>();
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas.Count; i++)
				{
					BJPLLEBHAGO_DivaInfo dbDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[i];
					if(dbDiva.PPEGAKEIEGM_Enabled == 2)
					{
						l.Add(dbDiva.AHHJLDLAPAN_DivaId);
					}
				}
			}
			DownLoadUIManager.Instance.LoadResouce(l);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B4FF0 Offset: 0x6B4FF0 VA: 0x6B4FF0
		// // RVA: 0x11BE4E4 Offset: 0x11BE4E4 VA: 0x11BE4E4
		private IEnumerator Co_MainProc()
		{
			//0x11BFC54 
			yield return this.StartCoroutineWatched(Co_InitializeQuestionary());
			KEHOJEJMGLJ.HHCJCDFCLOB.OEPPEGHGNNO = InstallGuiEvent;
			int tutoEnd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd;
			int INAEAAJIJMF = 0;
			int freeMusicId = 0;
			if (tutoEnd != 2)
			{
				for (int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					INAEAAJIJMF = 1;
					DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo serverDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i];
					if (serverDiva.CPGFPEDMDEH > 0)
					{
						BJPLLEBHAGO_DivaInfo dbdiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[serverDiva.DIPKCALNIII_DivaId - 1];
						freeMusicId = dbdiva.LIOGKHIGJKN_FreeMusicId;
						INAEAAJIJMF = 1;
						break;
					}
				}
			}
			List<string> str = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.IJCPBPFEGDM_GetEventsInstallFiles();
			if(str.Count > 0)
			{
				if(KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE == null)
				{
					KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE = str;
				}
				else
				{
					KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE.AddRange(str);
				}
			}
			if(freeMusicId != 0)
			{
				KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(freeMusicId);
				EONOEHOKBEB_Music minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
				if(fminfo.PPEGAKEIEGM_Enabled == 2)
				{
					List<string> path = SoundResource.CreateBgmFilePathList(minfo.KKPAHLMJKIH_WavId);
					if(KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE == null)
					{
						KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE = path;
					}
					else
					{
						KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE.AddRange(path);
					}
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.ACGKEJKPFIA((FreeCategoryId.Type)fminfo.DEPGBBJMFED_CategoryId, fminfo.GHBPLHBNMBK_FreeMusicId, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL);
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.NGNECOFAMKP((FreeCategoryId.Type)fminfo.DEPGBBJMFED_CategoryId);
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.ACGKEJKPFIA_SetSelectedSong(false, fminfo.GHBPLHBNMBK_FreeMusicId, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL);
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.GJDEHJBAMNH_SetSeries(MusicSelectConsts.SeriesType.All);
				}
			}
			HBCPJANGOLB h = new HBCPJANGOLB();
			h.OBKGEDCKHHE();
			List<string> str2 = HBCPJANGOLB.LMFHAGHJIEM_GetAssetsList(h);
			if(str2.Count > 0)
			{
				if (KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE == null)
				{
					KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE = str2;
				}
				else
				{
					KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE.AddRange(str2);
				}
				KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE.Add("dr/ep/cmn.xab");
				KEHOJEJMGLJ.HHCJCDFCLOB.FBGNDKKDOIE.Add("dr/ep/001.xab");
			}
			KEHOJEJMGLJ.HHCJCDFCLOB.PAHGEEOFEPM_Install(KEHOJEJMGLJ.ACGGHEIMPHC.GGCIMLDFDOC, FinishDownLoad, DownLoadError, INAEAAJIJMF);
			yield return null;
			while(!m_IsFinish && !m_IsDispDownLoadUI)
			{
				yield return null;
			}
			if(m_IsExecuteQuestionary)
			{
				if(!DownLoadUIManager.Instance.IsLoadLayout)
				{
					LoadResource();
				}
			}
			if(DownLoadUIManager.Instance.IsLoadLayout)
			{
				while (!DownLoadUIManager.Instance.IsLoadedLayout)
					yield return null;
				m_Layout = DownLoadUIManager.Instance.Layout;
				m_Layout.InVisible();
			}
			//LAB_011c0374
			if (!m_IsExecuteQuestionary)
			{
				;
			}
			else
			{
				m_questionary.transform.SetParent(DownLoadUIManager.Instance.UIRoot.transform, false);
				yield return this.StartCoroutineWatched(Co_QuestionayProc());
				//5
			}
			//LAB_011c044c
			if (!m_IsDispDownLoadUI || m_IsFinish)
			{
				;
			}
			else
			{
				yield return this.StartCoroutineWatched(Co_DownLoadProc());
				//6
			}
			//LAB_011c0484
			yield return this.StartCoroutineWatched(Co_InitializeUnionDataProc());
			//7
			GameManager.Instance.CreateViewPlayerData();
			NextScene("Menu");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B5068 Offset: 0x6B5068 VA: 0x6B5068
		// // RVA: 0x11BE7E4 Offset: 0x11BE7E4 VA: 0x11BE7E4
		private IEnumerator Co_InitializeQuestionary()
		{
			//0x11BF7A4
			m_IsExecuteQuestionary = m_anketoMrg.KHEKNNFCAOI(1, false);
			if (!m_IsExecuteQuestionary)
				yield break;
			m_questionary = Instantiate(m_questionaryPrefab).GetComponent<LayoutQuestionary>();
			m_questionary.LoadResource();
			while (m_questionary.IsLoading())
				yield return null;
			m_questionary.SetFinishDownLoad();
			m_questionary.PushOkHander += OnQuestionaryOk;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B50E0 Offset: 0x6B50E0 VA: 0x6B50E0
		// // RVA: 0x11BE890 Offset: 0x11BE890 VA: 0x11BE890
		private IEnumerator Co_QuestionayProc()
		{
			//0x11C102C
			m_Layout.SwaipTouch.enabled = false;
			yield return this.StartCoroutineWatched(m_questionary.Co_Proc(m_anketoMrg.KICOACCACII_QData, m_anketoMrg.MCJBEJBMJMF_TotalCount));
			m_questionary.gameObject.SetActive(false);
			m_Layout.SwaipTouch.enabled = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B5158 Offset: 0x6B5158 VA: 0x6B5158
		// // RVA: 0x11BE93C Offset: 0x11BE93C VA: 0x11BE93C
		private IEnumerator Co_DownLoadProc()
		{
			TodoLogger.Log(0, "Co_DownLoadProc");
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B51D0 Offset: 0x6B51D0 VA: 0x6B51D0
		// // RVA: 0x11BE9E8 Offset: 0x11BE9E8 VA: 0x11BE9E8
		private IEnumerator Co_InitializeUnionDataProc()
		{
			//0x11BFA78
			GameManager.Instance.InitializeUnionData();
			while(!GameManager.Instance.IsUnionDataInitialized)
			{
				yield return null;
			}
		}

		// // RVA: 0x11BEA7C Offset: 0x11BEA7C VA: 0x11BEA7C
		private void FinishDownLoad()
		{
			if(!m_IsFinish)
				m_IsFinish = true;
		}

		// // RVA: 0x11BEAA4 Offset: 0x11BEAA4 VA: 0x11BEAA4
		private void DownLoadError()
		{
			TodoLogger.Log(0, "DownloadScene.DownLoadError");
		}

		// // RVA: 0x11BEB0C Offset: 0x11BEB0C VA: 0x11BEB0C
		private void OnQuestionaryOk(LayoutQuestionaryButton[] buttons, int qIndex)
		{
			for (int i = 0; i < m_anketoMrg.KICOACCACII_QData[qIndex].LPKAJMLOAMF_ChoiceText.Length; i++)
			{
				m_anketoMrg.KICOACCACII_QData[qIndex].MHBBJADMHPN_ChoiceSelected[i] = buttons[i].IsOn();
			}
			m_anketoMrg.HGOHIJMEIHG_UpdateResult(m_anketoMrg.KICOACCACII_QData[qIndex]);
		}

		// // RVA: 0x11BEC9C Offset: 0x11BEC9C VA: 0x11BEC9C Slot: 13
		protected override void DoUpdateMain()
		{
			return;
		}

		// // RVA: 0x11BECA0 Offset: 0x11BECA0 VA: 0x11BECA0
		private bool InstallGuiEvent(int type, float per)
		{
			switch(type)
			{
				case 1:
					LoadResource();
					m_IsDispDownLoadUI = true;
					break;
				case 2:
					m_Layout.FinishDownLoad();
					if(m_questionary != null)
					{
						m_questionary.SetFinishDownLoad();
					}
					break;
				case 3:
					m_Layout.SetProgressPer(per);
					if(m_questionary != null)
					{
						m_questionary.SetProgressValue((int)per);
					}
					break;
				case 4:
					return m_Layout != null;
			}
			return false;
		}

		// // RVA: 0x11BEA90 Offset: 0x11BEA90 VA: 0x11BEA90
		// private void Downloaded() { }

		// // RVA: 0x11BEEF8 Offset: 0x11BEEF8 VA: 0x11BEEF8
		// private bool IsFinish() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B5248 Offset: 0x6B5248 VA: 0x6B5248
		// // RVA: 0x11BF104 Offset: 0x11BF104 VA: 0x11BF104
		// private bool <Co_DownLoadProc>b__15_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B5258 Offset: 0x6B5258 VA: 0x6B5258
		// // RVA: 0x11BF12C Offset: 0x11BF12C VA: 0x11BF12C
		// private bool <Co_DownLoadProc>b__15_2() { }
	}
}

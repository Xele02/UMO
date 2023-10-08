using CriWare;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Common
{
	public class SingleVoicePlayer : MonoBehaviour
	{
		private static Dictionary<string, int> s_cueSheetRefCntTable = new Dictionary<string, int>(); // 0x0
		private CriAtomExPlayback playback; // 0x10

		public CriAtomSource source { get; private set; } // 0xC
		public bool isPlaying { get { return playback.GetStatus() != CriAtomExPlayback.Status.Removed; } private set { return; } } //0x1394090 0x13940B8

		//// RVA: 0x1393C74 Offset: 0x1393C74 VA: 0x1393C74
		private static int AddCueSheetRefCnt(string cueSheetName)
		{
			if (s_cueSheetRefCntTable.ContainsKey(cueSheetName))
				s_cueSheetRefCntTable[cueSheetName]++;
			else
				s_cueSheetRefCntTable.Add(cueSheetName, 1);
			return s_cueSheetRefCntTable[cueSheetName];
		}

		//// RVA: 0x1393E74 Offset: 0x1393E74 VA: 0x1393E74
		private static int SubCueSheetRefCnt(string cueSheetName)
		{
			if(s_cueSheetRefCntTable.ContainsKey(cueSheetName))
			{
				s_cueSheetRefCntTable[cueSheetName]--;
				int v = s_cueSheetRefCntTable[cueSheetName];
				if (v < 1)
					s_cueSheetRefCntTable.Remove(cueSheetName);
				return v;
			}
			return 0;
		}

		// RVA: 0x13940BC Offset: 0x13940BC VA: 0x13940BC
		private void Awake()
		{
			source = gameObject.AddComponent<CriAtomSource>();
		}

		// RVA: 0x1394144 Offset: 0x1394144 VA: 0x1394144
		private void OnDestroy()
		{
			RemoveCueSheet();
		}

		//// RVA: 0x13943D4 Offset: 0x13943D4 VA: 0x13943D4
		public bool RequestChangeCueSheet(string cueSheetName, UnityAction onEndCallback)
		{
			if(source == null)
			{
				if (onEndCallback != null)
					onEndCallback();
				return false;
			}
			else
			{
				if(source.cueSheet == cueSheetName)
				{
					CriAtomCueSheet cueSheet = CriAtom.GetCueSheet(source.cueSheet);
					if(cueSheet != null)
					{
						if (onEndCallback != null)
							onEndCallback();
						return false;
					}
				}
				if(SoundResource.InstallCueSheet(cueSheetName))
				{
					this.StartCoroutineWatched(Co_InstallProcess(cueSheetName, onEndCallback));
					return true;
				}
				ChangeCueSheet(cueSheetName);
				if (onEndCallback != null)
					onEndCallback();
				return true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73ABD0 Offset: 0x73ABD0 VA: 0x73ABD0
		//// RVA: 0x13945A0 Offset: 0x13945A0 VA: 0x13945A0
		private IEnumerator Co_InstallProcess(string cueSheetName, UnityAction onEndCallback)
		{
			//0x1395404
			yield return new WaitWhile(() =>
			{
				//0x1395364
				return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
			});
			ChangeCueSheet(cueSheetName);
			if (onEndCallback != null)
				onEndCallback();
		}

		//// RVA: 0x1394660 Offset: 0x1394660 VA: 0x1394660
		protected void ChangeCueSheet(string cueSheetName)
		{
			if(source != null)
			{
				if(source.cueSheet == cueSheetName && CriAtom.GetCueSheet(cueSheetName) != null)
				{
					return;
				}
				RemoveCueSheet();
				source.cueSheet = cueSheetName;
				if(AddCueSheetRefCnt(source.cueSheet) < 2)
				{
					SoundResource.AddCueSheet(source.cueSheet);
					if(!string.IsNullOrEmpty(source.cueSheet))
					{
						if (CriAtom.GetAcb(source.cueSheet) != null)
							return;
					}
					RemoveCueSheet();
				}
			}
		}

		//// RVA: 0x1394148 Offset: 0x1394148 VA: 0x1394148
		public bool RemoveCueSheet()
		{
			if(source != null)
			{
				if(source.cueSheet != "")
				{
					string s = source.cueSheet;
					source.cueSheet = "";
					source.cueName = "";
					int cnt = SubCueSheetRefCnt(s);
					if(cnt < 1)
					{
						if(!SoundManager.Instance.IsUingCueSheetByVoicePlayer(s))
						{
							SoundResource.RemoveCueSheet(s);
						}
					}
					return true;
				}
			}
			return false;
		}

		//// RVA: 0x1394FC8 Offset: 0x1394FC8 VA: 0x1394FC8
		public bool Play(string cueName)
		{
			if (source != null)
			{
				playback = source.Play(cueName);
				return true;
			}
			return false;
		}

		//// RVA: 0x1395094 Offset: 0x1395094 VA: 0x1395094
		//public bool Play(int cueId) { }

		//// RVA: 0x1395160 Offset: 0x1395160 VA: 0x1395160
		public bool Stop()
		{
			return Stop(false);
		}

		//// RVA: 0x1395168 Offset: 0x1395168 VA: 0x1395168
		protected bool Stop(bool ignoresReleaseTime)
		{
			if(source != null)
			{
				source.player.Stop(ignoresReleaseTime);
				return true;
			}
			return false;
		}
	}
}

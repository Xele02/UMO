using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Events;
using XeSys.Gfx;

public class PrologueControl : LayoutUGUIScriptBase
{
	public UnityAction BgmChangeEventHandler; // 0x14
	private StringBuilder m_strBulder = new StringBuilder(64); // 0x18
	private AbsoluteLayout m_root; // 0x20
	private AbsoluteLayout[] m_prologueAnime; // 0x24
	private bool m_isBgmChanged; // 0x28
	private float BgmChangeTimeOffset = -3; // 0x2C
	private float m_bgmChangeTime; // 0x30
	private float m_time; // 0x34
	private bool m_isPlaying; // 0x38
	private List<float> m_animeChangeTime = new List<float>(); // 0x3C
	private int m_nextPlayAnimeIndex; // 0x40
	private const string PrologueStartLabelName = "go_act";
	private const string PrologueEndLabelName = "st_act";
	private static readonly string[] ExIDTbl = new string[3]
	{
		"sw_cmn_tuto02_sw_cmn_tuto02_01_anim",
		"sw_cmn_tuto02_sw_cmn_tuto02_02_anim",
		"sw_cmn_tuto02_sw_cmn_tuto02_03_anim"
	}; // 0x0

	public bool IsInitialized { get; private set; } // 0x1C

	// RVA: 0xDFBD70 Offset: 0xDFBD70 VA: 0xDFBD70 Slot: 5
	public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
	{
		ClearLoadedCallback();
		this.StartCoroutineWatched(LoadTextureCoroutine());
		m_root = layout.FindViewByExId("root_cmn_tuto02_sw_cmn_tuto02") as AbsoluteLayout;
		m_bgmChangeTime = m_root[0].FrameAnimation.SearchLabelFrame("bg_change") * m_root[0].FrameAnimation.FrameSec + BgmChangeTimeOffset;
		m_animeChangeTime.Add(0);
		m_animeChangeTime.Add(m_root[0].FrameAnimation.SearchLabelFrame("bg_change") * m_root[0].FrameAnimation.FrameSec);
		m_animeChangeTime.Add(m_root[0].FrameAnimation.SearchLabelFrame("go_act_03") * m_root[0].FrameAnimation.FrameSec);
		m_prologueAnime = new AbsoluteLayout[ExIDTbl.Length];
		for(int i = 0; i < ExIDTbl.Length; i++)
		{
			m_prologueAnime[i] = layout.FindViewByExId(ExIDTbl[i]) as AbsoluteLayout;
		}
		return true;
	}

	// RVA: 0xDFC424 Offset: 0xDFC424 VA: 0xDFC424
	private void OnDestroy()
	{
		return;
	}

	// RVA: 0xDFC428 Offset: 0xDFC428 VA: 0xDFC428
	private void Update()
	{
		if(m_isPlaying)
		{
			m_time = m_root[0].FrameAnimation.AnimCount;
			if(m_nextPlayAnimeIndex < m_animeChangeTime.Count)
			{
				if (m_animeChangeTime[m_nextPlayAnimeIndex] <= m_time)
					PlayNextPrologueAnime();
			}
		}
		if (m_root != null && !m_isBgmChanged && m_bgmChangeTime <= m_time && BgmChangeEventHandler != null)
		{
			BgmChangeEventHandler();
			m_isBgmChanged = true;
		}
	}

	//// RVA: 0xDFC708 Offset: 0xDFC708 VA: 0xDFC708
	//private bool IsChangeBgm() { }

	//[IteratorStateMachineAttribute] // RVA: 0x68FF70 Offset: 0x68FF70 VA: 0x68FF70
	//// RVA: 0xDFC398 Offset: 0xDFC398 VA: 0xDFC398
	private IEnumerator LoadTextureCoroutine()
	{
		//0xDFCAF4
		IsInitialized = true;
		yield break;
	}

	//// RVA: 0xDFC790 Offset: 0xDFC790 VA: 0xDFC790
	public void Play()
	{
		m_isPlaying = true;
		m_time = 0;
		m_root.StartAllAnimGoStop("st_wait_01", "st_act");
		PlayNextPrologueAnime();
	}

	//// RVA: 0xDFC5BC Offset: 0xDFC5BC VA: 0xDFC5BC
	private void PlayNextPrologueAnime()
	{
		if (m_prologueAnime.Length <= m_nextPlayAnimeIndex)
			return;
		m_prologueAnime[m_nextPlayAnimeIndex].StartChildrenAnimGoStop("go_act", "st_act");
		m_prologueAnime[m_nextPlayAnimeIndex].StartAllAnimDecoLoop();
		m_nextPlayAnimeIndex++;
	}

	//// RVA: 0xDFC834 Offset: 0xDFC834 VA: 0xDFC834
	public bool IsPlaying()
	{
		return m_root.IsPlayingChildren();
	}

	//// RVA: 0xDFC744 Offset: 0xDFC744 VA: 0xDFC744
	//private void OnBgmChange() { }
}

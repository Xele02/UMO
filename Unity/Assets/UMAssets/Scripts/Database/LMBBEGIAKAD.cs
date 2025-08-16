
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use LMBBEGIAKAD_EventQuest", true)]
public class LMBBEGIAKAD { }
public class LMBBEGIAKAD_EventQuest : DIHHCBACKGG_DbSection
{
	public class BILPFCFHJLE
	{
		public int OBGBAOLONDD_EventId; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public string HEDAGCNPHGD_RankingName; // 0x10
		public string OCGFKMHNEOF; // 0x14
		public string FEMMDNIELFC_MusicSelectDesc; // 0x18
		public long BONDDBOFBND_RankingStart; // 0x20
		public long HPNOGLIFJOP_RankingEnd; // 0x28
		public long EHHFFKAFOMC; // 0x30
		public long LNFKGHNHJKE_RankingEnd2; // 0x38
		public long JGMDAOACOJF_RewardStart; // 0x40
		public long IDDBFFBPNGI_RewardEnd; // 0x48
		public long KNLGKBBIBOH_RewardEnd2; // 0x50
		public int KHIKEGLBGAF; // 0x58
		public int DPJCFLKFEPN; // 0x5C
		public int MJBKGOJBPAD_TicketType; // 0x60
		public int JKFPADIAKCK; // 0x64
		public int EKJFNHHKBPL; // 0x68
		public sbyte POGEFBMBPCB; // 0x6C
		public sbyte AHKNMANFILO; // 0x6D
		public sbyte MOEKELIIDEO_SaveIdx; // 0x6E
		public sbyte HKKNEAGCIEB; // 0x6F
		public sbyte AHKPNPNOAMO; // 0x70
		public string OMCAOJJGOGG; // 0x74
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO = new NNJFKLBPBNK_SecureString(); // 0x78
		public List<int> JHPCPNJJHLI = new List<int>(); // 0x7C
		public List<int> EPHAKDAPAHE = new List<int>(); // 0x80
		public List<int> HIAMHLLHAON_PlayCostByDiff = new List<int>(); // 0x84
		public List<int> BKBEPOFJOJG = new List<int>(); // 0x88
		public int HIOOGLEJBKM_StartAdventureId; // 0x8C
		public int FJCADCDNPMP_EndAdventureId; // 0x90
		public int[] EJBGHLOOLBC_HelpIds; // 0x94
		public List<int> EEOGPJJCKHH_Drops = new List<int>(); // 0x98
		public List<int> HEABAENHIDE = new List<int>(); // 0x9C

		public string OCDMGOGMHGE { get { return EBGIDCIIGDO.DNJEJEANJGL_Value; } set { EBGIDCIIGDO.DNJEJEANJGL_Value = value; } } //0x10BB8BC HBAAAKFHDBB 0x10BA320 NHJLJOIPOFK

		//// RVA: 0x10B883C Offset: 0x10B883C VA: 0x10B883C
		public void LHPDDGIJKNB() 
		{
			OBGBAOLONDD_EventId = 0;
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			EHHFFKAFOMC = 0;
			KHIKEGLBGAF = 0;
			DPJCFLKFEPN = 0;
			MJBKGOJBPAD_TicketType = 1;
			POGEFBMBPCB = 0;
			AHKNMANFILO = 0;
			OPFGFINHFCE_Name = null;
			HEDAGCNPHGD_RankingName = null;
			OCGFKMHNEOF = null;
			FEMMDNIELFC_MusicSelectDesc = null;
			OCDMGOGMHGE = "";
			EPHAKDAPAHE.Clear();
			HEABAENHIDE.Clear();
			JHPCPNJJHLI.Clear();
			HIAMHLLHAON_PlayCostByDiff.Clear();
			OMCAOJJGOGG = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
			AHKPNPNOAMO = 0;
			JKFPADIAKCK = 0;
			EKJFNHHKBPL = 0;
			EEOGPJJCKHH_Drops.Clear();
		}

		//// RVA: 0x10BB49C Offset: 0x10BB49C VA: 0x10BB49C
		//public uint CAOGDCBPBAN() { }
	}

	public class HIIIHLEJEGI
	{
		public int PPFNGGCBJKC; // 0x8
		public int KFCIJBLDHOK; // 0xC
		public int JLEIHOEGMOP; // 0x10
	}

	public class PAPFNFFDMHG
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x10BBA20 DEMEPMAEJOO 0x10BBA30 HIGKAIDMOKN
		public int CNKFPJCGNFE_SceneId { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB; } } //0x10BBA40 GJBOGOFHGNP 0x10BBA50 GJDGIDCMJMH
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB; } } //0x10BBA60 NCIMMDJLPLJ 0x10BBA70 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB; } } //0x10BBA80 PKMNOMELPMN 0x10BBA90 IABBJBAHKCE

		//// RVA: 0x10BB794 Offset: 0x10BB794 VA: 0x10BB794
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10BA8E8 Offset: 0x10BA8E8 VA: 0x10BA8E8
		//public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HGHOHICGBEP JMHECKKKMLK) { }

		//// RVA: 0x10BBAA0 Offset: 0x10BBAA0 VA: 0x10BBAA0
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class OMHPMBCNAPC
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x10BB9B0 DEMEPMAEJOO 0x10BB9C0 HIGKAIDMOKN
		public int GNFBMCGMCFO_BonusBefore { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB; } } //0x10BB9D0 NCIMMDJLPLJ 0x10BB9E0 HNAJAFBHOLM
		public int BFFGFAMJAIG_BonusAfter { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB; } } //0x10BB9F0 PKMNOMELPMN 0x10BBA00 IABBJBAHKCE

		//// RVA: 0x10BB7C0 Offset: 0x10BB7C0 VA: 0x10BB7C0
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10BABB0 Offset: 0x10BABB0 VA: 0x10BABB0
		//public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HGHOHICGBEP JMHECKKKMLK) { }

		//// RVA: 0x10BBA10 Offset: 0x10BBA10 VA: 0x10BBA10
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class JGMJOONMPJN
	{
		public int FBGGEFFJJHB; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM_GachaIds = new List<int>(); // 0x14

		public int KHPHAAMGMJP_EpId { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB; } } //0x10BB8E8 ABFDDKBBPCH 0x10BB8F8 MHDOIIEMDEH
		public int OFIAENKCJME_BaseBonus { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB; } } //0x10BB908 KADLAKFANGA 0x10BB918 AIDAPNCEPOB

		//// RVA: 0x10BB7E4 Offset: 0x10BB7E4 VA: 0x10BB7E4
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x10BAEB8 Offset: 0x10BAEB8 VA: 0x10BAEB8
		//public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, HGHOHICGBEP JMHECKKKMLK) { }

		//// RVA: 0x10BB928 Offset: 0x10BB928 VA: 0x10BB928
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class FFJHPLIMOLK
	{
		public int GLCLFMGPMAN; // 0x8
		public int HMFFHLPNMPH; // 0xC
		public int NMKEOMCMIPP; // 0x10
	}

	public class LNGOGDOIJHI
	{
		public int PPFNGGCBJKC; // 0x8
		public int DNBFMLBNAEE_Point; // 0xC
		public List<FFJHPLIMOLK> AHJNPEAMCCH = new List<FFJHPLIMOLK>(); // 0x10
		public bool JOPPFEHKNFO; // 0x14

		//// RVA: 0x10BB64C Offset: 0x10BB64C VA: 0x10BB64C
		//public uint CAOGDCBPBAN() { }
	}

	public BILPFCFHJLE NGHKJOEDLIP_Settings = new BILPFCFHJLE(); // 0x20
	public List<LNGOGDOIJHI> FCIPEDFHFEM = new List<LNGOGDOIJHI>(); // 0x24 totalreward?
	public List<AKIIJBEJOEP> NNMPGOAGEOL_Missions = new List<AKIIJBEJOEP>(); // 0x28 // quests
	public List<PKADMPNDMGP> HKODBHPMLCP_Cards = new List<PKADMPNDMGP>(); // 0x2C cards
	public List<PAPFNFFDMHG> GEGAEDDGNMA_EpBonusByScene = new List<PAPFNFFDMHG>(); // 0x30
	public List<OMHPMBCNAPC> OGMHMAGDNAM_EpBonusBySceneRarity = new List<OMHPMBCNAPC>(); // 0x34
	public List<JGMJOONMPJN> LHAKGDAGEMM_EpBonusInfo = new List<JGMJOONMPJN>(); // 0x38
	public List<HIIIHLEJEGI> ADPFKHEMNBL = new List<HIIIHLEJEGI>(); // 0x44
	public List<AIGOEAPJGEB> MBHDIJJEOFL = new List<AIGOEAPJGEB>(); // 0x48

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x3C IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x40 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x10B7EB4 Offset: 0x10B7EB4 VA: 0x10B7EB4
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if(FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
			return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
		return KKMJBMKHGNH;
	}

	//// RVA: 0x10B7F98 Offset: 0x10B7F98 VA: 0x10B7F98
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
		return KKMJBMKHGNH;
	}

	//// RVA: 0x10B807C Offset: 0x10B807C VA: 0x10B807C
	public List<int> GEFEGEHCFNE(int AKNELONELJK)
	{
		List<int> res = new List<int>(HKODBHPMLCP_Cards.Count);
		for(int i = 0; i < HKODBHPMLCP_Cards.Count; i++)
		{
			if(HKODBHPMLCP_Cards[i].PPEGAKEIEGM_Enabled == 2)
			{
				if(HKODBHPMLCP_Cards[i].DGMIADAEGAI_TargetDifficultyType == AKNELONELJK + 1)
					res.Add(i);
			}
		}
		return res;
	}

	// RVA: 0x10B8264 Offset: 0x10B8264 VA: 0x10B8264
	public LMBBEGIAKAD_EventQuest()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 37;
	}

	// RVA: 0x10B8674 Offset: 0x10B8674 VA: 0x10B8674 Slot: 8
	protected override void KMBPACJNEOF()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB();
		FCIPEDFHFEM.Clear();
		HKODBHPMLCP_Cards.Clear();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
		ADPFKHEMNBL.Clear();
		GEGAEDDGNMA_EpBonusByScene.Clear();
		LHAKGDAGEMM_EpBonusInfo.Clear();
		OGMHMAGDNAM_EpBonusBySceneRarity.Clear();
	}

	// RVA: 0x10B89F0 Offset: 0x10B89F0 VA: 0x10B89F0 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		HGHOHICGBEP data = HGHOHICGBEP.HEGEKFMJNCC(DBBGALAPFGC);
		DGKKMKLCEDF(data);
		GPEKKMGGBPF(data);
		CFOFJPLEDEA(data);
		FBPNBANCLDA(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG;
			OHJFBLFELNK.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC, d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC, d);
		}
		for(int i = 0; i < data.KIEKMCKCMGD.Length; i++)
		{
			HIIIHLEJEGI d = new HIIIHLEJEGI();
			d.PPFNGGCBJKC = data.KIEKMCKCMGD[i].PPFNGGCBJKC;
			d.KFCIJBLDHOK = data.KIEKMCKCMGD[i].KFCIJBLDHOK;
			d.JLEIHOEGMOP = data.KIEKMCKCMGD[i].JLEIHOEGMOP;
			ADPFKHEMNBL.Add(d);
		}

		UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_Name+" "+NGHKJOEDLIP_Settings.OBGBAOLONDD_EventId);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			if (NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart += offset;
			if (NGHKJOEDLIP_Settings.EHHFFKAFOMC != 0) NGHKJOEDLIP_Settings.EHHFFKAFOMC += offset;
			if (NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd != 0) NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd += offset;
			if (NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 != 0) NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 += offset;
			if (NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart != 0) NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart += offset;
			if (NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd != 0) NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd += offset;
			if (NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 != 0) NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 += offset;

			for(int i = 0; i < NNMPGOAGEOL_Missions.Count; i++)
			{
				if (NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start != 0) NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End != 0) NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
		}
		return true;
	}

	// RVA: 0x10BA1C0 Offset: 0x10BA1C0 VA: 0x10BA1C0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "LMBBEGIAKAD_EventQuest.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x10B8E30 Offset: 0x10B8E30 VA: 0x10B8E30
	private bool DGKKMKLCEDF(HGHOHICGBEP HDNNNIPDHEB)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_EventId = (int)HDNNNIPDHEB.HMBHNLCFDIH.OBGBAOLONDD;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_Name = HDNNNIPDHEB.HMBHNLCFDIH.OPFGFINHFCE;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = HDNNNIPDHEB.HMBHNLCFDIH.HEDAGCNPHGD;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF = HDNNNIPDHEB.HMBHNLCFDIH.OCGFKMHNEOF;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = HDNNNIPDHEB.HMBHNLCFDIH.BONDDBOFBND;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = HDNNNIPDHEB.HMBHNLCFDIH.HPNOGLIFJOP;
		NGHKJOEDLIP_Settings.EHHFFKAFOMC = HDNNNIPDHEB.HMBHNLCFDIH.EHHFFKAFOMC;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = HDNNNIPDHEB.HMBHNLCFDIH.LNFKGHNHJKE;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = HDNNNIPDHEB.HMBHNLCFDIH.JGMDAOACOJF;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = HDNNNIPDHEB.HMBHNLCFDIH.IDDBFFBPNGI;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = HDNNNIPDHEB.HMBHNLCFDIH.KNLGKBBIBOH;
		NGHKJOEDLIP_Settings.KHIKEGLBGAF = (int)HDNNNIPDHEB.HMBHNLCFDIH.KHIKEGLBGAF;
		NGHKJOEDLIP_Settings.DPJCFLKFEPN = (int)HDNNNIPDHEB.HMBHNLCFDIH.DPJCFLKFEPN;
		NGHKJOEDLIP_Settings.POGEFBMBPCB = (sbyte)HDNNNIPDHEB.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO = (sbyte)HDNNNIPDHEB.HMBHNLCFDIH.AHKNMANFILO;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)HDNNNIPDHEB.HMBHNLCFDIH.MOEKELIIDEO;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE = HDNNNIPDHEB.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP_Settings.MJBKGOJBPAD_TicketType = HDNNNIPDHEB.HMBHNLCFDIH.MJBKGOJBPAD;
		NGHKJOEDLIP_Settings.FEMMDNIELFC_MusicSelectDesc = HDNNNIPDHEB.HMBHNLCFDIH.FEMMDNIELFC;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB = (sbyte)HDNNNIPDHEB.HMBHNLCFDIH.HKKNEAGCIEB;
		NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId = HDNNNIPDHEB.HMBHNLCFDIH.HIOOGLEJBKM;
		NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId = HDNNNIPDHEB.HMBHNLCFDIH.FJCADCDNPMP;
		NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds = HDNNNIPDHEB.HMBHNLCFDIH.EJBGHLOOLBC;
		NGHKJOEDLIP_Settings.AHKPNPNOAMO = (sbyte)HDNNNIPDHEB.HMBHNLCFDIH.AHKPNPNOAMO;
		NGHKJOEDLIP_Settings.JKFPADIAKCK = HDNNNIPDHEB.HMBHNLCFDIH.JKFPADIAKCK;
		NGHKJOEDLIP_Settings.OMCAOJJGOGG = HDNNNIPDHEB.HMBHNLCFDIH.OMCAOJJGOGG;
		NGHKJOEDLIP_Settings.EKJFNHHKBPL = HDNNNIPDHEB.HMBHNLCFDIH.EKJFNHHKBPL;
		for(int i = 0; i < HDNNNIPDHEB.HMBHNLCFDIH.JHPCPNJJHLI.Length; i++)
		{
			if(HDNNNIPDHEB.HMBHNLCFDIH.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI.Add(HDNNNIPDHEB.HMBHNLCFDIH.JHPCPNJJHLI[i]);
			}
		}
		for(int i = 0; i < HDNNNIPDHEB.HMBHNLCFDIH.EPHAKDAPAHE.Length; i++)
		{
			NGHKJOEDLIP_Settings.EPHAKDAPAHE.Add(HDNNNIPDHEB.HMBHNLCFDIH.EPHAKDAPAHE[i]);
		}
		for(int i = 0; i < HDNNNIPDHEB.HMBHNLCFDIH.HEABAENHIDE.Length; i++)
		{
			NGHKJOEDLIP_Settings.HEABAENHIDE.Add(HDNNNIPDHEB.HMBHNLCFDIH.HEABAENHIDE[i]);
		}
		for(int i = 0; i < HDNNNIPDHEB.HMBHNLCFDIH.HIAMHLLHAON.Length; i++)
		{
			NGHKJOEDLIP_Settings.HIAMHLLHAON_PlayCostByDiff.Add((int)HDNNNIPDHEB.HMBHNLCFDIH.HIAMHLLHAON[i]);
		}
		for(int i = 0; i < HDNNNIPDHEB.HMBHNLCFDIH.BKBEPOFJOJG.Length; i++)
		{
			NGHKJOEDLIP_Settings.BKBEPOFJOJG.Add((int)HDNNNIPDHEB.HMBHNLCFDIH.BKBEPOFJOJG[i]);
		}
		NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Clear();
		for(int i = 0; i < HDNNNIPDHEB.HMBHNLCFDIH.EEOGPJJCKHH.Length; i++)
		{
			NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops.Add((int)HDNNNIPDHEB.HMBHNLCFDIH.EEOGPJJCKHH[i]);
		}
		AIGOEAPJGEB.KHEKNNFCAOI(MBHDIJJEOFL, HDNNNIPDHEB);
		return true;
	}

	//// RVA: 0x10BA300 Offset: 0x10BA300 VA: 0x10BA300
	//private bool DGKKMKLCEDF(EDOHBJAPLPF IDLHJIOMJBK, int KAPMOPMDHJE) { }

	//// RVA: 0x10BA354 Offset: 0x10BA354 VA: 0x10BA354
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF OBHAFLMHAKG, string OPFGFINHFCE, ref bool NGJDHLGMHMH) { }

	//// RVA: 0x10BA534 Offset: 0x10BA534 VA: 0x10BA534
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM) { }

	//// RVA: 0x10B9AAC Offset: 0x10B9AAC VA: 0x10B9AAC
	private bool GPEKKMGGBPF(HGHOHICGBEP HDNNNIPDHEB)
	{
		for(int i = 0; i < HDNNNIPDHEB.MCHFABAKPMH.Length; i++)
		{
			LNGOGDOIJHI d = new LNGOGDOIJHI();
			d.PPFNGGCBJKC = (int)HDNNNIPDHEB.MCHFABAKPMH[i].PPFNGGCBJKC;
			d.DNBFMLBNAEE_Point = (int)HDNNNIPDHEB.MCHFABAKPMH[i].FOILNHKHHDF;
			d.JOPPFEHKNFO = HDNNNIPDHEB.MCHFABAKPMH[i].JOPPFEHKNFO != 0;
			for(int j = 0; j < HDNNNIPDHEB.MCHFABAKPMH[i].AIHOJKFNEEN.Length; j++)
			{
				FFJHPLIMOLK d2 = new FFJHPLIMOLK();
				d2.GLCLFMGPMAN = HDNNNIPDHEB.MCHFABAKPMH[i].AIHOJKFNEEN[j];
				d2.HMFFHLPNMPH = (int)HDNNNIPDHEB.MCHFABAKPMH[i].BFINGCJHOHI[j];
				d2.NMKEOMCMIPP = (int)HDNNNIPDHEB.MCHFABAKPMH[i].JJHPDDPKBHF[j];
				d.AHJNPEAMCCH.Add(d2);
			}
			FCIPEDFHFEM.Add(d);
		}
		return true;
	}

	//// RVA: 0x10BA308 Offset: 0x10BA308 VA: 0x10BA308
	//private bool GPEKKMGGBPF(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x10B9E88 Offset: 0x10B9E88 VA: 0x10B9E88
	private bool CFOFJPLEDEA(HGHOHICGBEP HDNNNIPDHEB)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < HDNNNIPDHEB.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP d = new AKIIJBEJOEP();
			d.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, i + 1, xor, HDNNNIPDHEB);
			NNMPGOAGEOL_Missions.Add(d);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0x10BA310 Offset: 0x10BA310 VA: 0x10BA310
	//private bool CFOFJPLEDEA(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x10BA020 Offset: 0x10BA020 VA: 0x10BA020
	private bool FBPNBANCLDA(HGHOHICGBEP HDNNNIPDHEB)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < HDNNNIPDHEB.DGPHHJCPNOO.Length; i++)
		{
			PKADMPNDMGP d = new PKADMPNDMGP();
			d.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, i + 1, xor, HDNNNIPDHEB);
			HKODBHPMLCP_Cards.Add(d);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0x10BA318 Offset: 0x10BA318 VA: 0x10BA318
	//private bool FBPNBANCLDA(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x10BA764 Offset: 0x10BA764 VA: 0x10BA764
	//private bool JBNBGGDDEGG(HGHOHICGBEP JMHECKKKMLK) { }

	//// RVA: 0x10BAA2C Offset: 0x10BAA2C VA: 0x10BAA2C
	//private bool ABICOINNGEK(HGHOHICGBEP JMHECKKKMLK) { }

	//// RVA: 0x10BACB4 Offset: 0x10BACB4 VA: 0x10BACB4
	//private bool EGLHCMDNFOE(HGHOHICGBEP JMHECKKKMLK) { }

	// RVA: 0x10BB08C Offset: 0x10BB08C VA: 0x10BB08C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "LMBBEGIAKAD_EventQuest.CAOGDCBPBAN");
		return 0;
	}
}

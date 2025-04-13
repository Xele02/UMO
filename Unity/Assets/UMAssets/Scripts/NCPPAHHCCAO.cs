
using System.Collections.Generic;
using XeSys;

public class NCPPAHHCCAO
{
	private int FBGGEFFJJHB; // 0x8
	private long BBEGLBMOBOF; // 0x10
	private int EHOIENNDEDH; // 0x18
	private int MKENMKMJFKP; // 0x1C
	private int HONLHOODCKN; // 0x20
	private int PDNDHGFKNOI; // 0x24
	private int EAJCFBCHIFB; // 0x28
	private int KAFDPIJEBPN; // 0x2C
	private int LAPHCBOBAJN; // 0x30
	private int IPAKEGGICML; // 0x34
	private int IFEHKNJONPL; // 0x38

	public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x1ADA0E0 DEMEPMAEJOO 0x1ADA0F0 HIGKAIDMOKN
	public int INDDJNMPONH { get { return MKENMKMJFKP ^ FBGGEFFJJHB; } set { MKENMKMJFKP = FBGGEFFJJHB ^ value; } } //0x1ADA100 GHAILOLPHPF 0x1ADA110 BACGOKIGMBC
	public int IDELKEKDIFD_CharaId { get { return HONLHOODCKN ^ FBGGEFFJJHB; } set { HONLHOODCKN = FBGGEFFJJHB ^ value; } } //0x1ADA120 HIMAGNHENDH 0x1ADA130 IOPEENMGODH
	public int BEHMEDMNJMC_EmotionId { get { return PDNDHGFKNOI ^ FBGGEFFJJHB; } set { PDNDHGFKNOI = FBGGEFFJJHB ^ value; } } //0x1ADA140 FFDHAICGIIF 0x1ADA150 IAIEKNACIJC
	public int EKLIPGELKCL { get { return EAJCFBCHIFB ^ FBGGEFFJJHB; } set { EAJCFBCHIFB = FBGGEFFJJHB ^ value; } } //0x1ADA160 OEEHBGECGKL 0x1ADA170 GHLMHLJJBIG
	public int EDEEMPJPFCP { get { return LAPHCBOBAJN ^ FBGGEFFJJHB; } set { LAPHCBOBAJN = FBGGEFFJJHB ^ value; } } //0x1ADA180 LNELAEPIDOL 0x1ADA190 FMPMDBENAGN
	public int HDHNEILDILJ_SnsCharaId { get { return KAFDPIJEBPN ^ FBGGEFFJJHB; } set { KAFDPIJEBPN = FBGGEFFJJHB ^ value; } } //0x1ADA1A0 MLECPDIKEPC 0x1ADA1B0 LBGPIFGNOMF
	public int CPKMLLNADLJ { get { return IPAKEGGICML ^ FBGGEFFJJHB; } set { IPAKEGGICML = FBGGEFFJJHB ^ value; } } //0x1ADA1C0 BJPJMGHCDNO 0x1ADA1D0 BPKIOJBKNBP
	public int BFINGCJHOHI_Cnt { get { return IFEHKNJONPL ^ FBGGEFFJJHB; } set { IFEHKNJONPL = FBGGEFFJJHB ^ value; } } //0x1ADA1E0 LFMCLIDAPHB 0x1ADA1F0 EDAEPDGGFJJ

	// RVA: 0x1ADA200 Offset: 0x1ADA200 VA: 0x1ADA200
	public NCPPAHHCCAO()
	{
		LHPDDGIJKNB();
	}

	//// RVA: 0x1ADA220 Offset: 0x1ADA220 VA: 0x1ADA220
	public void LHPDDGIJKNB()
	{
		FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
		EKLIPGELKCL = 0;
		HDHNEILDILJ_SnsCharaId = 0;
		EDEEMPJPFCP = 0;
		BFINGCJHOHI_Cnt = 0;
		BBEGLBMOBOF = FBGGEFFJJHB;
		PPFNGGCBJKC = 0;
		INDDJNMPONH = 0;
		IDELKEKDIFD_CharaId = 0;
		BEHMEDMNJMC_EmotionId = 0;
	}

	//// RVA: 0x1ADA2CC Offset: 0x1ADA2CC VA: 0x1ADA2CC
	//public static List<NCPPAHHCCAO> GNNPBHOOAIP() { }

	//// RVA: 0x1ADA6C0 Offset: 0x1ADA6C0 VA: 0x1ADA6C0
	public static List<NCPPAHHCCAO> FKDIMODKKJD()
	{
		List<NCPPAHHCCAO> l = new List<NCPPAHHCCAO>();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FJPOELGFPBP_DecoStamp.FHBIIONKIDI_Stamps.Count; i++)
			{
				IOEKHJBOMDH_DecoStamp.GFPPDCEPLCM saveStamp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FJPOELGFPBP_DecoStamp.FHBIIONKIDI_Stamps[i];
				if (saveStamp.PPFNGGCBJKC_Id > 0)
				{
					if(saveStamp.PPFNGGCBJKC_Id <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps.Count)
					{
						IHFIAFDLAAK_DecoStamp.MFHKPMPJGHC dbStamp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps[saveStamp.PPFNGGCBJKC_Id - 1];
						if(dbStamp.PLALNIIBLOF_Enabled == 2)
						{
							NCPPAHHCCAO stamp = new NCPPAHHCCAO();
							stamp.PPFNGGCBJKC = dbStamp.PPFNGGCBJKC;
							stamp.INDDJNMPONH = dbStamp.GBJFNGCDKPM;
							stamp.IDELKEKDIFD_CharaId = dbStamp.JBFLEDKDFCO_CharaId;
							stamp.BEHMEDMNJMC_EmotionId = dbStamp.ALAEHBKAEPB;
							stamp.EKLIPGELKCL = dbStamp.EKLIPGELKCL;
							stamp.EDEEMPJPFCP = dbStamp.NGILPOOLBCF;
							stamp.CPKMLLNADLJ = 0;
							stamp.HDHNEILDILJ_SnsCharaId = dbStamp.JINEKNIBOFI_SnsCharaId;
							if(stamp.IDELKEKDIFD_CharaId > 0)
							{
								if(stamp.IDELKEKDIFD_CharaId <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters.Count)
								{
									BOKMNHAFJHF_Sns.JFMDDEBLCAA_CharaInfo snsChara = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[stamp.IDELKEKDIFD_CharaId - 1];
									if(snsChara.PPEGAKEIEGM_Enabled == 2)
									{
										stamp.CPKMLLNADLJ = snsChara.CPKMLLNADLJ_Serie;
									}
								}
							}
							stamp.BFINGCJHOHI_Cnt = saveStamp.BFINGCJHOHI_Cnt;
							l.Add(stamp);
						}
					}
				}
			}
		}
		return l;
	}

	//// RVA: 0x1ADACF8 Offset: 0x1ADACF8 VA: 0x1ADACF8
	public static string GHHOBKGGADG(int PPFNGGCBJKC)
	{
		return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(string.Format("dc_itm_nm_{0:D4}_srf", PPFNGGCBJKC));
	}

	//// RVA: 0x1ADAE28 Offset: 0x1ADAE28 VA: 0x1ADAE28
	public static string EFNHFKLKNHJ(int PPFNGGCBJKC)
	{
		//string str = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.EFEGBHACJAL("desc_string_hanyo", JpStringLiterals.StringLiteral_12526);
		// UMO : desc_string_hanyo is the same as StringLiteral_12526, so use that to have the translation string.
		string str = JpStringLiterals.StringLiteral_12526;
		if(PPFNGGCBJKC > 0)
		{
			if(PPFNGGCBJKC <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Count)
			{
				IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP serif = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[PPFNGGCBJKC - 1];
				if(serif.JBFLEDKDFCO > 0)
				{
					if(serif.JBFLEDKDFCO <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters.Count)
					{
						BOKMNHAFJHF_Sns.JFMDDEBLCAA_CharaInfo sns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[serif.JBFLEDKDFCO - 1];
						//return sns.OPFGFINHFCE_Name + IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.EFEGBHACJAL("desc_string_senyo", JpStringLiterals.StringLiteral_12528);
						// UMO : desc_string_senyo is the same as StringLiteral_12528, so use that to have the translation string.
						return sns.OPFGFINHFCE_Name + JpStringLiterals.StringLiteral_12528;
					}
				}
			}
		}
		return str;
	}

	//// RVA: 0x1ADB18C Offset: 0x1ADB18C VA: 0x1ADB18C
	public static List<int> MGHDHIJIGLD()
	{
		List<int> res = new List<int>();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			res.AddRange(OCHICNLNALL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara, "initial_give_stamp"));
			res.AddRange(OCHICNLNALL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, "initial_give_serif"));
		}
		return res;
	}

	//// RVA: 0x1ADB36C Offset: 0x1ADB36C VA: 0x1ADB36C
	private static List<int> OCHICNLNALL(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, string LJNAKDMILMC)
	{
		List<int> res = new List<int>();
		string str = LKMHPJKIFDN.GAPONCJOKAC_DecoStamp.EFEGBHACJAL(LJNAKDMILMC, "");
		string[] strs = str.Split(new char[] { ',' });
		for(int i = 0; i < strs.Length; i++)
		{
			int v = 0;
			if(int.TryParse(strs[i], out v) && v > 0)
			{
				if(EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN, LDEGEHAEALK, INDDJNMPONH, v, null) == 0)
				{
					EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(LKMHPJKIFDN, LDEGEHAEALK, INDDJNMPONH, v, 1, null);
					res.Add(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(INDDJNMPONH, v));
				}
			}
		}
		return res;
	}
}

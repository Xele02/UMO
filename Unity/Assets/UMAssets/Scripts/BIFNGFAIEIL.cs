
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XeApp.Game.Common;

public class BIFNGFAIEIL
{
	public static int AEGKCNDEHDO; // 0x4
	private PJKPGLKHGIP BNEGNOBCHGP = new PJKPGLKHGIP(); // 0x8
	private string ELLBAAFKDCH_FilePath; // 0xC
	private string BOFPFGNHBAJ_SavePath; // 0x10
	private int MLJGJMGNNPP; // 0x14

	public static BIFNGFAIEIL HHCJCDFCLOB { get; private set; } // 0x0 NKACBOEHELJ OKPMHKNCNAL

	//// RVA: 0xC7FF90 Offset: 0xC7FF90 VA: 0xC7FF90
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		CIOECGOMILE.HHCJCDFCLOB.BJCPJPLPDIH.Add(LEPNMDBJAIE);
		CIOECGOMILE.HHCJCDFCLOB.BFHJLPDOEPB.Add(KGMNAMKNADC);
		BOFPFGNHBAJ_SavePath = Application.persistentDataPath + "/SaveData";
		if (!Directory.Exists(BOFPFGNHBAJ_SavePath))
			Directory.CreateDirectory(BOFPFGNHBAJ_SavePath);
		ELLBAAFKDCH_FilePath = BOFPFGNHBAJ_SavePath + "/snscache.bin";
	}

	//// RVA: 0xC801A4 Offset: 0xC801A4 VA: 0xC801A4
	public static void BLICHJOLKAO_DeleteCache()
	{
		string path = Application.persistentDataPath + "/SaveData" + "/snscache.bin";
		if (File.Exists(path))
			File.Delete(path);
	}

	//// RVA: 0xC802E0 Offset: 0xC802E0 VA: 0xC802E0
	public void DNKCCHCEPBH(bool GFPBKOPKNCB = false)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				if(Database.Instance.roomText != null)
				{
                    OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
                    BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
					List<BOKMNHAFJHF_Sns.KEIGMAOCJHK> dbSns = db.OMGFKMANMAB_Sns.CDENCMNHNGA;
					//EOHDAOAJOHH.HHCJCDFCLOB
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					int i78 = 0;
					for(int i = 0; i < 2000; i++)
					{
						BOKMNHAFJHF_Sns.KEIGMAOCJHK snsData = dbSns[i];
						if(snsData.PPEGAKEIEGM_Enabled == 2)
						{
							DDEMMEPBOIA_Sns.EFIFBJGKPJF snsSave = serverSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[i];
							if(snsSave.BEBJKJKBOGH_Date == 0 && snsData.AJIDLAGFPGM_TalkId != 0)
							{
								SNSRoomTextData.Header header = Database.Instance.roomText.textData.FindHeader(snsData.AJIDLAGFPGM_TalkId);
								if(header != null)
								{
									if(HLMJIADBPIJ.IBHJAMDGGMC((NJLGICBHIOC.EOFJDIACFEC)snsData.JKNGNIMLDDJ, snsData.DPIBHFNDJII, snsData.EKPBOLNFGJB, serverSave, db, time))
									{
										long i6468 = time + i78;
										long l3 = time + i78;
										if(snsData.MALFHCHNEFN_RoomId == 0)
										{
											if(snsData.JKNGNIMLDDJ == 10)
											{
												if(time >= snsData.DPIBHFNDJII)
													i6468 = snsData.DPIBHFNDJII;
												l3 = i6468;
											}
											else if(snsData.JKNGNIMLDDJ == 12)
											{
												if(time >= JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.IALIHKHGMFJ((int)snsData.DPIBHFNDJII))
												{
													l3 = snsData.DPIBHFNDJII;
												}
											}
											else if(snsData.JKNGNIMLDDJ == 13)
											{
												l3 = time + snsData.DPIBHFNDJII * 86400;
											}
											else
											{
												l3 = time + i78;
											}
											if(header.startIndex <= header.endIndex)
											{
												bool b = false;
												int u9 = (int)(l3 + i78);
												for(int j = 0; header.startIndex + j < header.endIndex; j++)
												{
													if(!b)
													{
														ILCCJNDFFOB.HHCJCDFCLOB.JOLBIMMKGIP(snsData.MALFHCHNEFN_RoomId, snsData.AIPLIEMLHGC, snsData.AJIDLAGFPGM_TalkId, 0);
														SNSRoomTextData.TalkData tData = Database.Instance.roomText.textData.FindData(j + header.startIndex);
														BOKMNHAFJHF_Sns.JFMDDEBLCAA charaInfo = db.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[tData.charaId - 1];
														string msg = Database.Instance.roomText.textData.FindMessage(tData.messageIndex);
														EOHDAOAJOHH.HHCJCDFCLOB.HKMEADILMGB(u9 + tData.timeOffset, snsData.AJIDLAGFPGM_TalkId * 100 + j, msg, charaInfo.EAHPLCJMPHD);
													}
													b = true;
												}
											}
										}
										else
										{
											bool c = false;
											if(snsData.JKNGNIMLDDJ == 10)
											{
												if(time >= snsData.DPIBHFNDJII)
												{
													i6468 = snsData.DPIBHFNDJII;
													c = true;
												}
											}
											else if(snsData.JKNGNIMLDDJ == 12)
											{
												if(time >= JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.IALIHKHGMFJ((int)snsData.DPIBHFNDJII))
												{
													i6468 = snsData.DPIBHFNDJII;
												}
											}
											else
											{
												;
											}
											if(header.startIndex <= header.endIndex)
											{
												bool b = false;
												for(int j = 0; header.startIndex + j < header.endIndex; j++)
												{
													if(!b)
													{
														ILCCJNDFFOB.HHCJCDFCLOB.JOLBIMMKGIP(snsData.MALFHCHNEFN_RoomId, snsData.AIPLIEMLHGC, snsData.AJIDLAGFPGM_TalkId, 0);
														SNSRoomTextData.TalkData tData = Database.Instance.roomText.textData.FindData(j + header.startIndex);
														BOKMNHAFJHF_Sns.JFMDDEBLCAA charaInfo = db.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[tData.charaId - 1];
														string msg = charaInfo.OPFGFINHFCE_Name + JpStringLiterals.StringLiteral_9630;
														if(c)
														{
															EOHDAOAJOHH.HHCJCDFCLOB.HKMEADILMGB(i6468 + tData.timeOffset, snsData.AJIDLAGFPGM_TalkId * 100 + j, msg, charaInfo.EAHPLCJMPHD);
														}
													}
													b = true;
												}
											}
											i78 += MLJGJMGNNPP;
											snsSave.BEBJKJKBOGH_Date = i6468;
										}
									}
								}
							}
						}
					}
                }
			}
		}
	}

	//// RVA: 0xC80F4C Offset: 0xC80F4C VA: 0xC80F4C
	//public JNNDPBFDEAM.PBOLAGAGMMD MMCALIAHFNI(long JHNMKKNEENE, int AJIDLAGFPGM, bool FBBNPFFEJBN) { }

	//// RVA: 0xC80F54 Offset: 0xC80F54 VA: 0xC80F54
	public void LEPNMDBJAIE(List<string> OHNJJIMGKGK)
	{
		string str = OHNJJIMGKGK.Find((string GHPLINIACBB) =>
		{
			//0xC82EB0
			return GHPLINIACBB == "sns";
		});
		if (str == null)
			return;
		BNEGNOBCHGP.JCHLONCMPAJ(ELLBAAFKDCH_FilePath);
	}

	//// RVA: 0xC810DC Offset: 0xC810DC VA: 0xC810DC
	public void KGMNAMKNADC()
	{
		BNEGNOBCHGP.ADOIBPKFJKB();
	}

	//// RVA: 0xC81108 Offset: 0xC81108 VA: 0xC81108
	public bool FMHMCMIAOAC()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns != null)
		{
			if(Database.Instance.roomText.textData != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG.Count > 0)
				{
					for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA.Count; i++)
					{
                        BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
						if(dbSns.PPEGAKEIEGM_Enabled == 2)
						{
                            DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[i];
							if(saveSns.BEBJKJKBOGH_Date != 0)
							{
								if(time >= saveSns.BEBJKJKBOGH_Date)
								{
                                    SNSRoomTextData.Header header = Database.Instance.roomText.textData.FindHeader(dbSns.AJIDLAGFPGM_TalkId);
									if(header != null)
									{
										if(header.count > saveSns.LDJIMGPHFPA_Cnt)
											return true;
									}
                                }
							}
                        }
                    }
				}
			}
		}
		return false;
	}

	//// RVA: 0xC81550 Offset: 0xC81550 VA: 0xC81550
	public void DLKJAPDLDFG(bool HEDFNFLEPHI, int NIGMABNOBEF = 0)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				if(Database.Instance.roomText != null)
				{
					long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					for(int i = 0; i < 2000; i++)
					{
						BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
						if(dbSns.PPEGAKEIEGM_Enabled == 2)
						{
							DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[i];
							if(dbSns.JKNGNIMLDDJ == 14)
							{
								if(dbSns.DPIBHFNDJII == NIGMABNOBEF)
								{
									SNSRoomTextData.Header h = Database.Instance.roomText.textData.FindHeader(dbSns.AJIDLAGFPGM_TalkId);
									if(h != null)
									{
										saveSns.BEBJKJKBOGH_Date = t;
										if(!HEDFNFLEPHI)
										{
											saveSns.LDJIMGPHFPA_Cnt = 0;
										}
										else
										{
											saveSns.LDJIMGPHFPA_Cnt = (short)h.count;
										}
										return;
									}
								}
							}
						}
					}
				}
			}
		}
	}

	//// RVA: 0xC819F4 Offset: 0xC819F4 VA: 0xC819F4
	public int OKBOEKMCBJM(long EOLFJGMAJAB = 0)
	{
		int res = 0;
		if(EOLFJGMAJAB == 0)
		{
			EOLFJGMAJAB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}
		for(int i = 0; i < 2000; i++)
		{
			BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
			if(dbSns.PPEGAKEIEGM_Enabled == 2)
			{
				DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[i];
				if(saveSns.BEBJKJKBOGH_Date != 0)
				{
					if(EOLFJGMAJAB >= saveSns.BEBJKJKBOGH_Date)
						res++;
				}
			}
		}
		return res;
	}

	//// RVA: 0xC81D10 Offset: 0xC81D10 VA: 0xC81D10
	public bool DNFPMBFNDCA()
	{
		if(PGIGNJDPCAH.AIMFCMCMOIH() == PGIGNJDPCAH.IMOIPBMGIPN.HJNNKCMLGFL/*0*/)
		{
			return JFLJKDIDGFO() < OKBOEKMCBJM(0);
		}
		return false;
	}

	//// RVA: 0xC81F44 Offset: 0xC81F44 VA: 0xC81F44
	public int FGGDEKAJCIF()
	{
		if(PGIGNJDPCAH.AIMFCMCMOIH() == 0)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(JFLJKDIDGFO() != OKBOEKMCBJM(time))
				return BLILIEEPLAD(time);
		}
		return 0;
	}

	//// RVA: 0xC820A8 Offset: 0xC820A8 VA: 0xC820A8
	private int BLILIEEPLAD(long EOLFJGMAJAB)
	{
        List<DDEMMEPBOIA_Sns.EFIFBJGKPJF> saveSnsList = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG;
        List<BOKMNHAFJHF_Sns.KEIGMAOCJHK> dbSnsList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA;
		int found = -1;
		for(int i = 0; i < 2000; i++)
		{
			if(dbSnsList[i].PPEGAKEIEGM_Enabled == 2)
			{
				if(saveSnsList[i].BEBJKJKBOGH_Date != 0)
				{
					if(EOLFJGMAJAB >= saveSnsList[i].BEBJKJKBOGH_Date)
					{
						if(found == -1 || saveSnsList[found].BEBJKJKBOGH_Date >= saveSnsList[i].BEBJKJKBOGH_Date)
							found = i;
					}
				}
			}
		}
		if(found > -1)
			return found + 1;
		return 0;
	}

	//// RVA: 0xC823C4 Offset: 0xC823C4 VA: 0xC823C4
	public void ALIANOFCAEI()
	{
		OILGDFPFIJP(OKBOEKMCBJM());
	}

	//// RVA: 0xC81DD0 Offset: 0xC81DD0 VA: 0xC81DD0
	public int JFLJKDIDGFO()
	{
		int res = 0;
		if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			res = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JLJJHDGEHLK_RecvSns;
		}
		if(res < BNEGNOBCHGP.PAAFIOOKJIP_ReceivedSns)
		{
			res = BNEGNOBCHGP.PAAFIOOKJIP_ReceivedSns;
		}
		return res;
	}

	//// RVA: 0xC823F4 Offset: 0xC823F4 VA: 0xC823F4
	public void OILGDFPFIJP(int HMFFHLPNMPH)
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JLJJHDGEHLK_RecvSns = HMFFHLPNMPH;
		BNEGNOBCHGP.PAAFIOOKJIP_ReceivedSns = HMFFHLPNMPH;
		BNEGNOBCHGP.HJMKBCFJOOH(ELLBAAFKDCH_FilePath);
	}

	//// RVA: 0xC82510 Offset: 0xC82510 VA: 0xC82510
	public int CEDPKMOHANM(int MALFHCHNEFN)
	{
		if(Database.Instance.roomText == null)
			return 0;
		int res = 0;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA.Count; i++)
		{
			BOKMNHAFJHF_Sns.KEIGMAOCJHK dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
			if(dbItem.PPEGAKEIEGM_Enabled == 2 && dbItem.MALFHCHNEFN_RoomId == MALFHCHNEFN)
			{
				DDEMMEPBOIA_Sns.EFIFBJGKPJF saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[i];
				if(saveItem.BEBJKJKBOGH_Date != 0)
				{
					if(time >= saveItem.BEBJKJKBOGH_Date && dbItem.AJIDLAGFPGM_TalkId != 0)
					{
						if(dbItem.JKNGNIMLDDJ == 15)
						{
							if (saveItem.PMKJFKJFDOC_Itm == 0)
								continue;
						}
						SNSRoomTextData.Header h = Database.Instance.roomText.textData.FindHeader(dbItem.AJIDLAGFPGM_TalkId);
						if(h != null)
						{
							if (h.count == saveItem.LDJIMGPHFPA_Cnt)
								res++;
						}
					}
				}
			}
		}
		return res;
	}

	//// RVA: 0xC82974 Offset: 0xC82974 VA: 0xC82974
	public bool EEGOJOFABAF(int MALFHCHNEFN, int AJIDLAGFPGM)
	{
		if(Database.Instance.roomText != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA.Count; i++)
			{
				BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
				if(dbSns.PPEGAKEIEGM_Enabled == 2 && dbSns.MALFHCHNEFN_RoomId == MALFHCHNEFN && dbSns.AJIDLAGFPGM_TalkId == AJIDLAGFPGM && AJIDLAGFPGM != 0)
				{
					DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[i];
					if(saveSns.BEBJKJKBOGH_Date != 0)
					{
						if(time >= saveSns.BEBJKJKBOGH_Date)
						{
							SNSRoomTextData.Header h = Database.Instance.roomText.textData.FindHeader(dbSns.AJIDLAGFPGM_TalkId);
							if(h != null)
							{
								if (h.count == saveSns.LDJIMGPHFPA_Cnt)
									return true;
							}
						}
					}
				}
			}
		}
		return false;
	}
}

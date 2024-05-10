
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public class FDDIIKBJNNA
{
	public List<GAKAAIHLFKI> NPKPBDIDBBG_RoomData = new List<GAKAAIHLFKI>(); // 0x8
	public List<FHFEHOBCIIP> KHCACDIKJLG = new List<FHFEHOBCIIP>(); // 0xC

	// // RVA: 0xFC8280 Offset: 0xFC8280 VA: 0xFC8280
	public void KHEKNNFCAOI(bool DENGEJFHAFA, bool IAHLNPMFJMH = false, int BBDLLIEOLCB = -1)
	{
		//IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		JALKJCLEPJN();
		NNIIGAECOHO();
		OPBFFEMJBFH(time, DENGEJFHAFA, IAHLNPMFJMH, BBDLLIEOLCB);
	}

	// // RVA: 0xFCA83C Offset: 0xFCA83C VA: 0xFCA83C
	public void KHEKNNFCAOI(int AIPLIEMLHGC)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		HNEJELAAION(time, AIPLIEMLHGC);
	}

	// // RVA: 0xFCAFC8 Offset: 0xFCAFC8 VA: 0xFCAFC8
	// public void JCHLONCMPAJ() { }

	// // RVA: 0xFC8418 Offset: 0xFC8418 VA: 0xFC8418
	public void JALKJCLEPJN()
	{
		BOKMNHAFJHF_Sns snsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns;
		KHCACDIKJLG.Clear();
		for(int i = 0; i < snsDb.KHCACDIKJLG_Characters.Count; i++)
		{
			if(snsDb.KHCACDIKJLG_Characters[i].PPEGAKEIEGM_Enabled == 2)
			{
				FHFEHOBCIIP data = new FHFEHOBCIIP();
				data.IDELKEKDIFD_CharaId = snsDb.KHCACDIKJLG_Characters[i].IDELKEKDIFD;
				data.EAHPLCJMPHD = snsDb.KHCACDIKJLG_Characters[i].EAHPLCJMPHD;
				data.OPFGFINHFCE_Name = snsDb.KHCACDIKJLG_Characters[i].OPFGFINHFCE_Name;
				data.HAPAFECPFEK_AtName = snsDb.KHCACDIKJLG_Characters[i].HAPAFECPFEK_AtName;
				KHCACDIKJLG.Add(data);
			}
		}
	}

	// // RVA: 0xFC86B8 Offset: 0xFC86B8 VA: 0xFC86B8
	public void NNIIGAECOHO()
	{
		BOKMNHAFJHF_Sns snsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns;
		NPKPBDIDBBG_RoomData.Clear();
		for(int i = 0; i < snsDb.NPKPBDIDBBG_Room.Count; i++)
		{
			if(snsDb.NPKPBDIDBBG_Room[i].PPEGAKEIEGM_Enabled == 2 && snsDb.NPKPBDIDBBG_Room[i].MALFHCHNEFN_Room > 0)
			{
				GAKAAIHLFKI data = new GAKAAIHLFKI();
				data.MALFHCHNEFN_Id = snsDb.NPKPBDIDBBG_Room[i].MALFHCHNEFN_Room;
				data.JBOECJOONLP = 0;
				data.OPFGFINHFCE_Name = snsDb.NPKPBDIDBBG_Room[i].OPFGFINHFCE_Name;
				data.IJEKNCDIIAE = 0;
				data.IHCEJBAEEDO = snsDb.NPKPBDIDBBG_Room[i].PKOKDPHHLCG;
				NPKPBDIDBBG_RoomData.Add(data);
			}
		}
	}

	// // RVA: 0xFCA93C Offset: 0xFCA93C VA: 0xFCA93C
	public void HNEJELAAION(long JHNMKKNEENE, int AIPLIEMLHGC)
	{
		JALKJCLEPJN();
		NPKPBDIDBBG_RoomData.Clear();
		MessageBank bk = MessageManager.Instance.GetBank("master");
		BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[AIPLIEMLHGC - 1];
		BOKMNHAFJHF_Sns.LEBAGJNJJNG_Room dbRoom = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.NPKPBDIDBBG_Room[dbSns.MALFHCHNEFN_RoomId - 1];
		GAKAAIHLFKI g = new GAKAAIHLFKI();
		g.MALFHCHNEFN_Id = dbRoom.MALFHCHNEFN_Room;
		g.OPFGFINHFCE_Name = dbRoom.OPFGFINHFCE_Name;
		g.JBOECJOONLP = 0;
		g.IHCEJBAEEDO = dbRoom.PKOKDPHHLCG;
		g.IJEKNCDIIAE = 0;
		g.ILDLJMCIKAK = 0;
		g.AIPLIEMLHGC = 0;
		NPKPBDIDBBG_RoomData.Add(g);
		SNSRoomTextData data = Database.Instance.roomText.textData;
		if(data != null)
		{
			SNSRoomTextData.Header h = data.FindHeader(dbSns.AJIDLAGFPGM_TalkId);
			for(int i = h.startIndex; i <= h.endIndex; i++)
			{
                SNSRoomTextData.TalkData IDLHJIOMJBK = data.FindData(i);
				IMKNEDJDNGC d = new IMKNEDJDNGC();
				d.GAIEHFCHAOK = true;
				d.BEBJKJKBOGH_Date = JHNMKKNEENE + IDLHJIOMJBK.timeOffset;
				d.FMDCAFCHBJH_Offset = IDLHJIOMJBK.timeOffset;
				d.AIPLIEMLHGC = dbSns.AIPLIEMLHGC;
				d.AJIDLAGFPGM = dbSns.AJIDLAGFPGM_TalkId;
				d.LJGOOOMOMMA_Desc = data.FindMessage(IDLHJIOMJBK.messageIndex);
				d.IDELKEKDIFD_CharaId = IDLHJIOMJBK.charaId;
				d.HDBOIICCEIA = KHCACDIKJLG.FindIndex((FHFEHOBCIIP GHPLINIACBB) =>
				{
					//0xFCB94C
					return GHPLINIACBB.IDELKEKDIFD_CharaId == IDLHJIOMJBK.charaId;
				});
				d.OIPCCBHIKIA_Index = i - h.startIndex;
				d.OKMMDJCAHNK_WinShapeId = IDLHJIOMJBK.windowShapeId;
				d.HMKFHLLAKCI_WindowSizeId = IDLHJIOMJBK.windowSizeId;
				g.CNEOPOINCBA.Add(d);
            }
		}
	}

	// // RVA: 0xFC8A6C Offset: 0xFC8A6C VA: 0xFC8A6C
	public void OPBFFEMJBFH(long JHNMKKNEENE, bool DENGEJFHAFA, bool IAHLNPMFJMH, int BBDLLIEOLCB = -1)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns != null)
			{
				if(Database.Instance.roomText.textData != null)
				{
					MessageBank bk = MessageManager.Instance.GetBank("master");
					int sns_event_room_pre_open = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("sns_event_room_pre_open", 1);
					List<DDEMMEPBOIA_Sns.EFIFBJGKPJF> GHCOHBMCNNJ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG;
					for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA.Count; i++)
					{
						BOKMNHAFJHF_Sns.KEIGMAOCJHK NDFIEMPPMLF = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
						if(NDFIEMPPMLF.PPEGAKEIEGM_Enabled == 2)
						{
							GAKAAIHLFKI g = NPKPBDIDBBG_RoomData.Find((GAKAAIHLFKI GHPLINIACBB) =>
							{
								//0xFCBB70
								return GHPLINIACBB.MALFHCHNEFN_Id == NDFIEMPPMLF.MALFHCHNEFN_RoomId;
							});
							if(g != null)
							{
								if(BBDLLIEOLCB > -1)
								{
									if (NDFIEMPPMLF.MALFHCHNEFN_RoomId != BBDLLIEOLCB)
										continue;
								}
								//IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.NPKPBDIDBBG_Room[NDFIEMPPMLF.MALFHCHNEFN]
								DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = GHCOHBMCNNJ[i];
								if(DENGEJFHAFA || (saveSns.BEBJKJKBOGH_Date != 0 && JHNMKKNEENE >= saveSns.BEBJKJKBOGH_Date))
								{
									SNSRoomTextData.Header header = Database.Instance.roomText.textData.FindHeader(NDFIEMPPMLF.AJIDLAGFPGM_TalkId);
									if(header != null)
									{
										if(NDFIEMPPMLF.MALFHCHNEFN_RoomId != 0)
										{
											if(!IAHLNPMFJMH || (NDFIEMPPMLF.MALFHCHNEFN_RoomId == 1 && NDFIEMPPMLF.JKNGNIMLDDJ == 14))
											{
												//LAB_00fc91e8
												if(g.JBOECJOONLP < saveSns.BEBJKJKBOGH_Date)
												{
													g.JBOECJOONLP = saveSns.BEBJKJKBOGH_Date;
												}
												if(g.IJEKNCDIIAE < NDFIEMPPMLF.IJEKNCDIIAE)
												{
													g.IJEKNCDIIAE = NDFIEMPPMLF.IJEKNCDIIAE;
												}
												if(NDFIEMPPMLF.JKNGNIMLDDJ == 10)
												{
													if(g.ILDLJMCIKAK < NDFIEMPPMLF.DPIBHFNDJII)
													{
														g.ILDLJMCIKAK = NDFIEMPPMLF.DPIBHFNDJII;
													}
												}
												if(g.AIPLIEMLHGC < NDFIEMPPMLF.AIPLIEMLHGC)
												{
													g.AIPLIEMLHGC = NDFIEMPPMLF.AIPLIEMLHGC;
												}
												bool b = true;
												if(!IAHLNPMFJMH)
												{
													b = (header.endIndex + 1) - header.startIndex != saveSns.LDJIMGPHFPA_Cnt;
												}
												IMKNEDJDNGC data = new IMKNEDJDNGC();
												data.BEBJKJKBOGH_Date = saveSns.BEBJKJKBOGH_Date;
												data.AIPLIEMLHGC = NDFIEMPPMLF.AIPLIEMLHGC;
												data.AJIDLAGFPGM = NDFIEMPPMLF.AJIDLAGFPGM_TalkId;
												data.OIPCCBHIKIA_Index = 0;
												data.IDELKEKDIFD_CharaId = 1;
												data.FMDCAFCHBJH_Offset = 0;
												data.GAIEHFCHAOK = b;
												data.HDBOIICCEIA = KHCACDIKJLG.FindIndex((FHFEHOBCIIP GHPLINIACBB) =>
												{
													//0xFCB81C
													return GHPLINIACBB.IDELKEKDIFD_CharaId == 1;
												});
												data.OPFGFINHFCE_Name = bk.GetMessageByLabel("sns_nm_"+ NDFIEMPPMLF.AIPLIEMLHGC.ToString("D4"));
												data.LJGOOOMOMMA_Desc = bk.GetMessageByLabel("sns_dsc_" + NDFIEMPPMLF.AIPLIEMLHGC.ToString("D4"));
												data.EDCBHGECEBE = true;
												g.CNEOPOINCBA.Add(data);
												for(int j = header.startIndex; j <= header.endIndex; j++)
												{
													SNSRoomTextData.TalkData IDLHJIOMJBK = Database.Instance.roomText.textData.FindData(j);
													IMKNEDJDNGC data2 = new IMKNEDJDNGC();
													data2.GAIEHFCHAOK = b;
													data2.BEBJKJKBOGH_Date = saveSns.BEBJKJKBOGH_Date + IDLHJIOMJBK.timeOffset;
													data2.FMDCAFCHBJH_Offset = IDLHJIOMJBK.timeOffset;
													data2.AIPLIEMLHGC = NDFIEMPPMLF.AIPLIEMLHGC;
													data2.AJIDLAGFPGM = NDFIEMPPMLF.AJIDLAGFPGM_TalkId;
													data2.LJGOOOMOMMA_Desc = Database.Instance.roomText.textData.FindMessage(IDLHJIOMJBK.messageIndex);
													data2.IDELKEKDIFD_CharaId = IDLHJIOMJBK.charaId;
													data2.HDBOIICCEIA = KHCACDIKJLG.FindIndex((FHFEHOBCIIP GHPLINIACBB) =>
													{
														//0xFCBBBC
														return GHPLINIACBB.IDELKEKDIFD_CharaId == IDLHJIOMJBK.charaId;
													});
													data2.OIPCCBHIKIA_Index = j - header.startIndex;
													data2.OKMMDJCAHNK_WinShapeId = IDLHJIOMJBK.windowShapeId;
													data2.HMKFHLLAKCI_WindowSizeId = IDLHJIOMJBK.windowSizeId;
													g.CNEOPOINCBA.Add(data2);
												}
											}
										}
									}
								}
							}
						}
					}
					for(int i = 0; i < NPKPBDIDBBG_RoomData.Count; i++)
					{
						NPKPBDIDBBG_RoomData[i].CNEOPOINCBA.Sort((IMKNEDJDNGC HKICMNAACDA, IMKNEDJDNGC BNKHBCBJBKI) =>
						{
							//0xFCB998
							DDEMMEPBOIA_Sns.EFIFBJGKPJF elem1 = GHCOHBMCNNJ[HKICMNAACDA.AIPLIEMLHGC - 1];
							DDEMMEPBOIA_Sns.EFIFBJGKPJF elem2 = GHCOHBMCNNJ[BNKHBCBJBKI.AIPLIEMLHGC - 1];
							int res = elem1.BEBJKJKBOGH_Date.CompareTo(elem2.BEBJKJKBOGH_Date);
							if(res == 0)
							{
								res = HKICMNAACDA.AIPLIEMLHGC.CompareTo(BNKHBCBJBKI.AIPLIEMLHGC);
								if(res == 0)
								{
									if(HKICMNAACDA.EDCBHGECEBE != BNKHBCBJBKI.EDCBHGECEBE)
									{
										res = -1;
										if (!HKICMNAACDA.EDCBHGECEBE)
											res = 1;
									}
									if(res == 0)
									{
										return HKICMNAACDA.OIPCCBHIKIA_Index.CompareTo(BNKHBCBJBKI.OIPCCBHIKIA_Index);
									}
								}
							}
							return res;
						});
					}
					if(!IAHLNPMFJMH)
					{
						//LAB_00fca464
						for (int i = 0; i < NPKPBDIDBBG_RoomData.Count; i++)
						{
							if(NPKPBDIDBBG_RoomData[i].IHCEJBAEEDO != 0)
							{
								BOKMNHAFJHF_Sns.LEBAGJNJJNG_Room dbRoom = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.NPKPBDIDBBG_Room[NPKPBDIDBBG_RoomData[i].MALFHCHNEFN_Id];
								if(NPKPBDIDBBG_RoomData[i].MALFHCHNEFN_Id != 0)
								{
									IKDICBBFBMI_EventBase i_ = null;
									int a = 1;
									bool b = false;
									if(dbRoom.EKANGPODCEP != 0)
									{
										IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(dbRoom.EKANGPODCEP);
										if(ev == null)
										{
											b = true;
											a = 1;
										}
										else
										{
											a = 1;
											b = false;
											if(ev.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI_6 || ev.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD.HINPDNKNAHO_10)
											{
												b = ev.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD.DOAENCHBAEO_11;
												a = (sns_event_room_pre_open != 1 || b) ? 1 : 0;
												i_ = ev;
											}
										}
									}
									int cnt = 0;
									for(int j = 0; j < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA.Count; j++)
									{
										BOKMNHAFJHF_Sns.KEIGMAOCJHK dbData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[j];
										if(dbData.MALFHCHNEFN_RoomId == NPKPBDIDBBG_RoomData[i].MALFHCHNEFN_Id && dbData.MALFHCHNEFN_RoomId == 2 && dbData.JKNGNIMLDDJ != 0)
										{
											long date = GHCOHBMCNNJ[j].BEBJKJKBOGH_Date;
											if (date == 0 || JHNMKKNEENE < date)
											{
												//LAB_00fc9f98
												if (cnt > a)
													continue;
												if(i_ == null && !(b || dbRoom.EEECOMPDNEJ != 5))
												{
													continue;
												}
												IMKNEDJDNGC data = new IMKNEDJDNGC();
												data.BEBJKJKBOGH_Date = date;
												data.AIPLIEMLHGC = dbData.AIPLIEMLHGC;
												data.AJIDLAGFPGM = dbData.AJIDLAGFPGM_TalkId;
												data.OIPCCBHIKIA_Index = 0;
												data.IDELKEKDIFD_CharaId = 1;
												data.FMDCAFCHBJH_Offset = 0;
												data.GAIEHFCHAOK = true;
												data.HDBOIICCEIA = KHCACDIKJLG.FindIndex((FHFEHOBCIIP GHPLINIACBB) =>
												{
													//0xFCB848
													return GHPLINIACBB.IDELKEKDIFD_CharaId == 1;
												});
												data.OPFGFINHFCE_Name = bk.GetMessageByLabel("sns_nm_" + data.AIPLIEMLHGC.ToString("D4"));
												if(b)
												{
													FBIOJHECAHB_EventStory.ENDMMNNOAIL evData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.GIBIMCOLLNN(dbData.AIPLIEMLHGC);
													data.LJGOOOMOMMA_Desc = JpStringLiterals.StringLiteral_10314;
													if(evData != null)
													{
														MessageBank bk2 = MessageManager.Instance.GetBank("menu");
														data.LJGOOOMOMMA_Desc = string.Format(bk2.GetMessageByLabel("event_story_text_006"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1), evData.PFGAKEDKOPD, EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1));
													}
												}
												else
												{
													if(dbRoom.EEECOMPDNEJ == 3)
													{
														data.LJGOOOMOMMA_Desc = JpStringLiterals.StringLiteral_10314;
													}
													else
													{
														data.LJGOOOMOMMA_Desc = bk.GetMessageByLabel("sns_dsc2_" + data.AIPLIEMLHGC.ToString("D4"));
														if(string.IsNullOrEmpty(data.LJGOOOMOMMA_Desc))
														{
															data.LJGOOOMOMMA_Desc = bk.GetMessageByLabel("sns_dsc_" + data.AIPLIEMLHGC.ToString("D4"));
														}
													}
												}
												data.EDCBHGECEBE = true;
												NPKPBDIDBBG_RoomData[i].CNEOPOINCBA.Add(data);
											}
											else
												cnt++;
										}
									}
								}
							}
						}
					}
					for(int i = 0; i < NPKPBDIDBBG_RoomData.Count; i++)
					{
						int a = NPKPBDIDBBG_RoomData[i].MCGDHHHFBMO_GetUnreadIndex(JHNMKKNEENE, false);
						int c = NPKPBDIDBBG_RoomData[i].BDNLOOAGKKE(JHNMKKNEENE, false, false);
						if (NPKPBDIDBBG_RoomData[i].HIDHLFCBIDE == 1)
						{
							NPKPBDIDBBG_RoomData.RemoveAt(i);
							break;
						}
						if (a < 1)
							a = c;
						if(a < 1)
						{
							NPKPBDIDBBG_RoomData.RemoveAt(i);
							i--;
						}
					}
					NPKPBDIDBBG_RoomData.Sort((GAKAAIHLFKI HKICMNAACDA, GAKAAIHLFKI BNKHBCBJBKI) =>
					{
						//0xFCB874
						int res = BNKHBCBJBKI.JBOECJOONLP.CompareTo(HKICMNAACDA.JBOECJOONLP);
						if(res == 0)
						{
							res = BNKHBCBJBKI.IJEKNCDIIAE.CompareTo(HKICMNAACDA.IJEKNCDIIAE);
							if(res == 0)
							{
								res = BNKHBCBJBKI.ILDLJMCIKAK.CompareTo(HKICMNAACDA.ILDLJMCIKAK);
								if(res == 0)
								{
									res = BNKHBCBJBKI.AIPLIEMLHGC.CompareTo(HKICMNAACDA.AIPLIEMLHGC);
								}
							}
						}
						return res;
					});
				}
			}
		}
	}

	// // RVA: 0xFCB060 Offset: 0xFCB060 VA: 0xFCB060
	// public static bool MCCBDKEAMDK(FDDIIKBJNNA ANJGLKIGLAN, bool LODIBNOGMBE = False) { }

	// // RVA: 0xFCB520 Offset: 0xFCB520 VA: 0xFCB520
	public static void FLKIIDJEJJM(FDDIIKBJNNA ANJGLKIGLAN)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(ANJGLKIGLAN == null)
		{
			ANJGLKIGLAN = new FDDIIKBJNNA();
			ANJGLKIGLAN.KHEKNNFCAOI(false, false, -1);
		}
		int a = 0;
		for(int i = 0; i < ANJGLKIGLAN.NPKPBDIDBBG_RoomData.Count; i++)
		{
			a += ANJGLKIGLAN.NPKPBDIDBBG_RoomData[i].FOBEBCPEILE_GetCurrentTalkIndex(time, false, false);
		}
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.INAECNHELAM_ShowSnsBal = a;
	}
}

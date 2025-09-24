
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public class FDDIIKBJNNA
{
	public List<GAKAAIHLFKI> NPKPBDIDBBG_Room = new List<GAKAAIHLFKI>(); // 0x8
	public List<FHFEHOBCIIP> KHCACDIKJLG_Characters = new List<FHFEHOBCIIP>(); // 0xC

	// // RVA: 0xFC8280 Offset: 0xFC8280 VA: 0xFC8280
	public void KHEKNNFCAOI_Init(bool DENGEJFHAFA, bool _IAHLNPMFJMH_Tutorial/* = false*/, int BBDLLIEOLCB/* = -1*/)
	{
		//IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		JALKJCLEPJN();
		NNIIGAECOHO();
		OPBFFEMJBFH(time, DENGEJFHAFA, _IAHLNPMFJMH_Tutorial, BBDLLIEOLCB);
	}

	// // RVA: 0xFCA83C Offset: 0xFCA83C VA: 0xFCA83C
	public void KHEKNNFCAOI_Init(int _AIPLIEMLHGC_SnsId)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		HNEJELAAION(time, _AIPLIEMLHGC_SnsId);
	}

	// // RVA: 0xFCAFC8 Offset: 0xFCAFC8 VA: 0xFCAFC8
	// public void JCHLONCMPAJ() { }

	// // RVA: 0xFC8418 Offset: 0xFC8418 VA: 0xFC8418
	public void JALKJCLEPJN()
	{
		BOKMNHAFJHF_Sns snsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns;
		KHCACDIKJLG_Characters.Clear();
		for(int i = 0; i < snsDb.KHCACDIKJLG_Characters.Count; i++)
		{
			if(snsDb.KHCACDIKJLG_Characters[i].PPEGAKEIEGM_Enabled == 2)
			{
				FHFEHOBCIIP data = new FHFEHOBCIIP();
				data.IDELKEKDIFD_CharaId = snsDb.KHCACDIKJLG_Characters[i].IDELKEKDIFD_CharaId;
				data.EAHPLCJMPHD_PId = snsDb.KHCACDIKJLG_Characters[i].EAHPLCJMPHD_PId;
				data.OPFGFINHFCE_name = snsDb.KHCACDIKJLG_Characters[i].OPFGFINHFCE_name;
				data.HAPAFECPFEK_AtName = snsDb.KHCACDIKJLG_Characters[i].HAPAFECPFEK_AtName;
				KHCACDIKJLG_Characters.Add(data);
			}
		}
	}

	// // RVA: 0xFC86B8 Offset: 0xFC86B8 VA: 0xFC86B8
	public void NNIIGAECOHO()
	{
		BOKMNHAFJHF_Sns snsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns;
		NPKPBDIDBBG_Room.Clear();
		for(int i = 0; i < snsDb.NPKPBDIDBBG_Room.Count; i++)
		{
			if(snsDb.NPKPBDIDBBG_Room[i].PPEGAKEIEGM_Enabled == 2 && snsDb.NPKPBDIDBBG_Room[i].MALFHCHNEFN_RoomId > 0)
			{
				GAKAAIHLFKI data = new GAKAAIHLFKI();
				data.MALFHCHNEFN_RoomId = snsDb.NPKPBDIDBBG_Room[i].MALFHCHNEFN_RoomId;
				data.JBOECJOONLP = 0;
				data.OPFGFINHFCE_name = snsDb.NPKPBDIDBBG_Room[i].OPFGFINHFCE_name;
				data.IJEKNCDIIAE_mver = 0;
				data.IHCEJBAEEDO = snsDb.NPKPBDIDBBG_Room[i].PKOKDPHHLCG_Next;
				NPKPBDIDBBG_Room.Add(data);
			}
		}
	}

	// // RVA: 0xFCA93C Offset: 0xFCA93C VA: 0xFCA93C
	public void HNEJELAAION(long _JHNMKKNEENE_Time, int _AIPLIEMLHGC_SnsId)
	{
		JALKJCLEPJN();
		NPKPBDIDBBG_Room.Clear();
		MessageBank bk = MessageManager.Instance.GetBank("master");
		BOKMNHAFJHF_Sns.KEIGMAOCJHK_Talk dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_table[_AIPLIEMLHGC_SnsId - 1];
		BOKMNHAFJHF_Sns.LEBAGJNJJNG_Room dbRoom = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.NPKPBDIDBBG_Room[dbSns.MALFHCHNEFN_RoomId];
		GAKAAIHLFKI g = new GAKAAIHLFKI();
		g.MALFHCHNEFN_RoomId = dbRoom.MALFHCHNEFN_RoomId;
		g.OPFGFINHFCE_name = dbRoom.OPFGFINHFCE_name;
		g.JBOECJOONLP = 0;
		g.IHCEJBAEEDO = dbRoom.PKOKDPHHLCG_Next;
		g.IJEKNCDIIAE_mver = 0;
		g.ILDLJMCIKAK = 0;
		g.AIPLIEMLHGC_SnsId = 0;
		NPKPBDIDBBG_Room.Add(g);
		SNSRoomTextData data = Database.Instance.roomText.textData;
		if(data != null)
		{
			SNSRoomTextData.Header h = data.FindHeader(dbSns.AJIDLAGFPGM_TalkId);
			for(int i = h.startIndex; i <= h.endIndex; i++)
			{
                SNSRoomTextData.TalkData IDLHJIOMJBK_data = data.FindData(i);
				IMKNEDJDNGC d = new IMKNEDJDNGC();
				d.GAIEHFCHAOK_New = true;
				d.BEBJKJKBOGH_date = _JHNMKKNEENE_Time + IDLHJIOMJBK_data.timeOffset;
				d.FMDCAFCHBJH_Offset = IDLHJIOMJBK_data.timeOffset;
				d.AIPLIEMLHGC_SnsId = dbSns.AIPLIEMLHGC_SnsId;
				d.AJIDLAGFPGM_TalkId = dbSns.AJIDLAGFPGM_TalkId;
				d.LJGOOOMOMMA_message = data.FindMessage(IDLHJIOMJBK_data.messageIndex);
				d.IDELKEKDIFD_CharaId = IDLHJIOMJBK_data.charaId;
				d.HDBOIICCEIA = KHCACDIKJLG_Characters.FindIndex((FHFEHOBCIIP _GHPLINIACBB_x) =>
				{
					//0xFCB94C
					return _GHPLINIACBB_x.IDELKEKDIFD_CharaId == IDLHJIOMJBK_data.charaId;
				});
				d.OIPCCBHIKIA_index = i - h.startIndex;
				d.OKMMDJCAHNK_WinShapeId = IDLHJIOMJBK_data.windowShapeId;
				d.HMKFHLLAKCI_WindowSizeId = IDLHJIOMJBK_data.windowSizeId;
				g.CNEOPOINCBA.Add(d);
            }
		}
	}

	// // RVA: 0xFC8A6C Offset: 0xFC8A6C VA: 0xFC8A6C
	public void OPBFFEMJBFH(long _JHNMKKNEENE_Time, bool DENGEJFHAFA, bool _IAHLNPMFJMH_Tutorial, int BBDLLIEOLCB/* = -1*/)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.FLHMJHBOBEA_Sns != null)
			{
				if(Database.Instance.roomText.textData != null)
				{
					MessageBank bk = MessageManager.Instance.GetBank("master");
					int sns_event_room_pre_open = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("sns_event_room_pre_open", 1);
					List<DDEMMEPBOIA_Sns.EFIFBJGKPJF> GHCOHBMCNNJ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.FLHMJHBOBEA_Sns.HAJEJPFGILG;
					for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_table.Count; i++)
					{
						BOKMNHAFJHF_Sns.KEIGMAOCJHK_Talk NDFIEMPPMLF_master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_table[i];
						if(NDFIEMPPMLF_master.PPEGAKEIEGM_Enabled == 2)
						{
							GAKAAIHLFKI g = NPKPBDIDBBG_Room.Find((GAKAAIHLFKI _GHPLINIACBB_x) =>
							{
								//0xFCBB70
								return _GHPLINIACBB_x.MALFHCHNEFN_RoomId == NDFIEMPPMLF_master.MALFHCHNEFN_RoomId;
							});
							if(g != null)
							{
								if(BBDLLIEOLCB > -1)
								{
									if (NDFIEMPPMLF_master.MALFHCHNEFN_RoomId != BBDLLIEOLCB)
										continue;
								}
								//IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.NPKPBDIDBBG_Room[NDFIEMPPMLF_master.MALFHCHNEFN_RoomId]
								DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = GHCOHBMCNNJ[i];
								if(DENGEJFHAFA || (saveSns.BEBJKJKBOGH_date != 0 && _JHNMKKNEENE_Time >= saveSns.BEBJKJKBOGH_date))
								{
									SNSRoomTextData.Header header = Database.Instance.roomText.textData.FindHeader(NDFIEMPPMLF_master.AJIDLAGFPGM_TalkId);
									if(header != null)
									{
										if(NDFIEMPPMLF_master.MALFHCHNEFN_RoomId != 0)
										{
											if(!_IAHLNPMFJMH_Tutorial || (NDFIEMPPMLF_master.MALFHCHNEFN_RoomId == 1 && NDFIEMPPMLF_master.JKNGNIMLDDJ_UnlockType == 14))
											{
												//LAB_00fc91e8
												if(g.JBOECJOONLP < saveSns.BEBJKJKBOGH_date)
												{
													g.JBOECJOONLP = saveSns.BEBJKJKBOGH_date;
												}
												if(g.IJEKNCDIIAE_mver < NDFIEMPPMLF_master.IJEKNCDIIAE_mver)
												{
													g.IJEKNCDIIAE_mver = NDFIEMPPMLF_master.IJEKNCDIIAE_mver;
												}
												if(NDFIEMPPMLF_master.JKNGNIMLDDJ_UnlockType == 10)
												{
													if(g.ILDLJMCIKAK < NDFIEMPPMLF_master.DPIBHFNDJII_UnlockCond1)
													{
														g.ILDLJMCIKAK = NDFIEMPPMLF_master.DPIBHFNDJII_UnlockCond1;
													}
												}
												if(g.AIPLIEMLHGC_SnsId < NDFIEMPPMLF_master.AIPLIEMLHGC_SnsId)
												{
													g.AIPLIEMLHGC_SnsId = NDFIEMPPMLF_master.AIPLIEMLHGC_SnsId;
												}
												bool b = true;
												if(!_IAHLNPMFJMH_Tutorial)
												{
													b = (header.endIndex + 1) - header.startIndex != saveSns.LDJIMGPHFPA_Cnt;
												}
												IMKNEDJDNGC data = new IMKNEDJDNGC();
												data.BEBJKJKBOGH_date = saveSns.BEBJKJKBOGH_date;
												data.AIPLIEMLHGC_SnsId = NDFIEMPPMLF_master.AIPLIEMLHGC_SnsId;
												data.AJIDLAGFPGM_TalkId = NDFIEMPPMLF_master.AJIDLAGFPGM_TalkId;
												data.OIPCCBHIKIA_index = 0;
												data.IDELKEKDIFD_CharaId = 1;
												data.FMDCAFCHBJH_Offset = 0;
												data.GAIEHFCHAOK_New = b;
												data.HDBOIICCEIA = KHCACDIKJLG_Characters.FindIndex((FHFEHOBCIIP _GHPLINIACBB_x) =>
												{
													//0xFCB81C
													return _GHPLINIACBB_x.IDELKEKDIFD_CharaId == 1;
												});
												data.OPFGFINHFCE_name = bk.GetMessageByLabel("sns_nm_"+ NDFIEMPPMLF_master.AIPLIEMLHGC_SnsId.ToString("D4"));
												data.LJGOOOMOMMA_message = bk.GetMessageByLabel("sns_dsc_" + NDFIEMPPMLF_master.AIPLIEMLHGC_SnsId.ToString("D4"));
												data.EDCBHGECEBE_Read = true;
												g.CNEOPOINCBA.Add(data);
												for(int j = header.startIndex; j <= header.endIndex; j++)
												{
													SNSRoomTextData.TalkData IDLHJIOMJBK_data = Database.Instance.roomText.textData.FindData(j);
													IMKNEDJDNGC data2 = new IMKNEDJDNGC();
													data2.GAIEHFCHAOK_New = b;
													data2.BEBJKJKBOGH_date = saveSns.BEBJKJKBOGH_date + IDLHJIOMJBK_data.timeOffset;
													data2.FMDCAFCHBJH_Offset = IDLHJIOMJBK_data.timeOffset;
													data2.AIPLIEMLHGC_SnsId = NDFIEMPPMLF_master.AIPLIEMLHGC_SnsId;
													data2.AJIDLAGFPGM_TalkId = NDFIEMPPMLF_master.AJIDLAGFPGM_TalkId;
													data2.LJGOOOMOMMA_message = Database.Instance.roomText.textData.FindMessage(IDLHJIOMJBK_data.messageIndex);
													data2.IDELKEKDIFD_CharaId = IDLHJIOMJBK_data.charaId;
													data2.HDBOIICCEIA = KHCACDIKJLG_Characters.FindIndex((FHFEHOBCIIP _GHPLINIACBB_x) =>
													{
														//0xFCBBBC
														return _GHPLINIACBB_x.IDELKEKDIFD_CharaId == IDLHJIOMJBK_data.charaId;
													});
													data2.OIPCCBHIKIA_index = j - header.startIndex;
													data2.OKMMDJCAHNK_WinShapeId = IDLHJIOMJBK_data.windowShapeId;
													data2.HMKFHLLAKCI_WindowSizeId = IDLHJIOMJBK_data.windowSizeId;
													g.CNEOPOINCBA.Add(data2);
												}
											}
										}
									}
								}
							}
						}
					}
					for(int i = 0; i < NPKPBDIDBBG_Room.Count; i++)
					{
						NPKPBDIDBBG_Room[i].CNEOPOINCBA.Sort((IMKNEDJDNGC _HKICMNAACDA_a, IMKNEDJDNGC _BNKHBCBJBKI_b) =>
						{
							//0xFCB998
							DDEMMEPBOIA_Sns.EFIFBJGKPJF elem1 = GHCOHBMCNNJ[_HKICMNAACDA_a.AIPLIEMLHGC_SnsId - 1];
							DDEMMEPBOIA_Sns.EFIFBJGKPJF elem2 = GHCOHBMCNNJ[_BNKHBCBJBKI_b.AIPLIEMLHGC_SnsId - 1];
							int res = elem1.BEBJKJKBOGH_date.CompareTo(elem2.BEBJKJKBOGH_date);
							if(res == 0)
							{
								res = _HKICMNAACDA_a.AIPLIEMLHGC_SnsId.CompareTo(_BNKHBCBJBKI_b.AIPLIEMLHGC_SnsId);
								if(res == 0)
								{
									if(_HKICMNAACDA_a.EDCBHGECEBE_Read != _BNKHBCBJBKI_b.EDCBHGECEBE_Read)
									{
										res = -1;
										if (!_HKICMNAACDA_a.EDCBHGECEBE_Read)
											res = 1;
									}
									if(res == 0)
									{
										return _HKICMNAACDA_a.OIPCCBHIKIA_index.CompareTo(_BNKHBCBJBKI_b.OIPCCBHIKIA_index);
									}
								}
							}
							return res;
						});
					}
					if(!_IAHLNPMFJMH_Tutorial)
					{
						//LAB_00fca464
						for (int i = 0; i < NPKPBDIDBBG_Room.Count; i++)
						{
							if(NPKPBDIDBBG_Room[i].IHCEJBAEEDO != 0)
							{
								BOKMNHAFJHF_Sns.LEBAGJNJJNG_Room dbRoom = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.NPKPBDIDBBG_Room[NPKPBDIDBBG_Room[i].MALFHCHNEFN_RoomId];
								if(NPKPBDIDBBG_Room[i].MALFHCHNEFN_RoomId != 0)
								{
									IKDICBBFBMI_EventBase i_ = null;
									int a = 1;
									bool b = false;
									if(dbRoom.EKANGPODCEP_EventId != 0)
									{
										IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(dbRoom.EKANGPODCEP_EventId);
										if(ev == null)
										{
											b = true;
											a = 1;
										}
										else
										{
											a = 1;
											b = false;
											if(ev.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6 || ev.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10)
											{
												b = ev.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
												a = (sns_event_room_pre_open != 1 || b) ? 1 : 0;
												i_ = ev;
											}
										}
									}
									int cnt = 0;
									for(int j = 0; j < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_table.Count; j++)
									{
										BOKMNHAFJHF_Sns.KEIGMAOCJHK_Talk dbData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_table[j];
										if(dbData.MALFHCHNEFN_RoomId == NPKPBDIDBBG_Room[i].MALFHCHNEFN_RoomId && dbData.MALFHCHNEFN_RoomId == 2 && dbData.JKNGNIMLDDJ_UnlockType != 0)
										{
											long date = GHCOHBMCNNJ[j].BEBJKJKBOGH_date;
											if (date == 0 || _JHNMKKNEENE_Time < date)
											{
												//LAB_00fc9f98
												if (cnt > a)
													continue;
												if(i_ == null && !(b || dbRoom.EEECOMPDNEJ != 5))
												{
													continue;
												}
												IMKNEDJDNGC data = new IMKNEDJDNGC();
												data.BEBJKJKBOGH_date = date;
												data.AIPLIEMLHGC_SnsId = dbData.AIPLIEMLHGC_SnsId;
												data.AJIDLAGFPGM_TalkId = dbData.AJIDLAGFPGM_TalkId;
												data.OIPCCBHIKIA_index = 0;
												data.IDELKEKDIFD_CharaId = 1;
												data.FMDCAFCHBJH_Offset = 0;
												data.GAIEHFCHAOK_New = true;
												data.HDBOIICCEIA = KHCACDIKJLG_Characters.FindIndex((FHFEHOBCIIP _GHPLINIACBB_x) =>
												{
													//0xFCB848
													return _GHPLINIACBB_x.IDELKEKDIFD_CharaId == 1;
												});
												data.OPFGFINHFCE_name = bk.GetMessageByLabel("sns_nm_" + data.AIPLIEMLHGC_SnsId.ToString("D4"));
												if(b)
												{
													FBIOJHECAHB_EventStory.ENDMMNNOAIL_StoryPartInfo evData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.GIBIMCOLLNN(dbData.AIPLIEMLHGC_SnsId);
													data.LJGOOOMOMMA_message = JpStringLiterals.StringLiteral_10314;
													if(evData != null)
													{
														MessageBank bk2 = MessageManager.Instance.GetBank("menu");
														data.LJGOOOMOMMA_message = string.Format(bk2.GetMessageByLabel("event_story_text_006"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1), evData.PFGAKEDKOPD_UnlockSpCost, EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1));
													}
												}
												else
												{
													if(dbRoom.EEECOMPDNEJ == 3)
													{
														data.LJGOOOMOMMA_message = JpStringLiterals.StringLiteral_10314;
													}
													else
													{
														data.LJGOOOMOMMA_message = bk.GetMessageByLabel("sns_dsc2_" + data.AIPLIEMLHGC_SnsId.ToString("D4"));
														if(string.IsNullOrEmpty(data.LJGOOOMOMMA_message))
														{
															data.LJGOOOMOMMA_message = bk.GetMessageByLabel("sns_dsc_" + data.AIPLIEMLHGC_SnsId.ToString("D4"));
														}
													}
												}
												data.EDCBHGECEBE_Read = true;
												NPKPBDIDBBG_Room[i].CNEOPOINCBA.Add(data);
											}
											else
												cnt++;
										}
									}
								}
							}
						}
					}
					for(int i = 0; i < NPKPBDIDBBG_Room.Count; i++)
					{
						int a = NPKPBDIDBBG_Room[i].MCGDHHHFBMO_GetUnreadIndex(_JHNMKKNEENE_Time, false);
						int c = NPKPBDIDBBG_Room[i].BDNLOOAGKKE(_JHNMKKNEENE_Time, false, false);
						if (NPKPBDIDBBG_Room[i].HIDHLFCBIDE_EventType == 1)
						{
							NPKPBDIDBBG_Room.RemoveAt(i);
							break;
						}
						if (a < 1)
							a = c;
						if(a < 1)
						{
							NPKPBDIDBBG_Room.RemoveAt(i);
							i--;
						}
					}
					NPKPBDIDBBG_Room.Sort((GAKAAIHLFKI _HKICMNAACDA_a, GAKAAIHLFKI _BNKHBCBJBKI_b) =>
					{
						//0xFCB874
						int res = _BNKHBCBJBKI_b.JBOECJOONLP.CompareTo(_HKICMNAACDA_a.JBOECJOONLP);
						if(res == 0)
						{
							res = _BNKHBCBJBKI_b.IJEKNCDIIAE_mver.CompareTo(_HKICMNAACDA_a.IJEKNCDIIAE_mver);
							if(res == 0)
							{
								res = _BNKHBCBJBKI_b.ILDLJMCIKAK.CompareTo(_HKICMNAACDA_a.ILDLJMCIKAK);
								if(res == 0)
								{
									res = _BNKHBCBJBKI_b.AIPLIEMLHGC_SnsId.CompareTo(_HKICMNAACDA_a.AIPLIEMLHGC_SnsId);
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
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(ANJGLKIGLAN == null)
		{
			ANJGLKIGLAN = new FDDIIKBJNNA();
			ANJGLKIGLAN.KHEKNNFCAOI_Init(false, false, -1);
		}
		int a = 0;
		for(int i = 0; i < ANJGLKIGLAN.NPKPBDIDBBG_Room.Count; i++)
		{
			a += ANJGLKIGLAN.NPKPBDIDBBG_Room[i].FOBEBCPEILE_GetCurrentTalkIndex(time, false, false);
		}
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.INAECNHELAM_show_sns_bal = a;
	}
}

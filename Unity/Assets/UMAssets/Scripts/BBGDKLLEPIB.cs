using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using XeSys;
using System.Text;

public class BBGDKLLEPIB
{
	private enum GPPPPOFHAJC
	{
		FKPEAGGKNLC = 0,
		MJKPBANHCOE = 1,
		KBMHDBKJKEO = 2,
		KHLKPDFNABB = 3,
		FCIFGLGBCEO = 4,
		FFBGDIFGJJF = 5,
		PBGLLFHFFLF = 6,
		CEAKNCGBLGO = 7,
		HGLCABLHPAP = 8,
		KOKOCMNDHBB = 9,
		HIMAJCDOMFG = 10,
		OFFIEHJKEOO = 11,
		IMMACKJJDOM = 12,
		CDGFOMPKJON = 13,
		KPGBOHOHFCI = 14,
		KIIGNCNANOH = 15,
		DIPMILDNFJJ = 16,
		BBBLDKGNCLH = 17,
		KEJKHGHFBLH = 18,
		JFILOMCKGKA = 19,
		EPMDKGPMOFN = 20,
		DCECAAAFEDP = 21,
		EOELNFLLEDJ = 22,
	}
	
	private float NDEJCDBHPLB = 180.0f; // 0x8
	public static bool BELNLBKJPCO = false; // 0x4
	private string FPCIBJLJOFI = "db"; // 0xC
	public static string JNPHAJICDPN = "/db/sd.dat"; // 0xC
	public static string FNHCECHLIJI = "/db/ar_marker.dat"; // 0x10
	public static string NLOICACDGNI = "/db/ar_event.dat"; // 0x14
	private static string JCMJBMBMJAK = null; // 0x18
	public string OCOGBOHOGGE; // 0x10 // db name?
	public List<long> PFMPODNDFIB = new List<long>(); // 0x14
	public long POCKENHKOBL; // 0x18
	public static bool FJDOHLADGFI = true; // 0x20
	private List<GCGNICILKLD_AssetFileInfo> ICCMKHKNAMJ; // 0x28
	private static DateTime CBHCDLLOBBK = new DateTime(1970, 1, 1, 0, 0, 0, 1, 0); // 0x28
	private const int AJCPBLIKDGB = 1;
	private const int FAHBCEJNLJD = 2;
	private const int HEDNPEJAEBH = 2;
	private long DMPNAEEIANJ; // 0x30
	private int HGOIEGFBABK = 5; // 0x38
	public bool PBAHJENPLFM; // 0x3C

	public static BBGDKLLEPIB HHCJCDFCLOB { get; private set; }  // 0x0 LGMPACEDIJF // NKACBOEHELJ 0xF1723C OKPMHKNCNAL 0xF172C8
	public static string FLHOFIEOKDH { get; set; } // 0x8 PGOHBLKDJOM // ODMAEKMPAGP 0xF17358 BBPOAGDNMOJ 0xF173E4
	public static string OGCDNCDMLCA { get { 
		if(JCMJBMBMJAK == null)
		{
			string str = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath;
			if(string.IsNullOrEmpty(str))
			{
				Debug.LogError("Install.InstallPathManager.CriWare_installTargetPath is null");
			}
			JCMJBMBMJAK = str + "/mx";
		}
		return JCMJBMBMJAK;
	} } //  FHOCCNDOAPJ 0xF17474
	public static string LHJNPJFNDNA { get; private set; } // 0x1C HCGGEEMOKFN // JBIPCECPFGN 0xF1762C ONAJIIACAEB 0xF176B8  // Rev?
	public OMIFMMJPMDJ OEPPEGHGNNO { get; set; }  // 0x20 KPEKONPJHCL LKCDOGAFPNM 0xF17894  NPJJMDFAIII 0xF1789C // Update percent callback
	public OBHIGCFPKJN MAIHLKPEHJN { get; set; } // 0x24 EAIFOAGPGGH KCLBNOKEPIG 0xF178A4 OCIMGEFKKLM 0xF178AC // Error CB

	// // RVA: 0xF17748 Offset: 0xF17748 VA: 0xF17748
	// public bool KHJHKNLEOAB(long JHNMKKNEENE) { }

	// // RVA: 0xF178B4 Offset: 0xF178B4 VA: 0xF178B4
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
    {
        HHCJCDFCLOB = this;
    }

	// // RVA: 0xF17934 Offset: 0xF17934 VA: 0xF17934
	private void FCPBCDOKOPD(BBGDKLLEPIB.GPPPPOFHAJC PPFNGGCBJKC_Id, string IPBHCLIHAPG)
	{
		return;
	}

	// // RVA: 0xF17938 Offset: 0xF17938 VA: 0xF17938
	public void PAHGEEOFEPM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
    {
		BBGDKLLEPIB.LHJNPJFNDNA = "";
		JCMJBMBMJAK = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/mx";
		N.a.StartCoroutine(EOFJPNPFGDM_Coroutine_Install(BHFHGFKBOHH, MOBEEPPKFLG));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BB854 Offset: 0x6BB854 VA: 0x6BB854
	// // RVA: 0xF17A70 Offset: 0xF17A70 VA: 0xF17A70
	private IEnumerator EOFJPNPFGDM_Coroutine_Install(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		UnityEngine.Debug.Log("Enter EOFJPNPFGDM_Coroutine_Install");
		// private BBGDKLLEPIB.<>c__DisplayClass45_0 OPLBFCEPDCH; // 0x14
				// public BBGDKLLEPIB KIGBLACMODG; // 0x8
				// public bool KOMKKBDABJP; // 0xC
		// private BBGDKLLEPIB.<>c__DisplayClass45_1 LBLMCMHMNGC; // 0x18
				// public Dictionary<string, int> FAOOOLDDBBB; // 0x8
				// public JPAPJLIPNOK COJNCNGHIJC; // 0xC
				// public BBGDKLLEPIB.<>c__DisplayClass45_0 PGFMIBMJBHD; // 0x10
				// // RVA: 0xF1A184 Offset: 0xF1A184 VA: 0xF1A184
				// internal void IPGJJANJOMJ() { }
				// // RVA: 0xF1A2B8 Offset: 0xF1A2B8 VA: 0xF1A2B8
				// internal void EGDGJOPDNFF() { }
				// // RVA: 0xF1A318 Offset: 0xF1A318 VA: 0xF1A318
				// internal void FKJIINPOGKK(JEHIAIPJNJF.HCJPJKCIBDL JGBPLIGAILE) { }
				// // RVA: 0xF1A474 Offset: 0xF1A474 VA: 0xF1A474
				// internal void BCMEPPIPGIB() { }
		// public DJBHIFLHJLK MOBEEPPKFLG; // 0x1C
		// public IMCBBOAFION BHFHGFKBOHH; // 0x20
		// private BBGDKLLEPIB.<>c__DisplayClass45_2 PHPPCOBECCA; // 0x24
				// public int APGOAMNGFFF; // 0x8
				// // RVA: 0xF1A4DC Offset: 0xF1A4DC VA: 0xF1A4DC
				// internal void EKHEBHFBKID() { }
				// // RVA: 0xF1A4E8 Offset: 0xF1A4E8 VA: 0xF1A4E8
				// internal void OIIFKBGOJKO() { }
		// private BBGDKLLEPIB.<>c__DisplayClass45_3 OGEABHOODHB; // 0x28
				// public int APGOAMNGFFF; // 0x8
				// // RVA: 0xF1A4FC Offset: 0xF1A4FC VA: 0xF1A4FC
				// internal void NNGKGAGFFBE() { }
				// // RVA: 0xF1A508 Offset: 0xF1A508 VA: 0xF1A508
				// internal void CAPIELNEBFB() { }
		// private PJKLMCGEJMK OKDOIAEGADK; // 0x2C
		// private JEHIAIPJNJF MHHFMCPJONH; // 0x30
		//0xF1A518
		if(OEPPEGHGNNO == null)
		{
			OEPPEGHGNNO = this.ALDMHFCFECK;
		}
		if(MAIHLKPEHJN == null)
		{
			MAIHLKPEHJN = JHHBAFKMBDL.HHCJCDFCLOB.DOHNKJKOGFJ;
		}
		DMPNAEEIANJ = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		LHJNPJFNDNA = null;
		Dictionary<string, int> FAOOOLDDBBB = new Dictionary<string, int>();
		//goto LAB_00f1b2e8;

		JPAPJLIPNOK COJNCNGHIJC = null;
		while(true)
		{
			COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.IFFNCAFNEAG_AddRequest<JPAPJLIPNOK>(new JPAPJLIPNOK());
			COJNCNGHIJC.FPCIBJLJOFI = FPCIBJLJOFI;
			yield return COJNCNGHIJC.GDPDELLNOBO(N.a);
			// 1
			if(COJNCNGHIJC.NPNNPNAIONN)
			{
				if(MOBEEPPKFLG != null)
					MOBEEPPKFLG();
				UnityEngine.Debug.Log("Exit Error EOFJPNPFGDM_Coroutine_Install");
				yield break;
			}

			FLHOFIEOKDH = COJNCNGHIJC.NFEAMMJIMPG.GLMGHMCOMEC;

			DMPNAEEIANJ = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(COJNCNGHIJC.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_ServerCurrentAssetRevision == LHJNPJFNDNA)
			{
				if(GBCDHECMDMC())
				{
					KEHOJEJMGLJ.AFKGMCBJBJA();
				}
				PKLPEIBEGNO(); // save used db version on disk
				GC.Collect();
				//goto LAB_00f1b02c;
				if(BHFHGFKBOHH != null)
					BHFHGFKBOHH();
				UnityEngine.Debug.Log("Exit EOFJPNPFGDM_Coroutine_Install");
				yield break;
			}
			//L254
			ICCMKHKNAMJ = new List<GCGNICILKLD_AssetFileInfo>();
			bool KOMKKBDABJP = false;

			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
				//0xF1A184
				DIDACHONHJA(ref FAOOOLDDBBB, OGCDNCDMLCA); // List files reccursively in /mx into FAOOOLDDBBB
				IAPEABPJPOE(COJNCNGHIJC.NFEAMMJIMPG, ref FAOOOLDDBBB); // Check files md5 on disk
				KOMKKBDABJP = true;
			});
			// L293
			while(!KOMKKBDABJP)
				yield return null;
			// L 698
			if(ICCMKHKNAMJ.Count == 0)
			{
				KOMKKBDABJP = false;
				NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
					//0xF1A2B8
					CIDPPOGCODB(FAOOOLDDBBB); // Delete files in FAOOOLDDBBB
					KOMKKBDABJP = true;
				});
				//LAB_00f1b234
				while(!KOMKKBDABJP)
					yield return null;
				LHJNPJFNDNA = COJNCNGHIJC.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_ServerCurrentAssetRevision;
				//LAB_00f1b2e8:
			}
			else
			{
				break;
			}
		}
		//L835
		if(OEPPEGHGNNO != null)
		{
			OEPPEGHGNNO(1, 0);
		}
		JEHIAIPJNJF_FileDownloader MHHFMCPJONH = new JEHIAIPJNJF_FileDownloader();
		MHHFMCPJONH.DOMFHDPMCCO_AddFiles(ICCMKHKNAMJ, FLHOFIEOKDH, JCMJBMBMJAK);
		MHHFMCPJONH.LBGNKOJFOFC = (JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo JGBPLIGAILE) => {
			//0xF1A318
			UnityEngine.Debug.Log("downloaded "+JGBPLIGAILE.AJPIGKBIDDL_LocalFileName+" in "+ JGBPLIGAILE.ADHHKEMDOIK_LocalPath+" from "+ JGBPLIGAILE.NFCMNIEHJML_ServerPath);
			FAOOOLDDBBB[JGBPLIGAILE.LAPFOLJGJMB_AssetFileInfo.OIEAICNAMNB_LocalFileName] = 2;
		};
		MHHFMCPJONH.LAOEGNLOJHC();
		//4
		while(true)
		{
			yield return null;
			MHHFMCPJONH.FBANBDCOEJL();
			//L.312
			if(MHHFMCPJONH.CMCKNKKCNDK_Status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI/*2*/)
			{
				OEPPEGHGNNO(3, 100);
				if(MHHFMCPJONH != null)
					MHHFMCPJONH.Dispose();
				OEPPEGHGNNO(2, 100);
				bool KOMKKBDABJP = false;
				NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
					//0xF1A474
					CIDPPOGCODB(FAOOOLDDBBB);
					KOMKKBDABJP = true;
				});
				//goto LAB_00f1ac88;
				//10
				while(!KOMKKBDABJP)
					yield return null;
				LHJNPJFNDNA = COJNCNGHIJC.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_ServerCurrentAssetRevision;
				if(GBCDHECMDMC())
				{
					KEHOJEJMGLJ.AFKGMCBJBJA();
				}
				PKLPEIBEGNO(); // save used db version on disk
				GC.Collect();
				//LAB_00f1b02c:
				if(BHFHGFKBOHH != null)
					BHFHGFKBOHH();
				UnityEngine.Debug.Log("Exit EOFJPNPFGDM_Coroutine_Install");
				yield break;
			}
			//L361
			if(MHHFMCPJONH.CMCKNKKCNDK_Status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LPLEIJIFOKN/*4*/)
			{
				int APGOAMNGFFF = 0;
				string errorType = "network";
				if(MHHFMCPJONH.BHICPONFJKM)
					errorType = "storage";
				int diskSpace = StorageSupport.GetAvailableStorageSizeMB();
				if(diskSpace > -1 && diskSpace < 50)
					errorType = "storage";
				MAIHLKPEHJN(errorType, () => {
					//0xF1A4DC
					APGOAMNGFFF = 1;
				}, () => {
					//0xF1A4E8
					APGOAMNGFFF = -1;
				});
				//goto LAB_00f1ab74;
				//5
				while(APGOAMNGFFF == 0)
					yield return null;
				if(APGOAMNGFFF != 1)
				{
					//goto LAB_00f1b7e4;
					MHHFMCPJONH.Dispose();
					UnityEngine.Debug.LogError("Exit Error EOFJPNPFGDM_Coroutine_Install");
					yield break;
				}
				MHHFMCPJONH.PBIMGBKLDPP();
				//goto LAB_00f1abe8;
				//6
				while(MHHFMCPJONH.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None/*0*/)
				{
					MHHFMCPJONH.FBANBDCOEJL();
					yield return null;
				}
				//goto LAB_00f1b81c;
				MHHFMCPJONH.LAOEGNLOJHC();
				// To 4
				continue;
			}
			
			//L410
			OEPPEGHGNNO(3, MHHFMCPJONH.HCAJCKCOCHC());
			if(MHHFMCPJONH.MNFGKBAEFFL() || MHHFMCPJONH.KAMPHNKAHAB_IsDiskFull)
			{
				//LAB_00f1b614:
				MHHFMCPJONH.PBIMGBKLDPP();
				//goto LAB_00f1ac10;
				//7
				while(MHHFMCPJONH.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None/*0*/)
				{
					MHHFMCPJONH.FBANBDCOEJL();
					yield return null;
				}
				int APGOAMNGFFF = 0;
				string errorType = "network";
				if(MHHFMCPJONH.BHICPONFJKM)
					errorType = "storage";
				int diskSpace = StorageSupport.GetAvailableStorageSizeMB();
				if(diskSpace > -1 && diskSpace < 50)
					errorType = "storage";
				MAIHLKPEHJN(errorType, () => {
					//0xF1A4FC
					APGOAMNGFFF = 1;
				}, () => {
					//0xF1A508
					APGOAMNGFFF = -1;
				});
				//goto LAB_00f1b744;
				//8
				//LAB_00f1b744:
				while(APGOAMNGFFF == 0)
					yield return null;
				if(APGOAMNGFFF == 1)
				{
					//LAB_00f1b7e4				
					MHHFMCPJONH.Dispose();
					UnityEngine.Debug.LogError("Exit Error EOFJPNPFGDM_Coroutine_Install");
					yield break;
				}
				MHHFMCPJONH.PBIMGBKLDPP();
				//LAB_00f1b7a8:
				while(MHHFMCPJONH.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None/*0*/)
				{
					MHHFMCPJONH.FBANBDCOEJL();
					yield return null;
				}
				//goto LAB_00f1b81c;
				MHHFMCPJONH.LAOEGNLOJHC();
				// To 4
				continue;
			}
			//L445
		//goto LAB_00f1b828;
		// To 4
		}
		
		UnityEngine.Debug.Log("Exit EOFJPNPFGDM_Coroutine_Install");
	}

	// // RVA: 0xF17B50 Offset: 0xF17B50 VA: 0xF17B50
	private void DIDACHONHJA(ref Dictionary<string, int> FAOOOLDDBBB, string CJJJPKJHOGM)
	{
		if(Directory.Exists(CJJJPKJHOGM))
		{
			string[] files = Directory.GetFiles(CJJJPKJHOGM);
			for(int i = 0; i < files.Length; i++)
			{
				string name = files[i].Substring(OGCDNCDMLCA.Length);
				name = name.Replace('\\', '/');
				FAOOOLDDBBB[name] = 1;
			}
			string[] dirs = Directory.GetDirectories(CJJJPKJHOGM);
			for(int i = 0; i < dirs.Length; i++)
			{
				DIDACHONHJA(ref FAOOOLDDBBB, dirs[i]);
			}
		}
	}

	// // RVA: 0xF17D68 Offset: 0xF17D68 VA: 0xF17D68
	public void CIDPPOGCODB(Dictionary<string, int> FAOOOLDDBBB)
	{
		foreach(var item in FAOOOLDDBBB)
		{
			if(item.Value == 1)
			{
				string path = OGCDNCDMLCA + item.Key;
				File.SetAttributes(path, FileAttributes.Normal);
				UnityEngine.Debug.Log("Delete File "+path);
				File.Delete(path);
			}
		}
	}

	// // RVA: 0xF180AC Offset: 0xF180AC VA: 0xF180AC
	private static bool NHIIAHGHOMH(string KLICLHJAMMD, long KPBJHHHMOJE) // check filetime
	{
		return (File.GetLastWriteTime(KLICLHJAMMD) - (CBHCDLLOBBK.AddSeconds(KPBJHHHMOJE))).TotalSeconds >= 2;
	}

	// // RVA: 0xF18248 Offset: 0xF18248 VA: 0xF18248
	private void IAPEABPJPOE(IKAHKDKIGNA CBLEBKOJJDB, ref Dictionary<string, int> FAOOOLDDBBB)
	{
		MD5 md5 = MD5.Create();
		Regex regex = new Regex(@"/db/md-(\d\d\d\d)(\d\d)(\d\d)-(\d\d)(\d\d)(\d\d)_v(\d+)_s1_h\w+.dat");
		POCKENHKOBL = 0;
		PFMPODNDFIB.Clear();
		for(int i = 0; i < CBLEBKOJJDB.KGHAJGGMPKL.Count; i++)
		{
			GCGNICILKLD_AssetFileInfo fileinfo = CBLEBKOJJDB.KGHAJGGMPKL[i];
			string name = fileinfo.OIEAICNAMNB_LocalFileName;
			Match m = regex.Match(name);
			if(m.Success)
			{
				if(m.Groups.Count > 0)
				{
					int val = Int32.Parse(m.Groups[1].Value);
					int val2 = Int32.Parse(m.Groups[2].Value);
					int val3 = Int32.Parse(m.Groups[3].Value);
					int val4 = Int32.Parse(m.Groups[4].Value);
					int val5 = Int32.Parse(m.Groups[5].Value);
					int val6 = Int32.Parse(m.Groups[6].Value);
					long time = Utility.GetTargetUnixTime(val, val2, val3, val4, val5, val6);
					if(DMPNAEEIANJ >= time)
					{
						PFMPODNDFIB.Add(time);
						if(POCKENHKOBL < time)
						{
							POCKENHKOBL = time;
							OCOGBOHOGGE = fileinfo.OIEAICNAMNB_LocalFileName;
						}
					}
				}
			}
		}
		
		for(int i = 0; i < CBLEBKOJJDB.KGHAJGGMPKL.Count; i++)
		{
			string path = OGCDNCDMLCA + CBLEBKOJJDB.KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName;
			Match m = regex.Match(CBLEBKOJJDB.KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName);
			if(!m.Success)
			{
				if(CBLEBKOJJDB.KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName == JNPHAJICDPN) // sd.dat
				{
					ICCMKHKNAMJ.Add(CBLEBKOJJDB.KGHAJGGMPKL[i]);
					continue;
				}
				if(File.Exists(path))
				{
					if(CBLEBKOJJDB.KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName != FNHCECHLIJI && CBLEBKOJJDB.KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName != NLOICACDGNI) // ar_marker.dat / ar_event.dat
					{
						continue;
					}
					
					if(NHIIAHGHOMH(path, CBLEBKOJJDB.KGHAJGGMPKL[i].CALJIGKCAAH_LastUpdated))
					{
						if(IFCHFDEDCGF(md5, path) == CBLEBKOJJDB.KGHAJGGMPKL[i].POEGMFKLFJG_Hash)
						{
							FAOOOLDDBBB[CBLEBKOJJDB.KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName] = 2;
							continue;
						}
					}
				}
			}
			else
			{
				if(m.Groups.Count > 0)
				{
					int val = Int32.Parse(m.Groups[1].Value);
					int val2 = Int32.Parse(m.Groups[2].Value);
					int val3 = Int32.Parse(m.Groups[3].Value);
					int val4 = Int32.Parse(m.Groups[4].Value);
					int val5 = Int32.Parse(m.Groups[5].Value);
					int val6 = Int32.Parse(m.Groups[6].Value);
					long time = Utility.GetTargetUnixTime(val, val2, val3, val4, val5, val6);
					if(time == POCKENHKOBL)
					{
						if(File.Exists(path))
						{
							if(NHIIAHGHOMH(path, CBLEBKOJJDB.KGHAJGGMPKL[i].CALJIGKCAAH_LastUpdated))
							{
								if(IFCHFDEDCGF(md5, path) != CBLEBKOJJDB.KGHAJGGMPKL[i].POEGMFKLFJG_Hash)
								{
									ICCMKHKNAMJ.Add(CBLEBKOJJDB.KGHAJGGMPKL[i]);
									continue;
								}
								FAOOOLDDBBB[CBLEBKOJJDB.KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName] = 2;
							}
							else
							{
								if(IFCHFDEDCGF(md5, path) != CBLEBKOJJDB.KGHAJGGMPKL[i].POEGMFKLFJG_Hash)
								{
									ICCMKHKNAMJ.Add(CBLEBKOJJDB.KGHAJGGMPKL[i]);
									continue;
								}
								FAOOOLDDBBB[CBLEBKOJJDB.KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName] = 2;
							}
						}
						else
						{
							ICCMKHKNAMJ.Add(CBLEBKOJJDB.KGHAJGGMPKL[i]);
						}
					}
				}
			}
		}
		
	}

	// // RVA: 0xF19620 Offset: 0xF19620 VA: 0xF19620
	private bool ALDMHFCFECK(int INDDJNMPONH, float LNAHJANMJNM)
	{
		return true;
	}

	// // RVA: 0xF19628 Offset: 0xF19628 VA: 0xF19628
	// private void EEHMGCMAOAB(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP) { }

	// // RVA: 0xF1961C Offset: 0xF1961C VA: 0xF1961C
	// public static void GFOMKMANCPP(string CJEKGLGBIHF, long KMNPPIKCPNG) { }

	// // RVA: 0xF193D4 Offset: 0xF193D4 VA: 0xF193D4
	private static string IFCHFDEDCGF(MD5 DMIPFEIICDP, string CJEKGLGBIHF)
	{
		FileStream f = File.OpenRead(CJEKGLGBIHF);
		byte[] hash = DMIPFEIICDP.ComputeHash(f);
		string str = "";
		for(int i = 0; i < hash.Length; i++)
		{
			str = str + string.Format("{0:x2}", hash[i]);
		}
		f.Dispose();
		return str;
	}

	// // RVA: 0xF19654 Offset: 0xF19654 VA: 0xF19654
	// private static void ALKHIONADIP(string CJJJPKJHOGM) { }

	// // RVA: 0xF197AC Offset: 0xF197AC VA: 0xF197AC
	private void PKLPEIBEGNO() // save used db version on disk
	{
		string dir = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + KCOGAGGCPBP.HAFLEFNJAKD_DirSys; // /sys
		if(!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
		if(string.IsNullOrEmpty(LHJNPJFNDNA))
			return;
		
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		json["rev"] = LHJNPJFNDNA;
		json["db"] = OCOGBOHOGGE;
		string jsonStr = IKPIMINCOPI_JsonMapper.EJCOJCGIBNG_ToJson(json);
		byte[] data = Encoding.UTF8.GetBytes(jsonStr);
		for(int i = 0; i < data.Length; i++)
		{
			data[i] = (byte)(data[i] ^ 0x1b);
		}
		
		UnityEngine.Debug.Log("Write file "+dir+"/"+KCOGAGGCPBP.HJNJMNFEJEH_File02);
		File.WriteAllBytes(dir+"/"+KCOGAGGCPBP.HJNJMNFEJEH_File02, data); // sys/02
	}

	// // RVA: 0xF19B10 Offset: 0xF19B10 VA: 0xF19B10
	private bool GBCDHECMDMC()
	{
		string dir = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + KCOGAGGCPBP.HAFLEFNJAKD_DirSys; // sys
		if(!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
		string file = dir + "/" + KCOGAGGCPBP.HJNJMNFEJEH_File02; // sys/02
		if(File.Exists(file))
		{
			byte[] data = File.ReadAllBytes(file);
			for(int i = 0; i < data.Length; i++)
			{
				data[i] = (byte)(data[i] ^ 0x1b);
			}
			string jsonStr = Encoding.UTF8.GetString(data);
			EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(jsonStr);
			
			if(json.BBAJPINMOEP_Contains("rev"))
			{
				if(!json.BBAJPINMOEP_Contains("db"))
				{
					if((string)json["rev"] == LHJNPJFNDNA)
					{
						return (string)json["db"] == OCOGBOHOGGE;
					}
				}
			}
		}
		return false;
	}
}

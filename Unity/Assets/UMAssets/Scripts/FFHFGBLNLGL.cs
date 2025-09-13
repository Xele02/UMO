
using System.Collections.Generic;
using System.IO;

public class FFHFGBLNLGL
{
	public class IHJLLOMMCCG
	{
		private int EHOIENNDEDH_IdCrypted; // 0x8
		private int HLMAFFLCCKD; // 0xC
		private int MPBBPNKICGA; // 0x10

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted; } set { EHOIENNDEDH_IdCrypted = value; } } //0x14DDA18 DEMEPMAEJOO 0x14DD31C HIGKAIDMOKN
		public int HMFFHLPNMPH { get { return HLMAFFLCCKD; } set { HLMAFFLCCKD = value; } } //0x14DDA20 NJOGDDPICKG 0x14DD324 NBBGMMBICNA
		public int MBACHPLELHF { get { return MPBBPNKICGA; } set { MPBBPNKICGA = value; } } //0x14DDA28 GBEOFPAFPEL 0x14DD32C GEBBPCBLJLG
	}

	private const int JNCCCCPBDIC = 1;
	private List<IHJLLOMMCCG> DHDCHLAIAMP = new List<IHJLLOMMCCG>(); // 0x8
	private string ELLBAAFKDCH_Filename; // 0xC

	// RVA: 0x14DCCA0 Offset: 0x14DCCA0 VA: 0x14DCCA0
	public FFHFGBLNLGL()
	{
		ELLBAAFKDCH_Filename = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/SaveData/gd";
	}

	//// RVA: 0x14DCD7C Offset: 0x14DCD7C VA: 0x14DCD7C
	//private void KHEKNNFCAOI(string _CJEKGLGBIHF_path) { }

	//// RVA: 0x14DCD84 Offset: 0x14DCD84 VA: 0x14DCD84
	public void PCODDPDFLHK()
	{
		DHDCHLAIAMP.Clear();
		if(File.Exists(ELLBAAFKDCH_Filename))
		{
			FileStream fs = new FileStream(ELLBAAFKDCH_Filename, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			int v = br.ReadInt32();
			int num = br.ReadInt32();
			for(int i = 0; i < num; i++)
			{
				IHJLLOMMCCG data = new IHJLLOMMCCG();
				data.PPFNGGCBJKC_Id = br.ReadInt32();
				data.HMFFHLPNMPH = br.ReadInt32();
				data.MBACHPLELHF = br.ReadInt32();
				//DHDCHLAIAMP.Add(data);
			}
			br.Dispose();
			fs.Dispose();
		}
	}

	//// RVA: 0x14DD334 Offset: 0x14DD334 VA: 0x14DD334
	public void HJMKBCFJOOH()
	{
		string dir = Path.GetDirectoryName(ELLBAAFKDCH_Filename);
		if(!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
		FileStream fs = new FileStream(ELLBAAFKDCH_Filename, FileMode.Create);
		BinaryWriter br = new BinaryWriter(fs);
		br.Write(1);
		br.Write(DHDCHLAIAMP.Count);
		for(int i = 0; i < DHDCHLAIAMP.Count; i++)
		{
			br.Write(DHDCHLAIAMP[i].PPFNGGCBJKC_Id);
			br.Write(DHDCHLAIAMP[i].HMFFHLPNMPH);
			br.Write(DHDCHLAIAMP[i].MBACHPLELHF);
		}
		br.Flush();
		br.Close();
		br.Dispose();
		fs.Dispose();
	}

	//// RVA: 0x14DDA30 Offset: 0x14DDA30 VA: 0x14DDA30
	public void NIFJAPKCPOK(int HHGMPEEGFMA, int BHBHMFCMLHN)
	{
		IHJLLOMMCCG d = DHDCHLAIAMP.Find((IHJLLOMMCCG _GHPLINIACBB_x) =>
		{
			//0x14DE0CC
			return _GHPLINIACBB_x.PPFNGGCBJKC_Id == HHGMPEEGFMA;
		});
		if(d == null)
		{
			d = new IHJLLOMMCCG();
			d.PPFNGGCBJKC_Id = HHGMPEEGFMA;
			DHDCHLAIAMP.Add(d);
		}
		d.HMFFHLPNMPH++;
		d.MBACHPLELHF = BHBHMFCMLHN;
	}

	//// RVA: 0x14DDBB8 Offset: 0x14DDBB8 VA: 0x14DDBB8
	public void INJFPFAJGPK_KeepGachaDraw(int BHBHMFCMLHN)
	{
		while(true)
		{
			int idx = DHDCHLAIAMP.FindIndex((IHJLLOMMCCG _GHPLINIACBB_x) =>
			{
				//0x14DE104
				return _GHPLINIACBB_x.MBACHPLELHF != BHBHMFCMLHN;
			});
			if (idx < 0)
				break;
			DHDCHLAIAMP.RemoveAt(idx);
		}
	}

	//// RVA: 0x14DDD08 Offset: 0x14DDD08 VA: 0x14DDD08
	public void NDLADIBEHAM()
	{
		DHDCHLAIAMP.Clear();
		HJMKBCFJOOH();
	}

	//// RVA: 0x14DDD88 Offset: 0x14DDD88 VA: 0x14DDD88
	public void LDCGCCGDLCB_UpdateSaveGacha(BBHNACPENDM_ServerSaveData LDEGEHAEALK)
	{
		for(int i = 0; i < DHDCHLAIAMP.Count; i++)
		{
			EGOLBAPFHHD_Common.PCHECKGDJDK item = LDEGEHAEALK.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(DHDCHLAIAMP[i].PPFNGGCBJKC_Id);
			if(item == null)
			{
				if(DHDCHLAIAMP[i].MBACHPLELHF == NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD)
				{
					LDEGEHAEALK.KCCLEHLLOFG_Common.NIFJAPKCPOK_SetGachaValue(DHDCHLAIAMP[i].PPFNGGCBJKC_Id, DHDCHLAIAMP[i].MBACHPLELHF);
				}
			}
			else
			{
				if(item.HMFFHLPNMPH < DHDCHLAIAMP[i].HMFFHLPNMPH)
					item.HMFFHLPNMPH = DHDCHLAIAMP[i].HMFFHLPNMPH;
			}
		}
	}
}

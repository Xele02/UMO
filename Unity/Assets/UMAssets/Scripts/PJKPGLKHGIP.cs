
using System.Collections.Generic;
using System.IO;

public class PJKPGLKHGIP
{
	public const int MGFLFGJOIJH = 2;
	public List<int> ONOICEHIHPJ_Ids = new List<int>(2000); // 0x8
	public List<int> KJNJHHHELBK_Dates = new List<int>(2000); // 0xC
	public int PAAFIOOKJIP_ReceivedSns; // 0x10

	//// RVA: 0x937A2C Offset: 0x937A2C VA: 0x937A2C
	//public bool LIPIIKKIKOI(int PPFNGGCBJKC) { }

	//// RVA: 0x937AFC Offset: 0x937AFC VA: 0x937AFC
	//public void ANIJHEBLMGB(int PPFNGGCBJKC, int BEBJKJKBOGH) { }

	//// RVA: 0x937BB0 Offset: 0x937BB0 VA: 0x937BB0
	public void JCHLONCMPAJ(string CJEKGLGBIHF)
	{
		PAAFIOOKJIP_ReceivedSns = 0;
		ONOICEHIHPJ_Ids.Clear();
		KJNJHHHELBK_Dates.Clear();
		if (CJEKGLGBIHF == null)
			return;
		if (File.Exists(CJEKGLGBIHF))
			File.Delete(CJEKGLGBIHF);
	}

	//// RVA: 0x937C8C Offset: 0x937C8C VA: 0x937C8C
	public void HJMKBCFJOOH(string CJEKGLGBIHF)
	{
		FileStream fs = new FileStream(CJEKGLGBIHF, FileMode.Create);
		BinaryWriter bw = new BinaryWriter(fs);
		bw.Write(2);
		bw.Write(ONOICEHIHPJ_Ids.Count);
		bw.Write(PAAFIOOKJIP_ReceivedSns);
		bw.Write(0);
		for(int i = 0; i < ONOICEHIHPJ_Ids.Count; i++)
		{
			bw.Write(ONOICEHIHPJ_Ids[i]);
			bw.Write(KJNJHHHELBK_Dates[i]);
		}
		bw.Flush();
		bw.Close();
		bw.Dispose();
		fs.Dispose();
	}

	//// RVA: 0x9382A0 Offset: 0x9382A0 VA: 0x9382A0
	//public void PCODDPDFLHK(string CJEKGLGBIHF) { }

	//// RVA: 0x9384CC Offset: 0x9384CC VA: 0x9384CC
	public void ADOIBPKFJKB()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns != null)
		{
			for(int i = 0; i < ONOICEHIHPJ_Ids.Count; i++)
			{
				if(((ONOICEHIHPJ_Ids[i] - 1) >> 4) < 125)
				{
					DDEMMEPBOIA_Sns.EFIFBJGKPJF data = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[ONOICEHIHPJ_Ids[i] - 1];
					if(data.BEBJKJKBOGH_Date == 0)
					{
						data.BEBJKJKBOGH_Date = KJNJHHHELBK_Dates[i];
					}
				}
			}
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JLJJHDGEHLK_RecvSns < PAAFIOOKJIP_ReceivedSns)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JLJJHDGEHLK_RecvSns = PAAFIOOKJIP_ReceivedSns;
			}
		}
	}
}

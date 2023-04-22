using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

// Represent a TAR file 
[System.Obsolete("Use CBBJHPBGBAJ_Archive", true)]
public class CBBJHPBGBAJ{}
public class CBBJHPBGBAJ_Archive
{
	public class JBCFNCNGLPM_File
	{
		public string OPFGFINHFCE_Name; // 0x8
		public byte[] DBBGALAPFGC_Data; // 0xC
	}

	private const int HMJJCPMKDEI_BlockSize = 512; // 0x0
	public List<JBCFNCNGLPM_File> KGHAJGGMPKL_Files = new List<JBCFNCNGLPM_File>(10); // 0x8

	// RVA: 0x18F7E78 Offset: 0x18F7E78 VA: 0x18F7E78
	public bool KHEKNNFCAOI_Load(byte[] GANPCOAGBBK_db)
	{
		if(BOBCNJIPPJN.AGJJGJCIMKI(GANPCOAGBBK_db))
		{
			GANPCOAGBBK_db = BOBCNJIPPJN.JCBCBNFPJDH(GANPCOAGBBK_db);
		}
		KGHAJGGMPKL_Files.Clear();
		int offset = 0;
		while(offset < GANPCOAGBBK_db.Length)
		{
			bool res = DLBCLCKFDJP_GetFlag(GANPCOAGBBK_db, offset);
			if(res)
			{
				JBCFNCNGLPM_File data = new JBCFNCNGLPM_File();
				string str = GIFPJBKOFAB_GetFilename(GANPCOAGBBK_db, offset);
				data.OPFGFINHFCE_Name = str;
				int size = CBOIHFIPHGN_GetSize(GANPCOAGBBK_db, offset);
				byte[] dataBytes = new byte[size];
				Buffer.BlockCopy(GANPCOAGBBK_db, offset + HMJJCPMKDEI_BlockSize, dataBytes, 0, size);
				data.DBBGALAPFGC_Data = dataBytes;
				KGHAJGGMPKL_Files.Add(data);
			}
			int end = offset + HMJJCPMKDEI_BlockSize;
			uint size_move = (uint)CBOIHFIPHGN_GetSize(GANPCOAGBBK_db, offset);
			size_move = ((size_move + 511) / HMJJCPMKDEI_BlockSize) * HMJJCPMKDEI_BlockSize;
			{
				uint a = size_move + 511;
				uint b = a >> 31;
				uint check = a + (b << 23);
				check = check & 0xFFFFFE00;
				if(check != size_move)
					Debug.Assert(false);
			}
			offset = end + (int)size_move;
		}
		return true;
	}
	
	// RVA: 0x18F80A0 Offset: 0x18F80A0 VA: 0x18F80A0
	private bool DLBCLCKFDJP_GetFlag(byte[] IAKPCFDLMKP_db, int POMLAOPLMNA_offset)
	{
		int A = POMLAOPLMNA_offset + 156; // ou 148 ??
		byte b = IAKPCFDLMKP_db[A];
		return b == '0'; // Flag is standard file
	}
	
	// RVA: 0x18F8100 Offset: 0x18F8100 VA: 0x18F8100
	private string GIFPJBKOFAB_GetFilename(byte[] IAKPCFDLMKP_db, int POMLAOPLMNA_offset)
	{
		int i = 0;
		for(; i < 99; i++)
		{
			if(IAKPCFDLMKP_db[POMLAOPLMNA_offset + i] == 0)
				break;
		}
		Encoding enc = Encoding.UTF8;
		// +2 to remove the "./" prefix
		string str = enc.GetString(IAKPCFDLMKP_db, POMLAOPLMNA_offset + 2, i - 2);
		return str;
	}
	
	// RVA: 0x18F81E8 Offset: 0x18F81E8 VA: 0x18F81E8
	private int CBOIHFIPHGN_GetSize(byte[] IAKPCFDLMKP_db, int POMLAOPLMNA_offset)
	{
		Encoding enc = Encoding.UTF8;
		string str = enc.GetString(IAKPCFDLMKP_db, POMLAOPLMNA_offset + 124, 12);
		int d = 1;
		int b = 0;
		for(int i = 0; i < str.Length - 1; i++)
		{
			byte c = (byte)str[str.Length - 2 - i];
			byte num = (byte)(c - 48);
			b = num * d + b;
			d = d << 3;
		}
		return b;
	}
	
	// RVA: 0x18F82E8 Offset: 0x18F82E8 VA: 0x18F82E8
	// private int JNJODIPMKFJ(byte[] IAKPCFDLMKP, int POMLAOPLMNA); // RVA: 0x18F82E8 Offset: 0x18F82E8
	
	// RVA: 0x18F830C Offset: 0x18F830C VA: 0x18F830C
    // public string MNNKOKNBJNC(); // RVA: 0x18F830C Offset: 0x18F830C
}

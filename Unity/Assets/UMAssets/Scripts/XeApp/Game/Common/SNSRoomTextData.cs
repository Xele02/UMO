using System;
using System.Collections.Generic;
using System.Text;

namespace XeApp.Game.Common
{
	public class SNSRoomTextData
	{
		public class Header
		{
			public int talkId; // 0x8
			public int startIndex; // 0xC
			public int endIndex; // 0x10
			public int headMessageIndex; // 0x14

			//public int count { get; } 0x138C084
		}

		public class TalkData
		{
			public short charaId; // 0x8
			public sbyte windowShapeId; // 0xA
			public sbyte windowSizeId; // 0xB
			public int messageIndex; // 0xC
			public int timeOffset; // 0x10
		}

		private const int SIGNATURE = 1297043282;
		private const int VER = 2;
		private const int SIZE_OF_TALKDATA = 20;
		private List<int> jumpOffsetTable; // 0x8
		private List<Header> headerList; // 0xC
		private List<TalkData> talkDataList; // 0x10
		private List<string> messageList; // 0x14

		//// RVA: 0x138B510 Offset: 0x138B510 VA: 0x138B510
		public Header FindHeader(int talkId)
		{
			TodoLogger.Log(0, "FindHeader");
			return null;
		}

		//// RVA: 0x138B7E4 Offset: 0x138B7E4 VA: 0x138B7E4
		public string FindMessage(int messageIndex)
		{
			TodoLogger.Log(0, "FindMessage");
			return "";
		}

		//// RVA: 0x138B8AC Offset: 0x138B8AC VA: 0x138B8AC
		public TalkData FindData(int talkIndex)
		{
			TodoLogger.Log(0, "FindData");
			return null;
		}

		//// RVA: 0x138B92C Offset: 0x138B92C VA: 0x138B92C
		public bool Init(byte[] dataBytes, int offset)
		{
			int signature = BitConverter.ToInt32(dataBytes, offset);
			int version = BitConverter.ToInt32(dataBytes, offset + 4);
			if(signature == SIGNATURE && version == VER)
			{
				int num = BitConverter.ToInt32(dataBytes, offset + 8);
				jumpOffsetTable = new List<int>(num);
				int off = offset + 12;
				for(int i = 0; i < num; i++)
				{
					jumpOffsetTable.Add(BitConverter.ToInt32(dataBytes, off));
					off += 4;
				}
				num = BitConverter.ToInt32(dataBytes, off);
				off += 4;
				headerList = new List<Header>(num);
				for(int i = 0; i < num; i++)
				{
					Header header = new Header();
					header.talkId = BitConverter.ToInt32(dataBytes, off);
					header.headMessageIndex = BitConverter.ToInt32(dataBytes, off + 4);
					header.startIndex = BitConverter.ToInt32(dataBytes, off + 8);
					header.endIndex = BitConverter.ToInt32(dataBytes, off + 12);
					headerList.Add(header);
					off += 16;
				}
				num = BitConverter.ToInt32(dataBytes, off);
				off += 4;
				talkDataList = new List<TalkData>(num);
				for(int i = 0; i < num; i++)
				{
					TalkData data = new TalkData();
					data.charaId = BitConverter.ToInt16(dataBytes, off);
					data.windowShapeId = (sbyte)dataBytes[off + 2];
					data.windowSizeId = (sbyte)dataBytes[off + 3];
					data.messageIndex = BitConverter.ToInt32(dataBytes, off + 4);
					data.timeOffset = BitConverter.ToInt32(dataBytes, off + 8);
					talkDataList.Add(data);
					off += 12;
				}
				num = BitConverter.ToInt32(dataBytes, off);
				off += 4;
				messageList = new List<string>(num);
				int strBaseOff = off + num * 8;
				for(int i = 0; i < num; i++)
				{
					int strOff = BitConverter.ToInt32(dataBytes, off);
					int strSize = BitConverter.ToInt32(dataBytes, off + 4);
					messageList.Add(Encoding.UTF8.GetString(dataBytes, strBaseOff + strOff, strSize));
				}
				return true;
			}
			return false;
		}
	}
}

using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        private class InternalBindInfo
        {
            public CriFsBinder binder;
            public CriFsBinder srcBinder;
            public string path;
            public IntPtr work;
            public int worksize;
            public CriFsBinder.Status status;
            public byte[] fileData;
            public FileInfo fileInfo;
        }

        private static Dictionary<uint, InternalBindInfo> bindList = new  Dictionary<uint, InternalBindInfo>();
        private static uint bindCnt = 0;

        public static uint criFsBinder_BindFile(/*IntPtr*/CriFsBinder binder, /*IntPtr*/CriFsBinder srcBinder, string path, IntPtr work, int worksize, out uint bindId)
        {
            InternalBindInfo info = new InternalBindInfo();
            info.binder = binder;
            info.srcBinder = srcBinder;
            info.path = path;
            info.work = work;
            info.worksize = worksize;
            info.status = CriFsBinder.Status.Analyze;
            info.fileInfo = GetFileInfo(path);
            bindId = ++bindCnt;
            bindList[bindId] = info;
            return 0;
        }

        public static int criFsBinder_GetStatus(uint bindId, out CriFsBinder.Status status)
        {
            if(bindList.ContainsKey(bindId))
            {
                status = bindList[bindId].status;
            }
            else
            {
                status = CriFsBinder.Status.Invalid;
            }
            return 0;
        }

        public static int criFsBinder_GetFileSize(CriFsBinder binder, string path, out long size)
        {
            FileInfo fi = GetFileInfo(path);
            size = -1;
            if(fi.Exists)
            {
                size = fi.Length;
            }
            return 0;
        }

        public static uint criFsBinder_Destroy(CriFsBinder binder)
        {
            foreach(var item in bindList)
            {
                if(item.Value.binder == binder)
                {
                    bindList.Remove(item.Key);
                    break;
                }
            }
            return 0;
        }
		
		public static uint criFsBinder_Create(out IntPtr binder)
		{
			binder = new IntPtr(1);
			return 0;
		}
    }
}

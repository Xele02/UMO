using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        public static int criFsLoader_Load(CriFsLoader loader, CriFsBinder binder, string path, long offset, long load_size, byte[] buffer, long buffer_size)
        {
            FileInfo fi = GetFileInfo(path);
            if(fi.Exists)
            {
                byte[] data = File.ReadAllBytes(fi.FullName);
                Buffer.BlockCopy(data, (int)offset, buffer, 0, (int)load_size);
            }

            return 0;
        }

        public static int criFsLoader_GetStatus(CriFsLoader loader, out CriFsLoader.Status status)
        {
            status = CriFsLoader.Status.Complete; // Load is instant for now
            return 0;
        }

        public static int criFsLoader_Destroy(CriFsLoader loader)
        {
            return 0;
        }
		
		public static int criFsLoader_Create(out IntPtr loader)
		{
			loader = new IntPtr(1);
			return 0;
		}
    }
}
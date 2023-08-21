package jp.co.xeen.xeapp;

import android.os.StatFs;

public class StorageSupport {
   public static int getAvailableStorageSizeMB(String var0) {
      StatFs var1 = new StatFs(var0);
      return (int)(var1.getAvailableBlocksLong() * var1.getBlockSizeLong() / 1048576L);
   }
}

package jp.co.xeen.xeapp;

import android.app.Activity;
import android.os.Build;
import com.unity3d.player.UnityPlayer;

public class PermissionManager {
    public static void requestPermission(String str) {
        Activity activity = UnityPlayer.currentActivity;
        if (hasPermission(str) || 23 > Build.VERSION.SDK_INT) {
            return;
        }
        activity.requestPermissions(new String[]{str}, 0);
    }

    public static boolean hasPermission(String str) {
        return Build.VERSION.SDK_INT < 23 || UnityPlayer.currentActivity.getApplicationContext().checkCallingOrSelfPermission(str) == 0;
    }
}
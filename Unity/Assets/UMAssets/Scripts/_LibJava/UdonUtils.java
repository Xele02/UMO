package jp.co.xeen.xeapp;

import android.annotation.TargetApi;
import android.media.MediaActionSound;
import android.os.Build;
import android.os.Handler;
import com.unity3d.player.UnityPlayer;

public class UdonUtils {
    private static MediaActionSound m_mas;

    private UdonUtils() {
    }

    @TargetApi(16)
    public static void playSystemShutterSound() {
        if (Build.VERSION.SDK_INT < 16) {
            return;
        }
        if (m_mas == null) {
            m_mas = new MediaActionSound();
        }
        m_mas.load(0);
        new Handler(UnityPlayer.currentActivity.getMainLooper()).postDelayed(new Runnable() { // from class: jp.co.xeen.xeapp.UdonUtils.1
            @Override // java.lang.Runnable
            public void run() {
                UdonUtils.m_mas.play(0);
            }
        }, 100L);
    }

    public static boolean checkCameraHardware() {
        return UnityPlayer.currentActivity.getApplicationContext().getPackageManager().hasSystemFeature("android.hardware.camera");
    }
}
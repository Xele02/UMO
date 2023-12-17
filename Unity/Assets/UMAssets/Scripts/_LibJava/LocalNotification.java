package jp.co.xeen.xeapp;

import android.app.Activity;
import android.app.AlarmManager;
import android.app.AppOpsManager;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.net.Uri;
import android.os.Build;
import androidx.core.app.NotificationCompat;
import android.util.Log;
import com.unity3d.player.UnityPlayer;
import java.lang.reflect.InvocationTargetException;

public class LocalNotification {
    private static final String CHECK_OP_NO_THROW = "checkOpNoThrow";
    private static final String OP_POST_NOTIFICATION = "OP_POST_NOTIFICATION";

    public static class Receiver extends BroadcastReceiver {
        @Override // android.content.BroadcastReceiver
        public void onReceive(Context context, Intent intent) {
            /*if (OverrideUnityPlayerNativeActivity.isActive()) {
                return;
            }*/
            int intExtra = intent.getIntExtra("xe_prime_key", 0);
            String stringExtra = intent.getStringExtra("xe_message");
            intent.getStringExtra("xe_ticker");
            String stringExtra2 = intent.getStringExtra("xe_title");
            intent.getStringExtra("xe_image");
            String stringExtra3 = intent.getStringExtra("xe_channel");
            PendingIntent activity = PendingIntent.getActivity(context, intExtra, context.getPackageManager().getLaunchIntentForPackage(context.getPackageName()), PendingIntent.FLAG_CANCEL_CURRENT);
            int identifier = context.getResources().getIdentifier("icon", "drawable", context.getPackageName());
            if (identifier == 0) {
                identifier = context.getResources().getIdentifier("my_app_icon", "drawable", context.getPackageName());
            }
            int identifier2 = context.getResources().getIdentifier("colorAccent", "color", context.getPackageName());
            try {
                NotificationCompat.Builder builder = new NotificationCompat.Builder(context, stringExtra3);
                builder.setContentIntent(activity);
                builder.setContentTitle(stringExtra2);
                builder.setContentText(stringExtra);
                builder.setSmallIcon(identifier);
                if (identifier2 != 0) {
                    builder.setColor(context.getResources().getColor(identifier2));
                }
                builder.setWhen(System.currentTimeMillis());
                builder.setDefaults(-1);
                builder.setAutoCancel(true);
                ((NotificationManager) context.getSystemService("notification")).notify(intExtra, builder.build());
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    public static void send(long j, int i, String str, String str2, String str3, String str4, String str5) {
        try {
            Activity activity = UnityPlayer.currentActivity;
            Context applicationContext = activity.getApplicationContext();
            Intent intent = new Intent(applicationContext, Receiver.class);
            intent.putExtra("xe_prime_key", i);
            intent.putExtra("xe_ticker", str);
            intent.putExtra("xe_title", str2);
            intent.putExtra("xe_message", str3);
            intent.putExtra("xe_image", str4);
            intent.putExtra("xe_channel", str5);
            ((AlarmManager) applicationContext.getSystemService(NotificationCompat.CATEGORY_ALARM)).set(0, j * 1000, PendingIntent.getBroadcast(activity, i, intent, 134217728));
        } catch (SecurityException e) {
            e.printStackTrace();
        }
    }

    public static void send(long j, int i, String str, String str2, String str3, String str4) {
        send(j, i, str, str2, str3, str4, "info");
    }

    public static void clear(int i) {
        Context applicationContext = UnityPlayer.currentActivity.getApplicationContext();
        PendingIntent broadcast = PendingIntent.getBroadcast(applicationContext, i, new Intent(applicationContext, Receiver.class), PendingIntent.FLAG_CANCEL_CURRENT);
        ((AlarmManager) applicationContext.getSystemService(NotificationCompat.CATEGORY_ALARM)).cancel(broadcast);
        broadcast.cancel();
    }

    public static boolean isNotificationEnabled() {
        Context applicationContext = UnityPlayer.currentActivity.getApplicationContext();
        ApplicationInfo applicationInfo = applicationContext.getApplicationInfo();
        String packageName = applicationContext.getPackageName();
        if (Build.VERSION.SDK_INT >= 18) {
            int i = applicationInfo.uid;
            try {
                AppOpsManager appOpsManager = (AppOpsManager) applicationContext.getSystemService("appops");
                Class<?> cls = Class.forName(AppOpsManager.class.getName());
                return ((Integer) cls.getMethod(CHECK_OP_NO_THROW, Integer.TYPE, Integer.TYPE, String.class).invoke(appOpsManager, Integer.valueOf(((Integer) cls.getDeclaredField(OP_POST_NOTIFICATION).get(Integer.class)).intValue()), Integer.valueOf(i), packageName)).intValue() == 0;
            } catch (ClassNotFoundException e) {
                e.printStackTrace();
            } catch (IllegalAccessException e2) {
                e2.printStackTrace();
            } catch (NoSuchFieldException e3) {
                e3.printStackTrace();
            } catch (NoSuchMethodException e4) {
                e4.printStackTrace();
            } catch (InvocationTargetException e5) {
                e5.printStackTrace();
            }
        }
        return false;
    }

    public static void openNotificationSetting() {
        Activity activity = UnityPlayer.currentActivity;
        activity.startActivity(new Intent("android.settings.APPLICATION_DETAILS_SETTINGS", Uri.parse("package:" + activity.getApplicationContext().getPackageName())));
    }
}
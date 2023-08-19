package com.crimw.crijavaclasses;

import android.content.Context;
import android.app.Activity;
import android.content.IntentFilter;
import android.content.Intent;
import android.content.BroadcastReceiver;
import android.media.AudioManager;

import com.unity3d.player.UnityPlayer;

public class CriOutputDeviceObserver {
   private static OutputDeviceStateReceiver receiver;

   public CriOutputDeviceObserver(Activity var1, String var2, String var3) {
      receiver = new OutputDeviceStateReceiver(var1, var2, var3);
   }

   public int CheckOutputDeviceType(Activity var1) {
      return receiver.getOutputDeviceType(var1);
   }

   public boolean IsDeviceConnected() {
      return receiver.isConnected();
   }

   public void Start(Activity var1) {
      IntentFilter var2 = new IntentFilter();
      var2.addAction("android.media.AUDIO_BECOMING_NOISY");
      var2.addAction("android.intent.action.HEADSET_PLUG");
      var2.addAction("android.media.ACTION_SCO_AUDIO_STATE_UPDATED");
      var2.addAction("android.bluetooth.a2dp.profile.action.CONNECTION_STATE_CHANGED");
      var1.registerReceiver(receiver, var2);
   }

   public void Stop(Activity var1) {
      var1.unregisterReceiver(receiver);
   }


   class OutputDeviceStateReceiver extends BroadcastReceiver {
      private OutputDeviceType device_type;
      private String gameObjectName;
      private boolean is_connected;
      private String methodName;

      public OutputDeviceStateReceiver(Activity var2, String var3, String var4) {
         this.is_connected = false;
         this.device_type = OutputDeviceType.BuiltinSpeaker;
         this.gameObjectName = null;
         this.methodName = null;
         this.gameObjectName = var3;
         this.methodName = var4;
         this.checkOutputDeviceType(var2);
      }

      private void checkOutputDeviceType(Activity var1) {
         AudioManager var2 = (AudioManager)var1.getSystemService("audio");
         if (var2.isWiredHeadsetOn()) {
            this.is_connected = true;
            this.device_type = OutputDeviceType.WiredDevice;
         } else if (!var2.isBluetoothA2dpOn() && !var2.isBluetoothScoOn()) {
            this.is_connected = false;
            this.device_type = OutputDeviceType.BuiltinSpeaker;
         } else {
            this.is_connected = true;
            this.device_type = OutputDeviceType.WirelessDevice;
         }

      }

      public int getOutputDeviceType(Activity var1) {
         this.checkOutputDeviceType(var1);
         return this.device_type.getInt();
      }

      public boolean isConnected() {
         return this.is_connected;
      }

      public void onReceive(Context var1, Intent var2) {
         if (!"android.media.AUDIO_BECOMING_NOISY".equals(var2.getAction()) && !"android.intent.action.HEADSET_PLUG".equals(var2.getAction()) && !"android.media.ACTION_SCO_AUDIO_STATE_UPDATED".equals(var2.getAction())) {
            if ("android.bluetooth.a2dp.profile.action.CONNECTION_STATE_CHANGED".equals(var2.getAction())) {
               UnityPlayer.UnitySendMessage(this.gameObjectName, this.methodName, "b");
            }
         } else {
            UnityPlayer.UnitySendMessage(this.gameObjectName, this.methodName, "a");
         }

      }

      public void setConnectedState(boolean var1) {
         this.is_connected = var1;
      }
   }

   enum OutputDeviceType {
      BuiltinSpeaker(0),
      WiredDevice(1),
      WirelessDevice(2);

      private final int id;
   
      private OutputDeviceType(int var3) {
         this.id = var3;
      }
   
      public int getInt() {
         return this.id;
      }
   }
   
}

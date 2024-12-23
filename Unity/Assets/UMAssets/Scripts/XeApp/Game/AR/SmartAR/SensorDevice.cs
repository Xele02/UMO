
using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public class SensorDevice : IDisposable
    {
        private delegate void SensorListenerDelegate(IntPtr state);
        private class MonoPInvokeCallbackAttribute : Attribute
        {
            protected Type type; // 0x8

            // RVA: 0x2B48E68 Offset: 0x2B48E68 VA: 0x2B48E68
            public MonoPInvokeCallbackAttribute(Type t)
            {
                type = t;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ProxyListeners
        {
            public IntPtr sensorListener_; // 0x0
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ProxyListenerDelegates
        {
            public IntPtr sensorListenerDelegate_; // 0x0
}

        public IntPtr self_; // 0x8
        private static SensorDevice thisObj_; // 0x0
        private ProxyListenerDelegates proxyListenerDelegates_; // 0xC
        private ProxyListeners proxyListeners_; // 0x10
        private SensorListener sensorListener_; // 0x14
        private SensorState sensorState_ = new SensorState(IntPtr.Zero); // 0x18

        // RVA: 0x2B47E3C Offset: 0x2B47E3C VA: 0x2B47E3C
        public SensorDevice(Smart smart) : this(smart, IntPtr.Zero)
        {
            //
        }

        // RVA: 0x2B47E9C Offset: 0x2B47E9C VA: 0x2B47E9C
        public SensorDevice(Smart smart, IntPtr nativeDevice)
        {
            self_ = sarSmartar_SarSensorDevice_SarSensorDevice(smart.self_, nativeDevice);
            proxyListenerDelegates_.sensorListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new SensorListenerDelegate(OnSensor));
            sarSmartar_SarSensorDeviceProxyListeners_sarCreate(ref proxyListenerDelegates_, out proxyListeners_);
        }

        // RVA: 0x2B4824C Offset: 0x2B4824C VA: 0x2B4824C Slot: 1
        ~SensorDevice()
        {
            Dispose();
        }

        // RVA: 0x2B482B0 Offset: 0x2B482B0 VA: 0x2B482B0 Slot: 4
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarSensorDevice_sarDelete(self_);
                self_ = IntPtr.Zero;
                sarSmartar_SarSensorDeviceProxyListeners_sarDelete(ref proxyListeners_);
                thisObj_ = null;
            }
        }

        [MonoPInvokeCallbackAttribute(typeof(SensorListenerDelegate))] // RVA: 0x5E0C2C Offset: 0x5E0C2C VA: 0x5E0C2C
        // // RVA: 0x2B47C54 Offset: 0x2B47C54 VA: 0x2B47C54
        private static void OnSensor(IntPtr state)
        {
            thisObj_.sensorState_.self_ = state;
            thisObj_.sensorListener_.OnSensor(thisObj_.sensorState_);
            thisObj_.sensorState_.self_ = IntPtr.Zero;
        }

        // // RVA: 0x2B48150 Offset: 0x2B48150 VA: 0x2B48150
#if UNITY_EDITOR
        private static void sarSmartar_SarSensorDeviceProxyListeners_sarCreate(ref SensorDevice.ProxyListenerDelegates delegates, out SensorDevice.ProxyListeners listeners)
        {
            listeners = new ProxyListeners();
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarSensorDeviceProxyListeners_sarCreate(ref SensorDevice.ProxyListenerDelegates delegates, out SensorDevice.ProxyListeners listeners);
#endif

        // // RVA: 0x2B48460 Offset: 0x2B48460 VA: 0x2B48460
#if UNITY_EDITOR
        private static void sarSmartar_SarSensorDeviceProxyListeners_sarDelete(ref SensorDevice.ProxyListeners listeners)
        {
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarSensorDeviceProxyListeners_sarDelete(ref SensorDevice.ProxyListeners listeners);
#endif

        // // RVA: 0x2B48554 Offset: 0x2B48554 VA: 0x2B48554
        // public int SetSensorListener(SensorListener listener) { }

        // // RVA: 0x2B486E8 Offset: 0x2B486E8 VA: 0x2B486E8
        // public int SetOwningNativeDevice(bool isOwning) { }

        // // RVA: 0x2B48874 Offset: 0x2B48874 VA: 0x2B48874
        public int GetDeviceInfo(SensorDeviceInfo info)
        {
            return sarSmartar_SarSensorDevice_sarGetDeviceInfo(self_, info.self_);
        }

        // // RVA: 0x2B48A0C Offset: 0x2B48A0C VA: 0x2B48A0C
        // public int GetNativeDevice(out IntPtr nativeDevice) { }

        // // RVA: 0x2B48B90 Offset: 0x2B48B90 VA: 0x2B48B90
        public int Start()
        {
            return sarSmartar_SarSensorDevice_sarStart(self_);
        }

        // RVA: 0x2B48CFC Offset: 0x2B48CFC VA: 0x2B48CFC
        public int Stop()
        {
            return sarSmartar_SarSensorDevice_sarStop(self_);
        }

#if UNITY_EDITOR
        private static IntPtr sarSmartar_SarSensorDevice_SarSensorDevice(IntPtr smart, IntPtr nativeDevice)
        {
            return IntPtr.Zero;
        }
#else
        // // RVA: 0x2B48048 Offset: 0x2B48048 VA: 0x2B48048
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarSensorDevice_SarSensorDevice(IntPtr smart, IntPtr nativeDevice);
#endif

        // // RVA: 0x2B48378 Offset: 0x2B48378 VA: 0x2B48378
#if UNITY_EDITOR
        private static void sarSmartar_SarSensorDevice_sarDelete(IntPtr self)
        {
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarSensorDevice_sarDelete(IntPtr self);
#endif

        // // RVA: 0x2B485F0 Offset: 0x2B485F0 VA: 0x2B485F0
        // private static extern int sarSmartar_SarSensorDevice_sarSetSensorListener(IntPtr self, IntPtr listener) { }

        // // RVA: 0x2B48778 Offset: 0x2B48778 VA: 0x2B48778
        // private static extern int sarSmartar_SarSensorDevice_sarSetOwningNativeDevice(IntPtr self, bool isOwning) { }

        // // RVA: 0x2B48918 Offset: 0x2B48918 VA: 0x2B48918
#if UNITY_EDITOR
        private static int sarSmartar_SarSensorDevice_sarGetDeviceInfo(IntPtr self, IntPtr info)
        {
            return 0;
        }
#else
        [DllImport("smartar")]
        private static extern int sarSmartar_SarSensorDevice_sarGetDeviceInfo(IntPtr self, IntPtr info);
#endif

        // // RVA: 0x2B48A98 Offset: 0x2B48A98 VA: 0x2B48A98
        // private static extern int sarSmartar_SarSensorDevice_sarGetNativeDevice(IntPtr self, out IntPtr nativeDevice) { }

        // // RVA: 0x2B48C18 Offset: 0x2B48C18 VA: 0x2B48C18
#if UNITY_EDITOR
        private static int sarSmartar_SarSensorDevice_sarStart(IntPtr self)
        {
            return 0;
        }
#else
        [DllImport("smartar")]
        private static extern int sarSmartar_SarSensorDevice_sarStart(IntPtr self);
#endif

        // // RVA: 0x2B48D80 Offset: 0x2B48D80 VA: 0x2B48D80
#if UNITY_EDITOR
        private static int sarSmartar_SarSensorDevice_sarStop(IntPtr self)
        {
            return 0;
        }
#else
        [DllImport("smartar")]
        private static extern int sarSmartar_SarSensorDevice_sarStop(IntPtr self);
#endif
    }
}
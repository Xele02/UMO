﻿using LibVLCSharp.Shared.Helpers;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibVLCSharp.Shared
{
    /// <summary>
    /// The renderer discoverer can be used to find and use a Chromecast or other distant renderers.
    /// </summary>
    public class RendererDiscoverer// : Internal
    {
/*        RendererDiscovererEventManager? _eventManager;
        const string Bonjour = "Bonjour_renderer";
        const string Mdns = "microdns_renderer";

        readonly struct Native
        {
            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_discoverer_new")]
            internal static extern IntPtr LibVLCRendererDiscovererNew(IntPtr libvlc, IntPtr name);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_discoverer_release")]
            internal static extern void LibVLCRendererDiscovererRelease(IntPtr rendererDiscoverer);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_discoverer_start")]
            internal static extern int LibVLCRendererDiscovererStart(IntPtr rendererDiscoverer);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_discoverer_stop")]
            internal static extern void LibVLCRendererDiscovererStop(IntPtr rendererDiscoverer);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_discoverer_event_manager")]
            internal static extern IntPtr LibVLCRendererDiscovererEventManager(IntPtr rendererDiscoverer);
        }

        /// <summary>
        /// Create a new renderer discoverer with a LibVLC and protocol name depending on host platform
        /// </summary>
        /// <param name="libVLC">libvlc instance this will be connected to</param>
        /// <param name="name">
        /// The service discovery protocol name depending on platform. Use <see cref="LibVLC.RendererList"/> to find the one for your platform,
        /// or let libvlcsharp find it for you
        /// </param>
        public RendererDiscoverer(LibVLC libVLC, string name = null)
            : base(() =>
            {
                if(string.IsNullOrEmpty(name))
                {
#if APPLE
                    name = Bonjour;
#else
                    name = Mdns;
#endif
                }

                var nameUtf8 = name.ToUtf8();
                return MarshalUtils.PerformInteropAndFree(() => 
                    Native.LibVLCRendererDiscovererNew(libVLC.NativeReference, nameUtf8), nameUtf8);
            }, Native.LibVLCRendererDiscovererRelease)
        {
        }

        private RendererDiscovererEventManager EventManager
        {
            get
            {
                if (_eventManager == null)
                {
                    var eventManagerPtr = Native.LibVLCRendererDiscovererEventManager(NativeReference);
                    _eventManager = new RendererDiscovererEventManager(eventManagerPtr);
                }
                return _eventManager;
            }
        }

        /// <summary>
        /// Start the renderer discovery
        /// </summary>
        /// <returns>true if start successful</returns>
        public bool Start() => Native.LibVLCRendererDiscovererStart(NativeReference) == 0;

        /// <summary>
        /// Stop the renderer discovery
        /// </summary>
        public void Stop() => Native.LibVLCRendererDiscovererStop(NativeReference);

        /// <summary>
        /// Raised when a renderer item has been found
        /// </summary>
        public event EventHandler<RendererDiscovererItemAddedEventArgs> ItemAdded
        {
            add => EventManager.AttachEvent(EventType.RendererDiscovererItemAdded, value);
            remove => EventManager.DetachEvent(EventType.RendererDiscovererItemAdded, value);
        }

        /// <summary>
        /// Raised when a renderer item has disappeared
        /// </summary>
        public event EventHandler<RendererDiscovererItemDeletedEventArgs> ItemDeleted
        {
            add => EventManager.AttachEvent(EventType.RendererDiscovererItemDeleted, value);
            remove => EventManager.DetachEvent(EventType.RendererDiscovererItemDeleted, value);
        }
    }

    /// <summary>
    /// A renderer item represents a device that libvlc can use to render media.
    /// </summary>
    public class RendererItem : Internal
    {
        const int VideoRenderer = 0x0002;
        const int AudioRenderer = 0x0001;

        readonly struct Native
        {
            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_item_name")]
            internal static extern IntPtr LibVLCRendererItemName(IntPtr rendererItem);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_item_release")]
            internal static extern void LibVLCRendererItemRelease(IntPtr rendererItem);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_item_hold")]
            internal static extern IntPtr LibVLCRendererItemHold(IntPtr rendererItem);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_item_type")]
            internal static extern IntPtr LibVLCRendererItemType(IntPtr rendererItem);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_item_icon_uri")]
            internal static extern IntPtr LibVLCRendererItemIconUri(IntPtr rendererItem);

            [DllImport(Constants.LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libvlc_renderer_item_flags")]
            internal static extern int LibVLCRendererItemFlags(IntPtr rendererItem);
        }

        internal RendererItem(IntPtr reference) : 
            base(() => reference, Native.LibVLCRendererItemRelease)
        {
            Native.LibVLCRendererItemHold(reference);
        }

        /// <summary>
        /// Name of the renderer item
        /// </summary>
        public string Name => Native.LibVLCRendererItemName(NativeReference).FromUtf8()!;

        /// <summary>
        /// Type of the renderer item
        /// </summary>
        public string Type => Native.LibVLCRendererItemType(NativeReference).FromUtf8()!;

        /// <summary>
        /// IconUri of the renderer item
        /// </summary>
        public string IconUri => Native.LibVLCRendererItemIconUri(NativeReference).FromUtf8();

        /// <summary>
        /// true if the renderer item can render video
        /// </summary>
        public bool CanRenderVideo => (Native.LibVLCRendererItemFlags(NativeReference) & VideoRenderer) != 0;

        /// <summary>
        /// true if the renderer item can render audio
        /// </summary>
        public bool CanRenderAudio => (Native.LibVLCRendererItemFlags(NativeReference) & AudioRenderer) != 0;*/
    }
}

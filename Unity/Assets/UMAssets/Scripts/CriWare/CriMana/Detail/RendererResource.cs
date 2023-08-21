using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace CriWare.CriMana.Detail
{
	public abstract class RendererResource : IDisposable
	{
		private bool disposed; // 0x8
		protected Shader shader; // 0xC
		protected Material currentMaterial; // 0x10
		protected bool hasAlpha; // 0x14
		protected bool additive; // 0x15
		protected bool applyTargetAlpha; // 0x16
		protected bool ui; // 0x17

		// RVA: 0x2951610 Offset: 0x2951610 VA: 0x2951610 Slot: 1
		~RendererResource()
		{
			Dispose(false);
		}

		// RVA: 0x29516EC Offset: 0x29516EC VA: 0x29516EC Slot: 4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// // RVA: 0x2951698 Offset: 0x2951698 VA: 0x2951698
		private void Dispose(bool disposing)
		{
			if (disposed) {
				return;
			}
			if (disposing) {
				OnDisposeManaged();
			}
			OnDisposeUnmanaged();
			disposed = true;
		}

		// // RVA: 0x29517AC Offset: 0x29517AC VA: 0x29517AC
		public int GetNumberOfFrameBeforeDestroy(int playerId)
		{
			return CRIWARE9BAE0415(playerId);
		}

		// // RVA: 0x29518C4 Offset: 0x29518C4 VA: 0x29518C4
		protected void SetupStaticMaterialProperties()
		{
			if(currentMaterial == null)
				return;
			int srcBlendMode = (int)UnityEngine.Rendering.BlendMode.SrcAlpha;
			int dstBlendMode = (int)UnityEngine.Rendering.BlendMode.Zero;
			if(!additive)
				dstBlendMode = (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha;
			else
			{
				srcBlendMode = (int)UnityEngine.Rendering.BlendMode.One;
				dstBlendMode = (int)UnityEngine.Rendering.BlendMode.One;
				if(hasAlpha)
					dstBlendMode = (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha;
			}
			if(currentMaterial.shader != shader)
			{
				currentMaterial.shader = shader;
			}
			currentMaterial.SetInt("_SrcBlendMode", srcBlendMode);
			currentMaterial.SetInt("_DstBlendMode", dstBlendMode);
			currentMaterial.SetInt("_CullMode", ui ? 0 : 2);
			currentMaterial.SetInt("_ZWriteMode", ui ? 0 : 1);
			if(hasAlpha)
			{
				currentMaterial.EnableKeyword("CRI_ALPHA_MOVIE");
			}
			if(applyTargetAlpha)
			{
				currentMaterial.EnableKeyword("CRI_APPLY_TARGET_ALPHA");
			}
			if(QualitySettings.activeColorSpace == ColorSpace.Linear)
				currentMaterial.EnableKeyword("CRI_LINEAR_COLORSPACE");
		}

		// // RVA: 0x2951BC4 Offset: 0x2951BC4 VA: 0x2951BC4
		// private void GetBlendModes(out int srcBlendMode, out int dstBlendMode) { }

		// // RVA: 0x2951C04 Offset: 0x2951C04 VA: 0x2951C04 Slot: 5
		public virtual void SetApplyTargetAlpha(bool flag)
		{
			applyTargetAlpha = flag;
			SetupStaticMaterialProperties();
		}

		// // RVA: 0x2951C0C Offset: 0x2951C0C VA: 0x2951C0C Slot: 6
		public virtual void SetUiRenderMode(bool flag)
		{
			ui = flag;
			SetupStaticMaterialProperties();
		}

		// // RVA: -1 Offset: -1 Slot: 7
		protected abstract void OnDisposeManaged();

		// // RVA: -1 Offset: -1 Slot: 8
		protected abstract void OnDisposeUnmanaged();

		// // RVA: -1 Offset: -1 Slot: 9
		public abstract bool IsPrepared();

		// // RVA: -1 Offset: -1 Slot: 10
		// public abstract bool ContinuePreparing();

		// // RVA: -1 Offset: -1 Slot: 11
		public abstract void AttachToPlayer(int playerId);

		// // RVA: -1 Offset: -1 Slot: 12
		public abstract bool UpdateFrame(int playerId, FrameInfo frameInfo, ref bool frameDrop);

		// // RVA: -1 Offset: -1 Slot: 13
		public abstract bool UpdateMaterial(Material material);

		// // RVA: -1 Offset: -1 Slot: 14
		public abstract void UpdateTextures();

		// // RVA: -1 Offset: -1 Slot: 15
		public abstract bool IsSuitable(int playerId, MovieInfo movieInfo, bool additive, Shader userShader);

		// // RVA: 0x2951C14 Offset: 0x2951C14 VA: 0x2951C14 Slot: 16
		public virtual void OnPlayerPause(bool pauseStatus)
		{
			return;
		}

		// // RVA: 0x2951C18 Offset: 0x2951C18 VA: 0x2951C18 Slot: 17
		// public virtual bool OnPlayerStopForSeek() { }

		// // RVA: 0x2951C20 Offset: 0x2951C20 VA: 0x2951C20 Slot: 18
		public virtual void OnPlayerStart()
		{
			return;
		}

		// // RVA: 0x2951C24 Offset: 0x2951C24 VA: 0x2951C24 Slot: 19
		public virtual bool ShouldSkipDestroyOnStopForSeek()
		{
			return false;
		}

		// // RVA: 0x2951C2C Offset: 0x2951C2C VA: 0x2951C2C Slot: 20
		// public virtual bool HasRenderedNewFrame() { }

		// // RVA: 0x2951C34 Offset: 0x2951C34 VA: 0x2951C34
		// public static uint NextPowerOfTwo(uint x) { }

		// // RVA: 0x2951C54 Offset: 0x2951C54 VA: 0x2951C54
		// public static int NextPowerOfTwo(int x) { }

		// // RVA: 0x2951C74 Offset: 0x2951C74 VA: 0x2951C74
		public static int CeilingWith(int x, int ceilingValue)
		{
			return (x+ceilingValue-1) & -ceilingValue;
		}

		// // RVA: 0x2951C88 Offset: 0x2951C88 VA: 0x2951C88
		public static int Ceiling16(int x)
		{
			return (x+15)& -16;
		}

		// // RVA: 0x2951C94 Offset: 0x2951C94 VA: 0x2951C94
		public static int Ceiling32(int x)
		{
			return (x+31)& -32;
		}

		// // RVA: 0x2951CA0 Offset: 0x2951CA0 VA: 0x2951CA0
		public static int Ceiling64(int x)
		{
			return (x+63)& -64;
		}

		// // RVA: 0x2951CAC Offset: 0x2951CAC VA: 0x2951CAC
		public static int Ceiling256(int x)
		{
			return (x+255)& -256;
		}

		// // RVA: 0x2951CB8 Offset: 0x2951CB8 VA: 0x2951CB8
		protected static void DisposeTextures(Texture[] textures)
		{
			if(textures != null)
			{
				for(int i = 0; i < textures.Length; i++)
				{
					if(textures[i] != null)
					{
						UnityEngine.Object.Destroy(textures[i]);
						textures[i] = null;
					}
				}
			}
		}

		// // RVA: 0x2951E18 Offset: 0x2951E18 VA: 0x2951E18
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		protected static extern bool CRIWARED6D2B5F7(int player_id, int num_textures, IntPtr[] tex_ptrs, [In] [Out] FrameInfo frame_info, ref bool frame_drop);
#else
		protected static bool CRIWARED6D2B5F7(int player_id, int num_textures, IntPtr[] tex_ptrs, FrameInfo frame_info, ref bool frame_drop)
		{
			return ExternLib.LibCriWare.CRIWARED6D2B5F7(player_id, num_textures, tex_ptrs, frame_info, ref frame_drop);
		}
#endif

		// // RVA: 0x2952028 Offset: 0x2952028 VA: 0x2952028
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		protected static extern bool CRIWARE14DB4020(int player_id, int num_textures, [In] [Out] IntPtr[] tex_ptrs);
#else
		protected static bool CRIWARE14DB4020(int player_id, int num_textures, [In] [Out] IntPtr[] tex_ptrs)
		{
			return ExternLib.LibCriWare.CRIWARE14DB4020(player_id, num_textures, tex_ptrs);
		}
#endif

		// // RVA: 0x2952150 Offset: 0x2952150 VA: 0x2952150
		// protected static extern bool CRIWAREDD310F2E(int player_id, int num_textures, [In] [Out] IntPtr[] tex_ptrs) { }

		// // RVA: 0x2952278 Offset: 0x2952278 VA: 0x2952278
		// protected static extern bool CRIWARED8906FFD(int player_id, int num_textures, [In] [Out] IntPtr[] tex_ptrs) { }

		// // RVA: 0x29517C0 Offset: 0x29517C0 VA: 0x29517C0
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		protected static extern sbyte CRIWARE9BAE0415(int player_id);
		#else
		protected static sbyte CRIWARE9BAE0415(int player_id)
		{
			return ExternLib.LibCriWare.CRIWARE9BAE0415(player_id);
		}
		#endif
	}


	public abstract class RendererResourceFactory : IDisposable
	{
		private static SortedList<int, RendererResourceFactory> factoryList = new SortedList<int, RendererResourceFactory>(); // 0x0
		private bool disposed; // 0x8

		// // RVA: 0x294F2E4 Offset: 0x294F2E4 VA: 0x294F2E4
		public static void RegisterFactory(RendererResourceFactory factory, int priority)
		{
			factoryList.Add(priority, factory);
		}

		// // RVA: 0x29559E8 Offset: 0x29559E8 VA: 0x29559E8
		public static void DisposeAllFactories()
		{
			foreach (var factoryWithPriority in factoryList) {
				factoryWithPriority.Value.Dispose();
			}
			factoryList.Clear();
		}

		// // RVA: 0x2955E28 Offset: 0x2955E28 VA: 0x2955E28
		public static RendererResource DispatchAndCreate(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
		{
			RendererResource	rendererResource	= null;

			foreach (var factoryWithPriority in factoryList) {
				rendererResource = factoryWithPriority.Value.CreateRendererResource(playerId, movieInfo, additive, userShader);
				if (rendererResource != null) {
					return rendererResource;
				}
			}

			UnityEngine.Debug.LogError("[CRIWARE] unsupported movie.");
			return null;
		}

		// // RVA: 0x2956224 Offset: 0x2956224 VA: 0x2956224 Slot: 1
		~RendererResourceFactory()
		{
			Dispose(false);
		}

		// // RVA: 0x2955D68 Offset: 0x2955D68 VA: 0x2955D68 Slot: 4
		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		// // RVA: 0x29562AC Offset: 0x29562AC VA: 0x29562AC
		private void Dispose(bool disposing)
		{
			if (disposed) {
				return;
			}
			if (disposing) {
				OnDisposeManaged();
			}
			OnDisposeUnmanaged();
			disposed = true;
		}

		// // RVA: -1 Offset: -1 Slot: 5
		protected abstract void OnDisposeManaged();

		// // RVA: -1 Offset: -1 Slot: 6
		protected abstract void OnDisposeUnmanaged();

		// // RVA: -1 Offset: -1 Slot: 7
		public abstract RendererResource CreateRendererResource(int playerId, MovieInfo movieInfo, bool additive, Shader userShader);
	}

	[System.AttributeUsage(System.AttributeTargets.Class)]
	public class RendererResourceFactoryPriorityAttribute : Attribute
	{
		public readonly int priority; // 0x8

		// RVA: 0x2956390 Offset: 0x2956390 VA: 0x2956390
		public RendererResourceFactoryPriorityAttribute(int priority)
		{
			this.priority = priority;
		}
	}
	public static partial class AutoResisterRendererResourceFactories
	{
		// RVA: 0x294EE68 Offset: 0x294EE68 VA: 0x294EE68
		public static void InvokeAutoRegister()
		{
			var factoryTypes = typeof(AutoResisterRendererResourceFactories).GetNestedTypes(BindingFlags.Public);
			foreach (var factoryType in factoryTypes) {
#if !UNITY_EDITOR && (ENABLE_DOTNET || (UNITY_WINRT && !ENABLE_IL2CPP))
				if (!factoryType.GetTypeInfo().IsSubclassOf(typeof(RendererResourceFactory))) {
#else
				if (!factoryType.IsSubclassOf(typeof(RendererResourceFactory))) {
#endif
					UnityEngine.Debug.LogError("[CRIWARE] internal logic error. " + factoryType.Name + " is required to be a subclass of RendererResourceFactory.");
					continue;
				}
#if !UNITY_EDITOR && (ENABLE_DOTNET || (UNITY_WINRT && !ENABLE_IL2CPP))
				var priorityAttribute = (RendererResourceFactoryPriorityAttribute)CustomAttributeExtensions.GetCustomAttribute(
					factoryType.GetTypeInfo(),
					typeof(RendererResourceFactoryPriorityAttribute)
					);
#else
				var priorityAttribute = (RendererResourceFactoryPriorityAttribute)System.Attribute.GetCustomAttribute(
					factoryType,
					typeof(RendererResourceFactoryPriorityAttribute)
					);
#endif
				if (priorityAttribute == null) {
					UnityEngine.Debug.LogError("[CRIWARE] internal logic error. need priority attribute. (" + factoryType.Name + ")");
					continue;
				}
				RendererResourceFactory.RegisterFactory(
					(RendererResourceFactory)System.Activator.CreateInstance(factoryType),
					priorityAttribute.priority
					);
			}
		}
	}
}

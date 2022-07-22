/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2015 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using System.Collections.Generic;
using System.Reflection;


namespace CriMana.Detail
{
	public abstract class RendererResource : System.IDisposable
	{
		private bool disposed = false;
		
		~RendererResource()
		{
			Dispose(false);
		}
		
		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}
		
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
	
		protected abstract void OnDisposeManaged();

		protected abstract void OnDisposeUnmanaged();
		
		public abstract bool IsPrepared();
		
		public abstract bool ContinuePreparing();
		
		public abstract void AttachToPlayer(int playerId);
		
		public abstract bool UpdateFrame(int playerId, FrameInfo frameInfo);
		
		public abstract bool UpdateMaterial(UnityEngine.Material material);
		
		public abstract bool IsSuitable(int playerId, MovieInfo movieInfo, bool additive, UnityEngine.Shader userShader);
		
		public static uint NextPowerOfTwo(uint x)
		{
			x = x - 1;
			x = x | (x >> 1);
			x = x | (x >> 2);
			x = x | (x >> 4);
			x = x | (x >> 8);
			x = x | (x >>16);
			return x + 1;
		}
		
		public static int NextPowerOfTwo(int x)
		{
			return (int)NextPowerOfTwo((uint)x);
		}
		
		public static int Ceiling16(int x)
		{
			return (x+15)& -16;
		}
		
		public static int Ceiling64(int x)
		{
			return (x+63)& -64;
		}
		
		public static int Ceiling256(int x)
		{
			return (x+255)& -256;
		}
	}




	public abstract class RendererResourceFactory : System.IDisposable
	{
		#region Static
		static private SortedList<int, RendererResourceFactory> factoryList = new SortedList<int, RendererResourceFactory>();

		static public void RegisterFactory(RendererResourceFactory factory, int priority)
		{
			factoryList.Add(priority, factory);
		}

		static public void DisposeAllFactories()
		{
			foreach (var factoryWithPriority in factoryList) {
				factoryWithPriority.Value.Dispose();
			}
			factoryList.Clear();
		}

		static public RendererResource DispatchAndCreate(int playerId, MovieInfo movieInfo, bool additive, UnityEngine.Shader userShader)
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
		#endregion


		#region Instance
		private bool disposed = false;
		
		~RendererResourceFactory()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}

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

		protected abstract void OnDisposeManaged();

		protected abstract void OnDisposeUnmanaged();

		public abstract RendererResource CreateRendererResource(int playerId, MovieInfo movieInfo, bool additive, UnityEngine.Shader userShader);
		#endregion
	}




	[System.AttributeUsage(System.AttributeTargets.Class)]
	public class RendererResourceFactoryPriorityAttribute : System.Attribute
	{
		public readonly int priority;
		public RendererResourceFactoryPriorityAttribute(int priority)
		{
			this.priority = priority;
		}
	}




	public static partial class AutoResisterRendererResourceFactories
	{
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
